using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        
        [Required]
        public string SectionNumber { get; set; }

        public string SectionEnglish { get; set; }
    }
}
