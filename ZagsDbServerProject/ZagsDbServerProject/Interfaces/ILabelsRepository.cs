using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface ILabelsRepository : IGenericRepository<Labels>
    {
        Task<IEnumerable<Labels>> GetLabelsByCategory(string category);
        Task<string> GetLabelsValue(int labelID, int languageID);
    }
}
