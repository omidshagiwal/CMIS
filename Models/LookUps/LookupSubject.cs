using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookupSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "اسم ضروری میباشد.")]
        [DisplayName("اسم")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "اسم انگلیسی ضروری میباشد.")]
        [DisplayName("اسم انگلیسی")]
        public string NameEnglish { get; set; }
        
        [DisplayName("ملاحظات")]
        public string Remarks { get; set; } 
        
        [DisplayName("حالت")]
        public Nullable<bool> Status { get; set; }
        
        [DisplayName("نمبر ترتیب در شهادتنامه")]
        public int? CertficateOrderNo { get; set; }
        
        [DisplayName("نمبر ترتیب")]
        public int? ViewOrder { get; set; }
    }
}
