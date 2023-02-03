using System;

namespace ZagsDbServerProject.Responces
{
    public class MothersDataWindowResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int CityzenshipID { get; set; }
        public int NationalityID { get; set; }
        public string PassportNumber { get; set; }
        public string PassportGivingOrgan { get; set; }
        public int CurrentCountryID { get; set; }
        public int CurrentRegionID { get; set; }
        public int CurrentCityDistrictID { get; set; }
        public int? CurrentVillageID { get; set; }
        public int CurrentAddressID { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime CurrentAddressLivingStartTime { get; set; }
        public string PlaceOfWork { get; set; }
        public int TypeOfActivitiesInWorkID { get; set; }
        public int EducationLevelID { get; set; }
        public int DocumentID1 { get; set; }
        public string DocumentAddressLink1 { get; set; }
        public int DocumentID2 { get; set; }
        public string DocumentAddressLink2 { get; set; }
        public int DocumentID3 { get; set; }
        public string DocumentAddressLink3 { get; set; }

    }
}
