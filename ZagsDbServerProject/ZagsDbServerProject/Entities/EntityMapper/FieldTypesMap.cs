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
    public class FieldTypesMap : IEntityTypeConfiguration<FieldTypes>
    {
        public void Configure(EntityTypeBuilder<FieldTypes> builder)
        {
            builder.HasData(
                new FieldTypes
                {
                    FieldTypeID = 1,
                    Name = "Text"
                },
                new FieldTypes
                {
                    FieldTypeID = 2,
                    Name = "Integer"
                },
                new FieldTypes
                {
                    FieldTypeID = 3,
                    Name = "Decimal"
                },
                new FieldTypes
                {
                    FieldTypeID = 4,
                    Name = "Date"
                },
                new FieldTypes
                {
                    FieldTypeID = 5,
                    Name = "Time"
                },
                new FieldTypes
                {
                    FieldTypeID = 6,
                    Name = "TypeAndPick"
                },
                new FieldTypes
                {
                    FieldTypeID = 7,
                    Name = "RadioButton"
                },
                new FieldTypes
                {
                    FieldTypeID = 8,
                    Name = "PickOneFromTable"
                },
                new FieldTypes
                {
                    FieldTypeID = 9,
                    Name = "ImageButton"
                },
                new FieldTypes
                {
                    FieldTypeID = 10,
                    Name = "DateAndTime"
                },
                new FieldTypes
                {
                    FieldTypeID = 11,
                    Name = "ID"
                }


            );
        }
    }
}
