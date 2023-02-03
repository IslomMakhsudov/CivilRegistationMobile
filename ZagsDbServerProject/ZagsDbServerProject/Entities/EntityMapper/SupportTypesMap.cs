using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class SupportTypesMap : IEntityTypeConfiguration<SupportTypes>
    {
        public void Configure(EntityTypeBuilder<SupportTypes> builder)
        {
            builder.HasData(
                new SupportTypes
                {
                    SupportTypeID = 1,
                    Name = "Mobile-Phone",
                    StatusID = 1
                },
                new SupportTypes
                {
                    SupportTypeID = 2,
                    Name = "Email",
                    StatusID = 1
                }
            );
        }
    }
}
