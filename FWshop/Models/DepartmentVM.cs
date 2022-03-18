using System.ComponentModel.DataAnnotations;


namespace FWshop.Models
{
    public class DepartmentVM
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter The Department Name")]
        public string DepartmentName { get; set; }


        [StringLength(20)]
        [Required(ErrorMessage = "Please Enter The Department Code")]
        public string DepartmentCode { get; set; }
    }
}
