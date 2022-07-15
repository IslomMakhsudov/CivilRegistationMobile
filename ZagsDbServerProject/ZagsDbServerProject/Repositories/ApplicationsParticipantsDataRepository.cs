using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZagsDbServerProject.Repositories
{
	public class ApplicationsParticipantsDataRepository : GenericRepository<ApplicationsParticipantsData>, IApplicationsParticipantsDataRepository
	{
		public ApplicationsParticipantsDataRepository(AppDbContext context) : base(context)
		{
		
		}
	}
}
