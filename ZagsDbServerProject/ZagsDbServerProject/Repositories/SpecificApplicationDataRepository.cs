using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Repositories
{
	public class SpecificApplicationDataRepository : GenericRepository<SpecificApplicationData>, ISpecificApplicationDataRepository
	{
		public SpecificApplicationDataRepository(AppDbContext context) : base(context)
		{
		
		}

		public async Task<int> GetLabelID(int specificApplicationDataID)
        {
			int labelID = await Task.FromResult((
				from spAD in context.SpecificApplicationData 
				where spAD.SpecificApplicationDataID == specificApplicationDataID 
				select spAD.LabelID).FirstOrDefault()
			);
			return labelID;
        }
	}
}
