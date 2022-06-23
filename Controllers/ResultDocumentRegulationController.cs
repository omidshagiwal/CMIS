using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class ResultDocumentRegulationController : Controller
    {
        ApplicationDbContext _db;
        HelpersController helpers;
        public ResultDocumentRegulationController(ApplicationDbContext db)
        {
            _db = db;
            helpers = new HelpersController(_db, null);
        }
        public IActionResult Index()
        {
            var resultDocReg = _db.ResultDocumentRegulations.Include(x => x.LookupSchool);

            return View(resultDocReg);
        }

        public IActionResult Create()
        {
            ViewBag.Provinces = helpers.getProvinces();
            ViewBag.shamsiYearsList = helpers.getYearsList();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResultDocumentRegulation resultDocReg)
        {
            if(ModelState.IsValid)
            {
                var isExist = _db.ResultDocumentRegulations
                    .SingleOrDefault(x => x.SchoolId == resultDocReg.SchoolId && x.Year == resultDocReg.Year);
                if(isExist != null)
                {
                    ViewBag.Message = "این مکتب در این سال محدودیت دارد.";
                    ViewBag.Provinces = helpers.getProvinces();
                    ViewBag.shamsiYearsList = helpers.getYearsList();
                    return View(resultDocReg);
                }
                _db.ResultDocumentRegulations.Add(resultDocReg);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "معلومات غلت است.";
                ViewBag.Provinces = helpers.getProvinces();
                ViewBag.shamsiYearsList = helpers.getYearsList();
                return View(resultDocReg);
            }
        }
        
        public JsonResult Regulations(int schoolId, int year)
        {
            Console.WriteLine("Hello" + schoolId + year);
            return Json(
                _db.ResultDocumentRegulations
                    .FirstOrDefault(x => x.SchoolId == schoolId && x.Year == year)
            );
        }
    }
}
