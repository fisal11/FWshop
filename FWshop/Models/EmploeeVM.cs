using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Models
{
    public class EmploeeVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Emploee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter The Emploee Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter The Emploee Salary")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Please Enter The Emploee Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter The HirDate ")]
        public DateTime HirDate { get; set; }
        [Required(ErrorMessage = "check the IsActive")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please Enter The Notes")]
        public string Notes { get; set; }
        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }
        public string DepartmentName { get; set; }
        public string DistrictName { get; set; }

        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public IFormFile CvUrl { get; set; }


    }
}
