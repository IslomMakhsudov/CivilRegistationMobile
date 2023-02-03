using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationsParticipantsDataRepository : GenericRepository<ApplicationsParticipantsData>, IApplicationsParticipantsDataRepository
	{
		public ApplicationsParticipantsDataRepository(AppDbContext context) : base(context)
		{
		
		}

		public async Task<IEnumerable<ApplicationsParticipantsData>> GetByPredicateWithNoLock(Expression<Func<ApplicationsParticipantsData, bool>> predicate)
        {
			var ans = await ToListWithNoLockAsync(context.ApplicationsParticipantsData, expression: predicate);
			return ans;
        }

		/*
        public override async void UpdateData(ApplicationsParticipantsData data)
        {
			Customers customer = context.Customers.Find()
			
			await Task.FromResult(context.Entry(data).State = EntityState.Modified);
		}*/
    }
}
