using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models.Main_Models
{
    public class Year
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearID { get; set; }
        public string YearValue { get; set; }
    }
}
