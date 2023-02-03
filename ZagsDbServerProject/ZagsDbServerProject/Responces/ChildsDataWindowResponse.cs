using System;
using System.Collections.Generic;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Responces
{
    public class ChildsDataWindowResponse
    {
        public int ApplicationID { get; set; } = 0;
        public int ApplicationParticipantsDataID { get; set; } = 0;
        public string ChildsSurname { get; set; } = "";
        public string ChildsName { get; set; } = "";
        public string ChildsPatronymic { get; set; } = "";
        public bool ChildsSex { get; set; } = true;
        public DateTime ChildsBirthday { get; set; }
        public int ChildsCountryID { get; set; } = 0;
        public int ChildsRegionID { get; set; } = 0;
        public int ChildsCityDistrictID { get; set; } = 0;
        public int? ChildsVillageID { get; set; } = 0;
        public int ChildsAddressID { get; set; } = 0;
        public string ChildsAddress { get; set; } = "";
        public int ChildsDocumentID1 { get; set; } = 0;
        public string ChildsDocumentsAddressLink1 { get; set; } = "";
        /*
        public int AmountOfBornBabies { get; set; }
        public int WhichChildInFamily { get; set; }
        public int ChildsWeightInGramms { get; set; }
        public int ChildsHeightInSms { get; set; }
        public int DurationOfPregnancyInWeeks { get; set; }*/
        public IEnumerable<SpecificDataFromDetailsTable> SpecificChildsData { get; set; }
    }
}
