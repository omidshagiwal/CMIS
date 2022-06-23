using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class StudentAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "حاضر ضروری میباشد.")]
        [DisplayName("حاضر")]
        [Range(0, 240, ErrorMessage = "حاضر نباید از 0 کم و از 240 زیاد شود.")]
        public int Present { get; set; }
        
        [Required(ErrorMessage = "غیر حاضر ضروری میباشد.")]
        [DisplayName("غیر حاضر")]
        [Range(0, 240, ErrorMessage = "غیر حاضر نباید از 0 کم و از 240 زیاد شود.")]
        public int Absent { get; set; }
        
        [Required(ErrorMessage = "مریض ضروری میباشد.")]
        [DisplayName("مریض")]
        [Range(0, 240, ErrorMessage = "مریض نباید از 0 کم و از 240 زیاد شود.")]
        public int Sick { get; set; }

        [Required(ErrorMessage = "رخصت ضروری میباشد.")]
        [DisplayName("رخصت")]
        [Range(0, 240, ErrorMessage = "رخصت نباید از 0 کم و از 240 زیاد شود.")]
        public int Leave { get; set; }

        [Required(ErrorMessage = "سال ضروری میباشد.")]
        [DisplayName("سال")]
        [Range(1300, 5000, ErrorMessage = "سال نباید از 1300 کم و از 5000 زیاد شود.")]
        public int Year { get; set; }

        [Required]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass LookupClass { get; set; }

        [Required]
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentProfile Student { get; set; }

        [NotMapped]
        [DisplayName("صنف")]
        public int Class { get; set; }

        [NotMapped]
        [DisplayName("اسم")]
        public string StudentName { get; set; }

        [NotMapped]
        [DisplayName("اسم پدر")]
        public string StudentFatherName { get; set; }

        [NotMapped]
        [DisplayName("مکتب")]
        public string SchoolFullName { get; set; }

        [NotMapped]
        [DisplayName("ایام تعلیمی")]
        [Range(0, 240, ErrorMessage = "ایام تعلیمی نباید از 0 کم و از 240 زیاد شود.")]
        public Nullable<int> StudyDays { get; set; }
    }
}
