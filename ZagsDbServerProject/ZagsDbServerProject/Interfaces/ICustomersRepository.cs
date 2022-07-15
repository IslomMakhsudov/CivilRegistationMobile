using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface ICustomersRepository : IGenericRepository<Customers>
    {
        Task<Customers> GetCustomerByExternalID(int externalID);
    }
}
