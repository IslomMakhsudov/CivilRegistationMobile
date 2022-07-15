using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationMembersNeededData", Schema = "dbo")]
    public class ApplicationMembersNeededData
    {
        [Key]
        public int ApplicationMembersNeededDataID { get; set; }
        [Required]
        public int CustomersDataColumn { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public bool IsRequired { get; set; }
        [MaxLength(50)]
        public string SourceTable { get; set; }


        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationMemberTypeID")]
        public int ApplicationMemberTypeID { get; set; }
        [Required, ForeignKey("FieldTypeID")]
        public int FieldTypeID { get; set; }
        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
        
    }
}
