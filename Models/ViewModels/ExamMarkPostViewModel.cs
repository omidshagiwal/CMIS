using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMIS.Models.ViewModels
{
    public class ExamMarksPostViewModel
    {
        [Required]
        public string StudentId { get; set; }
        public List<ExamMarks> ExamMarks { get; set; }
    }
    public class ExamMarks
    {
        [Required]
        public bool HasMarks { get; set; }
        public string Remarks { get; set; }
        [Required]
        [Range(10, 12)]
        public int Grade { get; set; }
        [Required]
        public string Position { get; set; }
        public List<SubjectMark> SubjectsMark { get; set; }
    }

    public class SubjectMark
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        [Range(0, 100)]
        public int Mark { get; set; }
    }
}
