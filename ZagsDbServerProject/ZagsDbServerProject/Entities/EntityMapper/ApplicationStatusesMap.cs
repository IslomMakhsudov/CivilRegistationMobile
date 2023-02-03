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
                    MobileLabelID = 357,
                    WebLabelID = 373
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 2,
                    Name = "Отправлено",
                    StatusID = 1,
                    MobileLabelID = 358,
                    WebLabelID = 1395
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 3,
                    Name = "В обработке",
                    StatusID = 1,
                    MobileLabelID = 1397,
                    WebLabelID = 1397
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 4,
                    Name = "Готово",
                    StatusID = 1,
                    MobileLabelID = 359,
                    WebLabelID = 360
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 5,
                    Name = "Отклонено",
                    StatusID = 1,
                    MobileLabelID = 361,
                    WebLabelID = 361
                }, new ApplicationStatuses
                {
                    ApplicationStatusID = 6,
                    Name = "На корректировке",
                    StatusID = 1,
                    MobileLabelID = 1388,
                    WebLabelID = 1388
                }
            );
        }
    }
}
