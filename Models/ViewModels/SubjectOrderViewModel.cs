using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CMIS.Models.ViewModels
{
    public class SubjectOrderViewModel
    {
        public SubjectOrder SubjectOrder { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> OrderTypes { get; set; }
    }
}