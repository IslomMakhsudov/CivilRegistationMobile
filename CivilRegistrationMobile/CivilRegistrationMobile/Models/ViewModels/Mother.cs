namespace CivilRegistrationMobile.Models
{
    public class Mother : ApplicationLists
    {
        public string IssuingAuth { get; set; } = "";
        public string CurrentAddress { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);
        public string PassportNumber { get; set; } = "";
        public DateTime LiveFrom { get; set; } = DateTime.Now.AddYears(-5);
        public string WorkPlace { get; set; } = "";
        public int RegisterCode { get; set; }
        public IFormFile? PersonDocumentPicture1 { get; set; } 
        public IFormFile? PersonDocumentPicture2 { get; set; }
        public IFormFile? MarriageDocumentPicture1 { get; set; }
    }
}
