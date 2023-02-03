namespace CivilRegistrationMobile.Models
{
    public class Filter
    {
        public int ApplicationType { get; set; }
        public DateTime From { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime To { get; set; } = DateTime.Now;
    }
}
