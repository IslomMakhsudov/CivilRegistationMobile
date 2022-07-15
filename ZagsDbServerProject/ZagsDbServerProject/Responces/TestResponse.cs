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
        public string ChildsCountry { get; set; }
        public int ChildsRegionID { get; set; }
        public string ChildsRegion { get; set; }
        public int ChildsCityDistrictID { get; set; }
        public string ChildsCityDistrict { get; set; }
        public int? ChildsVillageID { get; set; }
        public string ChildsVillage { get; set; }
        public int ChildsAddressID { get; set; }
        public string ChildsAddress { get; set; }
    }
}
