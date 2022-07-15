using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("SpecificApplicationData", Schema = "dbo")]
    public class SpecificApplicationData
    {
        [Key]
        public int SpecificApplicationDataID { get; set; }
        [Required, MaxLength(50)]
        public string SpecificApplicationDataName { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public bool IsRequired { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("FieldTypeID")]
        public int FieldTypeID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }

    }
}
