using CivilRegistrationMobile.Models.ViewModels.ValidationAttributes;

namespace CivilRegistrationMobile.Models
{
    public class Child : ApplicationLists
    {
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public bool? Sex { get; set; } = null;

        [ChildBirthday]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public DateTime TimeOfBirth { get; set; }
        public string Birthplace { get; set; } = "";
        public int NewbornCount { get; set; }
        public int ChildCount { get; set; }
        public int? Weight { get; set; } = null;
        public double? Height { get; set; } = null;
        public int? PregnancyDuration { get; set; } = null;
        public IFormFile? DocumentPicture1 { get; set; }
    }
}
