
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Responces
{
    public class ApplicationMemberTypesResponse
    {
        public int ApplicationMemberTypeID { get; set; }
        public string ApplicationMemberTypeName { get; set; }
        public string ApplicationMemberTypeGroupName { get; set; }
        public int ApplicationTypeID { get; set; }
        public int Order { get; set; }
        public int Label { get; set; }

        public ApplicationMemberTypesResponse(
            int ApplicationMemberTypeID,
            string ApplicationMemberTypeName,
            string ApplicationMemberTypeGroupName,
            int Order,
            int ApplicationTypeID,
            int Label
        )
        {
            this.ApplicationMemberTypeID = ApplicationMemberTypeID;
            this.ApplicationMemberTypeName = ApplicationMemberTypeName;
            this.ApplicationMemberTypeGroupName = ApplicationMemberTypeGroupName;
            this.ApplicationTypeID = ApplicationTypeID;
            this.Order = Order;
            this.Label = Label;
        }
    }
}
