using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class CustomersLogsRepository : GenericRepository<CustomersLogs>, ICustomersLogsRepository
    {
        public CustomersLogsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
