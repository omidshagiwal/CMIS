using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupEnrollmentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public string Condidtion{ get; set; }

    }
}
