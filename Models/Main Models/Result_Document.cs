using CMIS.Models;
using CMIS.Models.Main_Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models
{
    public class Result_Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultDocucmentID { get; set; }
        [Required]
        public string Result_Docucment_Code { get; set; }
        public int SchoolID { get; set; }
        public int ClassID { get; set; }
        public int SectionID { get; set; }
        public string Path { get; set; }
        public int Year { get; set; }
        public string UploadedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime InsertedDate { get; set; }
        public bool ThreeYearMarks { get; set; }

        //Relationship
        public virtual LookUp_School Lookup_School { get; set; }
        public virtual LookUp_Class lookup_class { get; set; }
        public virtual LookUp_Section Lookup_Section { get; set; }

    }
}
