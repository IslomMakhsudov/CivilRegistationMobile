using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class PaymentTypesGroupsMap : IEntityTypeConfiguration<PaymentTypesGroups>
    {
        public void Configure(EntityTypeBuilder<PaymentTypesGroups> builder)
        {
            builder.HasData(
                new PaymentTypesGroups
                {
                    PaymentTypesGroupID = 1,
                    Name = "Хизматрасонии пулӣ",
                    StatusID = 1
                },
                new PaymentTypesGroups
                {
                    PaymentTypesGroupID = 2,
                    Name = "Пардохт барои ҳуҷҷат",
                    StatusID = 1
                },
                new PaymentTypesGroups
                {
                    PaymentTypesGroupID = 3,
                    Name = "Боҷи давлатӣ",
                    StatusID = 1
                }
            );
        }
    }
}
