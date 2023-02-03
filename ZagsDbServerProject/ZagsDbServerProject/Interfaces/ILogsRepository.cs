using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZagsDbServerProject.Responces;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
    public interface ILogsRepository : IGenericRepository<Logs>
    {
        Task<IEnumerable<LogsResponse>> GetLogs(DateTime? eventTimeFrom, DateTime? eventTimeTo, int? applicationID);
    }
}
