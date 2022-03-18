using System.ComponentModel.DataAnnotations;

namespace FWshop.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
