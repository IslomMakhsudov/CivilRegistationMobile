using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class ApplicationDocumentTypesMap : IEntityTypeConfiguration<ApplicationDocumentTypes>
    {
        public void Configure(EntityTypeBuilder<ApplicationDocumentTypes> builder)
        {
            builder.HasData(
                new ApplicationDocumentTypes
                {
                    ApplicationDocumentTypeID = 1,
                    Name = "Аризаи модар ва имзои ӯ",
                    StatusID = 1
                },
                new ApplicationDocumentTypes
                {
                    ApplicationDocumentTypeID = 2,
                    Name = "Шаҳодатномаи ақди никоҳ",
                    StatusID = 1
                },
                new ApplicationDocumentTypes
                {
                    ApplicationDocumentTypeID = 3,
                    Name = "Шаҳодатномаи муқаррар намудани падарӣ",
                    StatusID = 1
                },
                new ApplicationDocumentTypes
                {
                    ApplicationDocumentTypeID = 4,
                    Name = "Шаҳодатнома (намуд аз пеш)",
                    StatusID = 1
                },
                new ApplicationDocumentTypes
                {
                    ApplicationDocumentTypeID = 5,
                    Name = "Шаҳодатнома (намуд аз қафо)",
                    StatusID = 1
                }
            );
        }
    }
}
