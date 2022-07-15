using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsPayments", Schema = "dbo")]
    public class ApplicationsPayments
    {
        [Key]
        public int ApplicationsPaymentID { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(30, 2)")]
        public decimal PaymentSum { get; set; }
        [Required]
        public DateTime PaymentTime { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string PaymentCode { get; set; }


        [Required, ForeignKey("PaymentSystemID")]
        public int PaymentSystemID { get; set; }
    }
}
