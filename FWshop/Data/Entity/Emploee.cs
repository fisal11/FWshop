using FWshop.Models.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Data.Entity
{
    [Table("Emploee")]
    public class Emploee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
       
        [Required]
        public float Salary { get; set; }

        [Required]
        public string Address { get; set; }
        public DateTime HirDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }

        public string PhotoName { get; set; }
        public string CvName { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }



    }
}
