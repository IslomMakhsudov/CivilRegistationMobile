using Microsoft.EntityFrameworkCore;
using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZagsDbServerProject.Repositories;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Responces;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Repositories
{
    public class LogsRepository : GenericRepository<Logs>, ILogsRepository
    {
        public LogsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LogsResponse>> GetLogs(DateTime? eventTimeFrom, DateTime? eventTimeTo, int? applicationID)
        {
            var ans = await Task.FromResult(
                from logs in context.Logs

                where (((applicationID == null) || logs.ApplicationID == applicationID)
                        && ((eventTimeFrom == null) ? ((eventTimeTo == null) || logs.EventTime <= eventTimeTo) 
                        : ((eventTimeTo == null) ? (logs.EventTime >= eventTimeFrom) : (logs.EventTime >= eventTimeFrom && logs.EventTime <= eventTimeTo))))
                join users in context.Users on logs.UserID equals users.UserID
                join operationsTypes in context.OperationsTypes on logs.OperationTypeID equals operationsTypes.OperationTypeID
                select new LogsResponse
                {
                    LogID = logs.LogID,
                    UserID = users.UserID,
                    UserName = users.Surname + " " + users.Name + " " + users.Patronymic,
                    OperationTypeID = operationsTypes.OperationTypeID,
                    OperationTypeName = operationsTypes.OperationTypeName,
                    Comment = logs.CommentOfAction,
                    ApplicationID = logs.ApplicationID,
                    EventTime = logs.EventTime
                }

            ) ;
            return ans;
        }
    }
}
