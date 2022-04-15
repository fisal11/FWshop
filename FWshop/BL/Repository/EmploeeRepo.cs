using AutoMapper;
using FWshop.BL.Helper;
using FWshop.BL.Interface;
using FWshop.Data.Database;
using FWshop.Data.Entity;
using FWshop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FWshop.BL.Repository
{
    public class EmploeeRepo : IEmploee
    {
        private readonly DbContainer _context;
        private readonly IMapper _mapper;

        public EmploeeRepo(DbContainer context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(EmploeeVM vM)
        {
            var addData = _mapper.Map<Emploee>(vM);
            addData.PhotoName = UploadFile.SavaFile(vM.PhotoUrl, "Photos");
            addData.CvName= UploadFile.SavaFile(vM.CvUrl, "Docs");

            _context.Emploee.Add(addData);
            _context.SaveChanges();
        }

        public void Delete(int id, EmploeeVM vM)
        {
            var delete = _context.Emploee.Find(vM.Id);
            _context.Emploee.Remove(delete);
            UploadFile.DeleteFile("Photos/", delete.PhotoName);
            UploadFile.DeleteFile("Docs/", delete.CvName);
            _context.SaveChanges();
        }
        public void Edit(EmploeeVM vM)
        {
            var newdata = _mapper.Map<Emploee>(vM);
            _context.Entry(newdata).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<EmploeeVM> Get()
        {
            var getData = _context.Emploee.Select(a => new EmploeeVM{
            Id=a.Id,
            Name=a.Name,    
            Email=a.Email,
            Salary=a.Salary,
            Address=a.Address,
            IsActive=a.IsActive,    
            Notes=a.Notes,
            HirDate=a.HirDate,
            PhotoName=a.PhotoName,
            CvName=a.CvName,
                //can I use the _mapper but the  DepartmentId =a.Department.DepartmentName
                // when i call it display the id not DepartmentName
                DepartmentName = a.Department.DepartmentName,
                //DistrictName = a.District.DistrictName,
                DepartmentId = a.DepartmentId,
                //DistrictId = a.DistrictId,
            });
            return getData;
           
        }

        public EmploeeVM GetById(int Id)
        {
            var getDataById = _context.Emploee.Where(a=>a.Id==Id).Select(a => new EmploeeVM
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Salary = a.Salary,
                Address = a.Address,
                IsActive = a.IsActive,
                Notes = a.Notes,
                HirDate = a.HirDate,
                PhotoName = a.PhotoName,
                CvName = a.CvName,
                //can I use the _mapper but the  DepartmentId =a.Department.DepartmentName
                // when i call it display the id not DepartmentName
                DepartmentName = a.Department.DepartmentName,
                //DistrictName = a.District.DistrictName,
                DepartmentId = a.DepartmentId,
               // DistrictId = a.DistrictId,
            }).FirstOrDefault();
            return getDataById;
        }
    }
}
