using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationTypePayments", Schema = "dbo")]
    public class ApplicationTypePayments
    {
        [Key]
        public int ApplicationTypePaymentID { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(30, 2)")]
        public decimal Percent { get; set; }
        [Required]
        public int Quantity { get; set; }


        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("PaymentTypeID")]
        public int PaymentTypeID { get; set; }
    }
}
