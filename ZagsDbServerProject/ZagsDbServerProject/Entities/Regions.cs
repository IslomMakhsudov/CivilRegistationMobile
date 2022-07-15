using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Regions", Schema = "dbo")]
    public class Regions
    {
        [Key]
        public int RegionID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
        [Required, ForeignKey("CountryID")]
        public int CountryID { get; set; }
    }
}
