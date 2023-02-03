using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("AffectedDataTables", Schema = "dbo")]
    public class AffectedDataTables
    {
        [Key]
        public int AffectedDataTableID { get; set; }
        [Required, ForeignKey("LogID")]
        public int LogID { get; set; }
        [Required, ForeignKey("DataTableID")]
        public int DataTableID { get; set; }  
    }
}
