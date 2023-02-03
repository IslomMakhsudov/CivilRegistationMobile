using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("ApplicationsParticipantsData", Schema = "dbo")]
    public class ApplicationsParticipantsData
    {
        [Key]
        public int ApplicationParticipantsDataID { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [NotMapped] // this annotation is used for calculated fields 
        public string FullName => $"{Surname} {Name} {((Patronymic != null) ? (Patronymic.Length > 0 ? Patronymic : "") : "")}";
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

        [Required, ForeignKey("CustomerID")] // № 14
        public int CustomerID { get; set; }
        [Required, ForeignKey("AddressID")]
        public int AddressID { get; set; }
        [Required, ForeignKey("LanguageID")]
        public int LanguageID { get; set; }
        [Required, ForeignKey("ApplicationID")]
        public int ApplicationID { get; set; }
        [Required, ForeignKey("ApplicationTypeID")]
        public int ApplicationTypeID { get; set; }
        [Required, ForeignKey("ApplicationMemberTypeID")]
        public int ApplicationMemberTypeID { get; set; }
        

        [ForeignKey("CurrentCitizenship")]
        public int? CurrentCitizenship { get; set; }
        [ForeignKey("MaritalStatusID")]
        public int MaritalStatusID { get; set; }
        [ForeignKey("CurrentNationality")]
        public int? CurrentNationality { get; set; }
        [ForeignKey("EducationLevelID")]
        public int? EducationLevelID { get; set; }
        [ForeignKey("TypeOfActivitiesInWorkID")]
        public int? TypeOfActivitiesInWorkID { get; set; }
    }
}
