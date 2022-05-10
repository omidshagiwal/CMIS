using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_StudentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int StatusID{ get; set; }
        public string StatusEnglishName { get; set; }
        public string StatusPashtoName { get; set; }

    }
}
