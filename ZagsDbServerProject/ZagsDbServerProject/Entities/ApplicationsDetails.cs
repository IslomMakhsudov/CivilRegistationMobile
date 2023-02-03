using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsDetails", Schema = "dbo")]
    public class ApplicationsDetails
    {
        [Key]
        public int ApplicationDetailID { get; set; }
        [Required, MaxLength(50)]
        public string Detail { get; set; } = "";


        [Required, ForeignKey("MistakeStatus")] 
        public int MistakeStatus { get; set; }
        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationTypesSpecificDataID")]
        public int ApplicationTypesSpecificDataID { get; set; }
        [Required, ForeignKey("SpecificApplicationDataID")]
        public int SpecificApplicationDataID { get; set; }
        [Required, ForeignKey("ApplicationMemberTypeID")]
        public int ApplicationMemberTypeID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
