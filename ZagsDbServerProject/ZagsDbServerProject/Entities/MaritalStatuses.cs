using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("MaritalStatuses", Schema = "dbo")]
    public class MaritalStatuses
    {
        [Key]
        public int MaritalStatusID { get; set; }
        [Required, MaxLength(50)]
        public string MaritalStatusName { get; set; }
        
        
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
