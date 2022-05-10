using CMIS.Models;
using CMIS.Models.Main_Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Class_Info
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public int GraduationYear { get; set; }
        //public int AdmissionID { get; set; }
        public long SchoolID { get; set; }
        public int SectionID { get; set; }
        //public int Student_Status_ID { get; set; }  //relation error
        public int EnrollmentStatusID { get; set; }
        public int DocumentOrderNo { get; set; }
        public int StudentOrderNo { get; set; }
        public bool IsVerified { get; set; }
        public System.Guid VerifiedBy { get; set; }
        public System.DateTime VerifiedDate { get; set; }
        public System.DateTime InsertedDate { get; set; }
        public string SpcialistName { get; set; }
        public string ClassPosition { get; set; }
        public string Remarks { get; set; }
        public System.Guid InsertedBy { get; set; }
        public bool IsCenterVerified { get; set; }
        public System.Guid CenterVerified_By { get; set; }
        public System.DateTime CenterVerified_Date { get; set; }
        public string CenterSpecialistName { get; set; }
        public System.Guid PromotedBy { get; set; }
        public System.DateTime PromotionDate { get; set; }
        public bool IsRecordUpdated { get; set; }
        public System.Guid UpdatedBy { get; set; }
        public System.DateTime UpdationDate { get; set; }
        public int PromotedYear { get; set; }
        public bool IsFinalVerified { get; set; }


        //Relationship
        public LookUp_Class LookUp_Class { get; set; }
        public LookUp_School LookUp_School { get; set; }
        public LookUp_Section LookUp_Section { get; set; }
        public Lookup_Enrollment_Status Lookup_Enrollment_Status { get; set; }
    }
}
