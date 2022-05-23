using CMIS.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class StudentProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        [DisplayName("اسم")]
        public string Name { get; set; }
        [Required]
        [DisplayName("اسم پدر")]
        public string FatherName { get; set; }
        [Required]
        [DisplayName("اسم به انگلیسی")]
        public string NameEnglish { get; set; }
        [Required]
        [DisplayName("اسم پدر به انگلیسی")]
        public string FatherNameEnglish { get; set; }
        [Required]
        [DisplayName("تاریخ تولد")]
        public long DateOfBirth { get; set; }
        [Required]
        [DisplayName("جنسیت")]
        public bool Gender { get; set; }
        [DisplayName("عکس")]
        public string Picture { get; set; }
        [DisplayName("ملاحظات")]
        public string Remarks { get; set; }
        [Required]
        [DisplayName("اسم پدرکلان")]
        public string GrandFatherName { get; set; }
        [Required]
        [DisplayName("نمبر تذکره")]
        public string NID { get; set; }

        //Relationship
        [DisplayName("ولایت")]
        public int ProvinceID { get; set; }
        public LookUp_Province Lookup_Province { get; set; }

        //unnecessary columns
        public int ClassEnrollment { get; set; }
        public string Entry_Type { get; set; }
        public bool ThreeYearMarks { get; set; }

        //unmaped columns
        [NotMapped]
        [Required]
        [DisplayName("نمبر اساس")]
        public string AsasNo { get; set; }
        [NotMapped]
        [Required]
        [DisplayName("سال فراغت")]
        public string GraduationYear { get; set; }
        [NotMapped]
        [Required]
        [DisplayName("نبر مکتب")]
        public string SchoolId { get; set; }
    }
}
