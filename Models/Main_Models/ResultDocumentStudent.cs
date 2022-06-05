using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class ResultDocumentStudent
    {
        //Primary Key and Foreign Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string ResultDocumentID { get; set; }

        [ForeignKey("ResultDocumentID")]
        public ResultDocument ResultDocument{ get; set; }

        //Primary Key
        [Key]
        [Required(ErrorMessage = "نمبر اساس ضروری میباشد.")]
        [DisplayName("نمبر اساس")]
        public string AsasNumber { get; set; }

        [Required(ErrorMessage = "اسم ضروری میباشد.")]
        [DisplayName("اسم")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "اسم پدر ضروری میباشد.")]
        [DisplayName("اسم پدر")]
        public string FatherName { get; set; }
        [Required(ErrorMessage ="نمبر جدول ضروری میباشد.")]
        [DisplayName("نمبر جدول")]
        public int ResultDocumentNumber { get; set; }
        [Required(ErrorMessage = "نمبر شعبه ضروری میباشد،")]
        [DisplayName("نمبر شعبه")]
        public int ClassSectionNumber { get; set; }
        [Required(ErrorMessage = "نمبر ترتیب شاگرد ضروری میباشد.")]
        [DisplayName("نمبر ترتیب شاگرد")]
        public int StudentOrderNumber { get; set; }
        public string StudentID { get; set; }
    }
}
