using System;   
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Applications", Schema = "dbo")]
    public class Applications
    {
        [Key]
        public int ApplicationID { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? PaidTime { get; set; }
        public DateTime? AcceptedTime { get; set; } = null;
        public DateTime? CompletedTime { get; set; } = null;
        public DateTime? RejectedTime { get; set; } = null;
        [Required]
        public int ExternalID { get; set; }
        [Required]
        public int ChequeID { get; set; }
        
        
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationSourceID")]
        public int ApplicationSourceID { get; set; }
        [Required, ForeignKey("ApplicationStatusID")]
        public int ApplicationStatusID { get; set; }


        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; } = null;
        [ForeignKey("ApplicationPaymentID")]
        public int? ApplicationPaymentID { get; set; } = null;
        [ForeignKey("PaymentSystemID")]
        public int? PaymentSystemID { get; set; } = null;
    }
}
