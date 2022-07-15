using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("UserStatuses", Schema = "dbo")]
    public class UserStatuses
    {
        [Key]
        public int UserStatusID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
