using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationTypeMembers", Schema = "dbo")]
    public class ApplicationTypeMembers
    {
        [Key]
        public int ApplicationTypeMemberID { get; set; }
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationMemberTypeID")]
        public int ApplicationMemberTypeID { get; set; }

    }
}
