using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_Student_Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int StudentSubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectNameEnglish { get; set; }
        public string Remarks { get; set; } 
        public bool Status { get; set; }
        public int? CertficateOrderNo { get; set; }
        public int ViewOrder { get; set; }
    }
}
