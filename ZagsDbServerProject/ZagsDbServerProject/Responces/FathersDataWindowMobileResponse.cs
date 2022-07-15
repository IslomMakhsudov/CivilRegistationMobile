using System;

namespace ZagsDbServerProject.Responces
{
    public class FathersDataWindowMobileResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string FathersSurname { get; set; }
        public string FathersName { get; set; }
        public string FathersPatronymic { get; set; }
        public DateTime FathersBirthday { get; set; }
        public int FathersCityzenshipID { get; set; }
        public int FathersNationalityID { get; set; }
        public string PassportNumber { get; set; }
        public string PassportGivingOrgan { get; set; }
        public int FathersCurrentCountryID { get; set; }
        public int FathersCurrentRegionID { get; set; }
        public int FathersCurrentCityDistrictID { get; set; }
        public int? FathersCurrentVillageID { get; set; }
        public int FathersCurrentAddressID { get; set; }
        public string FathersCurrentAddress { get; set; }
        public DateTime FathersCurrentAddressLivingStartTime { get; set; }
        public string FathersPlaceOfWork { get; set; }
        public int FathersEducationLevelID { get; set; }
    }
}
