using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class DepartmentsRepository : GenericRepository<RegistryOfficeDepartments>, IDepartmentsRepository
    {
        public DepartmentsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegistryOfficeDepartments>> GetDepartmentsWithLocations()
        {
            var ans = await Task.FromResult(
                from departments in context.RegistryOfficeDepartments 
                where departments.StatusID == 1 && departments.LocationLink != null
                select departments
            );
            return ans;
        }
    }
}
