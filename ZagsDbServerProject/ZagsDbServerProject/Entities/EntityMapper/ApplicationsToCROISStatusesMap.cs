using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationsToCROISStatusesMap : IEntityTypeConfiguration<ApplicationsToCROISStatuses>
    {
        public void Configure(EntityTypeBuilder<ApplicationsToCROISStatuses> builder)
        {
            builder.HasData(
                new ApplicationsToCROISStatuses
                {
                    ApplicationToCROISStatusID = 1,
                    Name = "Not sent yet",
                    StatusID = 1
                },
                new ApplicationsToCROISStatuses
                {
                    ApplicationToCROISStatusID = 2,
                    Name = "Sent before",
                    StatusID = 1
                },
                new ApplicationsToCROISStatuses
                {
                    ApplicationToCROISStatusID = 3,
                    Name = "Other errors",
                    StatusID = 1
                }
            );
        }
    }
}
