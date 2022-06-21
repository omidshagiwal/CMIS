using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models.ViewModels
{
    public class SubjectOrderJson
    {
        public List<Subject> SubjectOrder { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public int OrderType { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        
    }
    public class Subject
    {
        [Required]
        public int SortNumber { get; set; }
        [Required]
        public int Class { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
