using FWshop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWshop.Data.Entity
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public virtual ICollection<Emploee> Emploee { get; set; }

    }
}
