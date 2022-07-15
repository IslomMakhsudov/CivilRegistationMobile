using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Models;


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
            return await Task.FromResult(context.Set<Countries>().OrderBy(o => o.ShortName).ToList());
        }

        public async Task<IEnumerable<Regions>> GetAllRegions()
        {
            return await Task.FromResult(
                context.Regions.ToList()
            );
        }
        public async Task<IEnumerable<Regions>> GetAllRegionsOrdered()
        {
            return await Task.FromResult(context.Set<Regions>().OrderBy(o => o.Name).ToList());
        }
        public async Task<Regions> GetRegionByID(int regionID)
        {
            Regions ans = await Task.FromResult(
                context.Regions.Where(a => a.RegionID == regionID).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistricts()
        {
            return await Task.FromResult(
                context.CitiesDistricts.ToList()
            );
        }
        public async Task<IEnumerable<CitiesDistricts>> GetAllCitiesDistrictsOrdered()
        {
            return await Task.FromResult(context.Set<CitiesDistricts>().OrderBy(o => o.Name).ToList());
        }
        public async Task<CitiesDistricts> GetCityDistrictByID(int cityDistrictID)
        {
            CitiesDistricts ans = await Task.FromResult(
                context.CitiesDistricts.Where(a => a.CityDistrictID == cityDistrictID).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<Villages>> GetAllVillages()
        {
            return await Task.FromResult(
                context.Villages.ToList()
            );
        }
        public async Task<IEnumerable<Villages>> GetAllVillagesOrdered()
        {
            return await Task.FromResult(context.Set<Villages>().OrderBy(o => o.Name).ToList());
        }
        public async Task<Villages> GetVillageByID(int villageID)
        {
            Villages ans = await Task.FromResult(
                context.Villages.Where(a => a.VillageID == villageID).FirstOrDefault()
            );
            return ans;
        }

        public async Task<IEnumerable<EducationLevels>> GetAllEducationLevels()
        {
            return await Task.FromResult(
                context.EducationLevels.ToList()
            );
        }

        public async Task<IEnumerable<Cityzenship>> GetAllCitizenship()
        {
            return await Task.FromResult(
                context.Cityzenship.ToList()
            );
        }

        public async Task<IEnumerable<Nationalities>> GetAllNationalities()
        {
            return await Task.FromResult(
                context.Nationalities.ToList()
            );
        }

        public async Task<IEnumerable<ApplicationStatuses>> GetAllApplicationStatuses()
        {
            return await Task.FromResult(
                context.ApplicationStatuses.ToList()
            );
        }

        public async Task<IEnumerable<Cityzenship>> GetAllCityzenship()
        {
            return await Task.FromResult(
                context.Cityzenship.ToList()
            );
        }

        public async Task<IEnumerable<RegistryOfficeDepartments>> GetAllRegistryOfficeDepartments()
        {
            return await Task.FromResult(
                context.RegistryOfficeDepartments.ToList()
            );
        }
        public async Task<RegistryOfficeDepartments> GetRegistryOfficeDepartmentByID(int departmentID)
        {
            RegistryOfficeDepartments department = await Task.FromResult(
                context.RegistryOfficeDepartments.Find(departmentID)
            );
            return department;
        }
        
        public async Task<IEnumerable<Regions>> GetRegionsOfCountry(int countryID)
        {
            return await Task.FromResult(
                context.Regions.Where(r => r.CountryID == countryID).ToList()
            );
        }

        public async Task<IEnumerable<CitiesDistricts>> GetCitiesDistrictsOfRegion(int regionID)
        {
            return await Task.FromResult(
                context.CitiesDistricts.Where(c => c.RegionID == regionID).ToList()
            );
        }

        public async Task<IEnumerable<Villages>> GetVillagesOfCitiesDistricts(int cityDistrictID)
        {
            return await Task.FromResult(
                context.Villages.Where(v => v.CityDistrictID == cityDistrictID).ToList()
            );
        }
       
        public async Task<IEnumerable<Addresses>> GetAddressesOfVillagesOrCitiesDistricts(int? villagesID, int cityDistrictID)
        {
            if (villagesID != null)
            {
                return await Task.FromResult(
                    context.Addresses.Where(adr => adr.VillageID == villagesID)
                );
            }
            return await Task.FromResult(
                context.Addresses.Where(adr => adr.CityDistrictID == cityDistrictID).ToList()
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
    }
}
