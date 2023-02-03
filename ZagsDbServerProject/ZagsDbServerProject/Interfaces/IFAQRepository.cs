using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IFAQRepository : IGenericRepository<FAQ>
    {
        Task<IEnumerable<FAQ>> GetTopNFAQs(int N);
    }
}
