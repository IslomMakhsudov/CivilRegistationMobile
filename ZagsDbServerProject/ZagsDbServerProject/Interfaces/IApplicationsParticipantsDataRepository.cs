using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IApplicationsParticipantsDataRepository : IGenericRepository<ApplicationsParticipantsData>
    {
        Task<IEnumerable<ApplicationsParticipantsData>> GetByPredicateWithNoLock(Expression<Func<ApplicationsParticipantsData, bool>> predicate);
    }
}
