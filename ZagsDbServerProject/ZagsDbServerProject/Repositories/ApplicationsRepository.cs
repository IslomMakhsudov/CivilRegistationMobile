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
using ZagsDbServerProject.Exceptions;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationsRepository : GenericRepository<Applications>, IApplicationsRepository
    {
        public ApplicationsRepository(AppDbContext context) : base(context)
        {
        }

        // General methods
        public override async Task<IEnumerable<Applications>> GetAllData()
        {
            return await Task.FromResult(context.Set<Applications>().ToList());
        }


        public async Task<IEnumerable<CustomersApplicationsMobileResponse>> GetCustomersApplications(int externalID, int applicationSourceID, DateTime? CreatedTimeFrom, DateTime? CreatedTimeTo, int? applicationTypeID)
        {
            IEnumerable<CustomersApplicationsMobileResponse> customersApplications = await Task.FromResult(
                from customers in context.Customers
                where customers.ExternalID == externalID
                join applications in context.Applications on customers.ExternalID equals applications.ExternalID into appls
                from applicationsRes in appls.DefaultIfEmpty()
                where ((applicationTypeID == null) ? true : applicationsRes.ApplicationTypeID == applicationTypeID)
                    && ((CreatedTimeFrom == null)
                        ? ((CreatedTimeTo == null) ? true : applicationsRes.CreatedTime <= CreatedTimeTo)
                        : ((CreatedTimeTo == null) ? (applicationsRes.CreatedTime >= CreatedTimeFrom) : (applicationsRes.CreatedTime >= CreatedTimeFrom && applicationsRes.CreatedTime <= CreatedTimeTo)))
                join applicationTypes in context.ApplicationTypes on applicationsRes.ApplicationTypeID equals applicationTypes.ApplicationTypeID
                join labels in context.Labels on applicationTypes.LabelID equals labels.LabelID
                join applicationsDetails in context.ApplicationsDetails on new { applicationsRes.ApplicationID, applicationsRes.ApplicationTypeID } equals new { applicationsDetails.ApplicationID, applicationsDetails.ApplicationTypeID } into appDetails
                from applicationDetailsRes in appDetails.DefaultIfEmpty()
                where (applicationsRes.ApplicationTypeID == 1) ? applicationDetailsRes.ApplicationTypesSpecificDataID == 16 : applicationDetailsRes.ApplicationTypesSpecificDataID == 17

                select new CustomersApplicationsMobileResponse
                {
                    ApplicationID = applicationsRes.ApplicationID,
                    ApplicationTypeID = applicationTypes.ApplicationTypeID,
                    ApplicationTypeName = (customers.LanguageID == 1) ? labels.Label1 : ((customers.LanguageID == 2) ? labels.Label2 : labels.Label3),
                    CustomerID = customers.CustomerID,
                    ExternalID = externalID,
                    ApplicationStatusID = applicationsRes.ApplicationStatusID,
                    CreatedOrPaidDateTime = applicationsRes.PaidTime
                        ?? applicationsRes.CreatedTime,
                    RegistryOfficeDepartmentID = applicationsRes.DepartmentID ?? 0,
                    RegistratedByWhichMemberID = (applicationsRes.ApplicationTypeID == 1) ? GetIntValue(applicationDetailsRes.Detail) : null,
                    RegistratedByWhichAddress = (applicationsRes.ApplicationTypeID == 2) ? GetIntValue(applicationDetailsRes.Detail) : null
                }

            );
            return customersApplications;
        }

        public async Task<int> GetApplicationsAmount(int? croisID, int? applicationStatusID, int? applicationTypeID)
        {
            int hierarchyLevel = await Task.FromResult((
                from organizationUnits in context.OrganizationUnitNew1ForResearch
                where croisID == null || (organizationUnits.OrganizationUnitId == croisID)
                select organizationUnits.HierarchyLevel
            ).Min());
            int ans = await Task.FromResult((
                from applications in context.Applications
                where (applicationStatusID == null ? (
                        applications.ApplicationStatusID >= 2
                        && applications.ApplicationStatusID <= 6

                    ) : applications.ApplicationStatusID == applicationStatusID)
                    && applications.ApplicationParticipantsDataID != 0
                join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                where (hierarchyLevel == 1)
                    ? departments.CountryID == 185
                    : (hierarchyLevel == 2)
                        ? departments.RegionID == croisID
                        : (hierarchyLevel == 3)
                            ? departments.CityDistrictID == croisID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croisID
                                : false
                join apT in context.ApplicationTypes on applications.ApplicationTypeID equals apT.ApplicationTypeID
                where applicationTypeID == null ? true : applicationTypeID == apT.ApplicationTypeID
                select new
                {
                    applications.ApplicationID
                }
            ).Count());
            return ans;
        }

        public async Task<IEnumerable<AllApplicationsResponse>> GetAllApplications(
            int? croisID,
            int languageID,
            int? applicationStatusID,
            int? applicationTypeID, 
            int hierarchyLevel
        )
        {
            IEnumerable<AllApplicationsResponse> allApplicationsResponce = await Task.FromResult((
                from apps in context.Applications
                where (applicationStatusID == null ? (
                        apps.ApplicationStatusID >= 2
                        && apps.ApplicationStatusID <= 6
                    ) : apps.ApplicationStatusID == applicationStatusID)
                join departments in context.RegistryOfficeDepartments on apps.DepartmentID equals departments.DepartmentID
                where (hierarchyLevel == 1)
                    ? departments.CountryID == 185
                    : (hierarchyLevel == 2)
                        ? departments.RegionID == croisID
                        : (hierarchyLevel == 3)
                            ? departments.CityDistrictID == croisID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croisID
                                : false
                join apT in context.ApplicationTypes on apps.ApplicationTypeID equals apT.ApplicationTypeID
                where applicationTypeID == null ? true : applicationTypeID == apT.ApplicationTypeID
                join apTll in context.Labels on apT.LabelID equals apTll.LabelID
                join apSt in context.ApplicationStatuses on apps.ApplicationStatusID equals apSt.ApplicationStatusID
                join aPD in context.ApplicationsParticipantsData on apps.ApplicationParticipantsDataID equals aPD.ApplicationParticipantsDataID
                where aPD.ApplicationMemberTypeID == 1
                join childOrDeceasedAPD in context.ApplicationsParticipantsData on apps.ApplicationID equals childOrDeceasedAPD.ApplicationID
                where (apT.ApplicationTypeID == 1) 
                    ? childOrDeceasedAPD.ApplicationMemberTypeID == 2 
                    : (apT.ApplicationTypeID == 2) 
                        ? childOrDeceasedAPD.ApplicationMemberTypeID == 5
                        : false
                join childOrDeceasedLabel in context.Labels on true equals true
                where (apT.ApplicationTypeID == 1) ? childOrDeceasedLabel.LabelID == 1586 : childOrDeceasedLabel.LabelID == 1587
                join addr in context.Addresses on aPD.AddressID equals addr.AddressID
                join ll in context.Labels on apSt.WebLabelID equals ll.LabelID
                select new AllApplicationsResponse
                {
                    ApplicationID = apps.ApplicationID,
                    ApplicationTypeID = apps.ApplicationTypeID,
                    ApplicationName = (languageID == 1) ? apTll.Label1 : ((languageID == 2) ? apTll.Label2 : apTll.Label3),
                    ApplicationStatusID = apps.ApplicationStatusID,
                    CreatedOrPaidDate = (apps.PaidTime ?? apps.CreatedTime).ToString("g"),
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicantFullName = aPD.FullName,
                    ApplicantFullAddress = addr.FullAddress,
                    CellphoneNumber = aPD.TelephoneNumber,
                    
                    ApplicationStatus = languageID == 1 ? ll.Label1 : (languageID == 2 ? ll.Label2 : ll.Label3),
                    ChildOrDeceasedName = childOrDeceasedAPD.Surname + " " + childOrDeceasedAPD.Name + " " + (childOrDeceasedAPD.Patronymic ?? "") 
                    + (
                        (languageID == 1) ? childOrDeceasedLabel.Label1 : (languageID == 2) ? childOrDeceasedLabel.Label2 : childOrDeceasedLabel.Label3
                      )
                }
            ));
            return allApplicationsResponce;
        }

        public async Task<IEnumerable<ApplicationsResponse>> GetApplications(
            int languageID,
            int? applicationID,
            string applicantsFullName,
            int? applicationTypeID,
            int? cityDistrictID,
            int? croisID,
            DateTime? createdTimeFrom,
            DateTime? createdTimeTo,
            int[] applicationStatusesList, 
            int hierarchyLevel
        )
        {
            IEnumerable<ApplicationsResponse> ans;
            ans = await Task.FromResult(
                from applications in context.Applications
                where ((applicationID == null) || applications.ApplicationID == applicationID)
                    && ((applicationTypeID == null) || applications.ApplicationTypeID == applicationTypeID)
                    && ((createdTimeFrom == null)
                        ? ((createdTimeTo == null) || applications.CreatedTime <= createdTimeTo)
                        : ((createdTimeTo == null) ? (applications.CreatedTime >= createdTimeFrom) : (applications.CreatedTime >= createdTimeFrom && applications.CreatedTime <= createdTimeTo)))
                //&& (applicationStatusesList != null && applicationStatusesList.Contains(applications.ApplicationStatusID))
                join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                where (hierarchyLevel == 1)
                    ? departments.CountryID == 185
                    : (hierarchyLevel == 2)
                        ? departments.RegionID == croisID
                        : (hierarchyLevel == 3)
                            ? departments.CityDistrictID == croisID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croisID
                                : false
                join departmentAddresses in context.Addresses on departments.AddressID equals departmentAddresses.AddressID
                where ((cityDistrictID == null) || departmentAddresses.CityDistrictID == cityDistrictID)
                join aPD in context.ApplicationsParticipantsData on applications.ApplicationParticipantsDataID equals aPD.ApplicationParticipantsDataID
                where ((applicantsFullName == null) || (aPD.Surname + " " + aPD.Name + " " + aPD.Patronymic).Contains(applicantsFullName))
                join applicationStatuses in context.ApplicationStatuses on applications.ApplicationStatusID equals applicationStatuses.ApplicationStatusID
                where (applicationStatusesList != null && applicationStatusesList.Contains(applications.ApplicationStatusID))
                join labels in context.Labels on applicationStatuses.WebLabelID equals labels.LabelID
                join applicationTypes in context.ApplicationTypes on applications.ApplicationTypeID equals applicationTypes.ApplicationTypeID
                join appTypeLabels in context.Labels on applicationTypes.LabelID equals appTypeLabels.LabelID
                join citiesDistricts in context.CitiesDistricts on departmentAddresses.CityDistrictID equals citiesDistricts.CityDistrictID
                where citiesDistricts.IsMain && ((cityDistrictID == null) || departmentAddresses.CityDistrictID == cityDistrictID)
                select new ApplicationsResponse
                {
                    ApplicationID = applications.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicantsFullName = aPD.Surname + " " + aPD.Name + " " + aPD.Patronymic,
                    ApplicationTypeID = applicationTypes.ApplicationTypeID,
                    ApplicationTypeName = (languageID == 1) ? appTypeLabels.Label1 : ((languageID == 2) ? appTypeLabels.Label2 : appTypeLabels.Label3),
                    RegistryOfficeDepartmentID = departments.DepartmentID,
                    RegistryOfficeDepartmentName = departments.DepartmentName,
                    RegistryOfficeDepartmentAddress = departmentAddresses.FullAddress,
                    RegistryOfficeDepartmentCityDistrictID = citiesDistricts.CityDistrictUniqueID,
                    RegistryOfficeDepartmentCityDistrictName = citiesDistricts.Name,
                    CreatedOrPaidDateTime = applications.PaidTime
                        ?? applications.CreatedTime,
                    ApplicationStatusID = applications.ApplicationStatusID,
                    ApplicationStatusName = (languageID == 1) ? labels.Label1 : ((languageID == 2) ? labels.Label2 : labels.Label3)
                }
            );
            return ans;
        }

        public async Task<IEnumerable<PaidApplicationsResponse>> GetPaidApplications(
            int languageID,
            int? applicationID,
            string applicantsFullName,
            int? applicationTypeID,
            int? cityDistrictID,
            int? croisID,
            DateTime? createdTimeFrom,
            DateTime? createdTimeTo,
            int[] applicationStatusesList,
            string transactionID,
            DateTime? paidTimeFrom,
            DateTime? paidTimeTo,
            int? paymentSystemID,
            int? registryServiceTypeID,
            int hierarchyLevel
        )
        {
            IEnumerable<PaidApplicationsResponse> ans;
            ans = await Task.FromResult(
                from applications in context.Applications
                where (applicationID == null) ? true : applications.ApplicationID == applicationID
                    && ((createdTimeFrom == null)
                        ? ((createdTimeTo == null) ? true : applications.CreatedTime <= createdTimeTo)
                        : ((createdTimeTo == null) ? (applications.CreatedTime >= createdTimeFrom) : (applications.CreatedTime >= createdTimeFrom && applications.CreatedTime <= createdTimeTo)))
                join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                where (hierarchyLevel == 1)
                    ? departments.CountryID == 185
                    : (hierarchyLevel == 2)
                        ? departments.RegionID == croisID
                        : (hierarchyLevel == 3)
                            ? departments.CityDistrictID == croisID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croisID
                                : false
                join departmentAddresses in context.Addresses on departments.AddressID equals departmentAddresses.AddressID
                join aPD in context.ApplicationsParticipantsData on applications.ApplicationParticipantsDataID equals aPD.ApplicationParticipantsDataID
                where ((applicantsFullName == null) || aPD.FullName.Contains(applicantsFullName))
                    && ((cityDistrictID == null) || departmentAddresses.CityDistrictID == cityDistrictID)
                join applicationStatuses in context.ApplicationStatuses on applications.ApplicationStatusID equals applicationStatuses.ApplicationStatusID
                where (applicationStatusesList != null && applicationStatusesList.Contains(applications.ApplicationStatusID))
                join labels in context.Labels on applicationStatuses.WebLabelID equals labels.LabelID
                join paymentSystems in context.PaymentSystems on applications.PaymentSystemID equals paymentSystems.PaymentSystemID
                join applicationPayments in context.ApplicationsPayments on applications.ApplicationPaymentID equals applicationPayments.ApplicationsPaymentID
                where ((transactionID == null) || applications.ChequeID.Contains(transactionID))
                    && ((paidTimeFrom == null)
                        ? ((paidTimeTo == null) ? true : applications.PaidTime <= paidTimeTo)
                        : ((paidTimeTo == null) ? (applications.PaidTime >= paidTimeFrom) : (applications.PaidTime >= paidTimeFrom && applications.PaidTime <= paidTimeTo)))
                join appsPaymentsDetails1 in context.ApplicationsPaymentsDetails on applicationPayments.ApplicationsPaymentID equals appsPaymentsDetails1.ApplicationsPaymentID
                where appsPaymentsDetails1.PaymentServiceTypeName.Equals("Хизматрасонии пулӣ")
                join appsPaymentsDetails2 in context.ApplicationsPaymentsDetails on applicationPayments.ApplicationsPaymentID equals appsPaymentsDetails2.ApplicationsPaymentID
                where appsPaymentsDetails2.PaymentServiceTypeName.Equals("Пардохт барои ҳуҷҷат")
                join appsPaymentsDetails3 in context.ApplicationsPaymentsDetails on applicationPayments.ApplicationsPaymentID equals appsPaymentsDetails3.ApplicationsPaymentID
                where appsPaymentsDetails3.PaymentServiceTypeName.Equals("Боҷи давлатӣ")
                join applicationTypes in context.ApplicationTypes on applications.ApplicationTypeID equals applicationTypes.ApplicationTypeID
                where (applicationTypeID == null) ? true : applications.ApplicationTypeID == applicationTypeID
                join appTypeLabels in context.Labels on applicationTypes.LabelID equals appTypeLabels.LabelID
                join citiesDistricts in context.CitiesDistricts on departmentAddresses.CityDistrictID equals citiesDistricts.CityDistrictID
                where citiesDistricts.IsMain
                //join 
                select new PaidApplicationsResponse
                {
                    ApplicationID = applications.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicantsFullName = aPD.FullName,
                    ApplicationTypeID = applicationTypes.ApplicationTypeID,
                    ApplicationTypeName = (languageID == 1) ? appTypeLabels.Label1 : ((languageID == 2) ? appTypeLabels.Label2 : appTypeLabels.Label3),
                    RegistryOfficeDepartmentID = departments.DepartmentID,
                    RegistryOfficeDepartmentName = departments.DepartmentName,
                    RegistryOfficeDepartmentAddress = departmentAddresses.FullAddress,
                    RegistryOfficeDepartmentCityDistrictID = departmentAddresses.CityDistrictID,
                    RegistryOfficeDepartmentCityDistrictName = citiesDistricts.Name,
                    CreatedOrPaidDateTime = applications.PaidTime
                        ?? applications.CreatedTime,
                    ApplicationStatusID = applications.ApplicationStatusID,
                    ApplicationStatusName = (languageID == 1) ? labels.Label1 : ((languageID == 2) ? labels.Label2 : labels.Label3),
                    PaymentSystemID = applications.PaymentSystemID ?? 0,
                    ApplicationsPaymentID = applicationPayments.ApplicationsPaymentID,
                    PaidTime = applications.PaidTime.ToString(),
                    PaymentSum = (double)((registryServiceTypeID == null)
                                            ? applicationPayments.PaymentSum
                                            : (registryServiceTypeID == 1) ? appsPaymentsDetails1.Sum
                                                                           : (registryServiceTypeID == 2) ? appsPaymentsDetails2.Sum
                                                                                                          : (registryServiceTypeID == 3) ? appsPaymentsDetails3.Sum
                                                                                                                                         : 0),
                    PaymentSystemName = paymentSystems.ShortName,
                    TransactionID = applications.ChequeID
                }
            );
            return ans;
        }

        public async Task<ApplicationsChequeResponse> GetApplicationsCheque(int applicationTypeID, int applicationPaymentID, int paymentSystemID, int languageID)
        {
            int applicationStatus = await Task.FromResult((
                from applicationPayments in context.ApplicationsPayments 
                where applicationPayments.ApplicationsPaymentID == applicationPaymentID
                join applications in context.Applications on applicationPayments.ApplicationID equals applications.ApplicationID
                select applications.ApplicationStatusID
            ).FirstOrDefault());
            ApplicationsChequeResponse ans = null;
            if (!(applicationStatus == 5 || applicationStatus == 1))
            {
                var tmp = await Task.FromResult((
                    from applicationsPayments in context.ApplicationsPayments
                    where applicationsPayments.ApplicationsPaymentID == applicationPaymentID
                    join paymentSystems in context.PaymentSystems on applicationsPayments.PaymentSystemID equals paymentSystems.PaymentSystemID
                    join applicationTypes in context.ApplicationTypes on applicationTypeID equals applicationTypes.ApplicationTypeID
                    join appTypeLabels in context.Labels on applicationTypes.LabelID equals appTypeLabels.LabelID
                    join appParticipantsData in context.ApplicationsParticipantsData on applicationsPayments.ApplicationID equals appParticipantsData.ApplicationID
                    where appParticipantsData.ApplicationMemberTypeID == 1 //Заявитель
                select new
                    {
                        Payer = appParticipantsData.FullName,
                        appParticipantsData.PassportItnNumber,
                        paymentSystems.PaymentSystemID,
                        paymentSystems.FullName,
                        paymentSystems.TIN,
                        paymentSystems.BIC,
                        paymentSystems.Address,
                        applicationsPayments.PaymentTime,
                        applicationsPayments.PaymentCode,
                        applicationsPayments.PaymentSum,
                        applicationsPayments.PaymentCreditAccount,
                        applicationsPayments.PaymentDebitAccount,
                        ApplicationTypeName = (languageID == 1) ? appTypeLabels.Label1 : ((languageID == 2) ? appTypeLabels.Label2 : appTypeLabels.Label3)
                    }

                ).FirstOrDefault());

                IEnumerable<ApplicationsPaymentsDetails> applicationPaymentDetails = await Task.FromResult(
                    from applicationPaymentsDetails in context.ApplicationsPaymentsDetails
                    where applicationPaymentsDetails.ApplicationsPaymentID == applicationPaymentID
                    select applicationPaymentsDetails
                );
                ans = new ApplicationsChequeResponse
                {
                    PaymentSystemID = tmp.PaymentSystemID,
                    PaymentSystemName = tmp.FullName,
                    PaymentSystemTIN = tmp.TIN,
                    PaymentSystemBIC = tmp.BIC,
                    PaymentSystemAddress = tmp.Address,
                    PaidTime = tmp.PaymentTime,
                    ServiceName = tmp.ApplicationTypeName,
                    TransactionNumber = tmp.PaymentCode,
                    PaymentCreditAccount = tmp.PaymentCreditAccount,
                    PaymentDebitAccount = tmp.PaymentDebitAccount,
                    TotalSum = tmp.PaymentSum,
                    ApplicationsPaymentDetails = applicationPaymentDetails,
                    Payer = tmp.Payer,
                    PayerTIN = tmp.PassportItnNumber
                };
            }

            return ans;
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
                where appDocs1.DocumentTypeID == 4
                join appDocs2 in context.ApplicationDocuments on aPD.ApplicationID equals appDocs2.ApplicationID
                where appDocs2.DocumentTypeID == 5
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
            return  applicantsDataMobile;
        }

        public async Task<ChildsDataWindowResponse> GetChildsDataMobile(int applicationID, int languageID)
        {

            var childsData = (await Task.FromResult(
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 2
                join addr in context.Addresses on aPD.AddressID equals addr.AddressID
                join appDocs1 in context.ApplicationDocuments on aPD.ApplicationID equals appDocs1.ApplicationID
                where appDocs1.DocumentTypeID == 6
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
                    addr.CountryID,
                    appDocs1.ApplicationDocumentID,
                    appDocs1.AddressLink
                }
            )).FirstOrDefault();

            IEnumerable<SpecificDataFromDetailsTable> specificChildsData = GetSpecificDetailsOfApplication(applicationID, languageID, 2).Result;

            var ans = new ChildsDataWindowResponse
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
                ChildsDocumentID1 = childsData.ApplicationDocumentID,
                ChildsDocumentsAddressLink1 = childsData.AddressLink,
                SpecificChildsData = specificChildsData
            };
            return ans;
        }

        public async Task<FathersDataWindowResponse> GetFathersDataMobile(int applicationID)
        {
            var fathersData = await Task.FromResult((
                from apps in context.Applications
                where apps.ApplicationID == applicationID
                join aPD in context.ApplicationsParticipantsData on apps.ApplicationID equals aPD.ApplicationID
                where aPD.ApplicationMemberTypeID == 3
                join citizenship in context.Cityzenship on aPD.CurrentCitizenship equals citizenship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                join appDocs1 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs1.ApplicationID, appDocs1.ApplicationParticipantsDataID }
                where appDocs1.DocumentTypeID == 4
                join appDocs2 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs2.ApplicationID, appDocs2.ApplicationParticipantsDataID }
                where appDocs2.DocumentTypeID == 5
                select new FathersDataWindowResponse
                {
                    ApplicationID = apps.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    Surname = aPD.Surname,
                    Name = aPD.Name,
                    Patronymic = aPD.Patronymic,
                    Birthday = aPD.Birthday ?? DateTime.Today,
                    CityzenshipID = citizenship.CityzenshipID,
                    NationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    CurrentAddressID = addresses.AddressID,
                    CurrentAddress = addresses.AddressName,
                    CurrentVillageID = addresses.VillageID,
                    CurrentCityDistrictID = addresses.CityDistrictID,
                    CurrentRegionID = addresses.RegionID,
                    CurrentCountryID = addresses.CountryID,
                    CurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    PlaceOfWork = aPD.PlaceOfWork,
                    EducationLevelID = educationLevels.EducationLevelID,
                    DocumentID1 = appDocs1.ApplicationDocumentID,
                    AddressLink1 = appDocs1.AddressLink,
                    DocumentID2 = appDocs2.ApplicationDocumentID,
                    AddressLink2 = appDocs2.AddressLink
                }
            ).FirstOrDefault());
            return fathersData;
        }

        public async Task<MothersDataWindowResponse> GetMothersDataMobile(int applicationID)
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
                join appDocs1 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs1.ApplicationID, appDocs1.ApplicationParticipantsDataID }
                where appDocs1.DocumentTypeID == 4
                join appDocs2 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs2.ApplicationID, appDocs2.ApplicationParticipantsDataID }
                where appDocs2.DocumentTypeID == 5
                join appDocs3 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs3.ApplicationID, appDocs3.ApplicationParticipantsDataID }
                where appDocs3.DocumentTypeID == 2
                select new MothersDataWindowResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    Surname = aPD.Surname,
                    Name = aPD.Name,
                    Patronymic = aPD.Patronymic,
                    Birthday = aPD.Birthday ?? DateTime.Today,
                    CityzenshipID = ctznship.CityzenshipID,
                    NationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    CurrentAddressID = addresses.AddressID,
                    CurrentAddress = addresses.AddressName,
                    CurrentVillageID = villagesRes.VillageID,
                    CurrentCityDistrictID = citiesDistricts.CityDistrictID,
                    CurrentRegionID = regions.RegionID,
                    CurrentCountryID = countries.CountryID,
                    CurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    PlaceOfWork = aPD.PlaceOfWork,
                    TypeOfActivitiesInWorkID = aPD.TypeOfActivitiesInWorkID ?? 0,
                    EducationLevelID = educationLevels.EducationLevelID,
                    DocumentID1 = appDocs1.ApplicationDocumentID,
                    DocumentAddressLink1 = appDocs1.AddressLink,
                    DocumentID2 = appDocs2.ApplicationDocumentID,
                    DocumentAddressLink2 = appDocs2.AddressLink,
                    DocumentID3 = appDocs3.ApplicationDocumentID,
                    DocumentAddressLink3 = appDocs3.AddressLink
                }
            ).FirstOrDefault());
            return mothersData;
        }

        public async Task<DeceasedDataWindowMobileResponse> GetDeceasedDataMobile(int applicationID, int languageID)
        {

            var deceasedData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 5
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join aDs in context.ApplicationDocuments on new { aPD.ApplicationParticipantsDataID, aPD.ApplicationID, aPD.ApplicationTypeID } equals new { aDs.ApplicationParticipantsDataID, aDs.ApplicationID, aDs.ApplicationTypeID }
                where aDs.DocumentTypeID == 7
                select new
                {
                    aPD.ApplicationID,
                    aPD.ApplicationParticipantsDataID,
                    aPD.Surname,
                    aPD.Name,
                    aPD.Patronymic,
                    aPD.Birthday,
                    aPD.Sex,
                    addresses.AddressID,
                    addresses.AddressName,
                    addresses.VillageID,
                    addresses.CityDistrictID,
                    addresses.RegionID,
                    addresses.CountryID,
                    aDs.ApplicationDocumentID,
                    aDs.AddressLink,
                    aPD.CurrentCitizenship,
                    aPD.CurrentNationality,
                    aPD.EducationLevelID,
                    aPD.MaritalStatusID,
                    aPD.PlaceOfWork
                }).FirstOrDefault()
            );

            IEnumerable<SpecificDataFromDetailsTable> specificDeceasedData = GetSpecificDetailsOfApplication(applicationID, languageID, 5).Result;

            var ans = new DeceasedDataWindowMobileResponse
            {
                ApplicationID = deceasedData.ApplicationID,
                ApplicationParticipantsDataID = deceasedData.ApplicationParticipantsDataID,
                DeceasedSurname = deceasedData.Surname,
                DeceasedName = deceasedData.Name,
                DeceasedPatronymic = deceasedData.Patronymic,
                DeceasedBirthday = deceasedData.Birthday ?? DateTime.Today,
                DeceasedSex = deceasedData.Sex ?? true,
                DeceasedAddressID = deceasedData.AddressID,
                DeceasedAddress = deceasedData.AddressName,
                DeceasedVillageID = deceasedData.VillageID,
                DeceasedCityDistrictID = deceasedData.CityDistrictID,
                DeceasedRegionID = deceasedData.RegionID,
                DeceasedCountryID = deceasedData.CountryID,
                SpecificDeceasedData = specificDeceasedData,
                DeceasedDocumentID = deceasedData.ApplicationDocumentID,
                DeceasedDocumentAddressLink = deceasedData.AddressLink,
                DeceasedCityzenshipID = deceasedData.CurrentCitizenship ?? 0,
                DeceasedNationalityID = deceasedData.CurrentNationality ?? 0,
                DeceasedEducationLevelID = deceasedData.EducationLevelID ?? 0,
                DeceasedMaritalStatusID = deceasedData.MaritalStatusID,
                DeceasedPlaceOfWork = deceasedData.PlaceOfWork
            };
            return ans;
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
                join appDoc1 in context.ApplicationDocuments on aPD.ApplicationID equals appDoc1.ApplicationID
                where appDoc1.DocumentTypeID == 4
                join appDoc2 in context.ApplicationDocuments on aPD.ApplicationID equals appDoc2.ApplicationID
                where appDoc2.DocumentTypeID == 5
                //join 
                select new ApplicantsDataWindowWebResponse()
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    ApplicationsTypeOfExpiration = GetApplicationTypeOfExpirationByPaidTime(apps.MainEventTime ?? DateTime.MinValue, apps.SentTime ?? DateTime.Now),
                    ApplicantsCountryID = adrs.CountryID,
                    ApplicantsRegionID = adrs.RegionID,
                    ApplicantsCityDistrictID = adrs.CityDistrictID,
                    ApplicantsVillageID = adrs.VillageID,
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

        public async Task<ChildsDataWindowResponse> GetChildsDataWeb(int applicationID, int languageID)
        {
            var childsData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 2
                join adrs in context.Addresses on aPD.AddressID equals adrs.AddressID
                join appDoc1 in context.ApplicationDocuments on aPD.ApplicationID equals appDoc1.ApplicationID into appDocs
                from appDoc1Res in appDocs.DefaultIfEmpty()
                where appDoc1Res.DocumentTypeID == 6
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
                    ChildsVillageID = adrs.VillageID,
                    ChildsCityDistrictID = adrs.CityDistrictID,
                    ChildsRegionID = adrs.RegionID,
                    ChildsCountryID = adrs.CountryID,
                    ChildsDocumentID1 = appDoc1Res.ApplicationDocumentID,
                    ChildsDocumentsAddressLink1 = appDoc1Res.AddressLink
                }).FirstOrDefault()
            );


            IEnumerable<SpecificDataFromDetailsTable> specificChildsData = GetSpecificDetailsOfApplication(applicationID, languageID, 2).Result;

            if (specificChildsData.Count() == 0) return null;

            var ans = new ChildsDataWindowResponse
            {
                ApplicationID = childsData.ApplicationID,
                ApplicationParticipantsDataID = childsData.ApplicationParticipantsDataID,
                ChildsSurname = childsData.ChildsSurname,
                ChildsName = childsData.ChildsName,
                ChildsPatronymic = childsData.ChildsPatronymic,
                ChildsSex = childsData.ChildsSex,
                ChildsBirthday = childsData.ChildsBirthday,
                ChildsCountryID = childsData.ChildsCountryID,
                ChildsRegionID = childsData.ChildsRegionID,
                ChildsCityDistrictID = childsData.ChildsCityDistrictID,
                ChildsVillageID = childsData.ChildsVillageID,
                ChildsAddressID = childsData.ChildsAddressID,
                ChildsAddress = childsData.ChildsAddress,
                SpecificChildsData = specificChildsData,
                ChildsDocumentID1 = childsData.ChildsDocumentID1,
                ChildsDocumentsAddressLink1 = childsData.ChildsDocumentsAddressLink1
            };
            return ans;
        }

        public async Task<FathersDataWindowResponse> GetFathersDataWeb(int applicationID)
        {
            var fathersData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 3
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                join appDocs1 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs1.ApplicationID, appDocs1.ApplicationParticipantsDataID }
                where appDocs1.DocumentTypeID == 4
                join appDocs2 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs2.ApplicationID, appDocs2.ApplicationParticipantsDataID }
                where appDocs2.DocumentTypeID == 5
                select new FathersDataWindowResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    Surname = aPD.Surname,
                    Name = aPD.Name,
                    Patronymic = aPD.Patronymic,
                    Birthday = aPD.Birthday ?? DateTime.Today,
                    CityzenshipID = ctznship.CityzenshipID,
                    NationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    CurrentAddressID = addresses.AddressID,
                    CurrentAddress = addresses.AddressName,
                    CurrentVillageID = addresses.VillageID,
                    CurrentCityDistrictID = addresses.CityDistrictID,
                    CurrentRegionID = addresses.RegionID,
                    CurrentCountryID = addresses.CountryID,
                    CurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    PlaceOfWork = aPD.PlaceOfWork,
                    EducationLevelID = educationLevels.EducationLevelID,
                    DocumentID1 = appDocs1.ApplicationDocumentID,
                    AddressLink1 = appDocs1.AddressLink,
                    DocumentID2 = appDocs2.ApplicationDocumentID,
                    AddressLink2 = appDocs2.AddressLink
                }
            ).FirstOrDefault());
            return fathersData;
        }

        public async Task<MothersDataWindowResponse> GetMothersDataWeb(int applicationID)
        {
            var mothersData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 4
                join ctznship in context.Cityzenship on aPD.CurrentCitizenship equals ctznship.CityzenshipID
                join nationalities in context.Nationalities on aPD.CurrentNationality equals nationalities.NationalityID
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join educationLevels in context.EducationLevels on aPD.EducationLevelID equals educationLevels.EducationLevelID
                join appDocs1 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs1.ApplicationID, appDocs1.ApplicationParticipantsDataID }
                where appDocs1.DocumentTypeID == 4
                join appDocs2 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs2.ApplicationID, appDocs2.ApplicationParticipantsDataID }
                where appDocs2.DocumentTypeID == 5
                join appDocs3 in context.ApplicationDocuments
                    on new { aPD.ApplicationID, aPD.ApplicationParticipantsDataID }
                    equals new { appDocs3.ApplicationID, appDocs3.ApplicationParticipantsDataID }
                where appDocs3.DocumentTypeID == 2
                select new MothersDataWindowResponse
                {
                    ApplicationID = aPD.ApplicationID,
                    ApplicationParticipantsDataID = aPD.ApplicationParticipantsDataID,
                    Surname = aPD.Surname,
                    Name = aPD.Name,
                    Patronymic = aPD.Patronymic,
                    Birthday = aPD.Birthday ?? DateTime.Today,
                    CityzenshipID = ctznship.CityzenshipID,
                    NationalityID = nationalities.NationalityID,
                    PassportNumber = aPD.PassportNumber,
                    PassportGivingOrgan = aPD.PassportGivingOrgan,
                    CurrentAddressID = addresses.AddressID,
                    CurrentAddress = addresses.AddressName,
                    CurrentVillageID = addresses.VillageID,
                    CurrentCityDistrictID = addresses.CityDistrictID,
                    CurrentRegionID = addresses.RegionID,
                    CurrentCountryID = addresses.CountryID,
                    CurrentAddressLivingStartTime = aPD.CurrentAddressLivingStartTime ?? DateTime.Today,
                    PlaceOfWork = aPD.PlaceOfWork,
                    TypeOfActivitiesInWorkID = aPD.TypeOfActivitiesInWorkID ?? 0,
                    EducationLevelID = educationLevels.EducationLevelID,
                    DocumentID1 = appDocs1.ApplicationDocumentID,
                    DocumentAddressLink1 = appDocs1.AddressLink,
                    DocumentID2 = appDocs2.ApplicationDocumentID,
                    DocumentAddressLink2 = appDocs2.AddressLink,
                    DocumentID3 = appDocs3.ApplicationDocumentID,
                    DocumentAddressLink3 = appDocs3.AddressLink
                }
            ).FirstOrDefault());
            return mothersData;
        }


        // methods for death registration 

        public async Task<DeceasedDataWindowWebResponse> GetDeceasedDataWeb(int applicationID, int languageID)
        {

            var deceasedData = await Task.FromResult((
                from aPD in context.ApplicationsParticipantsData
                where aPD.ApplicationID == applicationID
                    && aPD.ApplicationMemberTypeID == 5
                join addresses in context.Addresses on aPD.AddressID equals addresses.AddressID
                join aDs in context.ApplicationDocuments on new { aPD.ApplicationParticipantsDataID, aPD.ApplicationID, aPD.ApplicationTypeID } equals new { aDs.ApplicationParticipantsDataID, aDs.ApplicationID, aDs.ApplicationTypeID }
                where aDs.DocumentTypeID == 7
                select new
                {
                    aPD.ApplicationID,
                    aPD.ApplicationParticipantsDataID,
                    aPD.Surname,
                    aPD.Name,
                    aPD.Patronymic,
                    aPD.Birthday,
                    aPD.Sex,
                    addresses.AddressID,
                    addresses.AddressName,
                    addresses.VillageID,
                    addresses.CityDistrictID,
                    addresses.RegionID,
                    addresses.CountryID,
                    aDs.ApplicationDocumentID,
                    aDs.AddressLink,
                    aPD.CurrentCitizenship,
                    aPD.CurrentNationality,
                    aPD.EducationLevelID,
                    aPD.MaritalStatusID,
                    aPD.PlaceOfWork
                }).FirstOrDefault()
            );

            IEnumerable<SpecificDataFromDetailsTable> specificDeceasedData = GetSpecificDetailsOfApplication(applicationID, languageID, 5).Result;

            var birthAddress = context.Addresses.Find(int.Parse(specificDeceasedData.Where(a => a.SpecificApplicationDataID == 7).FirstOrDefault().Value));
            var deathAddress = context.Addresses.Find(int.Parse(specificDeceasedData.Where(a => a.SpecificApplicationDataID == 9).FirstOrDefault().Value));
            var ans = new DeceasedDataWindowWebResponse
            {
                ApplicationID = deceasedData.ApplicationID,
                ApplicationParticipantsDataID = deceasedData.ApplicationParticipantsDataID,
                DeceasedSurname = deceasedData.Surname,
                DeceasedName = deceasedData.Name,
                DeceasedPatronymic = deceasedData.Patronymic,
                DeceasedBirthday = deceasedData.Birthday ?? DateTime.Today,
                DeceasedSex = deceasedData.Sex ?? true,
                DeceasedAddressID = deceasedData.AddressID,
                DeceasedAddress = deceasedData.AddressName,
                DeceasedVillageID = deceasedData.VillageID,
                DeceasedCityDistrictID = deceasedData.CityDistrictID,
                DeceasedRegionID = deceasedData.RegionID,
                DeceasedCountryID = deceasedData.CountryID,
                SpecificDeceasedData = specificDeceasedData,
                DeceasedDocumentID = deceasedData.ApplicationDocumentID,
                DeceasedDocumentAddressLink = deceasedData.AddressLink,
                DeceasedBirthAddressID = birthAddress.AddressID,
                DeceasedBirthAddress = birthAddress.AddressName,
                DeceasedBirthVillageID = birthAddress.VillageID,
                DeceasedBirthCityDistrictID = birthAddress.CityDistrictID,
                DeceasedBirthRegionID = birthAddress.RegionID,
                DeceasedBirthCountryID = birthAddress.CountryID,
                DeceasedDeathAddressID = deathAddress.AddressID,
                DeceasedDeathAddress = deathAddress.AddressName,
                DeceasedDeathVillageID = deathAddress.VillageID,
                DeceasedDeathCityDistrictID = deathAddress.CityDistrictID,
                DeceasedDeathRegionID = deathAddress.RegionID,
                DeceasedDeathCountryID = deathAddress.CountryID,
                DeceasedCityzenshipID = deceasedData.CurrentCitizenship ?? 0,
                DeceasedNationalityID = deceasedData.CurrentNationality ?? 0,
                DeceasedEducationLevelID = deceasedData.EducationLevelID ?? 0,
                DeceasedMaritalStatusID = deceasedData.MaritalStatusID,
                DeceasedPlaceOfWork = deceasedData.PlaceOfWork
                
            };
            return ans;
        }

        // API methods
        public async Task<IEnumerable<ApplicationsToCROISResponse>> GetApplicationsToCROIS()
        {
            var ans = await Task.FromResult(
                from applications in context.Applications
                where applications.ApplicationStatusID == 3
                select new ApplicationsToCROISResponse
                {
                    ApplicationID = applications.ApplicationID,
                    ApplicationTypeID = applications.ApplicationTypeID,
                    ApplicationsToCROISStatus = applications.ApplicationToCROISStatusID
                }
            );
            return ans;
        }

        public async Task<int> GetApplicationsAmount(int croID, int? applicationTypeID)
        {
            int hierarchyLevel = await Task.FromResult((
                from organizationUnits in context.OrganizationUnitNew1ForResearch
                where (organizationUnits.OrganizationUnitId == croID)
                select organizationUnits.HierarchyLevel
            ).Min());

            int ans = await Task.FromResult((

                from applications in context.Applications
                where(applications.ApplicationStatusID == 2
                    && applications.ApplicationParticipantsDataID != 0)
                join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                where (hierarchyLevel == 1) 
                    ? departments.CountryID == 185
                    : (hierarchyLevel == 2)
                        ? departments.RegionID == croID
                        : (hierarchyLevel == 3)
                            ? departments.CityDistrictID == croID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croID
                                : false
                join apT in context.ApplicationTypes on applications.ApplicationTypeID equals apT.ApplicationTypeID
                where applicationTypeID == null || applicationTypeID == apT.ApplicationTypeID
                select new
                {
                    applications.ApplicationID
                }
            ).Count());
            return ans;
        }

        // for printing
        
        public async Task<ApplicationsPrintingForm> GetApplicationsPrintingForms(int applicationID)
        {

            int applicationTypeID = await Task.FromResult((
                from applications in context.Applications 
                where applications.ApplicationID == applicationID
                select applications.ApplicationTypeID
            ).FirstOrDefault());
            BirthApplicationPrintingForm bf = null;
            DeathApplicationPrintingForm df = null;
            if (applicationTypeID == 1)
            {
                bf = await Task.FromResult((
                    from applications in context.Applications
                    where applications.ApplicationID == applicationID
                    join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                    join departmentsAddress in context.Addresses on departments.AddressID equals departmentsAddress.AddressID
                    join applicantAPD in context.ApplicationsParticipantsData on applications.ApplicationParticipantsDataID equals applicantAPD.ApplicationParticipantsDataID
                    join applicantsAddress in context.Addresses on applicantAPD.AddressID equals applicantsAddress.AddressID
                    join childsAPD in context.ApplicationsParticipantsData on applications.ApplicationID equals childsAPD.ApplicationID
                    where childsAPD.ApplicationMemberTypeID == 2
                    join childsAddress in context.Addresses on childsAPD.AddressID equals childsAddress.AddressID
                    join fathersAPD in context.ApplicationsParticipantsData on applications.ApplicationID equals fathersAPD.ApplicationID
                    where fathersAPD.ApplicationMemberTypeID == 3
                    join fathersNationality in context.Nationalities on fathersAPD.CurrentNationality equals fathersNationality.NationalityID
                    join fathersCityzenship in context.Cityzenship on fathersAPD.CurrentCitizenship equals fathersCityzenship.CityzenshipID
                    join mothersAPD in context.ApplicationsParticipantsData on applications.ApplicationID equals mothersAPD.ApplicationID
                    where mothersAPD.ApplicationMemberTypeID == 4
                    join mothersNationality in context.Nationalities on mothersAPD.CurrentNationality equals mothersNationality.NationalityID
                    join mothersCityzenship in context.Cityzenship on mothersAPD.CurrentCitizenship equals mothersCityzenship.CityzenshipID

                    select new BirthApplicationPrintingForm
                    {
                        DepartmentsAddress = "САҲШ-и " + departmentsAddress.AddressName,
                        ApplicantsFullName = applicantAPD.Surname + " " + applicantAPD.Name + " " + (applicantAPD.Patronymic ?? ""),
                        ApplicantsFullAddress = applicantsAddress.FullAddress,
                        ApplicantsPassportNumber = applicantAPD.PassportNumber,
                        ApplicantsPassportGivingOrgan = applicantAPD.PassportGivingOrgan,
                        ChildsSurname = childsAPD.Surname,
                        ChildsName = childsAPD.Name,
                        ChildsPatronymic = childsAPD.Patronymic,
                        ChildsSex = (childsAPD.Sex ?? false) ? "мард" : "зан",
                        ChildsBirthday = childsAPD.Birthday.Value.ToString("dd.MM.yyyy hh:mm:ss"),
                        ChildsFullAddress = childsAddress.FullAddress,
                        FathersFullName = fathersAPD.Surname + " " + fathersAPD.Name + " " + (fathersAPD.Patronymic ?? ""),
                        FathersBirthday = fathersAPD.Birthday.Value.Date.ToString("dd.MM.yyyy"),
                        FathersCityzenship = fathersCityzenship.Name,
                        FathersNationality = fathersNationality.Name,
                        MothersFullName = mothersAPD.Surname + " " + mothersAPD.Name + " " + (mothersAPD.Patronymic ?? ""),
                        MothersBirthday = mothersAPD.Birthday.Value.Date.ToString("dd.MM.yyyy"),
                        MothersCityzenship = mothersCityzenship.Name,
                        MothersNationality = mothersNationality.Name,
                        ApplicationCreatedTime = applications.CreatedTime

                    }

                ).FirstOrDefault());

            } 
            else
            {
                df = await Task.FromResult((
                    from applications in context.Applications
                    where applications.ApplicationID == applicationID
                    join departments in context.RegistryOfficeDepartments on applications.DepartmentID equals departments.DepartmentID
                    join departmentsAddress in context.Addresses on departments.AddressID equals departmentsAddress.AddressID
                    join applicantAPD in context.ApplicationsParticipantsData on applications.ApplicationParticipantsDataID equals applicantAPD.ApplicationParticipantsDataID
                    join applicantsAddress in context.Addresses on applicantAPD.AddressID equals applicantsAddress.AddressID
                    join deceasedAPD in context.ApplicationsParticipantsData on applications.ApplicationID equals deceasedAPD.ApplicationID
                    where deceasedAPD.ApplicationMemberTypeID == 5
                    join deceasedDeathDateSpecificData in context.ApplicationsDetails on deceasedAPD.ApplicationID equals deceasedDeathDateSpecificData.ApplicationID
                    where deceasedDeathDateSpecificData.SpecificApplicationDataID == 6
                    join deceasedDeathAddressSpecificData in context.ApplicationsDetails on deceasedAPD.ApplicationID equals deceasedDeathAddressSpecificData.ApplicationID
                    where deceasedDeathAddressSpecificData.SpecificApplicationDataID == 9
                    join deceasedDeathAddress in context.Addresses on deceasedDeathAddressSpecificData.Detail equals deceasedDeathAddress.AddressID.ToString()
                    join deceasedPermanentAddress in context.Addresses on deceasedAPD.AddressID equals deceasedPermanentAddress.AddressID
                    select new DeathApplicationPrintingForm
                    {
                        DepartmentsAddress = "САҲШ-и " + departmentsAddress.AddressName,
                        ApplicantsFullName = applicantAPD.Surname + " " + applicantAPD.Name + " " + (applicantAPD.Patronymic ?? ""),
                        ApplicantsFullAddress = applicantsAddress.FullAddress,
                        ApplicantsPassportNumber = applicantAPD.PassportNumber,
                        ApplicantsPassportGivingOrgan = applicantAPD.PassportGivingOrgan,
                        DeceasedSurname = deceasedAPD.Surname,
                        DeceasedName = deceasedAPD.Name,
                        DeceasedPatronymic = deceasedAPD.Patronymic ?? "",
                        DeceasedSex = (deceasedAPD.Sex ?? false) ? "мард" : "зан",
                        DeceasedDeathDate = DateTime.Parse(deceasedDeathDateSpecificData.Detail).ToString("dd.MM.yyyy"),
                        DeceasedDeathFullAddress = deceasedDeathAddress.FullAddress,
                        DeceasedPermanentFullAddress = deceasedPermanentAddress.FullAddress,
                        ApplicationCreatedTime = applications.CreatedTime
                    }
                ).FirstOrDefault());
            }
            ApplicationsPrintingForm ans = new ApplicationsPrintingForm
            {
                WhichApplicationTypesModel = applicationTypeID,
                BirthApplication = bf,
                DeathApplication = df
            };
            return ans;
        }
        // supportive methods
        public static string GetApplicationTypeOfExpirationByPaidTime(DateTime eventTime, DateTime endTime)
        {
            DateTime deadline1 = eventTime.AddMonths(3);
            //deadline1 = deadline1.AddDays(-1);
            DateTime deadline2 = eventTime.AddYears(1);
            //deadline2 = deadline2.AddDays(-1);

            string ans;
            if ((deadline1 - endTime).TotalDays >= 0)
            {
                ans = "то 3 моҳ";
            }
            else if ((deadline2 - endTime).TotalDays >= 0)
            {
                ans = "аз 3 моҳ то 1 сол";
            }
            else
            {
                ans = "аз 1 сол зиёд";
            }
            return ans;
        }

        public async Task<IEnumerable<SpecificDataFromDetailsTable>> GetSpecificDetailsOfApplication(int applicationID, int languageID, int applicationMemberTypeID)
        {
            var specificApplicationsData = (await Task.FromResult(
                from applicationsDetails in context.ApplicationsDetails
                where applicationsDetails.ApplicationID == applicationID
                    && applicationsDetails.ApplicationMemberTypeID == applicationMemberTypeID
                orderby applicationsDetails.SpecificApplicationDataID
                join applicationTypesSpecificData in context.ApplicationTypesSpecificData on applicationsDetails.ApplicationTypesSpecificDataID equals applicationTypesSpecificData.ApplicationTypesSpecificDataID
                join specificApplicationData in context.SpecificApplicationData on applicationTypesSpecificData.SpecificApplicationDataID equals specificApplicationData.SpecificApplicationDataID
                where specificApplicationData.StatusID == 1
                join fieldTypes in context.FieldTypes on specificApplicationData.FieldTypeID equals fieldTypes.FieldTypeID
                join labels in context.Labels on specificApplicationData.LabelID equals labels.LabelID
                //join proccessedValue in context.Labels on ((applicationsDetails.SpecificApplicationDataID == 16 || applicationsDetails.SpecificApplicationDataID == 17) ? (int.Parse(applicationsDetails.Detail) equals proccessedValue.LabelID)
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
            )).ToList();
            foreach (SpecificDataFromDetailsTable el in specificApplicationsData) 
            {
                el.Value = GetLabelOfWhichAddressDepartment(el.SpecificApplicationDataID, languageID, el.Value);
            }

            return specificApplicationsData;
        }

        public async Task<IEnumerable<PaymentTypesMobileResponse>> GetPaymentTypes(int applicationID, int applicationSourceID)
        {
            Applications applicationForUpdate = context.Applications.Find(applicationID);
            DateTime sentTime = DateTime.Now;
            applicationForUpdate.SentTime = sentTime;
            context.Entry(applicationForUpdate).State = EntityState.Modified;
            context.SaveChanges();

            var application = await Task.FromResult((
                from applications in context.Applications
                where applications.ApplicationID == applicationID
                    && applications.ApplicationSourceID == applicationSourceID
                //join aPD in context.ApplicationsParticipantsData on applications.ApplicationID equals aPD.ApplicationID
                //where aPD.ApplicationMemberTypeID == (applications.ApplicationTypeID == 1 ? 2 : 5) 
                select new
                {
                    applications.ApplicationTypeID,
                    applications.MainEventTime
                }
                ).FirstOrDefault());

            int applicationTypeID = application.ApplicationTypeID;
            DateTime eventTime = application.MainEventTime ?? DateTime.MinValue;
            List<PaymentTypesMobileResponse> ans = new();
            PaymentTypesMobileResponse f = new();
            PaymentTypesMobileResponse s = new();
            PaymentTypesMobileResponse th = new();
            string typeOfExpiration = GetApplicationTypeOfExpirationByPaidTime(eventTime, sentTime);
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
                        Summ = applicationTypePayments.Percent * applicationTypePayments.Quantity * (decimal)0.01 * indicator
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
            else
            {
                throw new NotInOneYearAppException();
                /*
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
                th.ServiceSum = (double)tmp3.Summ;*/
            }
            ans.Add(f);
            ans.Add(s);
            ans.Add(th);

            return ans;
        }

        public async Task<DepartmentToWhichAddressResponse> GetDepartmentToWhichAddress(int applicationID)
        {
            var ans = await Task.FromResult((
                from application in context.Applications
                where application.ApplicationID == applicationID
                join applicationsDetails in context.ApplicationsDetails on application.ApplicationID equals applicationsDetails.ApplicationID
                where (application.ApplicationTypeID == 1) ? applicationsDetails.ApplicationTypesSpecificDataID == 16 : applicationsDetails.ApplicationTypesSpecificDataID == 17
                select new DepartmentToWhichAddressResponse
                {
                    ApplicationID = application.ApplicationID,
                    RegistratedByWhichMemberID = (application.ApplicationTypeID == 1) ? int.Parse(applicationsDetails.Detail) : null,
                    RegistratedByWhichAddress = (application.ApplicationTypeID == 1) ? null : int.Parse(applicationsDetails.Detail)

                }
            ).FirstOrDefault());

            return ans;
        }


        public async Task<IEnumerable<RejectionCausesResponse>> GetRejectionCauses(int languageID)
        {
            var ans = await Task.FromResult(
                from rejectionCauses in context.RejectionCauses
                where rejectionCauses.StatusID.Equals(1)
                join labels in context.Labels on rejectionCauses.LabelID equals labels.LabelID
                select new RejectionCausesResponse
                {
                    RejectionCauseID = rejectionCauses.RejectionCauseID,
                    Name = rejectionCauses.Name,
                    RejectionLabel = (languageID == 1) ? labels.Label1 : ((languageID == 2) ? labels.Label2 : labels.Label3)
                }
            );
            return ans;
        }

        private static int GetIntValue(string detail)
        {
            int ans;
            try
            {
                ans = int.Parse(detail);
            }
            catch
            {
                ans = 0;
            }

            return ans;
        }

        private string GetLabelOfWhichAddressDepartment(int specificApplicationDataID, int languageID, string value)
        {
            string ans = null; 
            if (specificApplicationDataID == 16)
            {
                int intVal = int.Parse(value);
                ans = (
                    from ll in context.Labels
                    where (intVal == 3) ? ll.LabelID == 1563 : ll.LabelID == 1564
                    select (languageID == 1) ? ll.Label1 : (languageID == 2) ? ll.Label2 : ll.Label3
                ).FirstOrDefault();
            }
            else if (specificApplicationDataID == 17)
            {
                int intVal = int.Parse(value);
                ans = (
                    from ll in context.Labels
                    where (intVal == 1) ? ll.LabelID == 1565 : ll.LabelID == 1567
                    select (languageID == 1) ? ll.Label1 : (languageID == 2) ? ll.Label2 : ll.Label3
                ).FirstOrDefault();
            }
            else if (specificApplicationDataID == 6)
            {
                DateTime dateTimeVal = DateTime.Parse(value);
                ans = dateTimeVal.Date.ToString("d");
            }
            else ans = value;
            return ans;
        }
        /**
        private bool CheckDepartmentWithHierarchy(int hierarchyLevel, int? croisID)
        {
            if (croisID == null) return true;
            RegistryOfficeDepartments department = (
                from departmentDB in context.RegistryOfficeDepartments 
                where departmentDB.DepartmentID == departmentID
                select departmentDB
            ).FirstOrDefault();
            int hierarchyLevel = (
                from organizationUnit in context.OrganizationUnitNew1ForResearch
                where organizationUnit.OrganizationUnitId == croisID
                select organizationUnit.HierarchyLevel
            ).FirstOrDefault();
            var ans = hierarchyLevel switch
            {
                1 => department.CountryID == 185,// TJK
                2 => department.RegionID == croisID,
                3 => department.CityDistrictID == croisID,
                4 => department.VillageID == croisID,
                _ => false
            };
            return ans;
        }*/

    }
}
