using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProvinceID { get; set; }
        //public List<SelectList> ProvinceList { get; set; }
        public string ProvinceNameDari { get; set; }
        public string ProvinceNameEng { get; set; }
        public string ProvinceNamePashto { get; set; }
        public bool IsActive { get; set; }
    }
}
