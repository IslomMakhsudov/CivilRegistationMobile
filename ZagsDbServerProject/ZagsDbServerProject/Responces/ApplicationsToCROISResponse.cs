namespace ZagsDbServerProject.Responces
{
    public class ApplicationsToCROISResponse
    {
        public int ApplicationID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationsToCROISStatus { get; set; } // 1 - new sending, 2 - already sent before
        
    }
}
