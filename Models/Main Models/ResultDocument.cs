using CMIS.Models.Main_Models;
using Microsoft.AspNetCore.Identity;
using System;
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
        [Required]
        [DisplayName("نمبر سند")]
        public string DocucmentCode { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        [DisplayName("سال")]
        public int Year { get; set; }
        [Required]
        public DateTime InsertedDate { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool ThreeYearMarks { get; set; }

        //Relationships

        //[Required]
        public string UploadedBy { get; set; }
        //public IdentityUser UploadedByUser { set; get; }
        public string UpdatedBy { get; set; }
        //public IdentityUser UpdatedByUser { set; get; }

        [Required]
        public int SchoolID { get; set; }
        public LookUp_School LookupSchool { get; set; }

        [Required]
        public int ClassID { get; set; }
        public LookUp_Class LookupClass { get; set; }

        [Required]
        public int SectionID { get; set; }
        public LookUp_Section LookupSection { get; set; }
    }
}
