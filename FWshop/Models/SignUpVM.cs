using System.ComponentModel.DataAnnotations;

namespace FWshop.Models
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Please Enter Your UserName")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Not Matching")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
