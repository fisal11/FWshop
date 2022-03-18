using System.ComponentModel.DataAnnotations;

namespace FWshop.Areas.ContectUS.Models
{
    public class ConMail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter The Message")]
        public string Message { get; set; }
    }
}
