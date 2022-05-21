using CMIS.Models; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentFatherName { get; set; }
        public string StudentEngName { get; set; }
        public string StudentFatherEngName { get; set; }
        public long DateOfBirth { get; set; }
        public bool StudentGender { get; set; }
        public string StudentPicPath { get; set; }
        public int ProvinceID { get; set; }
        public string Remarks { get; set; }
        public string StudentGrandFatherName { get; set; }
        public string TazkiraNumber { get; set; }
        public int ClassEnrollment { get; set; }
        public string Entry_Type { get; set; } 
        public int ThreeYearMarks { get; set; }


        //Relationship
        public virtual LookUp_Province Lookup_Province { get; set; }
    }
}
