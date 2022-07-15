using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Villages", Schema = "dbo")]
    public class Villages
    {
        [Key]
        public int VillageUniqueID { get; set; }
        [Required]
        public int VillageID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = "";


        [Required, ForeignKey("CityDistrictID")]
        public int CityDistrictID { get; set; }
        [Required, ForeignKey("RegionID")]
        public int RegionID { get; set; }
        [Required, ForeignKey("CountryID")]
        public int CountryID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
