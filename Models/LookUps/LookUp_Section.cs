using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class LookUp_Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int SectionID { get; set; }
        public string SectionNumber { get; set; }
        public string SectionEnglish { get; set; }


    }
}
