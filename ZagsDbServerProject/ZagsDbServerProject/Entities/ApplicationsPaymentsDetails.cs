using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsPaymentsDetails", Schema = "dbo")]
    public class ApplicationsPaymentsDetails
    {
        [Key]
        public int ApplicationsPaymentsDetailID { get; set; }
        [Required, MaxLength(50)]
        public string PaymentServiceTypeName { get; set; }
        [Required, Column(TypeName = "DECIMAL(30, 2)")]
        public decimal Sum { get; set; }


        [Required, ForeignKey("ApplicationsPaymentID")]
        public int ApplicationsPaymentID { get; set; }
    }
}
