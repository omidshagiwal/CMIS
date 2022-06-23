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
            ViewBag.Schooldropdown = _db.LookupProvinces.Select(x => new SelectListItem
            {
                Text = x.NamePashto,
                Value = x.Id.ToString()
            });



            //ViewBag.ProvinceId = _db.LookUp_Province.Select(p => new SelectListItem
            //{
            //    Text = p.NamePashto,
            //    Value = p.Id.ToString(),
            //});
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult School_Create(LookupSchool obj)
        {
            var SchoolCount = _db.LookupSchools.Where(s => s.DistrictId == obj.DistrictId).Count();
            int SchoolID=0;

            if (SchoolCount > 0) {
            var SchoolMaxId = _db.LookupSchools.Where(s => s.DistrictId == obj.DistrictId).Max().Id+1;
            }
            else
            {
                if (obj.DistrictId > 0)
                {
                    string SchoolCode;
                    var DID = obj.DistrictId.ToString();
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
                obj.Id = SchoolID;
                _db.LookupSchools.Add(obj);
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
            //var DistrictList = new SelectList(_db.LookupDistrict.Where(d => d.Id == provinceId), "DistrictId", "DistrictName");
            var DistrictList = _db.LookupDistricts.Where(p=>p.ProvinceId== provinceId).Select(p => new SelectListItem
             {
                 Text = p.NameDari,
                 Value = p.Id.ToString(),
             });
            return Json(new { data = DistrictList.ToList() });
        }
        public IActionResult Province_Create()
        {
            IEnumerable<SelectListItem> prov = _db.LookupProvinces.Select(i => new SelectListItem
            {
                Text = i.NamePashto,
                Value = i.Id.ToString()
            });
            return View("Province_Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Province_Create(LookupProvince obj)
        {
            var provinceId = _db.LookupProvinces.Select(x => x.Id).Max() + 1;
            obj.Id = provinceId;
            _db.LookupProvinces.Add(obj);
            _db.SaveChanges();
            return View("index");
        }

    }
}
