using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Countries", Schema = "dbo")]
    public class Countries
    {
        [Key]
        public int CountryID { get; set; }
        [Required, MaxLength(50)]
        public string ShortName { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; }
        [Required, StringLength(2, MinimumLength = 2)]
        [Column(TypeName = "VARCHAR")]
        public string Code2 { get; set; }
        [Required, StringLength(3, MinimumLength = 3)]
        [Column(TypeName = "VARCHAR")]
        public string Code3 { get; set; }
        [Required]
        public int ExternalID { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
