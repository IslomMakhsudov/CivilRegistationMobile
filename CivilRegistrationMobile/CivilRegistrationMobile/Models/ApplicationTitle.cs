using System.Reflection.Metadata.Ecma335;

namespace CivilRegistrationMobile.Models
{
    public class ApplicationTitle
    {
        public int ApplicationID { get; set; }
        public int ApplicationType { get; set; }
        public string Title { get; set; } = "";
        public int ApplicationStatus { get; set; }
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public int RegistryOfficeID { get; set; }
        public int? MemberTypeId { get; set; }
        public int? AddressTypeId { get; set; }
        public string SvgFill { get; set; } = "";
        public string Blob { get; set; } = "";
        public string PathD { get; set; } = "";
        public string BotTextColor { get; set; } = "";
        public string BotText { get; set; } = "";
        public string ActionName { get; set; } = "";
    }
}
