using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ZagsDbServerProject.Entities
{
    [Table("OperationsTypes", Schema = "dbo")]
    public class OperationsTypes
    {
        [Key]
        public int OperationTypeId { get; set; }
        [Required, MaxLength(50)]
        public string OperationTypeName { get; set; }
    }
}
