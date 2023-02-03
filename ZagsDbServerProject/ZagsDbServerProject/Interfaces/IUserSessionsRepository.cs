using System;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Interfaces
{
    public interface IUserSessionsRepository : IGenericRepository<UserSessions>
    {
        void SetLastRequestTime(int userSessionID, DateTime newTime);
    }
}
