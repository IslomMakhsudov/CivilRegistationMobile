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
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 2,
                    Name = "Олии нопурра",
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 3,
                    Name = "Миёнаи махсус",
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 4,
                    Name = "Миёнаи умумӣ",
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 5,
                    Name = "Миёнаи нопурра",
                    StatusID = 1
                },
                new EducationLevels
                {
                    EducationLevelID = 6,
                    Name = "Ибтидоӣ ва аз он паст",
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
