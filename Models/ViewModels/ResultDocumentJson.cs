using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIS.Models.ViewModels
{
    public class ResultDocumentJsonViewModel
    {
        public string Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public string Path { get; set; }
        public int SchoolId { get; set; }
        public int TableNumber { get; set; }
        public int Year { get; set; }
        public int DistrictId { get; set; }
        public string ProvinceName { get; set; }
        public int StudentsCount { get; set; }
    }
}
