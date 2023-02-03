using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Interfaces
{
    public interface IPaymentsAccountsRepository : IGenericRepository<PaymentsAccounts>
    {
        Task<IEnumerable<PaymentsAccountsResponse>> GetPaymentsAccounts(int languageID);
    }
}
