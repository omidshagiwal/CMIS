using System;
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

        [Required(ErrorMessage = "اسم ضروری میباشد.")]
        [DisplayName("اسم")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "اسم پدر ضروری میباشد.")]
        [DisplayName("اسم پدر")]
        public string FatherName { get; set; }
        
        [Required(ErrorMessage = "اسم به انگلیسی ضروری میباشد.")]
        [DisplayName("اسم به انگلیسی")]
        public string NameEnglish { get; set; }
        
        [Required(ErrorMessage = "اسم پدر ضروری میباشد.")]
        [DisplayName("اسم پدر به انگلیسی")]
        public string FatherNameEnglish { get; set; }
        
        [Required(ErrorMessage = "تاریخ تولد ضروری میباشد.")]
        [DisplayName("تاریخ تولد")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [DisplayName("جنسیت")]
        [DefaultValue(1)]
        public int Gender { get; set; }
        
        [DisplayName("عکس")]
        public string Picture { get; set; }
        
        [DisplayName("ملاحظات")]
        public string Remarks { get; set; }
        
        [Required(ErrorMessage = "اسم پدر کلان ضروری میباشد.")]
        [DisplayName("اسم پدرکلان")]
        public string GrandFatherName { get; set; }

        [Required(ErrorMessage = "نمبر تذکره ضروری میباشد.")]
        [DisplayName("نمبر تذکره")]
        public string NID { get; set; }

        //Relationship
        [Required(ErrorMessage = "ولایت ضروری میباشد.")]
        [DisplayName("ولایت")]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public LookupProvince LookupProvince { get; set; }

        //unnecessary columns
        public int ClassEnrollment { get; set; }
        
        [DefaultValue("pro")]
        public string EntryType { get; set; }

        [DefaultValue(true)]
        public bool ThreeYearMarks { get; set; }

        //unmaped columns
        [NotMapped]
        [DisplayName("نمبر اساس")]
        public string AsasNo { get; set; }
        [NotMapped]
        [DisplayName("سال فراغت")]
        public string GraduationYear { get; set; }
        [NotMapped]
        [DisplayName("مکتب")]
        public int SchoolId { get; set; }
    }
}
