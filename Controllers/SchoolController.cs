using CMIS.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SchoolController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var schools = _db.LookupProvinces;
            return View(schools);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
