using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationStatusesMap : IEntityTypeConfiguration<ApplicationStatuses>
    {
        public void Configure(EntityTypeBuilder<ApplicationStatuses> builder)
        {
            builder.HasData(
                new ApplicationStatuses
                {
                    ApplicationStatusID = 1,
                    Name = "Создано",
                    StatusID = 1,
                    LabelID = 356
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 2,
                    Name = "Отправлено",
                    StatusID = 1,
                    LabelID = 357
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 3,
                    Name = "Одобрено",
                    StatusID = 1,
                    LabelID = 358
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 4,
                    Name = "Готово",
                    StatusID = 1,
                    LabelID = 359
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 5,
                    Name = "Отклонено",
                    StatusID = 1,
                    LabelID = 360
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 6,
                    Name = "Тест"
                }
            );
        }
    }
}
