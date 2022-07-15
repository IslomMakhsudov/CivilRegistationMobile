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
                    MaritalStatusName = "Холостой",
                    StatusID = 1,
                    LabelID = 369
                },
                new MaritalStatuses()
                {
                    MaritalStatusID = 2,
                    MaritalStatusName = "Женатый",
                    StatusID = 1,
                    LabelID = 370
                }
            );
        }
    }
}
