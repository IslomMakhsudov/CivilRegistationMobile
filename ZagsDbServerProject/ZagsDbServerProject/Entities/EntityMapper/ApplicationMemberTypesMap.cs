using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationMemberTypesMap : IEntityTypeConfiguration<ApplicationMemberTypes>
    {
        public void Configure(EntityTypeBuilder<ApplicationMemberTypes> builder)
        {
            builder.HasData(
                    new ApplicationMemberTypes()
                    {
                        ApplicationMemberTypeID = 1,
                        ApplicationMemberTypeName = "Заявитель",
                        ApplicationMemberTypeGroupName = "Заявитель",
                        Order = 1,
                        StatusID = 1
                        
                    },
                    new ApplicationMemberTypes()
                    {
                        ApplicationMemberTypeID = 2,
                        ApplicationMemberTypeName = "Новорождённый",
                        ApplicationMemberTypeGroupName = "Ребёнок",
                        Order = 2,
                        StatusID = 1
                    },
                    new ApplicationMemberTypes()
                    {
                        ApplicationMemberTypeID = 3,
                        ApplicationMemberTypeName = "Отец новорождённого",
                        ApplicationMemberTypeGroupName = "Родитель",
                        Order = 3,
                        StatusID = 1
                    },
                    new ApplicationMemberTypes()
                    {
                        ApplicationMemberTypeID = 4,
                        ApplicationMemberTypeName = "Мать новорождённого",
                        ApplicationMemberTypeGroupName = "Родитель",
                        Order = 4,
                        StatusID = 1
                    },
                    new ApplicationMemberTypes()
                    {
                        ApplicationMemberTypeID = 5,
                        ApplicationMemberTypeName = "Усопший",
                        ApplicationMemberTypeGroupName = "Усопший",
                        Order = 5,
                        StatusID = 1
                    }
                );
        }
    }
}
