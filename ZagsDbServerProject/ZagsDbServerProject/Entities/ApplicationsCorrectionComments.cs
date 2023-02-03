using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsCorrectionComments", Schema = "dbo")]
    public class ApplicationsCorrectionComments
    {
        [Key]
        public int ApplicationsCorrectionCommentID { get; set; }
        [Required, MaxLength(4000)]
        public string Comment { get; set; }
        [Required]
        public DateTime CorrectionTime { get; set; }
        [Required]
        public bool IsLast { get; set; }


        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
    }
}
