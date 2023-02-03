namespace ZagsDbServerProject.Responces
{
    public class ApplicantsDataWindowWebResponse
    {
        public int ApplicationParticipantsDataID { get; set; } = 0;
        public int ApplicationID { get; set; } = 0;
        public string ApplicationsTypeOfExpiration { get; set; } = "";
        public int ApplicantsCountryID { get; set; } = 0;
        public int ApplicantsRegionID { get; set; } = 0;
        public int ApplicantsCityDistrictID { get; set; } = 0;
        public int? ApplicantsVillageID { get; set; } = 0;
        public string ApplicantsAddress { get; set; } = "";
        public int ApplicantsAddressID { get; set; } = 0;
        public string ApplicantsSurname { get; set; } = "";
        public string ApplicantsName { get; set; } = "";
        public string ApplicantsPatronymic { get; set; } = "";
        public string ApplicantsITNNumber { get; set; } = "";
        public string ApplicantsPassportNumber { get; set; } = "";
        public string ApplicantsPassportGivingOrgan { get; set; } = "";
        public string ApplicantsTelephoneNumber { get; set; } = "";
        public int ApplicationDocumentID1 { get; set; } = 0;
        public string ApplicantsDocumentsAddressLink1 { get; set; } = "";
        public int ApplicationDocumentID2 { get; set; } = 0;
        public string ApplicantsDocumentsAddressLink2 { get; set; } = "";
    }
}
