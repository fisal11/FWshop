using FWshop.BL.Interface;
using FWshop.Models;
using FWshop.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace FWshop.Controllers
{
    [Authorize]
    public class EmploeeController : Controller
    {
        private readonly IEmploee _iemploee;
        private readonly IDepartment _department;
        private readonly ICountry _country;
        private readonly ICity _city;
        private readonly IDistrict _district;

        public EmploeeController(
            IEmploee emploee , IDepartment department,
            ICountry country, ICity city, IDistrict district)
        {
            _iemploee = emploee;
            _department = department;
            _country = country;
            _city = city;
            _district = district;
        }

        public IActionResult Index()
        {
            var data = _iemploee.Get();

            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = _iemploee.GetById(id);
            var Dptdata = _department.Get();

            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }

        public IActionResult Create()
        {
           
            var data = _department.Get();
            var Countrydata = _country.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(Countrydata , "Id", "CountryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmploeeVM emploeeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iemploee.Add(emploeeVM);
                    return RedirectToAction("Index");
                }
                var data = _department.Get();
                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
                return View(emploeeVM);

            }
            catch (Exception ex)
            {
                 View(ex);

            }
            return View();

        }

        public IActionResult Edit(int id)
        {
            var data = _iemploee.GetById(id);

            var Deptdata = _department.Get();
            ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmploeeVM emploeeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iemploee.Edit(emploeeVM);
                    return RedirectToAction("Index", "Emploee");
                }
                var dataList = _department.Get();
                ViewBag.DepartmentList = new SelectList(dataList,
                                  "Id", "DepartmentName", emploeeVM.DepartmentId);
             
                return View(emploeeVM);
            }
            catch (Exception ex)
            {
             return View(ex);

            }
        }

        public IActionResult Delete(int id)
        {
            var data = _iemploee.GetById(id);

            var dataList = _department.Get();
            var dataListofdistirect = _district.Get();
            ViewBag.DepartmentList = new SelectList(dataList, "Id", "DepartmentName", data.DepartmentId);
            ViewBag.DistrictList = new SelectList(dataListofdistirect, "Id", "DistrictName", data.DistrictId);

            return View(data);

        }
        [HttpPost]
        public IActionResult Delete(int id, EmploeeVM emploeeVM)
        {
                    _iemploee.Delete(id, emploeeVM);
                    return RedirectToAction("Index");      
        }


        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = _city.Get().Where(a => a.CountryId == CntryID);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = _district.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }
    }
}
