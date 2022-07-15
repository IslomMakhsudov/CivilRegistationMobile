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
    public class ApplicationTypesMap : IEntityTypeConfiguration<ApplicationTypes>
    {
        public void Configure(EntityTypeBuilder<ApplicationTypes> builder)
        {
            builder.HasData(
                new ApplicationTypes()
                {
                    ApplicationTypeID = 1,
                    AppTypeName = "регистрация рождения",
                    LabelID = 364,
                    StatusID = 1
                },
                new ApplicationTypes()
                {
                    ApplicationTypeID = 2,
                    AppTypeName = "регистрация смерти",
                    LabelID = 7,
                    StatusID = 1
                }/*,
                new ApplicationTypes()
                {
                    ApplicationTypeID = 3,
                    AppTypeName = "регистрация заключения брака",
                    StatusID = 1
                },
                new ApplicationTypes()
                {
                    ApplicationTypeID = 4,
                    AppTypeName = "регистрация расторжения брака",
                    StatusID = 1
                },
                new ApplicationTypes()
                {
                    ApplicationTypeID = 5,
                    AppTypeName = "регистрация усыновления(удочерения)",
                    StatusID = 1
                },
                new ApplicationTypes()
                {
                    ApplicationTypeID = 6,
                    AppTypeName = "регистрация установления отцовства",
                    StatusID = 1
                },
                new ApplicationTypes()
                {
                    ApplicationTypeID = 7,
                    AppTypeName = "регистрация перемены ФИО",
                    StatusID = 1
                }
                */);
        }
    }
}
