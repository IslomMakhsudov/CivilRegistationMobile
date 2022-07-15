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
    public class PaymentTypesMap : IEntityTypeConfiguration<PaymentTypes>
    {
        public void Configure(EntityTypeBuilder<PaymentTypes> builder)
        {
            builder.HasData(
                new PaymentTypes
                {
                    PaymentTypeID = 1,
                    Name = "За чистый бланк образца заявлений актов гражданского состояния",
                    StatusID = 1
                },
                new PaymentTypes
                {
                    PaymentTypeID = 2,
                    Name = "Для заполнения заявления регистрации актов гражданского состояния",
                    StatusID = 1
                },
                new PaymentTypes
                {
                    PaymentTypeID = 3,
                    Name = "Копирование документов",
                    StatusID = 1
                },
                new PaymentTypes
                {
                    PaymentTypeID = 4,
                    Name = "Поиск документов на основании архивов",
                    StatusID = 1
                },
                new PaymentTypes
                {
                    PaymentTypeID = 5,
                    Name = "Бланк свидетельства",
                    StatusID = 1
                },
                new PaymentTypes
                {
                    PaymentTypeID = 6,
                    Name = "Госпошлина",
                    StatusID = 1
                }
            );
        }
    }
}
