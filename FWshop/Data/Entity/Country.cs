using FWshop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Data.Entity
{
    [Table("Country")]

    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<City> City { get; set; }

    }
}
