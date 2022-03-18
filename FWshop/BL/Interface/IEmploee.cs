using FWshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Interface
{
    public interface IEmploee
    {
        IEnumerable<EmploeeVM> Get();
        EmploeeVM GetById(int Id);
        void Add(EmploeeVM vM);
        void Edit(EmploeeVM vM);
        void Delete(int id, EmploeeVM vM);
    }
}
