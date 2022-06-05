using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HelpersController helpers;
        public ProfileController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            helpers = new HelpersController(db, webHostEnvironment);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(string id)
        {
            ResultDocumentStudent student = null;
            try
            {
                student = _db.ResultDocumentStudents
                    .Include(a => a.ResultDocument)
                    .Include(b => b.ResultDocument.LookupSchool).SingleOrDefault(x => x.StudentID == id);

                if (student == null)
                {
                    ViewBag.ErrorMessage = "معلومات جدول شاگرد موجود نیست.";
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "سرور دچار مشکل شد.";
                return NotFound();
            }

            StudentProfile studentProfile = new StudentProfile();
            studentProfile.Id = student.StudentID;
            studentProfile.Name = student.StudentName;
            studentProfile.FatherName = student.FatherName;
            studentProfile.ClassEnrollment = student.StudentOrderNumber;
            studentProfile.GraduationYear = student.ResultDocument.Year + "";

            ViewBag.SchoolName = student.ResultDocument.LookupSchool.SchoolNameDari;
            ViewBag.Provinces = helpers.getProvinces();

            return View(studentProfile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentProfile studentProfile)
        {
            ResultDocumentStudent student = null;
            try
            {
                student = _db.ResultDocumentStudents
                    .Include(a => a.ResultDocument)
                    .Include(b => b.ResultDocument.LookupSchool)
                    .SingleOrDefault(x => x.StudentID == studentProfile.Id);

                if (student == null)
                {
                    ViewBag.ErrorMessage = "معلومات جدول شاگرد موجود نیست.";
                    return RedirectToAction("Create", student.StudentID);
                } 
                else
                {
                    var stdProfile = _db.StudentsProfile.Where(x => x.Id == studentProfile.Id).Count();
                    if (stdProfile != 0)
                    {
                        ViewBag.ErrorMessage = "معلومات جدول شاگرد موجود است.";
                        //redirect to marks page
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "سرور دچار مشکل شد.";
                return RedirectToAction("Create", student.StudentID);
            }

            studentProfile.GraduationYear = student.ResultDocument.Year + "";
            studentProfile.AsasNo = student.AsasNumber;
            DateTime DOB = DateTime.Parse(studentProfile.DateOfBirth + "");
            studentProfile.DateOfBirth = DOB;
            studentProfile.EntryType = "pro";
            studentProfile.ThreeYearMarks = true;

            if (ModelState.IsValid)
            {
                _db.StudentsProfile.Add(studentProfile);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "معلومات کامل نیست.";
                return RedirectToAction("Create", student.StudentID);
            }
        }
    }
}
