using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface ITajikNamesRepository : IGenericRepository<TajikNames>
    {
        Task<IEnumerable<TajikNames>> GetTajikNames();
        Task<IEnumerable<TajikNames>> GetTajikNames(string pattern);
    }
}
