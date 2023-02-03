using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationMistakesRepository : GenericRepository<ApplicationMistakes>, IApplicationMistakesRepository
    {
        public ApplicationMistakesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApplicationMistakes>> GetMistakesByApplicationID(int applicationID)
        {
            IEnumerable<ApplicationMistakes> ans = await Task.FromResult(
                context.ApplicationMistakes.Where(am => am.ApplicationID == applicationID).ToList()
            );
            return ans;
        }
    }
}
