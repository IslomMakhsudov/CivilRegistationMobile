using System;

namespace ZagsDbServerProject.Responces
{
    public class TestResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string ChildsSurname { get; set; }
        public string ChildsName { get; set; }
        public string ChildsPatronymic { get; set; }
        public bool ChildsSex { get; set; }
        public DateTime ChildsBirthday { get; set; }
        public int ChildsCountryID { get; set; }
        public int ChildsRegionID { get; set; }
        public int ChildsCityDistrictID { get; set; }
        public int? ChildsVillageID { get; set; }
        public int ChildsAddressID { get; set; }
        public string ChildsAddress { get; set; }
        public int ChildsDocumentID1 { get; set; } = 0;
        public string ChildsDocumentsAddressLink1 { get; set; } = "";
    }
}
