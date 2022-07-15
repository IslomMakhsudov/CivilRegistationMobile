namespace CivilRegistrationMobile.Models
{
    public class Deceased
    {
        public int CurrentCountry { get; set; }
        public int CurrentRegion { get; set; }
        public int CurrentCity { get; set; }
        public int? CurrentVillage { get; set; } = null;
        public int RegistryOffice { get; set; }
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string BirthPlace { get; set; } = "";
        public string DeathPlace { get; set; } = "";
        public string LastLivePlace { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfDeath { get; set; }
        public bool Sex { get; set; }
        public IFormFile? DeathDocumentPicture_1 { get; set; }
        public IFormFile? DeathDocumentPicture_2 { get; set; }
    }
}
