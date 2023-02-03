using Microsoft.EntityFrameworkCore;
using System;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class UserSessionsRepository : GenericRepository<UserSessions>, IUserSessionsRepository
    {
        public UserSessionsRepository(AppDbContext context) : base(context)
        {
        }

        public void SetLastRequestTime(int userSessionID, DateTime newTime)
        {
            var userSession = context.UserSessions.FindAsync(userSessionID).Result;
            userSession.LastRequestTime = newTime;
            context.Entry(userSession).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
