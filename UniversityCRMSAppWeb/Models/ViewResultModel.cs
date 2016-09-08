using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class ViewResultModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string GradeLaterId { get; set; }
        public int StudentId { get; set; }

    }
}