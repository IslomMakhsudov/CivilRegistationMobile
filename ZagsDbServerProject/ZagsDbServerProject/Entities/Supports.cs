using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("Supports", Schema = "dbo")]
    public class Supports
    {
        [Key]
        public int SupportID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string SupportText { get; set; }
        [Required, MaxLength(100)]
        public string URL { get; set; }



        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("SupportTypeID")]
        public int SupportTypeID { get; set; }
    }
}
