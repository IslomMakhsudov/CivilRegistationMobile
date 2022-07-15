using System;
using System.Collections.Generic;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Responces
{
    public class DeceasedDataWindowWebResponse
    {
        public int ApplicationParticipantsDataID { get; set; }
        public int ApplicationID { get; set; }
        public string DeceasedSurname { get; set; }
        public string DeceasedName { get; set; }
        public string DeceasedPatronymic { get; set; }
        public bool DeceasedSex { get; set; }
        public DateTime DeceasedBirthday { get; set; }
        /*
         * !!! Address in AppsParticipantsData is the last living address of deceased !!!
        */
        public int DeceasedAddressID { get; set; }
        public string DeceasedAddress { get; set; }
        public int? DeceasedVillageID { get; set; }
        public int DeceasedCityDistrictID { get; set; }
        public int DeceasedRegionID { get; set; }
        public int DeceasedCountryID { get; set; }
        public IEnumerable<SpecificDataFromDetailsTable> specificDeceasedData { get; set; }
    }
}
