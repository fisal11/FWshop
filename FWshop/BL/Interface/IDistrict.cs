using FWshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Interface
{
    public interface IDistrict
    {

        IEnumerable<DistrictVM> Get();
        DistrictVM GetById(int id);
    }
}
