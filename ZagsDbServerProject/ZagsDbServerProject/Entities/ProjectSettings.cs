using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("ProjectSettings", Schema = "dbo")]
    public class ProjectSettings
    {
        [Key]
        public int ProjectSettingID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Value { get; set; }
    }
}
