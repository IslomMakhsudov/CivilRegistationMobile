using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("RejectionCauses", Schema = "dbo")]
    public class RejectionCauses
    {
        [Key]
        public int RejectionCauseID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool NeedToCreateNewDraftCopy { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
