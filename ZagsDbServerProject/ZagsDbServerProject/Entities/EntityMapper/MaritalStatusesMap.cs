using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class MaritalStatusesMap : IEntityTypeConfiguration<MaritalStatuses>
    {
        public void Configure(EntityTypeBuilder<MaritalStatuses> builder)
        {
            builder.HasData(
                new MaritalStatuses()
                {
                    MaritalStatusID = 1,
                    MaritalStatusName = "Женатый",
                    StatusID = 1,
                    LabelID = 372
                },
                new MaritalStatuses()
                {
                    MaritalStatusID = 2,
                    MaritalStatusName = "Холостой",
                    StatusID = 1,
                    LabelID = 371
                },
                new MaritalStatuses()
                {
                    MaritalStatusID = 3,
                    MaritalStatusName = "Вдовец",
                    StatusID = 1,
                    LabelID = 375
                },
                new MaritalStatuses()
                {
                    MaritalStatusID = 4,
                    MaritalStatusName = "Разведённый",
                    StatusID = 1,
                    LabelID = 376
                },
                new MaritalStatuses()
                {
                    MaritalStatusID = 5,
                    MaritalStatusName = "Вдова",
                    StatusID = 1,
                    LabelID = 377
                }
            );
        }
    }
}
