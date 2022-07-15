using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationDocumentTypes", Schema = "dbo")]
    public class ApplicationDocumentTypes
    {
        [Key]
        public int ApplicationDocumentTypeID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        //[Required, MaxLength(5)] // just in case
        //public string Series { get; set; }
        //[Required]
        //public int AmountOfNumbers { get; set; }
    }
}
