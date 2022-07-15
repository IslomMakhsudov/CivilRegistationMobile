using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Entities
{
    [Table("Users", Schema = "dbo")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [NotMapped] // this annotation is used for calculated fields 
        public string FullName => $"{Surname} {Name} {(Patronymic.Length > 0 ? Patronymic : '\0')}";
        [Required, MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(15)]
        public string CellphoneNumber { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string Password { get; set; }
        public DateTime LastEnter { get; set; }
        [Required]
        public int AmountOfEnters { get; set; }


        [Required, ForeignKey("LanguageID")]
        public int LanguageID { get; set; }
        [Required, ForeignKey("RoleID")]
        public int RoleID { get; set; }
        [Required, ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        [Required, ForeignKey("UserStatusID")]
        public int UserStatusID { get; set; }
    }
}
