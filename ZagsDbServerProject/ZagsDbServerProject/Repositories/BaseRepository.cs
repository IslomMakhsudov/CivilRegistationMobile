using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Models;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
    public class BaseRepository : GenericRepository<object>, IBaseRepository
    {
        public BaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Countries>> GetAllCountries()
        {
            return await Task.FromResult(
                context.Countries.ToList()
            );
        }
        public async Task<IEnumerable<Countries>> GetAllCountriesOrdered()
        {
            return await Task.FromResult(context.Set<Countries>().Where(el => el.StatusID == 1).OrderBy(o => o.ShortName).ToList());
        }

        public async Task<IEnumerable<Regions>> GetAllRegions()
        {
            return await Task.FromResult(
                context.Regions.Where(el => el.StatusID == 1).ToList()
            );
        }
        public async Task<IEnumerable<Regions>> GetAllRegionsOrdered()
        {
            return await Task.FromResult(context.Set<Regions>().Where(el => el.StatusID == 1).OrderBy(o => o.Name).ToList());
        }
        public async Task<Regions> GetRegionByID(int regionID)
        {
            Regions ans = await Task.FromResult(
                context.Regions.Where(a => a.RegionID == regionID).Where(el => el.StatusID == 1).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistricts()
        {
            return await Task.FromResult(
                context.CitiesDistricts.Where(el => el.StatusID == 1).ToList()
            );
        }
        public async Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistrictsOrdered()
        {
            return await Task.FromResult(context.Set<CitiesDistricts>().Where(el => el.StatusID == 1).OrderBy(o => o.Name).ToList());
        }
        public async Task<CitiesDistricts> GetCityDistrictByID(int cityDistrictID)
        {
            CitiesDistricts ans = await Task.FromResult(
                context.CitiesDistricts.Where(a => a.CityDistrictID == cityDistrictID).Where(el => el.StatusID == 1).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<Villages>> GetAllVillages()
        {
            return await Task.FromResult(
                context.Villages.Where(el => el.StatusID == 1).ToList()
            );
        }
        public async Task<IEnumerable<Villages>> GetAllVillagesOrdered()
        {
            return await Task.FromResult(context.Set<Villages>().Where(el => el.StatusID == 1).OrderBy(o => o.Name).ToList());
        }
        public async Task<Villages> GetVillageByID(int villageID)
        {
            Villages ans = await Task.FromResult(
                context.Villages.Where(a => a.VillageID == villageID).Where(el => el.StatusID == 1).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<EducationLevels>> GetAllEducationLevels()
        {
            return await Task.FromResult(
                context.EducationLevels.Where(el => el.StatusID == 1).ToList()
            );
        }


        public async Task<IEnumerable<Nationalities>> GetAllNationalities()
        {
            return await Task.FromResult(
                context.Nationalities.Where(el => el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses()
        {
            return await Task.FromResult(
                context.ApplicationStatuses.Where(el => el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses(bool isAdmin)
        {
            return await Task.FromResult(
                context.ApplicationStatuses.Where(el => (isAdmin || el.ApplicationStatusID != 1) && el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<Cityzenship>> GetAllCityzenship()
        {
            return await Task.FromResult(
                context.Cityzenship.Where(el => el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<RegistryOfficeDepartments>> GetAllRegistryOfficeDepartments()
        {
            return await Task.FromResult(
                context.RegistryOfficeDepartments.Where(el => el.StatusID == 1).ToList()
            );
        }
        public async Task<RegistryOfficeDepartments> GetRegistryOfficeDepartmentByID(int departmentID)
        {
            RegistryOfficeDepartments department = await Task.FromResult(
                context.RegistryOfficeDepartments.Where(el => el.StatusID == 1 && el.DepartmentID == departmentID).FirstOrDefault()
            );
            return department;
        }
        public async Task<IEnumerable<RegistryOfficeDepartments>> GetRegistryOfficeDepartmentsOfVillagesOrCitiesDistricts(int? villageID, int cityDistrictID)
        {
            if (villageID != null)
            {
                return await Task.FromResult(
                    context.RegistryOfficeDepartments.Where(rod => rod.VillageID == villageID && rod.StatusID == 1)
                );
            }
            return await Task.FromResult(
                context.RegistryOfficeDepartments.Where(rod => rod.CityDistrictID == cityDistrictID && rod.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<RegistryOfficeDepartments>> GetAllDepartmentsOfOrganizationUnit(int croisID)
        {
            int hierarchyLevel = await Task.FromResult((
                from organizationUnit in context.OrganizationUnitNew1ForResearch
                where organizationUnit.OrganizationUnitId == croisID
                select organizationUnit.HierarchyLevel
            ).FirstOrDefault());
            var ans = await Task.FromResult(
                from departments in context.RegistryOfficeDepartments
                where 
                (hierarchyLevel == 1) 
                    ? departments.CountryID == 185 
                    : (hierarchyLevel == 2) 
                        ? departments.RegionID == croisID
                        : (hierarchyLevel == 3) 
                            ? departments.CityDistrictID == croisID
                            : (hierarchyLevel == 4)
                                ? departments.VillageID == croisID
                                : false
                select departments
            );
            return ans;
        }

        public async Task<IEnumerable<Regions>> GetRegionsOfCountry(int countryID)
        {
            return await Task.FromResult(
                context.Regions.Where(r => r.CountryID == countryID).Where(el => el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<CitiesDistricts>> GetCitiesDistrictsOfRegion(int regionID)
        {
            return await Task.FromResult(
                context.CitiesDistricts.Where(c => c.RegionID == regionID).Where(el => el.StatusID == 1).ToList()
            );
        }

        public async Task<IEnumerable<Villages>> GetVillagesOfCitiesDistricts(int cityDistrictID)
        {
            return await Task.FromResult(
                context.Villages.Where(v => v.CityDistrictID == cityDistrictID).Where(el => el.StatusID == 1).ToList()
            );
        }
       
        public async Task<IEnumerable<Addresses>> GetAddressesOfVillagesOrCitiesDistricts(int? villagesID, int cityDistrictID)
        {
            if (villagesID != null)
            {
                return await Task.FromResult(
                    context.Addresses.Where(adr => adr.VillageID == villagesID).Where(el => el.StatusID == 1).ToList()
                );
            }
            return await Task.FromResult(
                context.Addresses.Where(adr => adr.CityDistrictID == cityDistrictID).Where(el => el.StatusID == 1).ToList()
            );
        }
        /*
        public async void InsertCustomersRequest(object mobileModel, int customerID)
        {
            CustomerRequests customerRequests = new()
            {
                RequestTime = DateTime.Now,
                RequestJSONObject = mobileModel
            }
            context.CustomersFeedbacks.Add
        }*/

        public async Task<IEnumerable<TypesOfActivitiesInWork>> GetTypesOfActivitiesInWorks()
        {
            var ans = await Task.FromResult(
                context.TypesOfActivitiesInWorks.Where(el => el.StatusID == 1).ToList()
            );
            return ans;
        } 

        public async Task<IEnumerable<SupportsResponse>> GetSupports()
        {
            var ans = await Task.FromResult(
                from supportTypes in context.SupportTypes
                where supportTypes.StatusID == 1
                join suppports in context.Supports on supportTypes.SupportTypeID equals suppports.SupportTypeID
                select new SupportsResponse
                {
                    SupportID = suppports.SupportID,
                    SupportTypeID = supportTypes.SupportTypeID,
                    SupportText = supportTypes.Name,
                    SupportIconAddressLink = supportTypes.IconAddressLink,
                    SupportNumber = suppports.SupportText,
                    SupportURL = suppports.URL
                }
            );
            return ans;
        }

        public async Task<IEnumerable<PaymentSystems>> GetPaymentSystems()
        {
            var ans = await Task.FromResult(
                from paymentSystems in context.PaymentSystems.Where(el => el.StatusID == 1)
                select new PaymentSystems
                {
                    PaymentSystemID = paymentSystems.PaymentSystemID,
                    ShortName = paymentSystems.ShortName,
                    FullName = paymentSystems.FullName,
                    Address = paymentSystems.Address,
                    BIC = paymentSystems.BIC,
                    TIN = paymentSystems.TIN,
                    StatusID = paymentSystems.StatusID
                }
            );
            return ans;
        }

        public async Task<IEnumerable<PaymentTypes>> GetPaymentTypes()
        {
            var ans = await Task.FromResult(
                from paymentTypes in context.PaymentTypes.Where(el => el.StatusID == 1)
                select paymentTypes
            );
            return ans;
        }

        public async Task<IEnumerable<MaritalStatuses>> GetMaritalStatuses()
        {
            var ans = await Task.FromResult(
                from maritalStatuses in context.MaritalStatuses.Where(el => el.StatusID == 1)
                select maritalStatuses
            );
            return ans;
        }

        public async Task<IEnumerable<OrganizationUnitNew1ForResearch>> GetOrganizationUnits()
        {
            var ans = await Task.FromResult(
                from organizationUnits in context.OrganizationUnitNew1ForResearch
                where organizationUnits.StatusID == 1
                select organizationUnits
            );
            return ans;
        }

        public async Task<OrganizationUnitNew1ForResearch> GetOrganizationUnitByID(int croisOrganID)
        {
            OrganizationUnitNew1ForResearch ans = await Task.FromResult((
                from organizationUnits in context.OrganizationUnitNew1ForResearch
                where organizationUnits.OrganizationUnitId == croisOrganID && organizationUnits.StatusID == 1
                select organizationUnits
            ).FirstOrDefault());
            return ans;
        }

        public async Task<string> GetApplicationStatusLabelByID(int applicationStatusID, int platformID, int languageID)
        {
            string ans;
            if (platformID == 1) {
                ans = await Task.FromResult((
                    from applicationStatuses in context.ApplicationStatuses
                    join labels in context.Labels on applicationStatuses.MobileLabelID equals labels.LabelID
                    where applicationStatuses.ApplicationStatusID == applicationStatusID
                    select new
                    {
                        StatusLabel = (languageID == 1) ? labels.Label1 : (languageID == 2) ? labels.Label2 : labels.Label3
                    }
                ).FirstOrDefault().StatusLabel);
            } else
            {
                ans = await Task.FromResult((
                    from applicationStatuses in context.ApplicationStatuses
                    join labels in context.Labels on applicationStatuses.WebLabelID equals labels.LabelID
                    where applicationStatuses.ApplicationStatusID == applicationStatusID
                    select new
                    {
                        StatusLabel = (languageID == 1) ? labels.Label1 : (languageID == 2) ? labels.Label2 : labels.Label3
                    }
                ).FirstOrDefault().StatusLabel);
            }
            return ans;
        }

        public async Task<Dictionary<string, string>> GetPresentedTablesNames(int languageID)
        {

            var ans = await Task.FromResult(
                from dataTables in context.DataTables
                where dataTables.IsRepresentedInWeb == true
                join labels in context.Labels on dataTables.LabelID equals labels.LabelID
                select new
                {
                    dataTables.TableName,
                    LabelName = (languageID == 1) ? labels.Label1 : (languageID == 2) ? labels.Label2 : labels.Label3
                }
            );

            Dictionary<string, string> res = new();

            foreach (var item in ans)
            {
                res.Add(item.TableName, item.LabelName);
            }
            return res;
        }

        public async Task<IEnumerable<OrganizationUnitNew1ForResearch>> GetOrganizationUnitNew1ForResearch()
        {
            var ans = await Task.FromResult(
                from organizationUnitNew1ForResearch in context.OrganizationUnitNew1ForResearch
                where organizationUnitNew1ForResearch.StatusID == 1
                select organizationUnitNew1ForResearch
            );
            return ans;
        }
    }
}
