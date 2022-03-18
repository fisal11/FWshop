using System.ComponentModel.DataAnnotations;

namespace FWshop.Models
{
    public class SignInVM
    {
        [Required(ErrorMessage ="Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Rememberme { get; set; }

        

    }
}
