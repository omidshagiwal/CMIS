using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class ResultDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }

        [Required(ErrorMessage = "انتخاب سال ضروری میباشد.")]
        [DisplayName("سال")]
        public int Year { get; set; }
        
        [Required(ErrorMessage = "سکن جدول ضروری میباشد.")]
        [DisplayName("سکن جدول")]
        public string Path { get; set; }
        
        [Required]
        public DateTime InsertedDate { get; set; }
        
        [Required(ErrorMessage = "نمبر جدول ضروری میباشد.")]
        [DisplayName("نمبر جدول")]
        [Range(1,10000)]
        public int TableNumber { get; set; }

        [Required(ErrorMessage = "انتخاب مکتب ضروری میباشد.")]
        [DisplayName("مکتب")]
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool LookupSchool { get; set; }

        [Required]
        [DefaultValue(12)]
        public int ClassId { get; set; }
        //[ForeignKey("ClassId")]
        //public LookUp_Class LookupClass { get; set; }

        [Required(ErrorMessage = "انتخاب شعبه ضروری میباشد.")]
        [DisplayName("شعبه")]
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public LookupSection LookupSection { get; set; }

        //[Required]
        public string UploadedBy { get; set; }
        //[ForeignKey("UploadedBy")]
        //public IdentityUser UploadedByUser { set; get; }
        public string UpdatedBy { get; set; }
        //[ForeignKey("UpdatedBy")]
        //public IdentityUser UpdatedByUser { set; get; }

        //unnecessary field
        [Required]
        [DefaultValue(true)]
        public bool ThreeYearMarks { get; set; }

        [InverseProperty("ResultDocument")]
        public IEnumerable<ResultDocumentStudent> Students { get; set; }
    }
}
