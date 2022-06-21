using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var subjects = _db.LookupSubjects;
            return View(subjects);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LookupSubject subject)
        {
            subject.Id = _db.LookupSubjects.Count() + 1;
            
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "معلومات کامل نیست!";
                return View();
            }
            try
            {
                _db.LookupSubjects.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "سرور دچار مشکل شد.";
                return View();
            }
        }
        public IActionResult Edit(int id)
        {   
            if(id <= 0)
                return RedirectToAction("Index");
            
            var subject = _db.LookupSubjects.SingleOrDefault(x => x.Id == id);
            if (subject == null)
                return RedirectToAction("Create");

            return View(subject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LookupSubject subject)
        {
            var subjectInDB = _db.LookupSubjects.Where(x => x.Id == subject.Id).Count();
            if (subjectInDB != 1)
                return RedirectToAction("Create");

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "معلومات کامل نیست!";
                return View(subject);
            }
            try
            {
                _db.LookupSubjects.Update(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "سرور دچار مشکل شد.";
                return View(subject);
            }
        }
    }
}
