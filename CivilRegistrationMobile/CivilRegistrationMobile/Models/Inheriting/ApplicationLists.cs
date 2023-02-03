namespace CivilRegistrationMobile.Models.Inheriting
{
    public class ApplicationLists
    {
        public IEnumerable<SelectListItem>? CountryList { get; set; } = null;
        public IEnumerable<SelectListItem>? RegionList { get; set; } = null;
        public IEnumerable<SelectListItem>? CityList { get; set; } = null;
        public IEnumerable<SelectListItem>? VillageList { get; set; } = null;
        public IEnumerable<SelectListItem>? RegistryOfficeList { get; set; } = null;

        public IEnumerable<SelectListItem>? JobTypeList { get; set; }
        public IEnumerable<SelectListItem>? EducationList { get; set; }
        public IEnumerable<SelectListItem>? CitizenshipList { get; set; }
        public IEnumerable<SelectListItem>? NationalityList { get; set; }
        public IEnumerable<SelectListItem>? MaritalStatusesList  { get; set; }


        public int CurrentCountry { get; set; }
        public int CurrentRegion { get; set; }
        public int CurrentCity { get; set; }
        public int? CurrentVillage { get; set; } = null;
        public int? RegistryOffice { get; set; }

        public int Citizenship { get; set; }
        public int Nationality { get; set; }
        public int JobType { get; set; }
        public int Education { get; set; }
        public int MaritalStatus { get; set; }

        public string DocumentLink_1 { get; set; } = "";
        public string DocumentLink_2 { get; set; } = "";
        public string DocumentLink_3 { get; set; } = "";
    }
}
