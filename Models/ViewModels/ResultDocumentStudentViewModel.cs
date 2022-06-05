using CMIS.Models.Main_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models.ViewModels
{
    public class ResultDocumentStudentViewModel
    {
        public ResultDocument ResultDocument { get; set; }
        public int ResultDocumentBookNumber { get; set; }
        public List<ResultDocumentStudent> ResultDocumentStudents { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Years { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Provinces { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Sections { get; set; }

    }
}
