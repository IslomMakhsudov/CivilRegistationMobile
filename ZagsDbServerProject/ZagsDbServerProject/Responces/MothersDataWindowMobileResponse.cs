using System;

namespace ZagsDbServerProject.Responces
{
    public class MothersDataWindowMobileResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string MothersSurname { get; set; }
        public string MothersName { get; set; }
        public string MothersPatronymic { get; set; }
        public DateTime MothersBirthday { get; set; }
        public int MothersCityzenshipID { get; set; }
        public int MothersNationalityID { get; set; }
        public string PassportNumber { get; set; }
        public string PassportGivingOrgan { get; set; }
        public int MothersCurrentCountryID { get; set; }
        public int MothersCurrentRegionID { get; set; }
        public int MothersCurrentCityDistrictID { get; set; }
        public int MothersCurrentVillageID { get; set; }
        public int MothersCurrentAddressID { get; set; }
        public string MothersCurrentAddress { get; set; }
        public DateTime MothersCurrentAddressLivingStartTime { get; set; }
        public string MothersPlaceOfWork { get; set; }
        public string MothersProfessionInWork { get; set; }
        public int MothersEducationLevelID { get; set; }
    }
}
