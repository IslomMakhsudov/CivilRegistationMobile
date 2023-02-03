using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("TypesOfActivitiesInWork", Schema = "dbo")]
    public class TypesOfActivitiesInWork
    {
        [Key]
        public int TypeOfActivitiesInWorkID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CROIS2ExternalID { get; set; }


        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
