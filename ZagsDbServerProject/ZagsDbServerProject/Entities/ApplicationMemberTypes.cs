using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationMemberTypes", Schema = "dbo")]
    public class ApplicationMemberTypes
    {
        [Key]
        public int ApplicationMemberTypeID { get; set; }
        [Required, MaxLength(50)]
        public string ApplicationMemberTypeName { get; set; }
        [Required, MaxLength(50)]
        public string ApplicationMemberTypeGroupName { get; set; }
        [Required]
        public int Order { get; set; }
        
        
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
