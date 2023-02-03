namespace CivilRegistrationMobile.Models
{
    /// <summary>
    /// My Applicant
    /// </summary>
    public class Applicant : ApplicationLists
    {
        public bool Check { get; set; }
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string CurrentAddress { get; set; } = "";
        public string TIN { get; set; } = "";
        public string PassportNumber { get; set; } = "";
        public string IssuingAuth { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public int? RegisterTo { get; set; } = null;
        public int ApplicationType { get; set; }
        public IFormFile? DocumentPicture1 { get; set; }
        public IFormFile? DocumentPicture2 { get; set; }   
    }   
}
