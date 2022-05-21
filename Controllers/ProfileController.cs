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
            
            ViewBag.Provinces = provinces;
            return View();
        }

    }
}
