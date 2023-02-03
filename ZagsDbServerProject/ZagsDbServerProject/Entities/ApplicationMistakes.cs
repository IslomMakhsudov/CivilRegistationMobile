using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationMistakes", Schema = "dbo")]
    public class ApplicationMistakes
    {
        [Key]
        public int ApplicationMistakeID { get; set; }
        [Required, MaxLength(255)]
        public string FieldName { get; set; }


        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [Required, ForeignKey("ApplicationMemberTypeID")]
        public int ApplicationMemberTypeID { get; set; }
    }
}
