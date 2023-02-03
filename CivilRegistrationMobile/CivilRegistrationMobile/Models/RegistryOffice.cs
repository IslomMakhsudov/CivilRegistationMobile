using System.Reflection.Metadata.Ecma335;

namespace CivilRegistrationMobile.Models
{
    public class RegistryOffice
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string WorkTime { get; set; } = "";
        public string LocationLink { get; set; } = "";
    }
}
