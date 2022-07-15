using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Responces
{
    public class ChildsDataWindowMobileResponse
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
        public IEnumerable<SpecificDataFromDetailsTable> SpecificChildsData { get; set; }
        //public string 
    }
}
