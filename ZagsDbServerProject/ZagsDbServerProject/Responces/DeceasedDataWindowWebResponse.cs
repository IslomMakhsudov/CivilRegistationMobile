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
        public int DeceasedDocumentID { get; set; }
        public string DeceasedDocumentAddressLink { get; set; }
        public IEnumerable<SpecificDataFromDetailsTable> SpecificDeceasedData { get; set; }
        // Birth address
        public int DeceasedBirthAddressID { get; set; }
        public string DeceasedBirthAddress { get; set; }
        public int? DeceasedBirthVillageID { get; set; }
        public int DeceasedBirthCityDistrictID { get; set; }
        public int DeceasedBirthRegionID { get; set; }
        public int DeceasedBirthCountryID { get; set; }
        // Death address
        public int DeceasedDeathAddressID { get; set; }
        public string DeceasedDeathAddress { get; set; }
        public int? DeceasedDeathVillageID { get; set; }
        public int DeceasedDeathCityDistrictID { get; set; }
        public int DeceasedDeathRegionID { get; set; }
        public int DeceasedDeathCountryID { get; set; }
        public string DeceasedPlaceOfWork { get; set; }
        public int DeceasedEducationLevelID { get; set; }
        public int DeceasedMaritalStatusID { get; set; }
        public int DeceasedCityzenshipID { get; set; }
        public int DeceasedNationalityID { get; set; }
    }
}
