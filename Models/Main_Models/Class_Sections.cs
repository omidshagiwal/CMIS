using CMIS.Models;
using CMIS.Models.Main_Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorate_Certificate_App.Models.Models
{
    public class Class_Sections
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassSectionID { get; set; }
        public int ClassID { get; set; }
        public int SchoolID { get; set; }
        public int SectionID { get; set; }
        public int Year { get; set; }

        //relationship 
        public virtual LookupClass Lookup_Class { get; set; }
        public virtual LookupSchool Lookup_School { get; set; }
        public virtual LookUp_Section Lookup_Section { get; set; }
    }
}
