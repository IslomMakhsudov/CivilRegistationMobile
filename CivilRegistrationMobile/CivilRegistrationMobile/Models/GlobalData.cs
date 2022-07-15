namespace CivilRegistrationMobile.Models
{
    public static class GlobalData
    {
        public static int ApplicationID { get; set; } = 888;
        public static int CityID { get; set; }

        public static bool applicantCreated, childCreated, motherCreated, fatherCreated;

        public static int ColorCode { get; set; } = 0;  

        public static Applicant? _applicant { get; set; }

        public static Child? _child { get; set; }
        public static Mother? _mother { get; set; }
        public static Father? _father { get; set; }

        public static int ApplicationStatus { get; set; } = ((int)NewbornStatus.BeginRegistry);

        public enum NewbornStatus : int
        {
            BeginRegistry,
            ApplicantDone,
            ChildDone,
            FatherDone,
            MotherDone
        }
    }
}
