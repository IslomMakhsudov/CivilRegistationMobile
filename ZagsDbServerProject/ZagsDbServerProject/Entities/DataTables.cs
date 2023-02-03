using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("DataTables", Schema = "dbo")]
    public class DataTables
    {
        [Key]
        public int DataTableID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string TableName { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public bool IsRepresentedInWeb { get; set; }


        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
    }
}
