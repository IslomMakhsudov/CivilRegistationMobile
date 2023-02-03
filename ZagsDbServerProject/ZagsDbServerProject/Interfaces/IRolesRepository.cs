using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
	public interface IRolesRepository : IGenericRepository<Roles>
	{
        Task<bool> CanRoleMakeOperation(string roleName, int operationTypeID);
		Task<int[]> GetOperationsRole(string roleName);
        Task<IEnumerable<OperationsTypes>> GetOperationsTypes(string roleName);
        Task<IEnumerable<OperationsTypes>> GetAllOperationsTypes();
    }
}
