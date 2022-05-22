using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models
{
    public class StudentAdmission
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string Id { get; set; }
        [Required]
        [DisplayName("اساس نمبر")]
        public string AsasNo { get; set; }
        [Required]
        [DisplayName("سال فراغت")]
        public int GraduationYear { get; set; }
        [Required]
        [DisplayName("حالت")]
        public bool Status { get; set; }

        public string StudentId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        public int ClassId { get; set; }
        public string SchoolId { get; set; }
        public int SchoolProvinceId { get; set; }
		public int SchoolDistrictId { get; set; }
    }
}
