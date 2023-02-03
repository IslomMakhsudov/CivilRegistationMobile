using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Users>> GetUser(string login)
        {
            var ans = await Task.FromResult(
                from user in context.Users
                where user.Login == login && user.UserStatusID == 1
                select user
                );
                
            return ans;
        }
    }
}
