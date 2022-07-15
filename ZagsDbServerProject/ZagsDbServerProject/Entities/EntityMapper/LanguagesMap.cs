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
    public class LanguagesMap : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            builder.HasData(
                new Languages
                {
                    LanguageID = 1,
                    Code = "tg",
                    Name = "тоҷикӣ"
                },
                new Languages
                {
                    LanguageID = 2,
                    Code = "ru",
                    Name = "русский"
                },
                new Languages
                {
                    LanguageID = 3,
                    Code = "en",
                    Name = "english"
                }
            );
        }
    }
}
