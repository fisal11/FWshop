using System.ComponentModel.DataAnnotations;

namespace FWshop.Models
{
    public class CityVM
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
}
