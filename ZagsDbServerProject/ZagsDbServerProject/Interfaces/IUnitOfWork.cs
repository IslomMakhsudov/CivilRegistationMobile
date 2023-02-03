using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressesRepository Addresses { get; }
        IApplicationDocumentsRepository ApplicationDocuments { get; }
        IApplicationDocumentTypesRepository ApplicationDocumentTypes { get; }
        IApplicationMembersNeededDataRepository ApplicationMembersNeededData { get; }
        IApplicationMemberTypesRepository ApplicationMemberTypes { get; }
        IApplicationMistakesRepository ApplicationMistakes { get; }
        IApplicationsDetailsRepository ApplicationsDetails { get; }
        IApplicationsRepository Applications { get; }
        IApplicationsCorrectionCommentsRepository ApplicationsCorrectionComments { get; }
        IApplicationsParticipantsDataRepository ApplicationsParticipantsData { get; }
        IApplicationTypesRepository ApplicationTypes { get; }
        IBaseRepository BaseTypes { get; }
        ICustomersRepository Customers { get; }
        ICustomersLogsRepository CustomersLogs { get; }
        IDepartmentsRepository Departments { get; }
        IFAQRepository FAQ { get; }
        ILabelsRepository Labels { get; }
        ILogsRepository Logs { get; }
        IRolesRepository Roles { get; }
        IPaymentsAccountsRepository PaymentsAccounts { get; }
        ISpecificApplicationDataRepository SpecificApplicationData { get; }
        ITajikNamesRepository TajikNames { get; }
        IUsersRepository Users { get; }
        IUserSessionsRepository UserSessions { get; }
        IRolesOperationsRepository RolesOperations { get; }
        int Insert(object obj);
        Task<int> Complete();
        int Update(object obj);
    }
}