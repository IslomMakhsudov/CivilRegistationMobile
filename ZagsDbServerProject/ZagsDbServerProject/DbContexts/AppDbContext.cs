using Microsoft.EntityFrameworkCore;
using ZagsDbServerProject.Entities.EntityMapper;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<AffectedDataTables> AffectedDataTables { get; set; }
        public DbSet<ApplicationChangedStatus> ApplicationChangedStatus { get; set; }
        public DbSet<ApplicationDocuments> ApplicationDocuments { get; set; }
        public DbSet<ApplicationDocumentTypes> ApplicationDocumentTypes { get; set; }
        public DbSet<ApplicationMembersNeededData> ApplicationMembersNeededData { get; set; }
        public DbSet<ApplicationMemberTypes> ApplicationMemberTypes { get; set; }
        public DbSet<ApplicationMistakes> ApplicationMistakes { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<ApplicationsCorrectionComments> ApplicationsCorrectionComments { get; set; }
        public DbSet<ApplicationsDetails> ApplicationsDetails { get; set; }
        public DbSet<ApplicationSources> ApplicationSources { get; set; }
        public DbSet<ApplicationsParticipantsData> ApplicationsParticipantsData { get; set; }
        public DbSet<ApplicationsPayments> ApplicationsPayments { get; set; }
        public DbSet<ApplicationsPaymentsDetails> ApplicationsPaymentsDetails { get; set; }
        public DbSet<ApplicationStatusElements> ApplicationStatusElements { get; set; }
        public DbSet<ApplicationStatuses> ApplicationStatuses { get; set; }
        public DbSet<ApplicationsToCROISStatuses> ApplicationsToCROISStatuses { get; set; }
        public DbSet<ApplicationTypeMembers> ApplicationTypeMembers { get; set; }
        public DbSet<ApplicationTypePayments> ApplicationTypePayments { get; set; }
        public DbSet<ApplicationTypes> ApplicationTypes { get; set; }
        public DbSet<ApplicationTypesSpecificData> ApplicationTypesSpecificData { get; set; }
        public DbSet<CitiesDistricts> CitiesDistricts { get; set; }
        public DbSet<Cityzenship> Cityzenship { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersLogs> CustomersLogs { get; set; }
        public DbSet<CustomerRequests> CustomerRequests { get; set; }
        public DbSet<CustomersFeedbacks> CustomersFeedbacks { get; set; }
        public DbSet<DataTables> DataTables { get; set; }
        public DbSet<EducationLevels> EducationLevels { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<FieldTypes> FieldTypes { get; set; }
        public DbSet<InterfaceColors> InterfaceColors { get; set; }
        public DbSet<Labels> Labels { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<MaritalStatuses> MaritalStatuses { get; set; }
        public DbSet<Nationalities> Nationalities { get; set; }
        public DbSet<OperationsTypes> OperationsTypes { get; set; }
        public DbSet<OrganizationUnitNew1ForResearch> OrganizationUnitNew1ForResearch { get; set; }
        public DbSet<OtherStateOrgans> OtherStateOrgans { get; set; }
        public DbSet<PaymentsAccounts> PaymentsAccounts { get; set; }
        public DbSet<PaymentSystems> PaymentSystems { get; set; }
        public DbSet<PaymentTypes> PaymentTypes { get; set; }
        public DbSet<PaymentTypesGroups> PaymentTypesGroups { get; set; }
        public DbSet<ProjectSettings> ProjectSettings { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<RegistryOfficeDepartments> RegistryOfficeDepartments { get; set; }
        public DbSet<RejectionCauses> RejectionCauses { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesOperations> RolesOperations { get; set; }
        public DbSet<SpecificApplicationData> SpecificApplicationData { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<Supports> Supports { get; set; }
        public DbSet<SupportTypes> SupportTypes { get; set; }
        public DbSet<TajikNames> TajikNames { get; set; }
        public DbSet<TypesOfActivitiesInWork> TypesOfActivitiesInWorks { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }
        public DbSet<UserStatuses> UserStatuses { get; set; }
        public DbSet<UsersWorkplaces> UsersWorkplaces { get; set; }
        public DbSet<Villages> Villages { get; set; }
        //public DbSet<Addresses> Addresses { get; set; }
        

        public AppDbContext() : base() 
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.UseCollation("SQL_Latin1_General_CP1251_CI_AS");

            //modelBuilder.ApplyConfiguration(new CountriesMap());
            modelBuilder.ApplyConfiguration(new ApplicationDocumentTypesMap());
            modelBuilder.ApplyConfiguration(new ApplicationMembersNeededDataMap());

            modelBuilder.ApplyConfiguration(new ApplicationMemberTypesMap());
            modelBuilder.ApplyConfiguration(new ApplicationStatusesMap());
            modelBuilder.ApplyConfiguration(new ApplicationsToCROISStatusesMap());
            modelBuilder.ApplyConfiguration(new ApplicationTypeMembersMap());
            modelBuilder.ApplyConfiguration(new ApplicationTypesMap());
            modelBuilder.ApplyConfiguration(new ApplicationTypesSpecificDataMap());
            modelBuilder.ApplyConfiguration(new DataTablesMap());
            modelBuilder.ApplyConfiguration(new EducationLevelsMap());
            modelBuilder.ApplyConfiguration(new FieldTypesMap());
            modelBuilder.ApplyConfiguration(new LanguagesMap());
            modelBuilder.ApplyConfiguration(new MaritalStatusesMap());
            modelBuilder.Entity<Nationalities>().Property(t => t.NationalityID).ValueGeneratedNever();
            modelBuilder.ApplyConfiguration(new OperationsTypesMap());
            modelBuilder.ApplyConfiguration(new OtherStateOrgansMap());
            modelBuilder.ApplyConfiguration(new ProjectSettingsMap());
            modelBuilder.ApplyConfiguration(new PaymentTypesMap());
            modelBuilder.ApplyConfiguration(new PaymentTypesGroupsMap());
            modelBuilder.ApplyConfiguration(new RegionsMap());
            modelBuilder.ApplyConfiguration(new RejectionsCausesMap());
            modelBuilder.ApplyConfiguration(new SpecificApplicationDataMap());

            modelBuilder.ApplyConfiguration(new StatusesMap());
            modelBuilder.ApplyConfiguration(new SupportsMap());
            modelBuilder.ApplyConfiguration(new SupportTypesMap());
            modelBuilder.ApplyConfiguration(new TypesOfActivitiesInWorkMap());
            modelBuilder.ApplyConfiguration(new UserStatusesMap());
            // Havent added this migration 26/04/2022
        }
    }
}
