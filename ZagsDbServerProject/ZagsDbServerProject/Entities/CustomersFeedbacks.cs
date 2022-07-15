using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("CustomersFeedbacks", Schema = "dbo")]
    public class CustomersFeedbacks
    {
        [Key]
        public int CustomersFeedbackID { get; set; }
        [Required]
        public int CustomersMark { get; set; }
        [MaxLength(200)]
        public string CustomerComment { get; set; }


        [Required, ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
    }
}
