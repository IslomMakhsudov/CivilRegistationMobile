using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("PaymentTypesGroups", Schema = "dbo")]
    public class PaymentTypesGroups
    {
        [Key]
        public int PaymentTypesGroupID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
