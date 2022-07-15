using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationTypes", Schema = "dbo")]
    public class ApplicationTypes
    {
        [Key]
        public int ApplicationTypeID { get; set; }
        [Required, MaxLength(50)]
        public string AppTypeName { get; set; }

        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}