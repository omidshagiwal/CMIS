﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMIS.Models
{
    public class LookUp_District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameEnglish { get; set; }
        public int? DistrictIdNew { get; set; }


        //Relation
        public int ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual LookUp_Province province { get; set; }

    }
}
