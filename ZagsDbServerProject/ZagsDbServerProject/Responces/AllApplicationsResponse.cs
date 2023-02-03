using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Responces
{
    public class AllApplicationsResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationTypeID { get; set; }
        public string ApplicationName { get; set; }
        public int ApplicationStatusID { get; set; }
        public string CreatedOrPaidDate { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string ApplicantFullName { get; set; }
        public string ApplicantFullAddress { get; set; }
        public string CellphoneNumber { get; set; }
        public string ApplicationStatus { get; set; }
        public string ChildOrDeceasedName { get; set; }
    }

    public class DataApplicationsResponse
    {
        public IEnumerable<AllApplicationsResponse>  Data { get; set; }
    }
}
