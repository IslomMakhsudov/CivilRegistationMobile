using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsToCROISStatuses", Schema = "dbo")]
    public class ApplicationsToCROISStatuses
    {
        [Key]
        public int ApplicationToCROISStatusID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required]
        public int StatusID { get; set; }
    }
}
