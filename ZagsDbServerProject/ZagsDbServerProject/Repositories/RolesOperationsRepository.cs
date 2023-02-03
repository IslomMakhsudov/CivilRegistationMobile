using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class RolesOperationsRepository :GenericRepository<RolesOperations>, IRolesOperationsRepository
    {
        public RolesOperationsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
