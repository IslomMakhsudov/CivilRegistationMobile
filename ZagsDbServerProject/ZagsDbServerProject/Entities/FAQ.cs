using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("FAQ", Schema = "dbo")]
    public class FAQ
    {
        [Key]
        public int FaqID { get; set; }
        [Required, MaxLength(500)]
        public string FaqQuestion { get; set; }
        [Required, MaxLength(2000)]
        public string FaqAnswer { get; set; }
        


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
