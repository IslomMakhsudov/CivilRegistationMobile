using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationsDetailsRepository : GenericRepository<ApplicationsDetails>, IApplicationsDetailsRepository
	{
		public ApplicationsDetailsRepository(AppDbContext context) : base(context)
		{
			
		}
	}
}
