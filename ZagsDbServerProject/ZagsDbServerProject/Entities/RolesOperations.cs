using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("RolesOperations", Schema = "dbo")]
    public class RolesOperations
    {
        [Key]
        public int RolesOperationID { get; set; }
        [Required]
        public DateTime AddedTime { get; set; }


        [Required, ForeignKey("RoleID")]
        public int RoleID { get; set; }
        [Required, ForeignKey("OperationTypeID")]
        public int OperationTypeID { get; set; }
        [Required, ForeignKey("AddedUserID")]
        public int AddedUserID { get; set; }
    }
}
