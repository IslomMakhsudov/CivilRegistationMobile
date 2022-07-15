using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationStatuses", Schema = "dbo")]
    public class ApplicationStatuses
    {
        [Key]
        public int ApplicationStatusID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        

        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
