using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class ExamMark
    {
        //primaryKey
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        //primaryKey
        [Required]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentProfile StudentProfile { get; set; }
        
        //primaryKey
        [Required(ErrorMessage = "صنف ضروری میباشد.")]
        [DisplayName("صنف")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass LookupClass { get; set; }

        [Required(ErrorMessage = "نمره ضروری میباشد.")]
        [DisplayName("نمره")]
        public int Marks { get; set; }

        [DisplayName("نوع امتحان")]
        public int? ExamType { get; set; }

        [Required]
        public int GraduationYear { get; set; }

        [DisplayName("چک شده؟")]
        public bool? IsCheck { get; set; }

        [Required(ErrorMessage = "مضمون ضروری میباشد.")]
        [DisplayName("مضمون")]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public LookupSubject LookupSubject { get; set; }
    }
}
