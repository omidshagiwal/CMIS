using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class IssuedCertificate
    { 
        public string? StudentId { get; set; }

        public int? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public LookupDistrict LookupDistrict { get; set; }


        public string? SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool LookupSchool { get; set; }

        public StudentClassInfo StudentClassInfo { get; set; }

        public int GraduationYear { get; set; }
        
        public int RegisterationNo { get; set; }
        public int PageNo { get; set; }
        public string Path { get; set; }
        public DateTime? GeneratedDate { get; set; }
        
        public string GeneratedBy { get; set; }
        //user model
    }
}
