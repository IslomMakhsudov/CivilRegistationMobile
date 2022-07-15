using System;

namespace ZagsDbServerProject.Responces
{
    public class MothersDataWindowWebResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationParticipantsDataID { get; set; }
        public string MothersSurname { get; set; }
        public string MothersName { get; set; }
        public string MothersPatronymic { get; set; }
        public DateTime MothersBirthday { get; set; }
        public int MothersCityzenshipID { get; set; }
        public string MothersCityzenship { get; set; }
        public int MothersNationalityID { get; set; }
        public string MothersNationality { get; set; }
        public string PassportNumber { get; set; }
        public string PassportGivingOrgan { get; set; }
        public int MothersCurrentCountryID { get; set; }
        public string MothersCurrentCountry { get; set; }
        public int MothersCurrentRegionID { get; set; }
        public string MothersCurrentRegion { get; set; }
        public int MothersCurrentCityDistrictID { get; set; }
        public string MothersCurrentCityDistrict { get; set; }
        public int? MothersCurrentVillageID { get; set; }
        public string MothersCurrentVillage { get; set; }
        public int MothersCurrentAddressID { get; set; }
        public string MothersCurrentAddress { get; set; }
        public DateTime MothersCurrentAddressLivingStartTime { get; set; }
        public string MothersPlaceOfWork { get; set; }
        public string MothersProfessionInWork { get; set; }
        public int MothersEducationLevelID { get; set; }
        public string MothersEducationLevel { get; set; }
    }
}
