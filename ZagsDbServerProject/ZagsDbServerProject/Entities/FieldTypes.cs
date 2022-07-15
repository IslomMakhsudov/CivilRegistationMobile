using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("FieldTypes", Schema = "dbo")]
    public class FieldTypes
    {
        [Key]
        public int FieldTypeID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}