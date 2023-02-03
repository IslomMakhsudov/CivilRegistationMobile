using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class RejectionsCausesMap : IEntityTypeConfiguration<RejectionCauses>
    {
        public void Configure(EntityTypeBuilder<RejectionCauses> builder)
        {
            builder.HasData(
                new RejectionCauses
                {
                    RejectionCauseID = 1,
                    Name = "Application sent twice",
                    NeedToCreateNewDraftCopy = false,
                    StatusID = 1,
                    LabelID = 1390
                },
                new RejectionCauses
                {
                    RejectionCauseID = 2,
                    Name = "Department is chosen incorrectly",
                    NeedToCreateNewDraftCopy = true,
                    StatusID = 1,
                    LabelID = 1391
                }
            );
        }
    }
}
