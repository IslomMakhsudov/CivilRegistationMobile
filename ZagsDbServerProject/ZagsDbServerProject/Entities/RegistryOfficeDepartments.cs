using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("RegistryOfficeDepartments", Schema = "dbo")]
    public class RegistryOfficeDepartments
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required, MaxLength(255)]
        public string DepartmentName { get; set; }
        [MaxLength(100)]
        public string LocationLink { get; set; }
        [MaxLength(50)]
        public string Latitude { get; set; }
        [MaxLength(50)]
        public string Longitude { get; set; }
        [Required]
        public int WorkScheduleLabelID { get; set; } // Example: пн - сб, пн - пт
        [MaxLength(50)]
        public string WorkTime { get; set; }     // Example: 09:00 - 18:00 


        [Required, ForeignKey("AddressID")]
        public int AddressID { get; set; }
        [Required, ForeignKey("CityDistrictID")]
        public int CityDistrictID { get; set; }
        [Required, ForeignKey("RegionID")]
        public int RegionID { get; set; }
        [Required, ForeignKey("CountryID")]
        public int CountryID { get; set; }
        [Required, ForeignKey("OrganID")]
        public int OrganID { get; set; }
        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }

        [ForeignKey("VillageID")]
        public int? VillageID { get; set; }
    }
}
