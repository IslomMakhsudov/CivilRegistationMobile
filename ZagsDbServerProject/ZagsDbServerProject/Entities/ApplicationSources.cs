using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationSources", Schema = "dbo")]
    public class ApplicationSources
    {
        [Key]
        public int ApplicationSourceID { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
