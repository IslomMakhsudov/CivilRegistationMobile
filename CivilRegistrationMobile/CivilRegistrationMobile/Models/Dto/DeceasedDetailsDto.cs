namespace CivilRegistrationMobile.Models.DTO
{
    public class DeceasedDetailsDto
    {
        public object Detail { get; set; } = "";
        public int SpecificId { get; set; }
        public int ApplicationId { get; set; }
        public int? ApplicationSpecificId { get; set; }
        public bool CorrectingStatus { get; set; }
        public bool DeceasedCreated { get; set; }
    }
}
