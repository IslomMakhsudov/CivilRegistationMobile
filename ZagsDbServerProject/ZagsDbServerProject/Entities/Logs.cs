using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("Logs", Schema = "dbo")]
    public class Logs
    {
        [Key]
        public int LogID { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string CommentOfAction { get; set; }
        [Required]
        public DateTime EventTime { get; set; }


        [Required, ForeignKey("OperationTypeID")]
        public int OperationTypeID { get; set; }
        [ForeignKey("ApplicationID")]
        public int? ApplicationID { get; set; }
        [ForeignKey("OldStatusID")]
        public int? OldStatusID { get; set; }
        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        [ForeignKey("CustomerID")]
        public int? CustomerID { get; set; }

    }
}
