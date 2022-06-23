using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupProvince
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string NameDari { get; set; }

        [Required]
        public string NamePashto { get; set; }

        [Required]
        public string NameEnglish { get; set; }
        
        public bool IsActive { get; set; }
        //public List<SelectList> ProvinceList { get; set; }
    }
}
