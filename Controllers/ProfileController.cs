using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> provinces = _db.LookUp_Province.Select(x => new SelectListItem
            {
                Value = x.ProvinceID.ToString(),
                Text = x.ProvinceNameDari
            });

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

            ViewBag.shamsiYearsList = shamsiYearsList;
            ViewBag.Provinces = provinces;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentProfile studentProfile)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }
        public JsonResult Districts(string provinceId)
        {
            IEnumerable<SelectListItem> districts = _db.LookUp_District
                .Where(x => x.ProvinceID.ToString() == provinceId)
                .Select(x => new SelectListItem(x.DistrictID.ToString(), x.DistrictName));

            return Json(districts);
        }
        public JsonResult Schools(string districtId)
        {
            IEnumerable<SelectListItem> schools = _db.LookUp_School
                .Where(x => x.DistrictID.ToString() == districtId)
                .Select(x => new SelectListItem(x.SchoolID.ToString(), x.SchoolNameDari));

            return Json(schools);
        }
        private string GenerateStudentId(string schoolCode, string assasNo, string graduationYear)
        {
            string idToReturn = "";
            int GaraguationYear = Convert.ToInt32(graduationYear) - 2;
            string zeros = "";
            if (GaraguationYear > 0 && schoolCode.Length > 0)
            {
                switch (assasNo.Length)
                {
                    case 1:
                        zeros = "000000000";
                        break;
                    case 2:
                        zeros = "00000000"; 
                        break;
                    case 3:
                        zeros = "0000000";
                        break;
                    case 4:
                        zeros = "000000";
                        break;
                    case 5:
                        zeros = "00000";
                        break;
                    case 6:
                        zeros = "0000";
                        break;
                    case 7:
                        zeros = "000";
                        break;
                    case 8:
                        zeros = "00";
                        break;
                    case 9:
                        zeros = "0";
                        break;
                    default:
                        idToReturn = schoolCode + "-" + assasNo;
                        break; 
                }
            }
            idToReturn = schoolCode + "-" + zeros + "-" + assasNo;
            return idToReturn;

        }
    }
}
