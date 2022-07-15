using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("PaymentsAccounts", Schema = "dbo")]
    public class PaymentsAccounts
    {
        [Key]
        public int PaymentsAccountID { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string DebitAccount { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string CreditAccount { get; set; }


        [Required, ForeignKey("PaymentSystemID")]
        public int PaymentSystemID { get; set; }
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("PaymentTypeID")]
        public int PaymentTypeID { get; set; }
    }
}
