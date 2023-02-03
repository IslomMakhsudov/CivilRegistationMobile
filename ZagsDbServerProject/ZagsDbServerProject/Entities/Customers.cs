using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Customers", Schema = "dbo")]
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [NotMapped] // this annotation is used for calculated fields 
        public string FullName => $"{Surname} {Name} {(Patronymic.Length > 0 ? Patronymic : '\0')}";
        public DateTime? Birthday { get; set; }
        public bool? Sex { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(15)]
        public string TelephoneNumber { get; set; }
        [StringLength(9, MinimumLength = 9)]
        public string PassportNumber { get; set; }
        [StringLength(9, MinimumLength = 9)]
        public string PassportItnNumber { get; set; }
        [MaxLength(50)]
        public string PassportGivingOrgan { get; set; }
        [MaxLength(100)]
        public string PlaceOfWork { get; set; }
        public DateTime? CurrentAddressLivingStartTime { get; set; }
        public int? ExternalID { get; set; }


        [Required, ForeignKey("LanguageID")]
        public int LanguageID { get; set; }
        [ForeignKey("CityzenshipID")]
        public int? CityzenshipID { get; set; }
        [ForeignKey("NationalityID")]
        public int? NationalityID { get; set; }
        [ForeignKey("AddressID")]
        public int? AddressID { get; set; }
        [ForeignKey("VillageID")]
        public int? VillageID { get; set; }
        [ForeignKey("CityDistrictID")]
        public int? CityDistrictID { get; set; }
        [ForeignKey("RegionID")]
        public int? RegionID { get; set; }
        [ForeignKey("CountryID")]
        public int? CountryID { get; set; }
        [ForeignKey("EducationLevelID")]
        public int? EducationLevelID { get; set; }
        [ForeignKey("TypeOfActivitiesInWorkID")]
        public int? TypeOfActivitiesInWorkID { get; set; }
    }
}
