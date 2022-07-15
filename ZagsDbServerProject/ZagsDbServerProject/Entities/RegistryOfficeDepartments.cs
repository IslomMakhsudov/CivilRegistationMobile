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
