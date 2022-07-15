using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZagsDbServerProject.Responces;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
	public interface IApplicationMemberTypesRepository : IGenericRepository<ApplicationMemberTypes>
	{
		public Task<IEnumerable<ApplicationMemberTypesResponse>> GetApplicationMember(int applicationTypeID, int languageID);
	}
}
