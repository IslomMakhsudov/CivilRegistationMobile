using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("OtherStateOrgans", Schema = "dbo")]
    public class OtherStateOrgans
    {
        [Key]
        public int OrganID { get; set; }
        [Required, MaxLength(50)]
        public string OrganName { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
