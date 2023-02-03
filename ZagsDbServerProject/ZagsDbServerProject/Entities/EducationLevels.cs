using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZagsDbServerProject.Entities
{
    [Table("EducationLevels", Schema = "dbo")]
    public class EducationLevels
    {
        [Key]
        public int EducationLevelID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, ForeignKey("LabelID")]
        public int LabelID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
