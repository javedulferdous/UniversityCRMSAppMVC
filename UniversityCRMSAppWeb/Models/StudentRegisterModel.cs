using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class StudentRegisterModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        public string StudentName { get; set; }
         [Required]
         [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a valid Contact number")]
        [StringLength(11,MinimumLength = 11)]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Enter a Address")]
        public string Address { get; set; }
        public string StudentRegId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string  DepartmenName { get; set; }
       
        public int DepartmentId { get; set; }
    }
}