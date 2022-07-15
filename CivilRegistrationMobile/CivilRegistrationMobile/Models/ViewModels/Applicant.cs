namespace CivilRegistrationMobile.Models
{
    public class Applicant
    {
        public int CurrentCountry { get; set; } 
        public int CurrentRegion { get; set; }
        public int CurrentCity { get; set; }
        public int? CurrentVillage { get; set; } = null;
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string CurrentAddress { get; set; } = "";
        public string TIN { get; set; } = "";
        public string PassportNumber { get; set; } = "";
        public string IssuingAuth { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public IFormFile? DocumentPicture_1 { get; set; }
        public IFormFile? DocumentPicture_2 { get; set; }
    }   
}
