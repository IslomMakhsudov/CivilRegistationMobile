using CivilRegistrationMobile.Models.ViewModels.ValidationAttributes;

namespace CivilRegistrationMobile.Models
{
    public class Deceased : ApplicationLists
    {
        public IEnumerable<SelectListItem>? DeathCountryList { get; set; } = null;
        public IEnumerable<SelectListItem>? DeathRegionList { get; set; } = null;
        public IEnumerable<SelectListItem>? DeathCityList { get; set; } = null;
        public IEnumerable<SelectListItem>? DeathVillageList { get; set; } = null;

        public IEnumerable<SelectListItem>? BirthCountryList { get; set; } = null;
        public IEnumerable<SelectListItem>? BirthRegionList { get; set; } = null;
        public IEnumerable<SelectListItem>? BirthCityList { get; set; } = null;
        public IEnumerable<SelectListItem>? BirthVillageList { get; set; } = null;

        public int DeathCountry { get; set; }
        public int DeathRegion{ get; set; }
        public int DeathCity { get; set; }
        public int? DeathVillage { get; set; } = null;
        public string DeathAddress { get; set; } = "";

        public int BirthCountry { get; set; }
        public int BirthRegion { get; set; }
        public int BirthCity { get; set; }
        public int? BirthVillage { get; set; } = null;
        public string BirthAddress { get; set; } = "";

        public string CurrentAddress { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-30);
        [ChildBirthday]
        public DateTime DateOfDeath { get; set; } = DateTime.Now;
        public bool? Sex { get; set; } = null;
        public string WorkPlace { get; set; } = "";
        public int RegisterCode { get; set; }
        public IFormFile? DeathDocumentPicture1 { get; set; }
    }
}
