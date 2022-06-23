using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupDistrict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public string NameDari { get; set; }

        [Required]
        public string NameEnglish { get; set; }

        [Required]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public LookupProvince Province { get; set; }
        
        public int? IdNew { get; set; }
    }
}
