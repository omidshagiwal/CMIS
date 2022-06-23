using CMIS.Data;
using CMIS.Enums;
using CMIS.Models;
using CMIS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class ExamMarkController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HelpersController helpers;
        public ExamMarkController(ApplicationDbContext db)
        {
            _db = db;
            helpers = new HelpersController(_db, null);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string studentId, string ErrorMessage = "")
        {
            ViewBag.ErrorMessage = ErrorMessage;
            StudentProfile student = new StudentProfile();
            ResultDocumentStudent resultDocument = new ResultDocumentStudent();
            try
            {
                resultDocument = _db.ResultDocumentStudents
                        .Include(a => a.ResultDocument)
                        .Include(b => b.ResultDocument.LookupSchool)
                        .Include(c => c.ResultDocument.LookupSchool.District)
                        .Include(d => d.ResultDocument.LookupSchool.District.Province)
                        .SingleOrDefault(x => x.StudentId == studentId);

                if (resultDocument == null)
                    return RedirectToActionPermanent("NotFound", "Home",
                        new { ErrorMessage = "لطفا ID درست را وارد کنید." });

                student = _db.StudentsProfile.SingleOrDefault(x => x.Id == studentId);
                if (student == null)
                    return RedirectToActionPermanent("Create", "Profile",
                        new { id = studentId, ErrorMessage = "معلومات شاگرد موجود نیست." });
            }
            catch (Exception e)
            {
                return RedirectToActionPermanent("Create", "Profile",
                        new { studentId, ErrorMessage = "سرور دچار مشکل شد." + e.Message });
            }

            ExamMarkViewModel examMarkVM = new ExamMarkViewModel();
            examMarkVM.StudentId = student.Id;
            examMarkVM.StudentName = student.Name;
            examMarkVM.StudentFatherName = student.FatherName;
            examMarkVM.SchoolFullName = resultDocument.ResultDocument.LookupSchool.NameDari + ", " +
                resultDocument.ResultDocument.LookupSchool.District.NameDari + ", " +
                resultDocument.ResultDocument.LookupSchool.District.Province.NamePashto;
            examMarkVM.GraduationYear = resultDocument.ResultDocument.Year;
            examMarkVM.SchoolId = resultDocument.ResultDocument.SchoolId;
            examMarkVM.OrderTypes = helpers.SubjectOrderTypes();

            return View(examMarkVM);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] ExamMarksPostViewModel marks)
        {
            try
            {
                if (marks.ExamMarks.Count != 3)
                    return BadRequest( getJsonResult("معلومات مکمل نیست."));

                var resDoc = _db.ResultDocumentStudents
                    .Include(x => x.ResultDocument)
                    .SingleOrDefault(x => x.StudentId == marks.StudentId);
                if (resDoc == null)
                    return NotFound( getJsonResult(
                        "جدول نتایج پیدا نشد.",
                        "/ResultDocument/Create",
                        "اضافه نمودن جدول"
                        ));

                var student = _db.StudentsProfile
                    .SingleOrDefault(x => x.Id == marks.StudentId);
                if (student == null)
                    return NotFound( getJsonResult(
                        "معلومات شاگرد در سیستم موجود نیست.",
                        "/StudentProfile/Create?studentId=" + marks.StudentId,
                        "مکمل نمودن معلومات"
                        ));

                var marksRecordsCount = _db.StudentClassesInfo
                    .Where(x => x.StudentId == marks.StudentId)
                    .Count();
                if (marksRecordsCount > 0)
                    return BadRequest( getJsonResult(
                        "معلومات قبلا ثبت شده است.", 
                        "/Attendance/Create?studentId=" + marks.StudentId, 
                        "رفتن به مرحله بعدی</a>"
                        )); 

                foreach (var examMarks in marks.ExamMarks)
                {
                    if (examMarks.Grade < 10 || examMarks.Grade > 12)
                        return BadRequest( getJsonResult("معلومات صنف درست نیست.") );

                    if (examMarks.Position == "")
                        return BadRequest( getJsonResult("درجه ضروری میباشد.") );

                    var classId = _db.LookupClasses
                        .SingleOrDefault(x => x.ClassName == examMarks.Grade.ToString()).Id;
                    int year = (resDoc.ResultDocument.Year - 2) + (examMarks.Grade - 10);

                    if (examMarks.SubjectsMark != null)
                    {
                        foreach (var subjectMark in examMarks.SubjectsMark)
                        {
                            if (subjectMark.SubjectId <= 0 || subjectMark.Mark < 0 || subjectMark.Mark > 100)
                                return BadRequest(getJsonResult("نمره باید در بین 0 و 100 باشد"));

                            ExamMark examMark = new ExamMark();
                            examMark.Id = _db.ExamsMark.Local.Count + _db.ExamsMark.Count() + 1;
                            examMark.StudentId = student.Id;
                            examMark.ClassId = classId;
                            examMark.GraduationYear = year;
                            examMark.SubjectId = subjectMark.SubjectId;
                            examMark.Marks = subjectMark.Mark;
                            _db.ExamsMark.Add(examMark);
                        }
                    }

                    StudentClassInfo studentClass = new StudentClassInfo();
                    studentClass.GraduationYear = year.ToString();
                    studentClass.StudentId = student.Id;
                    studentClass.ClassId = classId;
                    studentClass.SchoolId = resDoc.ResultDocument.SchoolId;
                    studentClass.SectionId = resDoc.ResultDocument.SectionId;
                    studentClass.HasMarks = examMarks.HasMarks;
                    studentClass.Remarks = examMarks.Remarks;
                    studentClass.Position = examMarks.Position;
                    studentClass.EnrollmentStatusId = _db.LookupEnrollmentStatuses.First().Id;
                    _db.StudentClassesInfo.Add(studentClass);
                }

                _db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest( getJsonResult("سرور دچار مشکل شد."));
            }
        }
        
        private Object getJsonResult(string message = "", string link = "", string linkValue = "")
        {
            if(link == "")
                return new { message = "<p>" + message + "</p>", control = "" };
            
            return new { 
                message = "<h5>"+ message + "</h5>",
                control =  "<a class='btn btn-link' href='"+ link + "'>"+ linkValue + "</a>"
            };
        }
    }
}
