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
        public string ShortName { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string TIN { get; set; }
        [Required, MaxLength(50)]
        public string BIC { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
