using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ProjectSettingsMap : IEntityTypeConfiguration<ProjectSettings>
    {
        public void Configure(EntityTypeBuilder<ProjectSettings> builder)
        {
            builder.HasData(
                new ProjectSettings
                {
                    ProjectSettingID  = 1,
                    Name = "расчётный показатель",
                    Value = "64"
                }
            );
        }
    }
}
