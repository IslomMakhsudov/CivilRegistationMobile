using Microsoft.EntityFrameworkCore;
using ZagsDbServerProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ZagsDbServerProject.Responces;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationMemberTypesRepository : GenericRepository<ApplicationMemberTypes>, IApplicationMemberTypesRepository
    {
        public ApplicationMemberTypesRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<ApplicationMemberTypesResponse>> GetApplicationMember(int applicationTypeID, int languageID)
        {
            var ans = new List<ApplicationMemberTypesResponse>();
            IEnumerable<ApplicationMemberTypesResponse> gotApplicationMemberType = (IEnumerable<ApplicationMemberTypesResponse>)await Task.FromResult(

                context.ApplicationTypeMembers
                    .Where(o => o.ApplicationTypeID == applicationTypeID)
                    .Join(
                        context.ApplicationMemberTypes,
                        applTM => applTM.ApplicationMemberTypeID,
                        applMT => applMT.ApplicationMemberTypeID,
                        (applTM, applMT) => new { applTM, applMT }
                    )
                    .Where(a => a.applMT.StatusID == 1)
                    .Join(
                        context.Labels,
                        applTMT => applTMT.applMT.LabelID,
                        ll => ll.LabelID,
                        (applTMT, ll) => new { applTMT, ll }
                    )
                    .Select(res => new
                    {
                        res.applTMT.applMT.ApplicationMemberTypeID,
                        res.applTMT.applMT.ApplicationMemberTypeName,
                        res.applTMT.applMT.ApplicationMemberTypeGroupName,
                        res.applTMT.applMT.LabelID,
                        res.applTMT.applMT.Order,
                        LabelText = (languageID == 1) ? res.ll.Label1 : (languageID == 2) ? res.ll.Label2 : res.ll.Label3
                    }).AsEnumerable()
                );
            return gotApplicationMemberType;
        }
        

    }
}
