using CMIS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class HelpersController : Controller
    {
        ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly string documentResultsPath = "/resultdocuments";
        public HelpersController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IEnumerable<SelectListItem> getProvinces()
        {
            return _db.LookupProvinces.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameDari
            });
        }
        public IEnumerable<SelectListItem> getClasses()
        {
            return _db.LookupClasses.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ClassName
            });
        }
        public IEnumerable<SelectListItem> getSubjects()
        {
            return _db.LookupSubjects
                .Where(b => b.Status == true)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }
        public IEnumerable<SelectListItem> getSubjectOrderTypes()
        {
            List<SelectListItem> orderTypes = new List<SelectListItem>();
            
            orderTypes.Add(new SelectListItem
            {
                    Value = CMIS.Enums.SubjectOrderTypes.AllClass + "",
                    Text = "تمام صنف"
            });
            orderTypes.Add(new SelectListItem
            {
                Value = CMIS.Enums.SubjectOrderTypes.UnorderedResultDocument + "",
                Text = "جدول نا منظم"
            });

            return orderTypes;
        }
        public IEnumerable<SelectListItem> SubjectOrderTypes()
        {
            List<SelectListItem> orderTypes = new List<SelectListItem>();
            orderTypes.Add(new SelectListItem { Value = "1", Text = "تمام صنف" });
            orderTypes.Add(new SelectListItem { Value = "2", Text = "جدول نامنظم" });
            orderTypes.Add(new SelectListItem { Value = "3", Text = "زبان اول دری" });
            orderTypes.Add(new SelectListItem { Value = "4", Text = "زبان اول پشتو" });
            return orderTypes;
        }
        public IEnumerable<SelectListItem> getYearsList()
        {
            //621 years
            int shamsiYear = DateTime.Now.Year - 621;
            List<SelectListItem> shamsiYearsList = new List<SelectListItem>();
            for (int a = 0; a < 100; a++)
            {
                shamsiYearsList.Add(new SelectListItem
                {
                    Value = (shamsiYear - a).ToString(),
                    Text = (shamsiYear - a).ToString()
                });
            }
            return shamsiYearsList;
        }
        public IEnumerable<SelectListItem> getSections()
        {
            return _db.LookupSections.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.SectionNumber
            });
        }
        public JsonResult Provinces()
        {
            return Json(getProvinces());
        }
        public JsonResult Districts(string provinceId)
        {
            return Json(
                    _db.LookupDistricts
                        .Where(x => x.ProvinceId.ToString() == provinceId)
                        .Select(x => new SelectListItem(x.NameDari, x.Id.ToString()))
                );
        }
        public JsonResult Schools(string districtId)
        {
            return Json(
                    _db.LookupSchools
                        .Where(x => x.DistrictId.ToString() == districtId)
                        .Select(x => new SelectListItem(x.NameDari, x.Id.ToString()))
                );
        }
        public JsonResult Sections()
        {
            return Json(getSections());
        }
        public JsonResult Years()
        {
            return Json(getYearsList());
        }
        public JsonResult Subjects()
        {
            return Json(getSubjects());
        }
        public JsonResult Classes()
        {
            return Json(getClasses());
        }
        public bool createDirectory(string name) {
            if (name == null || name.Trim() == "")
                return false;

            try
            {
                System.IO.Directory.CreateDirectory(_webHostEnvironment.WebRootPath + name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string saveImage(IFormFile file, string name ,string path)
        {
            string fullPath = _webHostEnvironment.WebRootPath + path;
            string ext = Path.GetExtension(file.FileName).ToLower();
            name = name + ext;

            try
            {
                using (var fileStream = new FileStream(Path.Combine(fullPath + name), FileMode.Create))
                    file.CopyTo(fileStream);

                return name;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool deleteImage(string name, string path)
        {
            if (name == null || name.Trim() == "")
                return false;

            string fullPath = _webHostEnvironment.WebRootPath + path;
            var image = Path.Combine(fullPath, name);

            if (System.IO.File.Exists(image))
            {
                System.IO.File.Delete(image);
                return true;
            }

            return false;
        }
        public bool validateImage(IFormFile image)
        {
            if (image == null)
                return false;

            string ext = Path.GetExtension(image.FileName).ToLower();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                return true;

            return false;
        }
        public string createId(int schoolId, int year, string assasNo)
        {
            string Id = "";
            switch (assasNo.Length)
            {
                case 1:
                    Id = schoolId + "-" + year + "-" + "000000000" + assasNo;
                    break;
                case 2:
                    Id = schoolId + "-" + year + "-" + "00000000" + assasNo;
                    break;
                case 3:
                    Id = schoolId + "-" + year + "-" + "0000000" + assasNo;
                    break;
                case 4:
                    Id = schoolId + "-" + year + "-" + "000000" + assasNo;
                    break;
                case 5:
                    Id = schoolId + "-" + year + "-" + "00000" + assasNo;
                    break;
                case 6:
                    Id = schoolId + "-" + year + "-" + "0000" + assasNo;
                    break;
                case 7:
                    Id = schoolId + "-" + year + "-" + "000" + assasNo;
                    break;
                case 8:
                    Id = schoolId + "-" + year + "-" + "00" + assasNo;
                    break;
                case 9:
                    Id = schoolId + "-" + year + "-" + "0" + assasNo;
                    break;
                default:
                    if (assasNo.Length != 0 && assasNo.Length > 9)
                        Id = schoolId + "-" + year + "-" + assasNo;
                    break;
            }
            return Id;
        }
    }
}
