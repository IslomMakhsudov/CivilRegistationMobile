using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationTypesRepository : GenericRepository<ApplicationTypes>, IApplicationTypesRepository
	{
		public ApplicationTypesRepository(AppDbContext context) : base(context)
		{
		
		}
	}
}
