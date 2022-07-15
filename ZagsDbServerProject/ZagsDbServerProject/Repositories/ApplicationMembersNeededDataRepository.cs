using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Responces;

namespace ZagsDbServerProject.Repositories
{
    public class ApplicationMembersNeededDataRepository : GenericRepository<ApplicationMembersNeededData>, IApplicationMembersNeededDataRepository
    {
        public ApplicationMembersNeededDataRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApplicationMembersNeededDataResponse>> getApplicationMembersNeededDataNew(int applicationMemberTypeID, int languageID)
        {
            var ans = new List<ApplicationMembersNeededDataResponse>();
            IEnumerable<ApplicationMembersNeededDataResponse> gotApplicationMemberType = (IEnumerable<ApplicationMembersNeededDataResponse>)await Task.FromResult(

                context.ApplicationMemberTypes
                    .Where(o => o.ApplicationMemberTypeID == applicationMemberTypeID)
                    .Join(
                        context.ApplicationMembersNeededData,
                        applTM => applTM.ApplicationMemberTypeID,
                        applMTND => applMTND.ApplicationMemberTypeID,
                        (applTM, applMTND) => new { applTM, applMTND }
                    )
                    .Join(
                        context.Labels,
                        applTMTND => applTMTND.applMTND.LabelID,
                        ll => ll.LabelID,
                        (applTMTND, ll) => new { applTMTND, ll }
                    )
                    .Join(
                        context.FieldTypes,
                        applTMTND => applTMTND.applTMTND.applMTND.FieldTypeID,
                        ft => ft.FieldTypeID,
                        (applTMTND, ft) => new { applTMTND, ft }
                    )
                    .Select(res => new
                    {
                        res.applTMTND.applTMTND.applMTND.ApplicationMembersNeededDataID,
                        res.applTMTND.applTMTND.applMTND.ApplicationMemberTypeID,
                        res.applTMTND.applTMTND.applMTND.ApplicationTypeID,
                        res.applTMTND.applTMTND.applMTND.CustomersDataColumn,    
                        res.applTMTND.applTMTND.applMTND.Order,    
                        res.applTMTND.applTMTND.applMTND.IsRequired,
                        res.applTMTND.applTMTND.applMTND.SourceTable,
                        res.applTMTND.applTMTND.applMTND.FieldTypeID,
                        res.ft.Name,
                        LabelText = (languageID == 1) ? res.applTMTND.ll.Label1 : (languageID == 2) ? res.applTMTND.ll.Label2 : res.applTMTND.ll.Label3
                    }).AsEnumerable()
                );
            return gotApplicationMemberType;
        }
    }
}
