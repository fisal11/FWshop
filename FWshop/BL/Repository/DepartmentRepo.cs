using AutoMapper;
using FWshop.Data.Database;
using FWshop.Models;
using FWshop.Models.DTO;
using FWshop.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.Repository
{
    public class DepartmentRepo : IDepartment
    {
        private readonly DbContainer _context;
        private readonly IMapper _mapper;

        public DepartmentRepo(DbContainer context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(DepartmentVM vM)
        {
            var addData = _mapper.Map<Department>(vM); 
            _context.Department.Add(addData);
            _context.SaveChanges();
        }

        public IEnumerable<DepartmentVM> Get()
        {
            var getData = _context.Department.ToList();
            return _mapper.Map<IEnumerable<DepartmentVM>>(getData);
        }

        public DepartmentVM GetById(int id)
        {
            var data = _context.Department.Find(id);
            return _mapper.Map<DepartmentVM>(data);
        }

        public void Edit(DepartmentVM vM)
        {
            var newdata = _mapper.Map<Department>(vM);
            _context.Department.Update(newdata);
            _context.SaveChanges();
        }

        public void Delete(int id , DepartmentVM vM)
        {
            var  delete= _context.Department.Find(vM.Id);
            var newdata = _mapper.Map<Department>(delete);
            _context.Department.Remove(newdata);
            _context.SaveChanges();
        }
    }
}