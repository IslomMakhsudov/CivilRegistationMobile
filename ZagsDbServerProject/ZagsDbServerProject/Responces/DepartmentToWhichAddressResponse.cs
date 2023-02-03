namespace ZagsDbServerProject.Responces
{
    public class DepartmentToWhichAddressResponse
    {
        public int ApplicationID { get; set; }
        public int? RegistratedByWhichMemberID { get; set; }
        public int? RegistratedByWhichAddress { get; set; }
    }
}
