using ZagsDbServerProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class FAQRepository : GenericRepository<FAQ>, IFAQRepository
    {
        public FAQRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FAQ>> GetTopNFAQs(int N)
        {
            var ans = await Task.FromResult((
                from faqs in context.FAQ
                select new FAQ
                {
                    FaqID = faqs.FaqID,
                    FaqQuestion = faqs.FaqQuestion,
                    FaqAnswer = faqs.FaqAnswer,
                    StatusID = faqs.StatusID
                }
                
            ).Take(4));
            return ans;
        }
    }
}
