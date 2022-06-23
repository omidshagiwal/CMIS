using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models
{
    public class ResultDocumentRegulation
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="سال ضروری میباشد.")]
        [DisplayName("سال")]
        public int Year { get; set; }
        [Required(ErrorMessage = "تعداد شاگرد ها در سال ضروری میباشد.")]
        [DisplayName("تعداد شاگرد ها در سال")]
        [Range(1, 10000, ErrorMessage = "تعداد شاگرد ها نمیتواند از ۱ کم و از ۱۰۰۰۰ زیاد شود.")]
        public int TotalStudentsPerYear { get; set; }

        [Required(ErrorMessage = "تعداد شاگرد ها در صفحه ضروری میباشد.")]
        [DisplayName("تعداد شاگرد ها در صفحه")]
        [Range(1, 10, ErrorMessage = "تعداد شاگرد ها نمیتواند از ۱ کم و از ۱۰ زیاد شود.")]
        public int StudentsPerDocument { get; set; }

        [Required]
        [DefaultValue(false)]
        [DisplayName("شاگرد ها در جدول متحول است")]
        public bool IsVariable { get; set; }

        [Required(ErrorMessage = "مکتب ضروری میباشد.")]
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool LookupSchool { get; set; }
    }
}
