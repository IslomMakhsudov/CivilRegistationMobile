using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("CustomersLogs", Schema = "dbo")]
    public class CustomersLogs
    {
        [Key]
        public int CustomersLogID { get; set; }
        [Required]
        public int StatusCode { get; set; }
        [Required, MaxLength(500)]
        public string StatusMessage { get; set; }
        [Required]
        public DateTime EventTime { get; set; }
        [MaxLength(500)]
        public string InterfaceOfException { get; set; }


        [Required, ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        [ForeignKey("ApplicationID")]
        public int? ApplicationID { get; set; }
    }
}
