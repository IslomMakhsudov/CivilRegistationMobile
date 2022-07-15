using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("Languages", Schema = "dbo")]
    public class Languages
    {
        [Key]
        public int LanguageID { get; set; }
        [Required, StringLength(2, MinimumLength = 2)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

    }
}
