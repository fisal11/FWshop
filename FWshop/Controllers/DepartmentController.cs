using FWshop.Models;
using FWshop.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FWshop.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartment _idepartment;

        public DepartmentController(IDepartment idepartment)
        {
            _idepartment = idepartment;
        }
        public IActionResult Index()
        {
            var data = _idepartment.Get();

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM departmentVM)
        {
            _idepartment.Add(departmentVM);
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            var data = _idepartment.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM departmentVM)
        {
            _idepartment.Edit(departmentVM);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _idepartment.GetById(id);
            return View(data);
            
        }
        [HttpPost]
        
        public IActionResult Delete(int id , DepartmentVM departmentVM)
        {
            _idepartment.Delete(id , departmentVM);
            return RedirectToAction("Index");
        }
    }
}
