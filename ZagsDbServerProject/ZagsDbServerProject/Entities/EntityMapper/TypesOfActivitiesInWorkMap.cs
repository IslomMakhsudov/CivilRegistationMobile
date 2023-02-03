using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class TypesOfActivitiesInWorkMap : IEntityTypeConfiguration<TypesOfActivitiesInWork>
    {
        public void Configure(EntityTypeBuilder<TypesOfActivitiesInWork> builder)
        {
            builder.HasData(
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 1,
                    Name = "бо меҳнати фикрӣ",
                    CROIS2ExternalID = 1,
                    LabelID = 1595,
                    StatusID = 1
                },
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 2,
                    Name = "бо меҳнати ҷисмонӣ ба ғайр аз хоҷагии қишлоқ",
                    CROIS2ExternalID = 2,
                    LabelID = 1596,
                    StatusID = 1
                },
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 3,
                    Name = "бо меҳнати ҷисмонӣ дар хоҷагии қишлоқ",
                    CROIS2ExternalID = 3,
                    LabelID = 1597,
                    StatusID = 1
                },
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 4,
                    Name = "шуғл надоранд",
                    CROIS2ExternalID = 4,
                    LabelID = 1598,
                    StatusID = 1
                },
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 5,
                    Name = "дар таъминот",
                    CROIS2ExternalID = 5,
                    LabelID = 1599,
                    StatusID = 1
                },
                new TypesOfActivitiesInWork
                {
                    TypeOfActivitiesInWorkID = 6,
                    Name = "номаълум",
                    CROIS2ExternalID = 9,
                    LabelID = 1600,
                    StatusID = 1
                }
            );
        }
    }
}
