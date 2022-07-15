using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationStatusElements", Schema = "dbo")]
    public class ApplicationStatusElements
    {
        [Key]
        public int ApplicationStatusElementID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Icon { get; set; }
        [Required, MaxLength(50)]
        public string MyAppIconStyle { get; set; }
        [Required]
        public int DateTimeColumnNumber { get; set; }


        [Required, ForeignKey("TextLabelID")]
        public int TextLabelID { get; set; }
        [Required, ForeignKey("MiniTextLabelID")]
        public int MiniTextLabelID { get; set; }
        [Required, ForeignKey("MiniTextColorID")]
        public int MiniTextColorID { get; set; }
    }
}
