using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Interfaces
{
    public interface IApplicationMembersNeededDataRepository : IGenericRepository<ApplicationMembersNeededData>
    {
        public Task<IEnumerable<ApplicationMembersNeededDataResponse>> getApplicationMembersNeededDataNew(int applicationMemberTypeID, int languageID);
    }
}
