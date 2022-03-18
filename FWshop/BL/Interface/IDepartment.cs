using FWshop.Models;
using System.Collections.Generic;

namespace FWshop.Repository.IRepository
{
    public interface IDepartment
    {
        IEnumerable<DepartmentVM> Get();
        DepartmentVM GetById(int Id);
        void Add(DepartmentVM vM);
        void Edit(DepartmentVM vM);
        void Delete(int id , DepartmentVM vM);
    }
}
