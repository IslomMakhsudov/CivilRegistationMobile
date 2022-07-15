namespace ZagsDbServerProject.Models
{
    public class FullAddress
    {
        public string AddressName { get; set; }
        public string Village { get; set; } = "";
        public string CityDistrict { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
