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
    public class ApplicationTypesSpecificDataMap : IEntityTypeConfiguration<ApplicationTypesSpecificData>
    {
        public void Configure(EntityTypeBuilder<ApplicationTypesSpecificData> builder)
        {
            builder.HasData(
                // данные для рег-ии рождения
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 1,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 1,
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 2,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 2,
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 3,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 3,
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 4,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 4,
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 5,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 5,
                },
                // данные для рег-ии смерти
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 6,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 6,  
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 7,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 7,
                    SourceTable = "Addresses"
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 8,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 8,
                    SourceTable = "Addresses"
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 9,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 9,
                    SourceTable = "Addresses"
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 10,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 10,
                    SourceTable = "Addresses"
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 11,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 11
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 12,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 12  
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 13,
                    ApplicationTypeID = 2,
                     SpecificApplicationDataID = 13
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 14,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 14
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 15,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 15
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 16,
                    ApplicationTypeID = 1,
                    SpecificApplicationDataID = 16
                },
                new ApplicationTypesSpecificData
                {
                    ApplicationTypesSpecificDataID = 17,
                    ApplicationTypeID = 2,
                    SpecificApplicationDataID = 17
                }
            );
        }
    }
}
