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
    public class ApplicationTypePaymentsMap : IEntityTypeConfiguration<ApplicationTypePayments>
    {
        public void Configure(EntityTypeBuilder<ApplicationTypePayments> builder)
        {
            builder.HasData(
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 1,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 1,
                    Percent = 5,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 2,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 2,
                    Percent = 5,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 3,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 3,
                    Percent = 5,
                    Quantity = 2
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 4,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 4,
                    Percent = 25,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 5,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 5,
                    Percent = 20,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 6,
                    ApplicationTypeID = 1,
                    PaymentTypeID = 6,
                    Percent = 100,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 7,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 1,
                    Percent = 5,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 8,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 2,
                    Percent = 5,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 9,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 3,
                    Percent = 5,
                    Quantity = 2
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 10,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 4,
                    Percent = 25,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 11,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 5,
                    Percent = 20,
                    Quantity = 1
                },
                new ApplicationTypePayments
                {
                    ApplicationTypePaymentID = 12,
                    ApplicationTypeID = 2,
                    PaymentTypeID = 6,
                    Percent = 100,
                    Quantity = 1
                }

            );
        }
    }
}
