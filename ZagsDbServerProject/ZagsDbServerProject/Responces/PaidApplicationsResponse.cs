using System;

namespace ZagsDbServerProject.Responces
{
    public class PaidApplicationsResponse
    {
        public int ApplicationID { get; set; }
        public string TransactionID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string ApplicantsFullName { get; set; }
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }
        public int RegistryOfficeDepartmentID { get; set; }
        public string RegistryOfficeDepartmentName { get; set; }
        public string RegistryOfficeDepartmentAddress { get; set; }
        public int RegistryOfficeDepartmentCityDistrictID { get; set; }
        public string RegistryOfficeDepartmentCityDistrictName { get; set; }
        public DateTime CreatedOrPaidDateTime { get; set; }
        public int ApplicationsPaymentID { get; set; }
        public double PaymentSum { get; set; }
        public string PaidTime { get; set; }
        public int PaymentSystemID { get; set; }
        public string PaymentSystemName { get; set; }
        public int ApplicationStatusID { get; set; }
        public string ApplicationStatusName { get; set; }
    }
}
