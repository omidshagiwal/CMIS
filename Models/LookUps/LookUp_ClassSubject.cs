using Directorate_Certificate_App.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_ClassSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassSubjectID { get; set; } 
        public int ClassID { get; set; }
        public int SubjectID { get; set; } 
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int SortNo{ get; set; }


        //Relation
        public virtual LookUp_Class LookUp_Class { get; set; }
        public virtual Student_Subject Student_Subject { get; set; }

    }
}
