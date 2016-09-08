using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class ViewCourseFromStudentDepartmentName
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public int StudentId { set; get; }
    }
}