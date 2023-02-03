using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        public RolesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CanRoleMakeOperation(string roleName, int operationTypeID)
        {
            var tmp = await Task.FromResult(
                from roles in context.Roles
                where roles.Name == roleName
                join rolesOperations in context.RolesOperations on roles.RoleID equals rolesOperations.RoleID
                where rolesOperations.OperationTypeID == operationTypeID
                select new
                {
                    roles.Name,
                    rolesOperations.OperationTypeID
                });
            bool ans = true;
            if (tmp == null)
            {
                ans = false;
            }
            else
            {
                ans = tmp.Any();
                
            }
            return ans;
        }

        public async Task<int[]> GetOperationsRole(string roleName)
        {
            List<int> avaibleOperations = new();


            var res = await Task.FromResult(
                from roles in context.Roles
                where roles.Name == roleName
                join rolesOperations in context.RolesOperations on roles.RoleID equals rolesOperations.RoleID
                select new
                {
                    rolesOperations.OperationTypeID
                });

            foreach (var item in res)
            {
                avaibleOperations.Add(item.OperationTypeID);
            }

            return avaibleOperations.ToArray();
        }

        public async Task<IEnumerable<OperationsTypes>> GetOperationsTypes(string roleName)
        {
            var result = await Task.FromResult(
                from roles in context.Roles
                where roles.Name == roleName
                join rolesOperations in context.RolesOperations on roles.RoleID equals rolesOperations.RoleID
                join operTypes in context.OperationsTypes on rolesOperations.OperationTypeID equals operTypes.OperationTypeID
                select operTypes);

            return result;
        }

        public async Task<IEnumerable<OperationsTypes>> GetAllOperationsTypes()
        {
            return await Task.FromResult(context.OperationsTypes);
        }

    }
}
