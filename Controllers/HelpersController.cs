using CMIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class HelpersController : Controller
    {
        ApplicationDbContext _db;
        public HelpersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> getProvinces()
        {
            IEnumerable<SelectListItem> provinces = _db.LookUp_Province.Select(x => new SelectListItem
            {
                Value = x.ProvinceID.ToString(),
                Text = x.ProvinceNameDari
            });
            return provinces;
        }
        public IEnumerable<SelectListItem> getYearsList()
        {
            //621 years
            int shamsiYear = DateTime.Now.Year - 621;
            List<SelectListItem> shamsiYearsList = new List<SelectListItem>();
            for (int a = 0; a < 100; a++)
            {
                shamsiYearsList.Add(new SelectListItem(
                    (shamsiYear - a).ToString(),
                    (shamsiYear - a).ToString()
                ));
            }
            return shamsiYearsList;
        }
        public JsonResult Provinces()
        {
            IEnumerable<SelectListItem> provincs = getProvinces();

            return Json(provincs);
        }
        public JsonResult Districts(string provinceId)
        {
            IEnumerable<SelectListItem> districts = _db.LookUp_District
                .Where(x => x.ProvinceID.ToString() == provinceId)
                .Select(x => new SelectListItem(x.DistrictName, x.DistrictID.ToString()));

            return Json(districts);
        }
        public JsonResult Schools(string districtId)
        {
            IEnumerable<SelectListItem> schools = _db.LookUp_School
                .Where(x => x.DistrictID.ToString() == districtId)
                .Select(x => new SelectListItem(x.SchoolNameDari, x.SchoolID.ToString()));

            return Json(schools);
        }
    }
}
