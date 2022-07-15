using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class LabelsRepository : GenericRepository<Labels>, ILabelsRepository
    {
        public LabelsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Labels>> GetLabelsByCategory(string category)
        {
            return await Task.FromResult(
                context.Labels.Where(o => o.LabelsCategory == category)
                .AsEnumerable()
            );
        }

        public async Task<string> GetLabelsValue(int labelID, int languageID)
        {
            return await Task.FromResult(
                context.Labels
                .Where(ll => ll.LabelID == labelID)
                .Select(res => new
                {
                    ans = (languageID == 1) ? res.Label1 : (languageID == 2 ? res.Label2 : res.Label3)
                }
            ).FirstOrDefault().ans);
        }
    }
}
