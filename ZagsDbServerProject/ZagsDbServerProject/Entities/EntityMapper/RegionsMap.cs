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
    public class RegionsMap : IEntityTypeConfiguration<Regions>
    {
        public void Configure(EntityTypeBuilder<Regions> builder)
        {
            builder.HasData(
                new Regions
                {
                    RegionID = 4,
                    Name = "Вилояти Суғд",
                    CountryID = 185,
                    StatusID = 1
                },
                new Regions
                {
                    RegionID = 3,
                    Name = "Вилояти Хатлон",
                    CountryID = 185,
                    StatusID = 1
                },
                new Regions
                {
                    RegionID = 2,
                    Name = "ВМК Бадахшон",
                    CountryID = 185,
                    StatusID = 1
                },
                new Regions
                {
                    RegionID = 5,
                    Name = "ш. Душанбе",
                    CountryID = 185,
                    StatusID = 1
                },
                new Regions
                {
                    RegionID = 6,
                    Name = "Ноҳияҳои тобеи ҷумҳурӣ",
                    CountryID = 185,
                    StatusID = 1
                }
            );
        }
    }
}
