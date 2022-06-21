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
            ViewBag.Schooldropdown = _db.LookUp_Province.Select(x => new SelectListItem
            {
                Text = x.ProvinceNamePashto,
                Value = x.ProvinceID.ToString()
            });



            //ViewBag.ProvinceId = _db.LookUp_Province.Select(p => new SelectListItem
            //{
            //    Text = p.ProvinceNamePashto,
            //    Value = p.ProvinceID.ToString(),
            //});
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult School_Create(LookupSchool obj)
        {
            var SchoolCount = _db.LookUp_School.Where(s => s.DistrictID == obj.DistrictID).Count();
            int SchoolID=0;

            if (SchoolCount > 0) {
            var SchoolMaxId = _db.LookUp_School.Where(s => s.DistrictID == obj.DistrictID).Max().SchoolID+1;
            }
            else
            {
                if (obj.DistrictID > 0)
                {
                    string SchoolCode;
                    var DID = obj.DistrictID.ToString();
                    switch (DID.Length)
                    {
                        case 3:
                            SchoolCode = DID + "000001";
                            break;
                        case 4:
                            SchoolCode = DID + "00001";
                            break;

                        default:
                            SchoolCode = "0";
                            break;
                    }
                    SchoolID = Convert.ToInt32(SchoolCode);
                }
                else
                {
                    return View();
                }

            }

            if (SchoolID > 0)
            {
                obj.SchoolID = SchoolID;
                _db.LookUp_School.Add(obj);
                _db.SaveChanges();
                return View("Index");
            }
            else
            {
                return View();

            }

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
        public IActionResult Province_Create()
        {
            IEnumerable<SelectListItem> prov = _db.LookUp_Province.Select(i => new SelectListItem
            {
                Text = i.ProvinceNamePashto,
                Value = i.ProvinceID.ToString()
            });
            return View("Province_Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Province_Create(LookUp_Province obj)
        {
            var provinceId = _db.LookUp_Province.Select(x => x.ProvinceID).Max() + 1;
            obj.ProvinceID = provinceId;
            _db.LookUp_Province.Add(obj);
            _db.SaveChanges();
            return View("index");
        }

    }
}
