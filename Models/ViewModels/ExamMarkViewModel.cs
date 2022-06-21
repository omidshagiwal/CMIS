using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models.ViewModels
{
    public class ExamMarkViewModel
    {
        public String StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentFatherName { get; set; }
        public string SchoolFullName { get; set; }
        public int GraduationYear { get; set; }
        public int SchoolId { get; set; }
        public IEnumerable<SelectListItem> OrderTypes { get; set; }
        public List<ExamMarkSubjectViewModel> ExamMarks { get; set; }
    }
    public class ExamMarkSubjectViewModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? SortNumber { get; set; }
    }
}
