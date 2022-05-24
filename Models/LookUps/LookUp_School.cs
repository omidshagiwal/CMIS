using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_School
    {
        [Key]
        public int SchoolID { get; set; }
        public string SchoolNameDari { get; set; }
        public string SchoolNameEnglish { get; set; }
        public string SchoolNamePashto { get; set; }
        public string SchoolNamePrevious { get; set; }  
        public int CurrentStageId { get; set; } //is missing
        public bool IsDeleted { get; set; }
        public string EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }


        //Relation
        public int DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        public virtual LookUp_District District { get; set; }
    }
}
