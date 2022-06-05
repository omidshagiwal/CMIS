using CMIS.Data;
using CMIS.Models;
using CMIS.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Controllers
{
    public class ResultDocumentController : Controller
    {
        ApplicationDbContext _db;
        HelpersController helpers;
        public ResultDocumentController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            helpers = new HelpersController(db, webHostEnvironment);
        }
        public IActionResult Index()
        {
            IEnumerable<ResultDocument> resultDocuments = _db.ResultDocuments.Include(x => x.Students)
                .Include(c => c.LookupSchool)
                .Include(b => b.LookupSchool.District)
                .Include(b => b.LookupSchool.District.province);

            ViewBag.Provinces = helpers.getProvinces();
            return View();
        }
        public IActionResult ListDocumentsJson(int schoolId,int sectionId, int year)
        {
            try
            {
                IEnumerable<ResultDocumentJsonViewModel> resultDocuments = _db.ResultDocuments
                    .Include(a => a.LookupSchool)
                    .Include(b => b.LookupSchool.District)
                    .Include(c => c.LookupSchool.District.province)
                    .Include(d => d.Students)
                    .Where(x => x.SchoolID == schoolId && x.Year == year && x.SectionID == sectionId)
                    .Select(d => new ResultDocumentJsonViewModel
                    {
                        Id = d.ID,
                        InsertedDate = d.InsertedDate,
                        Path = d.Path,
                        SchoolId = d.SchoolID,
                        TableNumber = d.TableNumber,
                        Year = d.Year,
                        DistrictId = d.LookupSchool.District.DistrictID,
                        ProvinceName = d.LookupSchool.District.province.ProvinceNameEng,
                        StudentsCount = d.Students.Count()
                    }).ToList();

                return Ok(resultDocuments);
            }
            catch (Exception e)
            {
                return NotFound(new { message = "An exception occured." });
            }
        }
        public IActionResult ListStudentsJson(string documentId)
        {
            try
            {
                IEnumerable<ResultDocumentStudent> resDocStudents = _db.ResultDocumentStudents
                    .Where(x => x.ResultDocumentID == documentId);

                return Ok(resDocStudents);
            }
            catch (Exception)
            {
                return NotFound(new { message = "An exception occured." });
            }
        }
        public IActionResult Create()
        {
            ResultDocumentStudentViewModel resultDocumentStudentVM = new ResultDocumentStudentViewModel();
            resultDocumentStudentVM.Provinces = helpers.getProvinces();
            resultDocumentStudentVM.Years = helpers.getYearsList();
            resultDocumentStudentVM.Sections = helpers.getSections();

            return View(resultDocumentStudentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResultDocumentStudentViewModel resultDocViewModel)
        {
            resultDocViewModel.Provinces = helpers.getProvinces();
            resultDocViewModel.Years = helpers.getYearsList();
            resultDocViewModel.Sections = helpers.getSections();

            var files = HttpContext.Request.Form.Files;
            if (files == null && files.Count <= 0)
            {
                ViewBag.error = "سکن جدول ضروری میباشد.";
                return View(resultDocViewModel);
            }

            for (int i = 0; i < resultDocViewModel.ResultDocumentStudents.Count; i++)
                ModelState["ResultDocumentStudents["+i+"].ResultDocumentID"]
                    .ValidationState = ModelValidationState.Skipped;
            ModelState["ResultDocument.Path"].ValidationState = ModelValidationState.Skipped;

            if (ModelState.IsValid)
            {
                int documentsCount = _db.ResultDocuments
                    .Count(x => x.SchoolID == resultDocViewModel.ResultDocument.SchoolID &&
                    x.Year == resultDocViewModel.ResultDocument.Year);
                string resultDocumentId = helpers.createId(resultDocViewModel.ResultDocument.SchoolID,
                    resultDocViewModel.ResultDocument.Year - 1000, (documentsCount + 1) + "");
                resultDocViewModel.ResultDocument.ID = resultDocumentId;
                resultDocViewModel.ResultDocument.InsertedDate = DateTime.Now;

                int year = resultDocViewModel.ResultDocument.Year;
                int schoolId = resultDocViewModel.ResultDocument.SchoolID;
                int districtId = _db.LookUp_School.SingleOrDefault(x => x.SchoolID == schoolId).DistrictID;
                int provinceId = _db.LookUp_District.SingleOrDefault(x => x.DistrictID == districtId).ProvinceID;
                string provinceName = _db.LookUp_Province.SingleOrDefault(x => x.ProvinceID == provinceId).ProvinceNameEng.ToLower();

                var image = files[0];
                if (helpers.validateImage(image))
                {
                    string directory = helpers.documentResultsPath + "/" + 
                        provinceName + "/" + districtId + "/" + schoolId + "/" + year + "/";
                    if (helpers.createDirectory(directory))
                    {
                        try
                        {
                            resultDocViewModel.ResultDocument.Path = helpers.saveImage(image, resultDocumentId, directory); ;
                            _db.ResultDocuments.Add(resultDocViewModel.ResultDocument);

                            foreach (var student in resultDocViewModel.ResultDocumentStudents)
                            {
                                student.ResultDocumentID = resultDocumentId;
                                student.ResultDocumentNumber = resultDocViewModel.ResultDocument.TableNumber;
                                student.StudentID = helpers.createId(schoolId, year, student.AsasNumber);
                                _db.ResultDocumentStudents.Add(student);
                            }

                            _db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        catch (Exception)
                        {
                            ViewBag.error = "سکن جدول ثبت نشد، لطفآ با ادمین به تماس شوید.";
                            return View(resultDocViewModel);
                        }
                    }
                    else
                    {
                        ViewBag.error = ".فولدر جور نشد، لطفآ با ادمین به تماس شوید";
                        return View(resultDocViewModel);
                    }
                }
                else
                {
                    ViewBag.error = "عکس قابل قبول نیست، عکس ها باید با تایپ png, jpeg و jpg باشد.";
                    return View(resultDocViewModel);
                }
            }
            ViewBag.error = "معلومات کامل نیست.";
            return View(resultDocViewModel);
        }
    }
}
