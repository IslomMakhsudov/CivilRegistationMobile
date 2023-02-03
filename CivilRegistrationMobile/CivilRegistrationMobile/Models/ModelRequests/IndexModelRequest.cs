using System.Reflection.Metadata.Ecma335;

namespace CivilRegistrationMobile.Models.ModelRequests
{
    public class IndexModelRequest
    {
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Tin { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public string Issued { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CountryId { get; set; } = string.Empty;
        public string RegionId { get; set; } = string.Empty;
        public string CityId { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public string Lang { get; set; } = string.Empty;
        public string PayId { get; set; } = string.Empty;
    }
}
