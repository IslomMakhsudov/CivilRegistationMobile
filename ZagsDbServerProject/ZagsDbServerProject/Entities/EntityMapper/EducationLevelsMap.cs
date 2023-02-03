using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class EducationLevelsMap : IEntityTypeConfiguration<EducationLevels>
    {
        public void Configure(EntityTypeBuilder<EducationLevels> builder)
        {
            builder.HasData(
                new EducationLevels
                {
                    EducationLevelID = 1,
                    Name = "Олӣ",
                    LabelID = 1606,
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 2,
                    Name = "Олии нопурра",
                    LabelID = 1601,
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 3,
                    Name = "Миёнаи махсус",
                    LabelID = 1602,
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 4,
                    Name = "Миёнаи умумӣ",
                    LabelID = 1603,
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 5,
                    Name = "Миёнаи нопурра",
                    LabelID = 1604,
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 6,
                    Name = "Ибтидоӣ ва аз он паст",
                    LabelID = 1605,
                    StatusID = 1
                }/*,

                new EducationLevels
                {
                    EducationLevelID = 1,
                    Name = ""
                }*/
            );
        }
    }
}
