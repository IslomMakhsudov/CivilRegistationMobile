using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IApplicationsCorrectionCommentsRepository : IGenericRepository<ApplicationsCorrectionComments>
    {
        Task<IEnumerable<ApplicationsCorrectionComments>> GetApplicationsCorrectionComments(int applicationID);
        Task<ApplicationsCorrectionComments> GetLastCommentOfApplication(int applicationID);
    }
}
