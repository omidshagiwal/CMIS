using CMIS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Attendence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttendenceID { get; set; }
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public int Year { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public int Sick { get; set; }
        public int Leave { get; set; }

        //Relationship

        public LookUp_Class Lookup_Class { get; set; }
        public StudentProfile student_profile { get; set; }
    }
}
