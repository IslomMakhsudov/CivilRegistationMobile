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
    public class SpecificApplicationDataMap : IEntityTypeConfiguration<SpecificApplicationData>
    {
        public void Configure(EntityTypeBuilder<SpecificApplicationData> builder)
        {
            builder.HasData(
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 1,
                    SpecificApplicationDataName = "Вес (г)",
                    FieldTypeID = 2,
                    StatusID = 1,
                    IsRequired = true,
                    Order = 3,
                    LabelID = 41
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 2,
                    SpecificApplicationDataName = "Рост (см)",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 4,
                    IsRequired = true,
                    LabelID = 40
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 3,
                    SpecificApplicationDataName = "Количество новорождённых",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 1,
                    IsRequired = true,
                    LabelID = 37
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 4,
                    SpecificApplicationDataName = "Который ребёнок в семье?",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 2,
                    IsRequired = true,
                    LabelID = 38
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 5,
                    SpecificApplicationDataName = "Период беременности (нед.)",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 5,
                    IsRequired = true,
                    LabelID = 42
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 6,
                    SpecificApplicationDataName = "Семейное положение",
                    FieldTypeID = 1,
                    StatusID = 1,
                    Order = 6,
                    IsRequired = true,
                    LabelID = 361
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 7,
                    SpecificApplicationDataName = "Дата смерти",
                    FieldTypeID = 4,
                    StatusID = 1,
                    Order = 7,
                    IsRequired = true,
                    LabelID = 89
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 8,
                    SpecificApplicationDataName = "Место рождения: адрес",
                    FieldTypeID = 1,
                    StatusID = 1,
                    Order = 8,
                    IsRequired = true,
                    LabelID = 36
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 9,
                    SpecificApplicationDataName = "Место рождения: посёлок",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 9,
                    IsRequired = false,
                    LabelID = 16
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 10,
                    SpecificApplicationDataName = "Место рождения: город",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 10,
                    IsRequired = true,
                    LabelID = 15
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 11,
                    SpecificApplicationDataName = "Место рождения: регион",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 11,
                    IsRequired = true,
                    LabelID = 14
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 12,
                    SpecificApplicationDataName = "Место рождения: страна",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 12,
                    IsRequired = true,
                    LabelID = 363
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 13,
                    SpecificApplicationDataName = "Место смерти: адрес",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 13,
                    IsRequired = true,
                    LabelID = 90
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 14,
                    SpecificApplicationDataName = "Место смерти: посёлок",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 14,
                    IsRequired = true,
                    LabelID = 16
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 15,
                    SpecificApplicationDataName = "Место смерти: город",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 15,
                    IsRequired = true,
                    LabelID = 15
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 16,
                    SpecificApplicationDataName = "Место смерти: регион",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 16,
                    IsRequired = true,
                    LabelID = 14
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 17,
                    SpecificApplicationDataName = "Место смерти: страна",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 17,
                    IsRequired = true,
                    LabelID = 363
                }
            );
        }
    }
}
