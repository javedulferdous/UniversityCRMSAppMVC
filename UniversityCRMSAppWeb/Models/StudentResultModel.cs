using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class StudentResultModel
    {
        public int  Id { get; set; }
        public int CourseId { get; set; }
        public string GradeLaterId { get; set; }
        public int StudentId { get; set; }



    }
}