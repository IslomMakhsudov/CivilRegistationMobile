using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("Statuses", Schema = "dbo")]
    public class Statuses
    {
        [Key]
        public int StatusID { get; set; }
        [Required, MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

    }
}
