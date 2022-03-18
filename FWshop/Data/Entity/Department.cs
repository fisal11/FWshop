using FWshop.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Models.DTO
{
    [Table("Department")]
    public class Department
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string DepartmentName { get; set; }


        [StringLength(20)]
        [Required]
        public string DepartmentCode { get; set; }

        public virtual  ICollection<Emploee> emploee { get; set; }

    }
}
