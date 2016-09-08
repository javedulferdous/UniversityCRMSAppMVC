using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class CourseModel
    {
        
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
       public decimal Credit { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }
}