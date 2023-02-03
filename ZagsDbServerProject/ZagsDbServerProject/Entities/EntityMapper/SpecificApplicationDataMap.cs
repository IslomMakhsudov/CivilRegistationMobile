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
                    SpecificApplicationDataName = "Дата смерти",
                    FieldTypeID = 4,
                    StatusID = 1,
                    Order = 6,
                    IsRequired = true,
                    LabelID = 89
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 7,
                    SpecificApplicationDataName = "Место рождения: адрес (ID)",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 7,
                    IsRequired = true,
                    LabelID = 36
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 8,
                    SpecificApplicationDataName = "Место рождения: адрес (Name)",
                    FieldTypeID = 1,
                    StatusID = 1,
                    Order = 8,
                    IsRequired = true,
                    LabelID = 36
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 9,
                    SpecificApplicationDataName = "Место смерти: адрес (ID)",
                    FieldTypeID = 11,
                    StatusID = 1,
                    Order = 9,
                    IsRequired = true,
                    LabelID = 90
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 10,
                    SpecificApplicationDataName = "Место смерти: адрес (Name)",
                    FieldTypeID = 1,
                    StatusID = 1,
                    Order = 10,
                    IsRequired = true,
                    LabelID = 90
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 11,
                    SpecificApplicationDataName = "Документ подтв.-ий рождение ребёнка",
                    FieldTypeID = 1,
                    StatusID = 1,
                    Order = 11,
                    IsRequired = true,
                    LabelID = 43
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 12,
                    SpecificApplicationDataName = "Дата выдачи документа подтв.-ий рождение ребёнка",
                    FieldTypeID = 4,
                    StatusID = 1,
                    Order = 12,
                    IsRequired = true,
                    LabelID = 374
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 13,
                    SpecificApplicationDataName = "Который ребёнок в семье?",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 13,
                    IsRequired = false,
                    LabelID = 38
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 14,
                    SpecificApplicationDataName = "Возраст матери",
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 14,
                    IsRequired = true,
                    LabelID = 1375
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 15,
                    SpecificApplicationDataName = "Известен только год?",
                    FieldTypeID = 7,
                    StatusID = 1,
                    Order = 15,
                    IsRequired = true,
                    LabelID = 1376
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 16,
                    SpecificApplicationDataName = "По адресу кого регистрируется?", // 3 - отец, 4 - мать
                    FieldTypeID = 2,
                    StatusID = 1,
                    Order = 16,
                    IsRequired = false,
                    LabelID = 1384
                },
                new SpecificApplicationData
                {
                    SpecificApplicationDataID = 17,
                    SpecificApplicationDataName = "По какому адресу регистрируется?", // 1 - место последнего проживания, 2 - место смерти
                    FieldTypeID = 7,
                    StatusID = 1,
                    Order = 16,
                    IsRequired = false,
                    LabelID = 1385
                }
            );
        }
    }
}
