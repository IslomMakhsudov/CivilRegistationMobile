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
    public class ApplicationTypeMembersMap : IEntityTypeConfiguration<ApplicationTypeMembers>
    {
        public void Configure(EntityTypeBuilder<ApplicationTypeMembers> builder)
        {
            builder.HasData(
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 1,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 1
                },
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 2,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 2
                },
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 3,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 3
                },
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 4,
                    ApplicationTypeID = 1,
                    ApplicationMemberTypeID = 4
                },
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 5,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 1
                },
                new ApplicationTypeMembers()
                {
                    ApplicationTypeMemberID = 6,
                    ApplicationTypeID = 2,
                    ApplicationMemberTypeID = 5
                }

            );

        }
    }
}
