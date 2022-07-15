using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

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
        Task<IEnumerable<Cityzenship>> GetAllCitizenship();
        Task<IEnumerable<Nationalities>> GetAllNationalities();
        Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses();
        Task<IEnumerable<RegistryOfficeDepartments>> GetAllRegistryOfficeDepartments();
        Task<RegistryOfficeDepartments> GetRegistryOfficeDepartmentByID(int departmentID);
        Task<IEnumerable<Regions>> GetRegionsOfCountry(int countryID);
        Task<IEnumerable<CitiesDistricts>> GetCitiesDistrictsOfRegion(int regionID);
        Task<IEnumerable<Villages>> GetVillagesOfCitiesDistricts(int cityDistrictID);
        Task<IEnumerable<Addresses>> GetAddressesOfVillagesOrCitiesDistricts(int? villagesID, int cityDistrictID);

    }
}
