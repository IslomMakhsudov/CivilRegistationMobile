using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class SupportsMap : IEntityTypeConfiguration<Supports>
    {
        public void Configure(EntityTypeBuilder<Supports> builder)
        {
            builder.HasData(
                new Supports
                {
                    SupportID = 1,
                    Name = "Mobile-Phone",
                    SupportText = "+992(99)1119922",
                    URL = "tel://+992921119922",
                    StatusID = 1,
                    SupportTypeID = 1
                },
                new Supports
                {
                    SupportID = 2,
                    Name = "Email",
                    SupportText = "zags@gmail.com",
                    URL = "mailto:zags@gmail.com",
                    StatusID = 1,
                    SupportTypeID = 2
                }
            );
        }
    }
}
