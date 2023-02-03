using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customers> GetCustomerByExternalID(int externalID)
        {
            return await Task.FromResult(
                context.Customers
                .Where(a => a.ExternalID == externalID)
                .FirstOrDefault()
            );
        }
    }
}
