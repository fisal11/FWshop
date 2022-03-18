using FWshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Interface
{
    public interface ICity
    {

        IEnumerable<CityVM> Get();
        CityVM GetById(int id);
    }
}
