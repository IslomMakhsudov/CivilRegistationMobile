namespace CivilRegistrationMobile.Models
{
    public class Child
    {
        public string LastName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public bool Sex { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public TimeOnly TimeOfBirth { get; set; }
        public string Birthplace { get; set; } = "";
        public int NewbornCount { get; set; }
        public int ChildCount { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public int PregnancyDuration { get; set; }
        public string NewbornDocument { get; set; } = "";
        public DateOnly DocumentReceiptDate { get; set; }
        public IFormFile? DocumentPicture_1 { get; set; }
        public IFormFile? DocumentPicture_2 { get; set; }
    }
}
