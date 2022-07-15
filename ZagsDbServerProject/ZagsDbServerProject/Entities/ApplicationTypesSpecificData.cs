using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationTypesSpecificData", Schema = "dbo")]
    public class ApplicationTypesSpecificData
    {
        [Key]
        public int ApplicationTypesSpecificDataID { get; set; }
        [MaxLength(50)]
        public string SourceTable { get; set; }


        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("SpecificApplicationDataID")]
        public int SpecificApplicationDataID { get; set; }
    }
}
