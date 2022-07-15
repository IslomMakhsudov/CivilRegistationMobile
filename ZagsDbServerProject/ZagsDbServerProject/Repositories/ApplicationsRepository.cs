using Microsoft.EntityFrameworkCore;
using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZagsDbServerProject.Repositories;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Responces;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationsRepository : GenericRepository<Applications>, IApplicationsRepository
    {
        public ApplicationsRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Applications>> GetAllData()
        {
            return await Task.FromResult(context.Set<Applications>().ToList());
        }

        public async Task<IEnumerable<ApplicationsParticipantsData>> TestMethod()
        {
            return await Task.FromResult(
                context.Set<ApplicationsParticipantsData>().ToList()
            );
        }

        public async Task<IEnumerable<CustomersApplicationsMobileResponse>> GetCustomersApplications(int externalID, int applicationSourceID)
        {
            IEnumerable<CustomersApplicationsMobileResponse> customersApplications = await Task.FromResult(
                from customers in context.Customers
                where customers.ExternalID == externalID
                join applications in context.Applications on customers.ExternalID equals applications.ExternalID into appls
                from applicationsRes in appls.DefaultIfEmpty()
                where applicationsRes.ApplicationStatusID <= 5
                join applicationTypes in context.ApplicationTypes on applicationsRes.ApplicationTypeID equals applicationTypes.ApplicationTypeID
                join labels in context.Labels on applicationTypes.LabelID equals labels.LabelID
                select new CustomersApplicationsMobileResponse
                {
                    ApplicationID = applicationsRes.ApplicationID,
                    ApplicationTypeID = applicationTypes.ApplicationTypeID,
                    ApplicationTypeName = (customers.LanguageID == 1) ? labels.Label1 : ((customers.LanguageID == 2) ? labels.Label2 : labels.Label3),
                    CustomerID = customers.CustomerID,
                    ExternalID = externalID,
                    ApplicationStatusID = applicationsRes.ApplicationStatusID,
                    LastStatusDateTime = applicationsRes.RejectedTime
                        ?? applicationsRes.CompletedTime
                        ?? applicationsRes.AcceptedTime
                        ?? applicationsRes.PaidTime
                        ?? applicationsRes.CreatedTime
                }

            );
            return customersApplications;
        }

        public async Task<int> GetApplicationsAmount(int departmentID, int? applicationStatusID)
        {
            int ans = await Task.FromResult((
                from applications in context.Applications
                where applications.DepartmentID == departmentID
                    && (applicationStatusID == null ? (
                        applications.ApplicationStatusID >= 2
                        && applications.ApplicationStatusID <= 5
                    ) : applications.ApplicationStatusID == applicationStatusID)
                select new
                {
                    applications.ApplicationID
                }
            ).Count());
            return ans;
        }

        public async Task<IEnumerable<AllApplicationsResponse>> GetAllApplications(int departmentID, int languageID, int? applicationStatusID)
        {
            IEnumerable<AllApplicationsResponse> allApplicationsResponce = await Task.FromResult((
                from apps in context.Applications
                where apps.DepartmentID == departmentID
                    && (applicationStatusID == null ? (
                        apps.ApplicationStatusID >= 2 
                        && apps.ApplicationStatusID <= 5
                    ): apps.ApplicationStatusID == applicationStatusID)
                join apT in context.ApplicationTypes on apps.ApplicationTypeID equals apT.ApplicationTypeID
                join apSt in context.ApplicationStatuses on apps.ApplicationStatusID equals apSt.ApplicationStatusID
                join aPD in context.ApplicationsParticipantsData on apps.ExternalID equals aPD.ExternalID
                where aPD.ApplicationMemberTypeID == 1
                join addr in context.Addresses on aPD.AddressID equals addr.AddressID
                join ll in context.Labels on apSt.LabelID equals ll.LabelID
                select new AllApplicationsResponse
                {
                    ApplicationID = apps.ApplicationID,
                    ApplicationTypeID = apps.ApplicationTypeID,
                    ApplicationName = apT.AppTypeName,
                    ApplicationStatusID = apSt.ApplicationStatusID,
                    LastStatusDate = apps.RejectedTime
                        ?? apps.CompletedTime
                        ?? apps.AcceptedTime
                        ?? apps.PaidTime
                        ?? apps.CreatedTime,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    //ApplicationParticipantsDataID = 1,
                    ApplicantFullName = aPD.FullName,
                    //ApplicantFullName = "+",
                    ApplicantFullAddress = addr.FullAddress,
                    //ApplicantFullAddress = "*",
                    CellphoneNumber = aPD.TelephoneNumber,
                    ApplicationStatus = languageID == 1 ? ll.Label1 : (languageID == 2 ? ll.Label2 : ll.Label3)
                }       
            ));
            return allApplicationsResponce;   
        }
        
        // methods for birth registration
        // Mobile methods
        public async Task<ApplicantsDataWindowMobileResponse> GetApplicantsDataMobile(int applicationID, int languageID)
        {
            ApplicantsDataWindowMobileResponse applicantsDataMobile = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID && aPD.ApplicationMemberTypeID == 1
                join addr in context.Addresses on aPD.AddressID equals addr.AddressID
                join appDocs1 in context.ApplicationDocuments on aPD.ApplicationID equals appDocs1.ApplicationID
                join appDocs2 in context.ApplicationDocuments on aPD.ApplicationID equals appDocs2.ApplicationID
                select new ApplicantsDataWindowMobileResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicantsCountryID = addr.CountryID,
                    ApplicantsRegionID = addr.RegionID,
                    ApplicantsCityDistrictID = addr.CityDistrictID,
                    ApplicantsVillageID = addr.VillageID,
                    ApplicantsAddress = addr.AddressName,
                    ApplicantsSurname = aPD.Surname,
                    ApplicantsName = aPD.Name,
                    ApplicantsPatronymic = aPD.Patronymic,
                    ApplicantsITNNumber = aPD.PassportItnNumber,
                    ApplicantsPassportNumber = aPD.PassportItnNumber,
                    ApplicantsPassportGivingOrgan = aPD.PassportGivingOrgan,
                    ApplicantsTelephoneNumber = aPD.TelephoneNumber,
                    ApplicationDocumentID1 = appDocs1.ApplicationDocumentID,
                    ApplicantsDocumentsAddressLink1 = appDocs1.AddressLink,
                    ApplicationDocumentID2 = appDocs2.ApplicationDocumentID,
                    ApplicantsDocumentsAddressLink2 = appDocs2.AddressLink
                }).FirstOrDefault());
            return applicantsDataMobile;
        }

        public async Task<ChildsDataWindowMobileResponse> GetChildsDataMobile(int applicationID, int languageID)
        {

            var childsData = (await Task.FromResult(
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID 
                    && aPD.ApplicationMemberTypeID == 2
                join addr in context.Addresses on aPD.AddressID equals addr.AddressID
                select new
                {
                    aPD.ApplicationID,
                    aPD.ApplicationParticipantsDataID,
                    aPD.Surname,
                    aPD.Name,
                    aPD.Patronymic,
                    aPD.Sex,
                    aPD.Birthday,
                    addr.AddressID,
                    addr.AddressName,
                    VillageID = addr.VillageID,
                    addr.CityDistrictID,
                    addr.RegionID,
                    addr.CountryID
                }
            )).FirstOrDefault();

            IEnumerable<SpecificDataFromDetailsTable> specificChildsData = await Task.FromResult(
                from appDt in context.ApplicationsDetails 
                where appDt.ApplicationID == applicationID
                    && appDt.ApplicationMemberTypeID == 2
                orderby appDt.SpecificApplicationDataID
                join spAD in context.SpecificApplicationData on appDt.SpecificApplicationDataID equals spAD.SpecificApplicationDataID
                where spAD.StatusID == 1
                join fldTyps in context.FieldTypes on spAD.FieldTypeID equals fldTyps.FieldTypeID
                join ll in context.Labels on spAD.LabelID equals ll.LabelID
                select new SpecificDataFromDetailsTable
                {
                    SpecificApplicationDataID = spAD.SpecificApplicationDataID,
                    SpecificApplicationDataName = spAD.SpecificApplicationDataName,
                    Order = spAD.Order,
                    IsRequired = spAD.IsRequired,
                    FieldTypeID = spAD.FieldTypeID,
                    FieldTypeName = fldTyps.Name,
                    FieldsLabel = (languageID == 1) ? ll.Label1 : ((languageID == 2) ? ll.Label2 : ll.Label3),
                    Value = appDt.Detail,
                    MistakeStatus = appDt.MistakeStatus
                }
            );

            var ans = new ChildsDataWindowMobileResponse
            {
                ApplicationID = childsData.ApplicationID,
                ApplicationParticipantsDataID = childsData.ApplicationParticipantsDataID,
                ChildsSurname = childsData.Surname,
                ChildsName = childsData.Name,
                ChildsPatronymic = childsData.Patronymic,
                ChildsSex = childsData.Sex ?? false,
                ChildsBirthday = childsData.Birthday ?? DateTime.Today,
                ChildsCountryID = childsData.CountryID,
                ChildsRegionID = childsData.RegionID,
                ChildsCityDistrictID = childsData.CityDistrictID,
                ChildsVillageID = childsData.VillageID,
                ChildsAddressID = childsData.AddressID,
                ChildsAddress = childsData.AddressName,
                SpecificChildsData = specificChildsData
            };
            return ans;
        }

        public async Task<FathersDataWindowMobileResponse> GetFathersDataMobile(int applicationID)
        {
            var fathersData = await Task.FromResult((
                from apps in context.Applications 
                where apps.ApplicationID == applicationID
                join aPD in context.ApplicationsParticipantsData on apps.ApplicationID equals aPD.ApplicationID
                where aPD.ApplicationMemberTypeID == 3
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                select new FathersDataWindowMobileResponse
                {
                    ApplicationID = apps.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    FathersSurname = aPD.Surname,
                    FathersName = aPD.Name,
                    FathersPatronymic = aPD.Patronymic,
                    FathersBirthday = aPD.Birthday ?? DateTime.Today,
                    FathersCityzenshipID = ctznship.CityzenshipID,
                    FathersNationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    FathersCurrentAddressID = addresses.AddressID,
                    FathersCurrentAddress = addresses.AddressName,
                    FathersCurrentVillageID = addresses.VillageID,
                    FathersCurrentCityDistrictID = addresses.CityDistrictID,
                    FathersCurrentRegionID = addresses.RegionID,
                    FathersCurrentCountryID = addresses.CountryID,
                    FathersCurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    FathersPlaceOfWork = aPD.PlaceOfWork,
                    FathersEducationLevelID = educationLevels.EducationLevelID
                }
            ).FirstOrDefault());
            return fathersData;
        }

        public async Task<MothersDataWindowMobileResponse> GetMothersDataMobile(int applicationID)
        {
            var mothersData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 4
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join villages in context.Villages on addresses.VillageID equals villages.VillageID into vllgs
                from villagesRes in vllgs.DefaultIfEmpty()
                join citiesDistricts in context.CitiesDistricts on addresses.CityDistrictID equals citiesDistricts.CityDistrictID
                join regions in context.Regions on addresses.RegionID equals regions.RegionID
                join countries in context.Countries on addresses.CountryID equals countries.CountryID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                select new MothersDataWindowMobileResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    MothersSurname = aPD.Surname,
                    MothersName = aPD.Name,
                    MothersPatronymic = aPD.Patronymic,
                    MothersBirthday = aPD.Birthday ?? DateTime.Today,
                    MothersCityzenshipID = ctznship.CityzenshipID,
                    MothersNationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    MothersCurrentAddressID = addresses.AddressID,
                    MothersCurrentAddress = addresses.AddressName,
                    MothersCurrentVillageID = villagesRes.VillageID,
                    MothersCurrentCityDistrictID = citiesDistricts.CityDistrictID,
                    MothersCurrentRegionID = regions.RegionID,
                    MothersCurrentCountryID = countries.CountryID,
                    MothersCurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    MothersPlaceOfWork = aPD.PlaceOfWork,
                    MothersProfessionInWork = aPD.ProfessionInWork,
                    MothersEducationLevelID = educationLevels.EducationLevelID
                }
            ).FirstOrDefault());
            return mothersData;
        }

        // Web methods
        public async Task<ApplicantsDataWindowWebResponse> GetApplicantsDataWeb(int applicationID)
        {
            ApplicantsDataWindowWebResponse applicantsData = await Task.FromResult((
                from apps in context.Applications 
                where apps.ApplicationID == applicationID
                join aPD in context.ApplicationsParticipantsData on apps.ApplicationID equals aPD.ApplicationID
                where aPD.ApplicationMemberTypeID == 1
                join adrs in context.Addresses on aPD.AddressID equals adrs.AddressID
                join countries in context.Countries on adrs.CountryID equals countries.CountryID
                join regions in context.Regions on adrs.RegionID equals regions.RegionID
                join citiesDistricts in context.CitiesDistricts on adrs.CityDistrictID equals citiesDistricts.CityDistrictID
                join villages in context.Villages on adrs.VillageID equals villages.VillageID into vllgs
                from villagesRes in vllgs.DefaultIfEmpty()
                join appDoc1 in context.ApplicationDocuments on aPD.ApplicationID equals appDoc1.ApplicationID
                join appDoc2 in context.ApplicationDocuments on aPD.ApplicationID equals appDoc2.ApplicationID
                    //join 
                select new ApplicantsDataWindowWebResponse()
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicationsTypeOfExpiration = GetApplicationTypeOfExpirationByPaidTime(apps.AcceptedTime ?? DateTime.Today),
                    ApplicantsCountryID = countries.CountryID,
                    ApplicantsCountry = countries.ShortName,
                    ApplicantsRegionID = regions.RegionID,
                    ApplicantsRegion = regions.Name,
                    ApplicantsCityDistrictID = citiesDistricts.CityDistrictID,
                    ApplicantsCityDistrict = citiesDistricts.Name,
                    ApplicantsVillageID = villagesRes.VillageID,
                    ApplicantsVillage = villagesRes.Name,
                    ApplicantsAddressID = adrs.AddressID,
                    ApplicantsAddress = adrs.AddressName,
                    ApplicantsSurname = aPD.Surname,
                    ApplicantsName = aPD.Name,
                    ApplicantsPatronymic = aPD.Patronymic,
                    ApplicantsITNNumber = aPD.PassportItnNumber,
                    ApplicantsPassportNumber = aPD.PassportNumber,
                    ApplicantsPassportGivingOrgan = aPD.PassportGivingOrgan,
                    ApplicantsTelephoneNumber = aPD.TelephoneNumber,
                    ApplicationDocumentID1 = appDoc1.ApplicationDocumentID,
                    ApplicantsDocumentsAddressLink1 = appDoc1.AddressLink,
                    ApplicationDocumentID2 = appDoc2.ApplicationDocumentID,
                    ApplicantsDocumentsAddressLink2 = appDoc2.AddressLink
                }).FirstOrDefault()
            );
            
            return applicantsData;
        }

        public async Task<ChildsDataWindowWebResponse> GetChildsDataWeb(int applicationID, int languageID)
        {
            var childsData  = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 2
                join adrs in context.Addresses on aPD.AddressID equals adrs.AddressID
                join countries in context.Countries on adrs.CountryID equals countries.CountryID
                join regions in context.Regions on adrs.RegionID equals regions.RegionID
                join citiesDistricts in context.CitiesDistricts on adrs.CityDistrictID equals citiesDistricts.CityDistrictID
                join villages in context.Villages on adrs.VillageID equals villages.VillageID into vllgs
                from villagesRes in vllgs.DefaultIfEmpty()
                select new TestResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ChildsSurname = aPD.Surname,
                    ChildsName = aPD.Name,
                    ChildsPatronymic = aPD.Patronymic,
                    ChildsSex = aPD.Sex ?? true,
                    ChildsBirthday = aPD.Birthday ?? DateTime.Today,
                    ChildsAddressID = adrs.AddressID,
                    ChildsAddress = adrs.AddressName,
                    ChildsVillageID = villagesRes.VillageID,
                    ChildsVillage = villagesRes.Name,
                    ChildsCityDistrictID = citiesDistricts.CityDistrictID,
                    ChildsCityDistrict = citiesDistricts.Name,
                    ChildsRegionID = regions.RegionID,
                    ChildsRegion = regions.Name,
                    ChildsCountryID = countries.CountryID,
                    ChildsCountry = countries.ShortName
                }).FirstOrDefault()
            );
            

            IEnumerable<SpecificDataFromDetailsTable> specificChildsData = await Task.FromResult(
                from applicationsDetails in context.ApplicationsDetails
                where applicationsDetails.ApplicationID == applicationID 
                    && applicationsDetails.ApplicationMemberTypeID == 2
                orderby applicationsDetails.SpecificApplicationDataID
                join applicationTypesSpecificData in context.ApplicationTypesSpecificData on applicationsDetails.ApplicationTypesSpecificDataID equals applicationTypesSpecificData.ApplicationTypesSpecificDataID
                join specificApplicationData in context.SpecificApplicationData on applicationTypesSpecificData.SpecificApplicationDataID equals specificApplicationData.SpecificApplicationDataID
                where specificApplicationData.StatusID == 1
                join fieldTypes in context.FieldTypes on specificApplicationData.FieldTypeID equals fieldTypes.FieldTypeID
                join labels in context.Labels on specificApplicationData.LabelID equals labels.LabelID
                select new SpecificDataFromDetailsTable
                {
                    ApplicationDetailID = applicationsDetails.ApplicationDetailID,
                    SpecificApplicationDataID = specificApplicationData.SpecificApplicationDataID,
                    SpecificApplicationDataName = specificApplicationData.SpecificApplicationDataName,
                    Order = specificApplicationData.Order,
                    IsRequired = specificApplicationData.IsRequired,
                    FieldTypeID = specificApplicationData.FieldTypeID,
                    FieldsLabel = (languageID == 1) ? labels.Label1 : ((languageID == 2) ? labels.Label2 : labels.Label3),
                    FieldTypeName = fieldTypes.Name,
                    SourceTable = applicationTypesSpecificData.SourceTable,
                    Value = applicationsDetails.Detail,
                    MistakeStatus = 3
                }
            );

            var ans = new ChildsDataWindowWebResponse
            {
                ApplicationID = childsData.ApplicationID,
                ApplicationParticipantsDataID = childsData.ApplicationParticipantsDataID,
                ChildsSurname = childsData.ChildsSurname,
                ChildsName = childsData.ChildsName,
                ChildsPatronymic = childsData.ChildsPatronymic,
                ChildsSex = childsData.ChildsSex,
                ChildsBirthday = childsData.ChildsBirthday,
                ChildsCountryID = childsData.ChildsCountryID,
                ChildsCountry = childsData.ChildsCountry,
                ChildsRegionID = childsData.ChildsRegionID,
                ChildsRegion = childsData.ChildsRegion,
                ChildsCityDistrictID = childsData.ChildsCityDistrictID,
                ChildsCityDistrict = childsData.ChildsCityDistrict,
                ChildsVillageID = childsData.ChildsVillageID,
                ChildsVillage = childsData.ChildsVillage,
                ChildsAddressID = childsData.ChildsAddressID,
                ChildsAddress = childsData.ChildsAddress,
                SpecificChildsData = specificChildsData
            };
            return ans;
        }

        public async Task<FathersDataWindowWebResponse> GetFathersDataWeb(int applicationID)
        {
            var fathersData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 3
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID 
                join villages in context.Villages on addresses.VillageID equals villages.VillageID into vllgs
                from villagesRes in vllgs.DefaultIfEmpty()
                join citiesDistricts in context.CitiesDistricts on addresses.CityDistrictID equals citiesDistricts.CityDistrictID
                join regions in context.Regions on addresses.RegionID equals regions.RegionID
                join countries in context.Countries on addresses.CountryID equals countries.CountryID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                select new FathersDataWindowWebResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    FathersSurname = aPD.Surname,
                    FathersName = aPD.Name,
                    FathersPatronymic = aPD.Patronymic,
                    FathersBirthday = aPD.Birthday ?? DateTime.Today,
                    FathersCityzenshipID = ctznship.CityzenshipID,
                    FathersCityzenship = ctznship.Name,
                    FathersNationalityID = nationalities.NationalityID,
                    FathersNationality = nationalities.Name,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    FathersCurrentAddressID = addresses.AddressID,
                    FathersCurrentAddress = addresses.AddressName,
                    FathersCurrentVillageID = villagesRes.VillageID,
                    FathersCurrentVillage = villagesRes.Name,
                    FathersCurrentCityDistrictID = citiesDistricts.CityDistrictID,
                    FathersCurrentCityDistrict = citiesDistricts.Name,
                    FathersCurrentRegionID = regions.RegionID,
                    FathersCurrentRegion = regions.Name,
                    FathersCurrentCountryID = countries.CountryID,
                    FathersCurrentCountry = countries.ShortName,
                    FathersCurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    FathersPlaceOfWork = aPD.PlaceOfWork,
                    FathersEducationLevelID = educationLevels.EducationLevelID,
                    FathersEducationLevel = educationLevels.Name
                }
            ).FirstOrDefault());
            return fathersData;
        }

        public async Task<MothersDataWindowWebResponse> GetMothersDataWeb(int applicationID)
        {
            var mothersData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 4
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join villages in context.Villages on addresses.VillageID equals villages.VillageID into vllgs
                from villagesRes in vllgs.DefaultIfEmpty()
                join citiesDistricts in context.CitiesDistricts on addresses.CityDistrictID equals citiesDistricts.CityDistrictID
                join regions in context.Regions on addresses.RegionID equals regions.RegionID
                join countries in context.Countries on addresses.CountryID equals countries.CountryID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                select new MothersDataWindowWebResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    MothersSurname = aPD.Surname,
                    MothersName = aPD.Name,
                    MothersPatronymic = aPD.Patronymic,
                    MothersBirthday = aPD.Birthday ?? DateTime.Today,
                    MothersCityzenshipID = ctznship.CityzenshipID,
                    MothersCityzenship = ctznship.Name,
                    MothersNationalityID = nationalities.NationalityID,
                    MothersNationality = nationalities.Name,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    MothersCurrentAddressID = addresses.AddressID,
                    MothersCurrentAddress = addresses.AddressName,
                    MothersCurrentVillageID = villagesRes.VillageID,
                    MothersCurrentVillage = villagesRes.Name,
                    MothersCurrentCityDistrictID = citiesDistricts.CityDistrictID,
                    MothersCurrentCityDistrict = citiesDistricts.Name,
                    MothersCurrentRegionID = regions.RegionID,
                    MothersCurrentRegion = regions.Name,
                    MothersCurrentCountryID = countries.CountryID,
                    MothersCurrentCountry = countries.ShortName,
                    MothersCurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    MothersPlaceOfWork = aPD.PlaceOfWork,
                    MothersProfessionInWork = aPD.ProfessionInWork,
                    MothersEducationLevelID = educationLevels.EducationLevelID,
                    MothersEducationLevel = educationLevels.Name
                }
            ).FirstOrDefault());
            return mothersData;
        }
        
        
        // methods for death registration 
        /*
        public async Task<DeceasedDataWindowWebResponse> GetDeceasedDataWeb(int applicationID)
        {
            var deceasedData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 5
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
            ));
        } */

        // supportive methods
        public static string GetApplicationTypeOfExpirationByPaidTime(DateTime paidTime)
        {
            DateTime today = DateTime.Now;
            DateTime deadline1 = paidTime.AddMonths(3);
            deadline1 = deadline1.AddDays(-1);
            DateTime deadline2 = paidTime.AddYears(1);
            deadline2 = deadline2.AddDays(-1);

            string ans;
            if ((deadline1 - today).TotalDays >= 0)
            {
                ans = "то 3 моҳ";
            } else if ((deadline2 - today).TotalDays >= 0)
            {
                ans = "аз 3 моҳ то 1 сол";
            } else
            {
                ans = "аз 1 сол зиёд";
            }
            return ans;
        }
        
        public async Task<IEnumerable<PaymentTypesMobileResponse>> GetPaymentTypes(int applicationID, int applicationSourceID)
        {
            var application = await Task.FromResult((
                from applications in context.Applications
                where applications.ApplicationID == applicationID
                    && applications.ApplicationSourceID == applicationSourceID
                select new
                {
                    applications.ApplicationTypeID,
                    applications.PaidTime
                }

                ).FirstOrDefault());
            int applicationTypeID = application.ApplicationTypeID;
            DateTime paidTime = application.PaidTime ?? DateTime.Today;
            List<PaymentTypesMobileResponse> ans = new();
            PaymentTypesMobileResponse f = new();
            PaymentTypesMobileResponse s = new();
            PaymentTypesMobileResponse th = new();
            string typeOfExpiration = GetApplicationTypeOfExpirationByPaidTime(paidTime);
            f.RegistryService = "Хизматрасонии пулӣ";
            s.RegistryService = "Пардохт барои ҳуҷҷат";
            th.RegistryService = "Боҷи давлатӣ";
            Decimal indicator = decimal.Parse(context.ProjectSettings.Find(1).Value);
            if (typeOfExpiration == "то 3 моҳ")
            {
                var tmp1 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID >= 1
                        && applicationTypePayments.PaymentTypeID <= 2
                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal) 0.01 * indicator
                    }
                ));
                f.ServiceSum = (double)tmp1.Sum(a => a.Summ);
                s.ServiceSum = 0;
                th.ServiceSum = 0;
            } 
            else if (typeOfExpiration == "аз 3 моҳ то 1 сол")
            {
                var tmp1 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID >= 1
                        && applicationTypePayments.PaymentTypeID <= 4
                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
                    }
                ));
                f.ServiceSum = (double)tmp1.Sum(a => a.Summ);
                var tmp2 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID == 5
                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
                    }
                ).FirstOrDefault());
                s.ServiceSum = (double)tmp2.Summ;
                th.ServiceSum = 0;
            } 
            else {
                var tmp1 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID >= 1
                        && applicationTypePayments.PaymentTypeID <= 4
                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
                    }
                ));
                f.ServiceSum = (double)tmp1.Sum(a => a.Summ);
                var tmp2 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID == 5

                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
                    }
                ).FirstOrDefault());
                s.ServiceSum = (double)tmp2.Summ;
                var tmp3 = await Task.FromResult((
                    from applicationTypePayments in context.ApplicationTypePayments
                    where applicationTypePayments.ApplicationTypeID == applicationTypeID
                        && applicationTypePayments.PaymentTypeID == 6
                    select new
                    {
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
                    }
                ).FirstOrDefault());
                th.ServiceSum = (double)tmp3.Summ;
            }
            ans.Add(f);
            ans.Add(s);
            ans.Add(th);
            return ans;
        }
    }
}
