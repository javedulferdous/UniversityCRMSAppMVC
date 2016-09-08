
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class SaveResultViewModel
    {
        public int StudentId { get; set; }

        public string StudentRegId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}