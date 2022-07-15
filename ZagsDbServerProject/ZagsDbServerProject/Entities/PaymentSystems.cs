using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("PaymentSystems", Schema = "dbo")]
    public class PaymentSystems
    {
        [Key]
        public int PaymentSystemID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
