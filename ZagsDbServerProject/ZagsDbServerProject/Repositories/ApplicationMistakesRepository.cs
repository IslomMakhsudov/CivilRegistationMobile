using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationMistakesRepository : GenericRepository<ApplicationMistakes>, IApplicationMistakesRepository
    {
        public ApplicationMistakesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
