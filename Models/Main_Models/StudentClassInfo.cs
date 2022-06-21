using CMIS.Models.Main_Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class StudentClassInfo
    {
        [Key, Column(Order = 1)]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentProfile Student { get; set; }

        [Key, Column(Order = 2)]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass Class { get; set; }

        [Key, Column(Order = 3)]
        public string GraduationYear { get; set; }

        public Nullable<int> SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool School { get; set; }
        
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public LookUp_Section Section { get; set; }
        
        public int EnrollmentStatusId { get; set; }
        [ForeignKey("EnrollmentStatusId")]
        public Lookup_Enrollment_Status EnrollmentStatus { get; set; }

        public bool? HasMarks { get; set; }
        public string? Remarks { get; set; }
        public string? Position { get; set; }
        public DateTime InsertedDate { get; set; }

        public string? InsertedBy { get; set; }
        public Nullable<int> StatusId { get; set; }
        public bool? IsVerified { get; set; }
        public System.Guid? VerifiedBy { get; set; }
        public System.DateTime? VerifiedDate { get; set; }
        public string? SpcialistName { get; set; }
        public bool? IsCenterVerified { get; set; }
        public System.Guid? CenterVerified_By { get; set; }
        public System.DateTime? CenterVerified_Date { get; set; }
        public string? CenterSpecialistName { get; set; }
        public System.Guid? PromotedBy { get; set; }
        public System.DateTime? PromotionDate { get; set; }
        public bool? IsRecordUpdated { get; set; }
        public System.Guid? UpdatedBy { get; set; }
        public System.DateTime? UpdationDate { get; set; }
        public bool? IsFinalVerified { get; set; }
        public Nullable<int> AdmissionId { get; set; }
        public int? DocumentOrderNo { get; set; }
        public int? StudentOrderNo { get; set; }
        public int? PromotedYear { get; set; }

    }


}
