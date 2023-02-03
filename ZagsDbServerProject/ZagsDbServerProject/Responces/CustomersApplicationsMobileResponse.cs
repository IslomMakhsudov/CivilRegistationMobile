using System;

namespace ZagsDbServerProject.Responces
{
    public class CustomersApplicationsMobileResponse
    {
        public int CustomerID { get; set; }
        public int ExternalID { get; set; }
        public int ApplicationID { get; set; }
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }
        public DateTime CreatedOrPaidDateTime { get; set; }
        public int ApplicationStatusID { get; set; }
        public int RegistryOfficeDepartmentID { get; set; }
        public int? RegistratedByWhichMemberID { get; set; }
        public int? RegistratedByWhichAddress { get; set; }
    }
}
