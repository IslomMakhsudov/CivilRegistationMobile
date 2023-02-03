using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
	public interface IUsersRepository : IGenericRepository<Users>
	{
		Task<IEnumerable<Users>> GetUser(string login);
	}
}
