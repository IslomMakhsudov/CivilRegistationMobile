namespace CivilRegistrationMobile.Models
{
    public class Father
    {
        public int CurrentCountry { get; set; }
        public int CurrentRegion { get; set; }
        public int CurrentCity { get; set; }
        public int? CurrentVillage { get; set; } = null;
        public int RegistryOffice { get; set; }
        public string CurrentAddress { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public int Citizenship { get; set; }
        public int Nationality { get; set; }
        public string PassportNumber { get; set; } = "";
        public DateOnly LiveFrom { get; set; }  
        public string WorkPlace { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string Education { get; set; } = "";
        public IFormFile? PersonDocumentPicture_1 { get; set; }
        public IFormFile? PersonDocumentPicture_2 { get; set; }
        public IFormFile? MarriageDocumentPicture_1 { get; set; }
        public IFormFile? MarriageDocumentPicture_2 { get; set; }
    }
}
