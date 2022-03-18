using FWshop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Data.Entity
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public virtual ICollection<District> district { get; set; }


    }
}
