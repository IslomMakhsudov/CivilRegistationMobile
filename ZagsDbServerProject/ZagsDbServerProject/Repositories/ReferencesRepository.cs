using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
    public class ReferencesRepository : GenericRepository<Object>, IReferencesRepository
    {
        public ReferencesRepository(AppDbContext context) : base(context)
        {
        }

        // public async Task<>

        // separate methods of tables

        public async Task<IEnumerable<Addresses>> GetAddresses()
        {
            var ans = await Task.FromResult(
                from addresses in context.Addresses
                where addresses.StatusID == 1 && addresses.AddressID <= 448
                select addresses
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationMemberTypes>> GetApplicationMemberTypes()
        {
            var ans = await Task.FromResult(
                from applicationMemberTypes in context.ApplicationMemberTypes
                where applicationMemberTypes.StatusID == 1
                select applicationMemberTypes
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationSources>> GetApplicationSources()
        {
            var ans = await Task.FromResult(
                from applicationSources in context.ApplicationSources
                where applicationSources.ApplicationSourceID == 1
                select applicationSources
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationTypeMembersResponse>> GetApplicationTypeMembers(int languageID)
        {
            var ans = await Task.FromResult(
                from applicationTypeMembers in context.ApplicationTypeMembers
                join appType in context.ApplicationTypes on applicationTypeMembers.ApplicationTypeID equals appType.ApplicationTypeID
                join appTypeLabel in context.Labels on appType.LabelID equals appTypeLabel.LabelID
                join appMemberType in context.ApplicationMemberTypes on applicationTypeMembers.ApplicationTypeMemberID equals appMemberType.ApplicationMemberTypeID
                join appMemberTypeLabel in context.Labels on appMemberType.LabelID equals appMemberTypeLabel.LabelID
                select new ApplicationTypeMembersResponse
                {
                    ApplicationTypeMemberID = applicationTypeMembers.ApplicationTypeMemberID,
                    ApplicationTypeID = appType.ApplicationTypeID,
                    ApplicationTypeName = (languageID == 1) ? appTypeLabel.Label1 : ((languageID == 2) ? appTypeLabel.Label2 : appTypeLabel.Label3),
                    ApplicationMemberTypeID = appMemberType.ApplicationMemberTypeID,
                    ApplicationMemberTypeName = (languageID == 1) ? appMemberTypeLabel.Label1 : ((languageID == 2) ? appMemberTypeLabel.Label2 : appMemberTypeLabel.Label3)
                }
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationTypePayments>> GetApplicationTypePayments()
        {
            var ans = await Task.FromResult(
                from applicationTypePayments in context.ApplicationTypePayments
                select applicationTypePayments
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationTypes>> GetApplicationTypes()
        {
            var ans = await Task.FromResult(
                from applicationTypes in context.ApplicationTypes
                select applicationTypes
            );
            return ans;
        }

        public async Task<IEnumerable<ApplicationTypesSpecificData>> GetApplicationTypesSpecificData()
        {
            var ans = await Task.FromResult(
                from applicationTypesSpecificData in context.ApplicationTypesSpecificData
                select applicationTypesSpecificData
            );
            return ans;
        }

        public async Task<IEnumerable<CitiesDistricts>> GetCitiesDistricts()
        {
            var ans = await Task.FromResult(
                from citiesDistricts in context.CitiesDistricts
                where citiesDistricts.StatusID == 1
                select citiesDistricts
            );
            return ans;
        }

        public async Task<IEnumerable<Cityzenship>> GetCityzenship()
        {
            var ans = await Task.FromResult(
                from cityzenship in context.Cityzenship
                where cityzenship.StatusID == 1
                select cityzenship
            );
            return ans;
        }

        public async Task<IEnumerable<Countries>> GetCountries()
        {
            var ans = await Task.FromResult(
                from countries in context.Countries
                where countries.StatusID == 1
                select countries
            );
            return ans;
        }

        public async Task<IEnumerable<EducationLevels>> GetEducationLevels()
        {
            var ans = await Task.FromResult(
                from educationLevels in context.EducationLevels
                where educationLevels.StatusID == 1
                select educationLevels
            );
            return ans;
        }

        public async Task<IEnumerable<FAQ>> GetFAQ()
        {
            var ans = await Task.FromResult(
                from faq in context.FAQ
                where faq.StatusID == 1
                select faq
            );
            return ans;
        }

        public async Task<IEnumerable<Languages>> GetLanguages()
        {
            var ans = await Task.FromResult(
                from languages in context.Languages
                where languages.StatusID == 1
                select languages
            );
            return ans;
        }

        public async Task<IEnumerable<MaritalStatuses>> GetMaritalStatuses()
        {
            var ans = await Task.FromResult(
                from maritalStatuses in context.MaritalStatuses
                where maritalStatuses.StatusID == 1
                select maritalStatuses
            );
            return ans;
        }

        public async Task<IEnumerable<Nationalities>> GetNationalities()
        {
            var ans = await Task.FromResult(
                from nationalities in context.Nationalities
                where nationalities.StatusID == 1
                select nationalities
            );
            return ans;
        }

        public async Task<IEnumerable<OperationsTypes>> GetOperationsTypes()
        {
            var ans = await Task.FromResult(
                from operationsTypes in context.OperationsTypes
                where operationsTypes.StatusID == 1
                select operationsTypes
            );
            return ans;
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

        public async Task<IEnumerable<OtherStateOrgans>> GetOtherStateOrgans()
        {
            var ans = await Task.FromResult(
                from otherStateOrgans in context.OtherStateOrgans
                where otherStateOrgans.StatusID == 1
                select otherStateOrgans
            );
            return ans;
        }

        public async Task<IEnumerable<PaymentSystems>> GetPaymentSystems()
        {
            var ans = await Task.FromResult(
                from paymentSystems in context.PaymentSystems
                where paymentSystems.StatusID == 1
                select paymentSystems
            );
            return ans;
        }

        public async Task<IEnumerable<PaymentTypes>> GetPaymentTypes()
        {
            var ans = await Task.FromResult(
                from paymentTypes in context.PaymentTypes
                where paymentTypes.StatusID == 1
                select paymentTypes
            );
            return ans;
        }

        public async Task<IEnumerable<Regions>> GetRegions()
        {
            var ans = await Task.FromResult(
                from regions in context.Regions
                where regions.StatusID == 1
                select regions
            );
            return ans;
        }

        public async Task<IEnumerable<RegistryOfficeDepartments>> GetRegistryOfficeDepartments()
        {
            var ans = await Task.FromResult(
                from registryOfficeDepartments in context.RegistryOfficeDepartments
                where registryOfficeDepartments.StatusID == 1
                select registryOfficeDepartments
            );
            return ans;
        }

        public async Task<IEnumerable<RejectionCauses>> GetRejectionCauses()
        {
            var ans = await Task.FromResult(
                from rejectionCauses in context.RejectionCauses
                where rejectionCauses.StatusID == 1
                select rejectionCauses
            );
            return ans;
        }

        public async Task<IEnumerable<SpecificApplicationData>> GetSpecificApplicationData()
        {
            var ans = await Task.FromResult(
                from specificApplicationData in context.SpecificApplicationData
                where specificApplicationData.StatusID == 1
                select specificApplicationData
            );
            return ans;
        }

        public async Task<IEnumerable<Supports>> GetSupports()
        {
            var ans = await Task.FromResult(
                from supports in context.Supports
                where supports.StatusID == 1
                select supports
            );
            return ans;
        }

        public async Task<IEnumerable<SupportTypes>> GetSupportTypes()
        {
            var ans = await Task.FromResult(
                from supportTypes in context.SupportTypes
                where supportTypes.StatusID == 1
                select supportTypes
            );
            return ans;
        }

        public async Task<IEnumerable<TypesOfActivitiesInWork>> GetTypesOfActivitiesInWork()
        {
            var ans = await Task.FromResult(
                from typesOfActivitiesInWork in context.TypesOfActivitiesInWorks
                where typesOfActivitiesInWork.StatusID == 1
                select typesOfActivitiesInWork
            );
            return ans;
        }

        public async Task<IEnumerable<UserStatuses>> GetUserStatuses()
        {
            var ans = await Task.FromResult(
                from userStatuses in context.UserStatuses
                where userStatuses.StatusID == 1
                select userStatuses
            );
            return ans;
        }

        public async Task<IEnumerable<Villages>> GetVillages()
        {
            var ans = await Task.FromResult(
                from villages in context.Villages
                where villages.StatusID == 1
                select villages
            );
            return ans;
        }

    }
}
