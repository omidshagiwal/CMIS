using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupSchool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم دری ضروری میباشد.")]
        [DisplayName("اسم دری")]
        public string NameDari { get; set; }

        [Required(ErrorMessage = "اسم پشتو ضروری میباشد.")]
        [DisplayName("اسم پشتو")]
        public string NamePashto { get; set; }

        [Required(ErrorMessage = "اسم انگلیسی ضروری میباشد.")]
        [DisplayName("اسم انگلیسی")]
        public string NameEnglish { get; set; }

        [DisplayName("اسم قبلی")]
        public string NamePrevious { get; set; }

        [Required(ErrorMessage = "ولسوالی ضروری میباشد.")]
        [DisplayName("ولسوالی")]
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public LookupDistrict District { get; set; }

        public DateTime EntryDate { get; set; }

        //user model relation
        public string EntryUserId { get; set; }

        //is missing
        public int CurrentStageId { get; set; }
        public bool IsDeleted { get; set; }
    }
}