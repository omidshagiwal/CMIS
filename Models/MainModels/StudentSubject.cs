using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class StudentSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int CertificateOrderNo { get; set; }
        public int ViewOrder { get; set; }

    }
}
