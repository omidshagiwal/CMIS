using Directorate_Certificate_App.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class Student_Class_Subject_Year
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }
        public int StudentSubjectID { get; set; }
        public int SchoolID { get; set; }
        public int Year { get; set; }
        public int OrderType { get; set; }
        public int OrderNo { get; set; }
        public int SortNo { get; set; }
        public string StudentID { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }

        //Relation
        public LookUp_Subject LookUp_Student_Subject { get; set; }
        public LookUp_School LookUp_School { get; set; }
        public Student_Profile Student_Profile { get; set; }
    }
}
