using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationMembersNeededDataMap : IEntityTypeConfiguration<ApplicationMembersNeededData>
    {
        public void Configure(EntityTypeBuilder<ApplicationMembersNeededData> builder)
        {
            builder.HasData(
                // данные для заявки о рождении
                // заявитель
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 1,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 2,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 3,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 4,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 7,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 5,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 8,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 6,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 9,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 7,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 10,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                // новорождённый
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 10,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 11,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 12,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 13,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2,
                    CustomersDataColumn = 5,
                    FieldTypeID = 10,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 14,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2,
                    CustomersDataColumn = 6,
                    FieldTypeID = 7,
                    IsRequired = true
                },
                // отец новорождённого
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 15,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 16,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 17,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 18,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 5,
                    FieldTypeID = 4,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 19,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 7,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 20,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 8,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 21,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 10,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 22,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 11,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 23,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 13,
                    FieldTypeID = 10,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 24,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 20,
                    FieldTypeID = 11,
                    SourceTable = "Citizenship",
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 25,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 21,
                    FieldTypeID = 11,
                    SourceTable = "Nationalities",
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 26,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3,
                    CustomersDataColumn = 22,
                    FieldTypeID = 11,
                    SourceTable = "EducationLevelID",
                    IsRequired = true
                },
                // мать новорождённого
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 27,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 28,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 29,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 30,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 5,
                    FieldTypeID = 4,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 31,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 7,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 32,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 8,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 33,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 10,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 34,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 11,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 35,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 12,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 36,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 13,
                    FieldTypeID = 10,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 37,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 20,
                    FieldTypeID = 11,
                    SourceTable = "Citizenship",
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 38,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 21,
                    FieldTypeID = 11,
                    SourceTable = "Nationalities",
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 39,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4,
                    CustomersDataColumn = 22,
                    FieldTypeID = 11,
                    SourceTable = "EducationLevelID",
                    IsRequired = true
                },
                // данные для заявки о смерти
                // заявитель
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 40,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 41,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 42,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 43,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 7,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 44,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 8,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 45,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 9,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 46,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1,
                    CustomersDataColumn = 10,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                // усопший
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 47,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 2,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 48,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 3,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 49,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 4,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 50,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 5,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 51,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 6,
                    FieldTypeID = 7,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 52,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 11,
                    FieldTypeID = 1,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 53,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 12,
                    FieldTypeID = 1,
                    IsRequired = false
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 54,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 20,
                    FieldTypeID = 11,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 55,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 21,
                    FieldTypeID = 11,
                    IsRequired = true
                },
                new ApplicationMembersNeededData()
                {
                    ApplicationMembersNeededDataID = 56,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5,
                    CustomersDataColumn = 22,
                    FieldTypeID = 11,
                    IsRequired = true
                }
            );
        }
    }
}
