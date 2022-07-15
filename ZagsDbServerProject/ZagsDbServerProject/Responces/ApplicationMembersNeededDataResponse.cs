using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Responces
{
    public class ApplicationMembersNeededDataResponse
    {
        public int ApplicationMembersNeededDataID { get; set; }
        public int ApplicationMemberTypeID { get; set; }
        public int CustomersDataColumn { get; set; }
        public int Order { get; set; }
        public bool IsRequired { get; set; }
        public string SourceTable { get; set; }
        public string FieldType { get; set; }
        public string Label { get; set; }

        public ApplicationMembersNeededDataResponse(
            int ApplicationMembersNeededDataID,
            int ApplicationMemberTypeID,
            int CustomersDataColumn,
            int Order,
            bool IsRequired,
            string SourceTable,
            string FieldType,
            string Label
        )
        {
            this.ApplicationMembersNeededDataID = ApplicationMembersNeededDataID;
            this.ApplicationMemberTypeID = ApplicationMemberTypeID;
            this.CustomersDataColumn = CustomersDataColumn;
            this.Order = Order;
            this.IsRequired = IsRequired;
            this.SourceTable = SourceTable;
            this.FieldType = FieldType;
            this.Label = Label;
        }
    }
}
