using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("Nationalities", Schema = "dbo")]
    public class Nationalities
    {
        [Key]
        public int NationalityID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int ExternalID { get; set; }


        [Required, ForeignKey("StatusID")]
        public int StatusID { get; set; }
    }
}
