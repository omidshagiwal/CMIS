using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupClassSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 

        [Required]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass Class { get; set; }

        [Required]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public StudentSubject StudentSubject { get; set; }

        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int SortNo{ get; set; }
    }
}
