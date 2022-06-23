using CMIS.Data;
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
    public class SubjectOrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HelpersController helpers;
        public SubjectOrderController(ApplicationDbContext db)
        {
            _db = db;
            helpers = new HelpersController(db, null);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<ExamMarkSubjectViewModel> Get(int schoolId, string year, int grade, int orderType, int orderNumber)
        {
            try
            {
                int classId = 0;
                var classObj = _db.LookupClasses.SingleOrDefault(x => x.ClassName == grade.ToString());
                
                if (classObj == null) return null;
                else classId = classObj.Id;

                if (orderType == 2)
                    return _db.SubjectsOrder.Include(a => a.LookupSubject)
                        .Where(x =>
                            x.SchoolId == schoolId &&
                            x.Year == year &&
                            x.OrderType == orderType &&
                            x.OrderNumber == orderNumber &&
                            x.ClassId == classId )
                        .Select(b => new ExamMarkSubjectViewModel {
                            SubjectId = b.SubjectId,
                            SubjectName = b.LookupSubject.Name,
                            SortNumber = b.SortNumber })
                        .OrderBy(x => x.SortNumber);

                if (orderType == 3 || orderType == 4)
                    return _db.SubjectsOrder.Include(a => a.LookupSubject)
                        .Where(x =>
                            x.OrderType == orderType &&
                            x.ClassId == classId )
                        .Select(b => new ExamMarkSubjectViewModel {
                            SubjectId = b.SubjectId,
                            SubjectName = b.LookupSubject.Name,
                            SortNumber = b.SortNumber })
                        .OrderBy(x => x.SortNumber);

                return _db.SubjectsOrder
                    .Include(a => a.LookupSubject).Where(x =>
                        x.SchoolId == schoolId &&
                        x.Year == year &&
                        x.OrderType == orderType &&
                        x.ClassId == classId )
                    .Select(b => new ExamMarkSubjectViewModel {
                        SubjectId = b.SubjectId,
                        SubjectName = b.LookupSubject.Name,
                        SortNumber = b.SortNumber })
                    .OrderBy(x => x.SortNumber);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public IActionResult Create()
        {
            SubjectOrderViewModel subjectOrderVM = new SubjectOrderViewModel();
            subjectOrderVM.Provinces = helpers.getProvinces();
            subjectOrderVM.Years = helpers.getYearsList();
            subjectOrderVM.OrderTypes = helpers.getSubjectOrderTypes();

            return View(subjectOrderVM);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SubjectOrderJson subjectOrderJson)
        {
            try
            {
                int schoolExist = _db.LookupSchools
                .Where(x => x.Id == subjectOrderJson.SchoolId)
                .Count();
                if (schoolExist <= 0 ||
                    subjectOrderJson.OrderType < 1 ||
                    subjectOrderJson.OrderType > 2 ||
                    subjectOrderJson.Year == "" ||
                    subjectOrderJson.SubjectOrder.Count < 49 ||
                    (subjectOrderJson.OrderNumber == 2 && subjectOrderJson.OrderNumber < 1)
                    )   return Json(BadRequest("معلومات کامل نیست."));

                if (subjectOrderJson.OrderType == 1)
                {
                    var orders = _db.SubjectsOrder
                        .Where(x => x.Year == subjectOrderJson.Year &&
                            x.SchoolId == subjectOrderJson.SchoolId &&
                            x.OrderType == subjectOrderJson.OrderType);
                    foreach (var item in orders)
                        _db.SubjectsOrder.Remove(item);
                }
                else if (subjectOrderJson.OrderType == 2)
                {
                    var orders = _db.SubjectsOrder
                        .Where(x => x.Year == subjectOrderJson.Year &&
                            x.SchoolId == subjectOrderJson.SchoolId &&
                            x.OrderType == subjectOrderJson.OrderType &&
                            x.OrderNumber == subjectOrderJson.OrderNumber);
                    foreach (var item in orders)
                        _db.SubjectsOrder.Remove(item);
                }
                _db.SaveChanges();
            
                foreach (var subject in subjectOrderJson.SubjectOrder)
                {
                    SubjectOrder subjectOrder = new SubjectOrder();
                    subjectOrder.SchoolId = subjectOrderJson.SchoolId;
                    subjectOrder.Year = subjectOrderJson.Year;
                    subjectOrder.OrderType = subjectOrderJson.OrderType;
                    subjectOrder.OrderNumber = subjectOrderJson.OrderNumber;
                    subjectOrder.SortNumber = subject.SortNumber;
                    subjectOrder.SubjectId = subject.SubjectId;
                    subjectOrder.ClassId = _db.LookupClasses
                        .SingleOrDefault(x => x.ClassName == subject.Class + "").Id;

                    if (subjectOrder.ClassId <= 0)
                        return Json(NotFound("صنف موجود نیست."));

                    _db.SubjectsOrder.Add(subjectOrder);
                }
                _db.SaveChanges();

                return Json(Ok("تنظیمات جدول موفقانه ثبت شد."));
            }
            catch (Exception e)
            {
                return Json(BadRequest("سرور دچار مشکل شد."));
            }
        }
    }
}
