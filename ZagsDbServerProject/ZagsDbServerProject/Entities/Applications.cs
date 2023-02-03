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
        public DateTime? MainEventTime { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime? PaidTime { get; set; }
        public DateTime? AcceptedTime { get; set; } = null;
        public DateTime? CompletedTime { get; set; } = null;
        public DateTime? RejectedTime { get; set; } = null;
        public DateTime? CorrectedTime { get; set; } = null;
        [Required]
        public int ExternalID { get; set; }
        [MaxLength(36)]
        public string ChequeID { get; set; }
        
        
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationSourceID")]
        public int ApplicationSourceID { get; set; }
        [Required, ForeignKey("ApplicationStatusID")]
        public int ApplicationStatusID { get; set; }
        [Required, ForeignKey("ApplicationToCROISStatusID")]
        public int ApplicationToCROISStatusID { get; set; } = 1;

        [Required, MaxLength(1000)]
        public string ApplicationToCROISStatusMessage { get; set; } = "";
        [Required, ForeignKey("ApplicationParticipantsDataID")] // applicants ID
        public int ApplicationParticipantsDataID { get; set; }
        [Required, MaxLength(50)]
        public string ApplicationToCROISuuID { get; set; } = "";


        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; } = null;
        [ForeignKey("ApplicationPaymentID")]
        public int? ApplicationPaymentID { get; set; } = null;
        [ForeignKey("PaymentSystemID")]
        public int? PaymentSystemID { get; set; } = null;
        [ForeignKey("RejectionCauseID")]
        public int RejectionCauseID { get; set; }
    }
}
