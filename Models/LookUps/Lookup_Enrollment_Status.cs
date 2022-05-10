using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class Lookup_Enrollment_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int EnrollmentStatusID { get; set; }
        public string Condidtion{ get; set; }

    }
}
