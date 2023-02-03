using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationsCorrectionCommentsRepository : GenericRepository<ApplicationsCorrectionComments>, IApplicationsCorrectionCommentsRepository
    {
        public ApplicationsCorrectionCommentsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApplicationsCorrectionComments>> GetApplicationsCorrectionComments(int applicationID)
        {
            var ans = await Task.FromResult(
                from applicationsCorrectionComments in context.ApplicationsCorrectionComments
                where applicationsCorrectionComments.ApplicationID == applicationID
                select applicationsCorrectionComments
            );
            return ans;
        }

        public async Task<ApplicationsCorrectionComments> GetLastCommentOfApplication(int applicationID)
        {
            var ans = await Task.FromResult((
                from applications in context.Applications
                where applications.ApplicationID == applicationID && applications.ApplicationStatusID == 6
                join applicationsCorrectionComments in context.ApplicationsCorrectionComments on applications.ApplicationID equals applicationsCorrectionComments.ApplicationID
                where applicationsCorrectionComments.IsLast
                select applicationsCorrectionComments
            ).FirstOrDefault());
            return ans;
        }
    }
}
