namespace ZagsDbServerProject.Responces
{
    public class ApplicationsPrintingForm
    {
        public int WhichApplicationTypesModel { get; set; } // 1 - birth applicaion, 2 - death applicaion
        public BirthApplicationPrintingForm BirthApplication { get; set; }
        public DeathApplicationPrintingForm DeathApplication { get; set; }
    }
}
