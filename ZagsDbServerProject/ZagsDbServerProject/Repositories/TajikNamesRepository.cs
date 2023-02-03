using System.Collections.Generic;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ZagsDbServerProject.Repositories
{
    public class TajikNamesRepository : GenericRepository<TajikNames>, ITajikNamesRepository
    {
        public TajikNamesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TajikNames>> GetTajikNames()
        {
            var ans = await Task.FromResult(
                from tajikNames in context.TajikNames
                where tajikNames.StatusID == 1
                select tajikNames
            );
            return ans;
        }

        public async Task<IEnumerable<TajikNames>> GetTajikNames(string pattern)
        {
            var ans = await Task.FromResult(
                from tajikNames in context.TajikNames
                where tajikNames.StatusID == 1 &&
                tajikNames.Name.StartsWith(pattern)
                //Substring(pattern.Length) == pattern
                select tajikNames
            );
            return ans.Take(5);
        }
    }
}
