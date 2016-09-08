using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.DAL;

namespace UniversityCRMSAppWeb.Controllers
{
    public class CourseViewController : Controller
    {
        private CourseViewManager courseViewManager = new CourseViewManager();
        private DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult ViewCourse()
        {

            var departments = departmentManager.GetDepartment();
            ViewBag.Departments = departments;
            ViewBag.PostBack = false;
            return View();
        }

        [HttpPost]
        public ActionResult ViewCourse(int departmentId)
        {
            var courses = courseViewManager.GetAllCoursesByDepartment(departmentId);
            ViewBag.Courses = courses;
            var departments = departmentManager.GetDepartment();
            ViewBag.Departments = departments;           
            ViewBag.PostBack = true;
            return View();
        }


    }
}