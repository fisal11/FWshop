using System.ComponentModel.DataAnnotations;

namespace FWshop.Models
{
    public class ResetPasswordVM
    {

        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

    }
}
