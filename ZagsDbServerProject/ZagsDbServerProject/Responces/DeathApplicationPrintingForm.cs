using System;

namespace ZagsDbServerProject.Responces
{
    public class DeathApplicationPrintingForm
    {
        public DateTime ApplicationCreatedTime { get; set; }
        public string DepartmentsAddress { get; set; }
        public string ApplicantsFullName { get; set; }
        public string ApplicantsFullAddress { get; set; }
        public string ApplicantsPassportNumber { get; set; }
        public string ApplicantsPassportGivingOrgan { get; set; }
        public string DeceasedSurname { get; set; }
        public string DeceasedName { get; set; }
        public string DeceasedPatronymic { get; set; }
        public string DeceasedSex { get; set; }
        public string DeceasedDeathDate { get; set; }
        public string DeceasedDeathFullAddress { get; set; }
        public string DeceasedPermanentFullAddress { get; set; }
    }
}
