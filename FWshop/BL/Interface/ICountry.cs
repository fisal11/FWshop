using FWshop.Models;
using System.Collections.Generic;

namespace FWshop.BL.Interface
{
    public interface ICountry
    {

        IEnumerable<CountryVM> Get();
        CountryVM GetById(int Id);

    }
}
