using Directorate_Certificate_App.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class Student_Issued_Certificate
    { 
        public string? StudentID { get; set; }
        public int? DistrictID { get; set; }
        public string? SchoolID { get; set; }
        public int GraduationYear { get; set; }
        public int RegisterationNo { get; set; }
        public int PageNo { get; set; }
        public string Path { get; set; }
        public string GeneratedBy { get; set; }
        public DateTime? GeneratedDate { get; set; }

        //Relation
        public virtual Student_Class_Info Student_Class_Info { get; set; }
        public virtual LookUp_District LookUp_District { get; set; }
        public virtual LookUp_School LookUp_School { get; set; }

    }
}
