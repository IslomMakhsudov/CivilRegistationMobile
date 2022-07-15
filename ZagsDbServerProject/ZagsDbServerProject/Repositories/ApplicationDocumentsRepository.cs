using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationDocumentsRepository : GenericRepository<ApplicationDocuments>, IApplicationDocumentsRepository
	{
		public ApplicationDocumentsRepository(AppDbContext context) : base(context)
		{
		
		}
	}
}
