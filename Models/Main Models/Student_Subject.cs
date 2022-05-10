using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Student_Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectEngName { get; set; }
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int CertificateOrderNo { get; set; }
        public int ViewOrder { get; set; }

    }
}
