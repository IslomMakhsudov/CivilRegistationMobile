using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IApplicationMistakesRepository : IGenericRepository<ApplicationMistakes>
    {
        Task<IEnumerable<ApplicationMistakes>> GetMistakesByApplicationID(int applicationID);
    }
}
