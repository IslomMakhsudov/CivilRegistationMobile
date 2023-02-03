namespace CivilRegistrationMobile.Models.DTO
{
    public class ApplicantDataDto
    {
        public bool ApplicantCreated { get; set; }
        public bool CorrectingStatus { get; set; }
        public int ApplicantFormCode { get; set; }
        public int ExternalId { get; set; }
        public HttpContext Context { get; set; }
        public Applications? Application { get; set; }
    }
}
