using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("UsersWorkplaces", Schema = "dbo")]
    public class UsersWorkplaces
    {
        [Key]
        public int UsersWorkplaceID { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required]
        public bool IsWorking { get; set; }


        [Required, ForeignKey("UserID")]
        public int UserID { get; set; }
        [Required, ForeignKey("RoleID")]
        public int RoleID { get; set; }
        [Required, ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
    }
}
