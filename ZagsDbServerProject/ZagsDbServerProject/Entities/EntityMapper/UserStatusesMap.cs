using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class UserStatusesMap : IEntityTypeConfiguration<UserStatuses>
    {
        public void Configure(EntityTypeBuilder<UserStatuses> builder)
        {
            builder.HasData(
                new UserStatuses
                {
                    UserStatusID = 1,
                    Name = "IsWorking",
                    StatusID = 1
                },
                new UserStatuses
                {
                    UserStatusID = 2,
                    Name = "NotWorkingTemporary",
                    StatusID = 1
                },
                new UserStatuses
                {
                    UserStatusID = 3,
                    Name = "NotWorkingPermanently",
                    StatusID = 1
                }
            );
        }
    }
}
