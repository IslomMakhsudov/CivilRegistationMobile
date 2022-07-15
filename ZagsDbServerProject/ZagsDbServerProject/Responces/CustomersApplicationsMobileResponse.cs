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
        public DateTime LastStatusDateTime { get; set; }
        public int ApplicationStatusID { get; set; }
    }
}
