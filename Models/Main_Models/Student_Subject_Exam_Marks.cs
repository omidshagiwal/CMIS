using CMIS.Models; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Subject_Exam_Marks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
        public int Marks { get; set; }
        public int ExamType { get; set; }
        public int GraduationYear { get; set; }
        public bool IsCheck { get; set; }


        //relationship

        public StudentProfile student_profile { get; set; }
        public LookUp_Class lookup_class { get; set; }
        public Student_Subject student_subject { get; set; }

    }
}
