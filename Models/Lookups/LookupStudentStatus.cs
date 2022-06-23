using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupStudentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id{ get; set; }

        public string NameEnglish { get; set; }

        public string NamePashto { get; set; }

    }
}
