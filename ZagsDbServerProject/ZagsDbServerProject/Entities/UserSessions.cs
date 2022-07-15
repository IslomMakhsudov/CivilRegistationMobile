using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("UserSessions", Schema = "dbo")]
    public class UserSessions
    {
        [Key]
        public int UserSessionID { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? LastRequestTime { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(16)]
        public string IpAddress { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string EnterCity { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string EnterRegion { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string EnterCountry { get; set; }

        [Required, ForeignKey("UserID")]
        public int UserID { get; set; }

    }
}
