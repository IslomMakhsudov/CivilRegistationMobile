using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationDocumentTypesRepository : GenericRepository<ApplicationDocumentTypes>, IApplicationDocumentTypesRepository
	{
		public ApplicationDocumentTypesRepository(AppDbContext context) : base(context)
		{
		
		}
	}
}
