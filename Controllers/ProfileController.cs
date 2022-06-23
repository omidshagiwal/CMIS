using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public IActionResult Create(string id, string ErrorMessage = "")
        {
            ViewBag.ErrorMessage = ErrorMessage;
            ResultDocumentStudent student = null;
            try
            {
                student = _db.ResultDocumentStudents
                    .Include(a => a.ResultDocument)
                    .Include(b => b.ResultDocument.LookupSchool).SingleOrDefault(x => x.StudentId == id);

                if (student == null)
                    return RedirectToActionPermanent("NotFound", "Home",
                        new { ErrorMessage = "معلومات جدول شاگرد موجود نیست." } );
            }
            catch (Exception e)
            {
                return RedirectToActionPermanent("NotFound", "Home",
                        new { ErrorMessage = "سرور دچار مشکل شد." });
            }

            StudentProfile studentProfile = new StudentProfile();
            studentProfile.Id = student.StudentId;
            studentProfile.Name = student.StudentName;
            studentProfile.FatherName = student.FatherName;
            studentProfile.ClassEnrollment = student.StudentOrderNumber;
            studentProfile.GraduationYear = student.ResultDocument.Year + "";
            studentProfile.AsasNo = student.AsasNumber;

            ViewBag.SchoolName = student.ResultDocument.LookupSchool.NameDari;
            ViewBag.Provinces = helpers.getProvinces();

            return View(studentProfile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentProfile studentProfile)
        {
            try
            {
                var stdResDoc = _db.ResultDocumentStudents
                    .Include(a => a.ResultDocument)
                    .Include(b => b.ResultDocument.LookupSchool)
                    .SingleOrDefault(x => x.StudentId == studentProfile.Id);

                if (stdResDoc == null)
                    return RedirectToActionPermanent("Create","ResultDocument", 
                        new { ErrorMessage = "معلومات جدول شاگرد موجود نیست."  });

                var stdProfile = _db.StudentsProfile.Where(x => x.Id == studentProfile.Id).Count();
                if (stdProfile != 0)
                    return RedirectToAction("Create", "ExamMark", 
                        new { studentId = studentProfile.Id, ErrorMessage = "معلومات شاگرد موجود است." });

                studentProfile.GraduationYear = stdResDoc.ResultDocument.Year.ToString();
                studentProfile.DateOfBirth = DateTime.Parse(studentProfile.DateOfBirth.ToString());
                studentProfile.EntryType = "pro";
                studentProfile.ThreeYearMarks = true;

                if (ModelState.IsValid)
                {
                    _db.StudentsProfile.Add(studentProfile);
                    _db.SaveChanges();
                    return RedirectToAction("Create", "ExamMark", 
                        new { studentId = studentProfile.Id });
                }
                else
                {
                    return RedirectToAction("Create",
                        new { id = stdResDoc.StudentId, ErrorMessage = "معلومات کامل نیست." });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Create", 
                    new { id = studentProfile.Id, ErrorMessage = "سرور دچار مشکل شد." + e.Message });
            }
        }
    }
}
