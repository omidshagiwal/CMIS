using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class EnrollmentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int EnrollmentStatusID { get; set; }
        public string Condidtion{ get; set; }

    }
}
