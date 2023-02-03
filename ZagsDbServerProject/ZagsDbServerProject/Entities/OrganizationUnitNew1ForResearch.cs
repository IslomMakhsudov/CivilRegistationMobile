using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("OrganizationUnitNew1ForResearch", Schema = "dbo")]
    public class OrganizationUnitNew1ForResearch
    {
        [Key]
        public int OrganizationUnitId { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR(MAX)")]
        public string UID { get; set; }
        public int? ParentID { get; set; }
        [Required, Column(TypeName = "NVARCHAR(MAX)")]
        public string ShortName { get; set; }
        [Required]
        public int HierarchyLevel { get; set; }
        public int? UserID { get; set; }
        public int? MappedDepartmentID { get; set; }
        public int? MappedAddressID { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
