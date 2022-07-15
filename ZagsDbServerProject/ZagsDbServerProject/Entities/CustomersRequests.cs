using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("CustomerRequests", Schema = "dbo")]
    public class CustomerRequests
    {
        [Key]
        public int CustomerRequestID { get; set; }
        [Required] 
        public DateTime RequestTime { get; set; }
        [Required, MaxLength(4000)]
        public string RequestJSONObject { get; set; }


        [Required, ForeignKey("Customer/ParticipantsData-ID")]
        public int CustomerID { get; set; }
    }
}
