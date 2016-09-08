using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class StudentRegisterViewModel
    {
        public string StudentRegisterId { get; set; }
        public string StudentName { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public String Address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}