using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class ClassSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public LookupClass Class { get; set; }

        [Required]
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public LookupSchool School { get; set; }

        [Required]
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public LookupSection Section { get; set; }
    }
}
