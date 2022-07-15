using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("InterfaceColors", Schema = "dbo")]
    public class InterfaceColors
    {
        [Key]
        public int InterfaceColorID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, Column(TypeName = "CHAR"), StringLength(7, MinimumLength = 7)]
        public string Value { get; set; }
    }
}
