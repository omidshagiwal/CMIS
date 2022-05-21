using Directorate_Certificate_App.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models
{
    public class Result_Document_Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultDocucmentStudentID { get; set; }
        public int? studentID { get; set; }
        public int AssasNo { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int ResultBookOrderNo { get; set; }
        public int ClassOrderNo { get; set; }
        public int StudentOrderNo { get; set; }

        //Relationship
        public virtual Student_Profile Student_Profile { get; set; }

    }
}
