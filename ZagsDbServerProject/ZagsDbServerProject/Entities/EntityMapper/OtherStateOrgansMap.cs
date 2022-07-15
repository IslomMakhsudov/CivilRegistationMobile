using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class OtherStateOrgansMap : IEntityTypeConfiguration<OtherStateOrgans>
    {
        public void Configure(EntityTypeBuilder<OtherStateOrgans> builder)
        {
            builder.HasData(
                new OtherStateOrgans
                {
                    OrganID = 1,
                    OrganName = "ЗАГС"
                }    
            );
        }
    }
}
