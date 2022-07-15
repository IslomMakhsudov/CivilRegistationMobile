using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Responces
{
    public class ApplicantsDataWindowMobileResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public int ApplicantsCountryID { get; set; }
        public int ApplicantsRegionID { get; set; }
        public int ApplicantsCityDistrictID { get; set; }
        public int? ApplicantsVillageID { get; set; }
        public string ApplicantsAddress { get; set; }
        public string ApplicantsSurname { get; set; }
        public string ApplicantsName { get; set; }
        public string ApplicantsPatronymic { get; set; }
        public string ApplicantsITNNumber { get; set; }
        public string ApplicantsPassportNumber { get; set; }
        public string ApplicantsPassportGivingOrgan { get; set; }
        public string ApplicantsTelephoneNumber { get; set; }
        public int ApplicationDocumentID1 { get; set; }
        public string ApplicantsDocumentsAddressLink1 { get; set; }
        public int ApplicationDocumentID2 { get; set; }
        public string ApplicantsDocumentsAddressLink2 { get; set; }
    }
}
