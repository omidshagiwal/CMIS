using CMIS.Models;
using CMIS.Models.Main_Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Class_Info
    {
        [Key, Column(Order =1)]
        public int StudentID { get; set; }
        [Key, Column(Order =2)]
        public int ClassID { get; set; }
        [Key, Column(Order = 3)]
        public int GraduationYear { get; set; }    
        public int AdmissionID { get; set; }
        public long SchoolID { get; set; }
        public int SectionID { get; set; }
        public int Student_Status_ID { get; set; }
        public int EnrollmentStatusID { get; set; }
        public int? DocumentOrderNo { get; set; }
        public int? StudentOrderNo { get; set; }
        public bool? IsVerified { get; set; }
        public System.Guid? VerifiedBy { get; set; }
        public System.DateTime? VerifiedDate { get; set; }
        public System.DateTime? InsertedDate { get; set; }
        public string? SpcialistName { get; set; }
        public string? ClassPosition { get; set; }
        public string? Remarks { get; set; }
        public System.Guid? InsertedBy { get; set; }
        public bool? IsCenterVerified { get; set; }
        public System.Guid? CenterVerified_By { get; set; }
        public System.DateTime? CenterVerified_Date { get; set; }
        public string? CenterSpecialistName { get; set; }
        public System.Guid? PromotedBy { get; set; }
        public System.DateTime? PromotionDate { get; set; }
        public bool? IsRecordUpdated { get; set; }
        public System.Guid? UpdatedBy { get; set; }
        public System.DateTime? UpdationDate { get; set; }
        public int? PromotedYear { get; set; }
        public bool? IsFinalVerified { get; set; }


        //Relationship
        public virtual StudentProfile Student_Profile { get; set; }
        public virtual LookUp_Class LookUp_Class { get; set; }
        public virtual LookUp_School LookUp_School { get; set; }
        public virtual LookUp_Section LookUp_Section { get; set; }
        public virtual Lookup_Enrollment_Status Lookup_Enrollment_Status { get; set; }
    }

    
}
