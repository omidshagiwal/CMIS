using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SchoolId { get; set; }
        public string SchoolNameDari { get; set; }
        public string SchoolNameEnglish { get; set; }
        public string SchoolNamePashto { get; set; }
        public string SchoolName_Previous { get; set; }
        public int DistrictId { get; set; }
        public LookUp_District District { get; set; }
        public int CurrentStageId { get; set; }
        public bool IsDeleted { get; set; }
        public string EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
