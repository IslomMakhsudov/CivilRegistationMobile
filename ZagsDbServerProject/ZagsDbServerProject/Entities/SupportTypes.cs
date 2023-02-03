using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("SupportTypes", Schema = "dbo")]
    public class SupportTypes
    {
        [Key]
        public int SupportTypeID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string IconAddressLink { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
