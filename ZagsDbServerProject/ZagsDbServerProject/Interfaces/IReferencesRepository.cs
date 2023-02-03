using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Repositories;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Interfaces
{
    public interface IReferencesRepository : IGenericRepository<Object>
    {
        Task<IEnumerable<Addresses>> GetAddresses();
        ///Task<IEnumerable<ApplicationMembersNeededData>> GetApplicationMembersNeededData();
        Task<IEnumerable<ApplicationMemberTypes>> GetApplicationMemberTypes();
        Task<IEnumerable<ApplicationSources>> GetApplicationSources();
        Task<IEnumerable<ApplicationTypeMembersResponse>> GetApplicationTypeMembers(int languageID);
        Task<IEnumerable<ApplicationTypePayments>> GetApplicationTypePayments();
        Task<IEnumerable<ApplicationTypes>> GetApplicationTypes();
        Task<IEnumerable<ApplicationTypesSpecificData>> GetApplicationTypesSpecificData();
        Task<IEnumerable<CitiesDistricts>> GetCitiesDistricts();
        Task<IEnumerable<Cityzenship>> GetCityzenship();
        Task<IEnumerable<Countries>> GetCountries();
        Task<IEnumerable<EducationLevels>> GetEducationLevels();
        Task<IEnumerable<FAQ>> GetFAQ();
        Task<IEnumerable<Languages>> GetLanguages();
        Task<IEnumerable<MaritalStatuses>> GetMaritalStatuses();
        Task<IEnumerable<Nationalities>> GetNationalities();
        Task<IEnumerable<OperationsTypes>> GetOperationsTypes();
        Task<IEnumerable<OrganizationUnitNew1ForResearch>> GetOrganizationUnitNew1ForResearch();
        Task<IEnumerable<OtherStateOrgans>> GetOtherStateOrgans();
        Task<IEnumerable<PaymentSystems>> GetPaymentSystems();
        Task<IEnumerable<PaymentTypes>> GetPaymentTypes();
        Task<IEnumerable<Regions>> GetRegions();
        Task<IEnumerable<RegistryOfficeDepartments>> GetRegistryOfficeDepartments();
        Task<IEnumerable<RejectionCauses>> GetRejectionCauses();
        Task<IEnumerable<SpecificApplicationData>> GetSpecificApplicationData();
        Task<IEnumerable<Supports>> GetSupports();
        Task<IEnumerable<SupportTypes>> GetSupportTypes();
        Task<IEnumerable<TypesOfActivitiesInWork>> GetTypesOfActivitiesInWork();
        Task<IEnumerable<UserStatuses>> GetUserStatuses();
        Task<IEnumerable<Villages>> GetVillages();

    }
}
