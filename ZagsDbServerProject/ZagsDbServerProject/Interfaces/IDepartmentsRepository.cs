using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IDepartmentsRepository : IGenericRepository<RegistryOfficeDepartments>
    {
        Task<IEnumerable<RegistryOfficeDepartments>> GetDepartmentsWithLocations();
    }
}
