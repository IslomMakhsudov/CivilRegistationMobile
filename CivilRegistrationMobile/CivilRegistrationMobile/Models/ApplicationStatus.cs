using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace CivilRegistrationMobile.Models
{
    public class ApplicationStatus
    {
        public string Title { get; set; } = "";
        public string LinkText { get; set; } = "";
        public int StatusID { get; set; }
        public int TypeID { get; set; }
        public int ApplicationID { get; set; }
        public int RegistryOfficeID { get; set; }
        public string UpTitle { get; set; } = "";
        public string UpDate { get; set; } = "";
        public string UpTime { get; set; } = "";
        public string UpStatusText { get; set; } = "";

        public string MidTitle { get; set; } = "";
        public string? MidDate { get; set; } = "";
        public string? MidTime { get; set; } = "";
        public string MidStatusText { get; set; } = "";

        public string? BotTitle { get; set; }
        public string? BotDate { get; set; } = "";
        public string? BotTime { get; set; } = "";
        public string? BotStatusText { get; set; }
        public string MainBtnText { get; set; } = "";
        public string CorrectBtnText { get; set; } = "";

    }
}
