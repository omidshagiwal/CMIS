using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMIS.Controllers
{
    public class LookUpController : Controller
    {

        private readonly ApplicationDbContext _db;
        ////private object item;

        public LookUpController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult School_Create()
        {
            IEnumerable<SelectListItem> Schooldropdown = _db.LookUp_Province.Select(x => new SelectListItem
            {
                Text = x.ProvinceNamePashto,
                Value = x.ProvinceID.ToString()
            });

            ViewBag.Schooldropdown = Schooldropdown;


            //ViewBag.ProvinceId = _db.LookUp_Province.Select(p => new SelectListItem
            //{
            //    Text = p.ProvinceNamePashto,
            //    Value = p.ProvinceID.ToString(),
            //});
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult School_Create(LookUp_School obj)
        {
            _db.LookUp_School.Add(obj);
            _db.SaveChanges();
            return View("School_Display");
        }
        public IActionResult School_Display(LookUp_Province lookUp_Province)
        {
            //LookUp_Province lookUp_province = new LookUp_Province();
            //lookUp_province.ProvinceList = new List<SelectList>();

            //var data = _db.LookUp_Province.ToList();
            //lookUp_Province.ProvinceList.Add(new SelectListItem
            //{
            //    Text = lookUp_Province.ProvinceNamePashto,
            //    Value = Convert.ToString(item.Id)
            //});

            IEnumerable<LookUp_School> objlist = _db.LookUp_School;
            return View(objlist);
        }

        [HttpGet]
        public JsonResult GetDistricts(int provinceId)
        {
            //var DistrictList = new SelectList(_db.LookUp_District.Where(d => d.ProvinceID == provinceId), "DistrictID", "DistrictName");
            var DistrictList = _db.LookUp_District.Where(p=>p.ProvinceID== provinceId).Select(p => new SelectListItem
             {
                 Text = p.DistrictName,
                 Value = p.DistrictID.ToString(),
             });
            return Json(new { data = DistrictList.ToList() });
        }


    }
}
