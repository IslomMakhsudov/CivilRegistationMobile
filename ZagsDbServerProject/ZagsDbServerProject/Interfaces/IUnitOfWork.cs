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
        IApplicationsParticipantsDataRepository ApplicationsParticipantsData { get; }
        IApplicationTypesRepository ApplicationTypes { get; }
        IBaseRepository BaseTypes { get; }
        ICustomersRepository Customers { get; }
        ILabelsRepository Labels { get; }
        IRolesRepository Roles { get; }
        ISpecificApplicationDataRepository SpecificApplicationData { get; }
        IUsersRepository Users { get; }
        
        int Insert(object obj);
        int Complete();
        int Update(object obj);
    }
}