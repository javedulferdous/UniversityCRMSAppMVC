using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UniversityCRMSAppWeb.Models
{
    public class ClassScheduleViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string ScheduleInfo { get; set; }       
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string RoomNo { get; set; }
        public string    DayName { get; set; }
        public string FromTime { get; set; }
        public string Totime { get; set; }
    }
}