using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("CitiesDistricts", Schema = "dbo")]
    public class CitiesDistricts
    {
        [Key]
        public int CityDistrictUniqueID { get; set; }
        [Required]
        public int CityDistrictID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsMain { get; set; }


        [Required, ForeignKey("RegionID")]
        public int RegionID { get; set; }
        [Required, ForeignKey("CountryID")]
        public int CountryID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
