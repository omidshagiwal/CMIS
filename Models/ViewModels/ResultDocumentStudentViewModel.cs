using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
