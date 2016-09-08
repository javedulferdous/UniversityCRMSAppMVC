using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class CourseViewManager
    {
        CourseViewGateway courseViewGateway = new CourseViewGateway();
        public List<CourseView> GetAllCoursesByDepartment(int DepartmentId)
        {
            return courseViewGateway.GetAllCoursesByDepartment(DepartmentId);
        }
    }
}