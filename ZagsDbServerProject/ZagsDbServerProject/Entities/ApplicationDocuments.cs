using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationDocuments", Schema = "dbo")]
    public class ApplicationDocuments
    {
        [Key]
        public int ApplicationDocumentID { get; set; }
        [Required, MaxLength(1024)] // because pictures links might be saved encoded
        public string AddressLink { get; set; }
        public DateTime? RecievedTime { get; set; }


        [Required, ForeignKey("DocumentTypeID")]
        public int DocumentTypeID { get; set; }
        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationsParticipantsDataID")]
        public int ApplicationsParticipantsDataID { get; set; }
    }
}
