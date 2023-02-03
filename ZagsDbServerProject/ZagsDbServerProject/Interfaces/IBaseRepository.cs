using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Interfaces
{
    public interface IBaseRepository : IGenericRepository<Object>
    {
        Task<IEnumerable<Countries>> GetAllCountries();
        Task<IEnumerable<Countries>> GetAllCountriesOrdered();
        Task<IEnumerable<Regions>> GetAllRegions();
        Task<IEnumerable<Regions>> GetAllRegionsOrdered();
        Task<Regions> GetRegionByID(int regionID);
        Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistricts();
        Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistrictsOrdered();
        Task<CitiesDistricts> GetCityDistrictByID(int cityDistrictID);
        Task<IEnumerable<Villages>> GetAllVillages();
        Task<IEnumerable<Villages>> GetAllVillagesOrdered();
        Task<Villages> GetVillageByID(int villageID);
        Task<IEnumerable<EducationLevels>> GetAllEducationLevels();
        Task<IEnumerable<Cityzenship>> GetAllCityzenship();
        Task<IEnumerable<Nationalities>> GetAllNationalities();
        Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses();
        Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses(bool isAdmin);
        Task<IEnumerable<RegistryOfficeDepartments>> GetAllRegistryOfficeDepartments();
        Task<RegistryOfficeDepartments> GetRegistryOfficeDepartmentByID(int departmentID);
        /// <summary>
        /// kalbosa
        /// </summary>
        /// <param name="villageID"></param>
        /// <param name="cityDistrictID"></param>
        /// <returns></returns>
        Task<IEnumerable<RegistryOfficeDepartments>> GetRegistryOfficeDepartmentsOfVillagesOrCitiesDistricts(int? villageID, int cityDistrictID);
        Task<IEnumerable<RegistryOfficeDepartments>> GetAllDepartmentsOfOrganizationUnit(int croisID);
        Task<IEnumerable<Regions>> GetRegionsOfCountry(int countryID);
        Task<IEnumerable<CitiesDistricts>> GetCitiesDistrictsOfRegion(int regionID);
        Task<IEnumerable<Villages>> GetVillagesOfCitiesDistricts(int cityDistrictID);
        Task<IEnumerable<Addresses>> GetAddressesOfVillagesOrCitiesDistricts(int? villagesID, int cityDistrictID);
        Task<IEnumerable<TypesOfActivitiesInWork>> GetTypesOfActivitiesInWorks();
        Task<IEnumerable<MaritalStatuses>> GetMaritalStatuses();
        Task<IEnumerable<SupportsResponse>> GetSupports();
        Task<IEnumerable<PaymentSystems>> GetPaymentSystems();
        Task<IEnumerable<PaymentTypes>> GetPaymentTypes();
        Task<IEnumerable<OrganizationUnitNew1ForResearch>> GetOrganizationUnits();
        Task<OrganizationUnitNew1ForResearch> GetOrganizationUnitByID(int croisOrganID);
        Task<string> GetApplicationStatusLabelByID(int applicationStatusID, int platformID, int languageID);
        Task<Dictionary<string, string>> GetPresentedTablesNames(int languageID);
        Task<IEnumerable<OrganizationUnitNew1ForResearch>> GetOrganizationUnitNew1ForResearch();
    }
}
