using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class SubjectOrder
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("سال")]
        public string Year { get; set; }
        [Required(ErrorMessage = "نوع ترتیب ضروری میباشد.")]
        [DisplayName("نوع ترتیب")]
        public int OrderType { get; set; }
        [DisplayName("نمبر ترتیب")]
        public int? OrderNumber { get; set; }
        [DisplayName("نمبر")]
        public int? SortNumber { get; set; }
        [DisplayName("ملاحظات")]
        public string Remarks { get; set; }
        [DisplayName("حالت")]
        public int? Status { get; set; }

        [DisplayName("صنف")]
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass LookupClass { get; set; }

        [Required(ErrorMessage = "مضمون ضروری میباشد.")]
        [DisplayName("مضمون")]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public LookupSubject LookupSubject { get; set; }

        [DisplayName("مکتب")]
        public int? SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool LookupSchool { get; set; }

        [DisplayName("شاگرد")]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentProfile StudentProfile { get; set; }

    }
}
