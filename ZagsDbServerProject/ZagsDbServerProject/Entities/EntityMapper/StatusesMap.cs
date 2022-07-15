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
    public class StatusesMap : IEntityTypeConfiguration<Statuses>
    {
        public void Configure(EntityTypeBuilder<Statuses> builder)
        {
            builder.HasData(
                new Statuses
                {
                    StatusID = 1,
                    Name = "Active"
                },
                new Statuses
                {
                    StatusID = 2,
                    Name = "Inactive"
                },
                new Statuses
                {
                    StatusID = 3,
                    Name = "Archived"
                }
            );
        }
    }
}
