using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class AllocateClassroomModel
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public DateTime FromTime { get; set; }      
        public DateTime ToTime { get; set; }
    }
}