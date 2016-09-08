using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class ViewStudentDetails
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
        
    }
}