using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace UniversityCRMSAppWeb.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TacherName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int DesignationId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CreditToBeTaken { get; set; }
        
        public decimal RemainingCredit { get; set; }
    }
}