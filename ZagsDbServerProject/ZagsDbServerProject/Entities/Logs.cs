using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("Logs", Schema = "dbo")]
    public class Logs
    {
        [Key]
        public int UserLogID { get; set; }
        [MaxLength(150)]
        public string CommentOfAction { get; set; }
        [Required]
        public DateTime EventTime { get; set; }


        [Required, ForeignKey("OperationTypeID")]
        public int OperationTypeID { get; set; }
        [ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        [ForeignKey("ApplicationStatusID")]
        public int ApplicationStatusID { get; set; }
        [ForeignKey("OldStatusID")]
        public int OldStatusID { get; set; }
        [ForeignKey("AffectedTableID")]
        public int AffectedTableID { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

    }
}
