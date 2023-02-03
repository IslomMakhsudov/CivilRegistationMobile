using System;

namespace ZagsDbServerProject.Responces
{
    public class BirthApplicationPrintingForm
    {
        public DateTime ApplicationCreatedTime { get; set; }
        public string DepartmentsAddress { get; set; } = "";
        public string ApplicantsFullName { get; set; } = "";
        public string ApplicantsFullAddress { get; set; } = "";
        public string ApplicantsPassportNumber { get; set; } = "";
        public string ApplicantsPassportGivingOrgan { get; set; } = "";
        public string ChildsSurname { get; set; } = "";
        public string ChildsName { get; set; } = "";
        public string ChildsPatronymic { get; set; } = "";
        public string ChildsSex { get; set; } = "";
        public string ChildsBirthday { get; set; } = "";
        public string ChildsFullAddress { get; set; } = "";
        public string FathersFullName { get; set; } = "";
        public string FathersBirthday { get; set; } = "";
        public string FathersCityzenship { get; set; } = "";
        public string FathersNationality { get; set; } = "";
        public string MothersFullName { get; set; } = "";
        public string MothersBirthday { get; set; } = "";
        public string MothersCityzenship { get; set; } = "";
        public string MothersNationality { get; set; } = "";
    }
}
