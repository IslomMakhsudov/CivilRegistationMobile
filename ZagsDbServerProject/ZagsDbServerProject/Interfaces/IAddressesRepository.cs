using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Interfaces
{
    public interface IAddressesRepository : IGenericRepository<Addresses>
    {
        Task<string> GetJoinedAddress(int addressID);
        Task<FullAddress> GetFullAddressByID(int addressID);
    }
}
