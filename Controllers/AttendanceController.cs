using CMIS.Data;
using CMIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class AttendanceController : Controller
    {
        ApplicationDbContext _db;
        public AttendanceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string studentId = "", string ErrorMessage = "")
        {
            ViewBag.ErrorMessage = ErrorMessage;
            if (studentId == "")
                return RedirectToActionPermanent("NotFound", "Home",
                        new { ErrorMessage = "ID شاگرد ضروری میباشد." });

            var student = _db.StudentsProfile.SingleOrDefault(x => x.Id == studentId);
            if (student == null)
                return RedirectToActionPermanent("NotFound", "Home",
                        new { ErrorMessage = "معلومات شاگرد موجود نیست." }); ;

            var classInfo = _db.StudentClassesInfo.Where(x => x.StudentId == studentId).Count();
            if(classInfo != 3)
                return RedirectToActionPermanent("Create","ExamMark",
                        new { studentId, ErrorMessage = "معلومات نمرات موجود نیست." });

            var stdResDoc = _db.ResultDocumentStudents
                .Include(x => x.ResultDocument)
                .Include(x => x.ResultDocument.LookupSchool.District.province)
                .Include(x => x.ResultDocument.LookupSchool.District)
                .Include(x => x.ResultDocument.LookupSchool)
                .SingleOrDefault(x => x.StudentID == studentId);

            string schoolFullName = stdResDoc.ResultDocument.LookupSchool.SchoolNameDari + ", " +
                    stdResDoc.ResultDocument.LookupSchool.District.DistrictName + ", " +
                    stdResDoc.ResultDocument.LookupSchool.District.province.ProvinceNamePashto;

            List<StudentAttendance> studentAttendances = new List<StudentAttendance>();
            for (int grade = 10; grade <= 12; grade++)
            {
                StudentAttendance studentAttendance = new StudentAttendance();
                studentAttendance.StudentId = student.Id;
                studentAttendance.StudentName = student.Name;
                studentAttendance.StudentFatherName = student.FatherName;
                studentAttendance.SchoolFullName = schoolFullName;
                studentAttendance.Class = grade;
                studentAttendance.ClassId = _db.LookUp_Class.SingleOrDefault(x => x.ClassName == grade + "").Id;
                studentAttendance.Year = (stdResDoc.ResultDocument.Year - 2) + (grade - 10);
                studentAttendances.Add(studentAttendance);
            }

            return View(studentAttendances);
        }
        [HttpPost]
        public IActionResult Create(IEnumerable<StudentAttendance> studentAttendances)
        {
            string studentId = "";
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var attendance in studentAttendances)
                    {
                        if (studentId != attendance.StudentId)
                            return RedirectToActionPermanent("Create",
                                new { studentId, ErrorMessage = "معلومات درست نیست." }); ;

                        studentId = attendance.StudentId;
                        int attendanceCount =  _db.StudentsAttendance.Where(x => x.StudentId == studentId).Count();
                        if(attendanceCount > 0)
                            return RedirectToActionPermanent("Create", 
                                new { studentId, ErrorMessage = "معلومات موجود است." });
                        
                        attendance.Id = _db.StudentsAttendance.Count() + _db.StudentsAttendance.Local.Count + 1;
                        _db.Add(attendance);
                    }

                    var student = _db.StudentsProfile.Where(x => x.Id == studentId).Count();
                    if (student != 1)
                        return RedirectToActionPermanent("Create",
                                new { studentId, ErrorMessage = "معلومات شاگرد در سیستم موجود نیست." });

                    _db.SaveChanges();
                }
                //go to next stage
                return RedirectToActionPermanent("Create", new { studentId, ErrorMessage = "Saved" });
            }
            catch (Exception e)
            {
                return RedirectToActionPermanent("Create", 
                    new { studentId, ErrorMessage = "سرور دچار مشکل شد." + e.Message });
            }
        }

    }
}
