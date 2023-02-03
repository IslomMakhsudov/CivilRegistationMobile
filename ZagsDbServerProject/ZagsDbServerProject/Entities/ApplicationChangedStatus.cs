using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationChangedStatus", Schema = "dbo")]
    public class ApplicationChangedStatus
    {
        [Key]
        public int ApplicationChangedStatusID { get; set; }
        [Required]
        public int ExternalID { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        [Required]
        public bool IsNotified { get; set; }
        public DateTime? NotifiedTime { get; set; }


        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [Required, ForeignKey("OldApplicationStatusID")]
        public int OldApplicationStatusID { get; set; }
        [Required, ForeignKey("NewApplicationStatusID")]
        public int NewApplicationStatusID { get; set; }


    }
}
