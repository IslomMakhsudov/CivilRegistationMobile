using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("Labels", Schema = "dbo")]
    public class Labels
    {
        [Key]
        public int LabelID { get; set; }
        [Required, MaxLength(50)]
        public string LabelsCategory { get; set; }
        [Required, MaxLength(255)]
        public string Label1 { get; set; }
        [Required, MaxLength(255)]
        public string Label2 { get; set; }
        [Required, MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Label3 { get; set; }

    }
}
