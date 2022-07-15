using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationSourcesMap : IEntityTypeConfiguration<ApplicationSources>
    {
        public void Configure(EntityTypeBuilder<ApplicationSources> builder)
        {
            builder.HasData(
                new ApplicationSources
                {
                    ApplicationSourceID = 1,
                    Name = "Амонат Мобайл",
                    StatusID = 1
                }    
            );
        }
    }
}
