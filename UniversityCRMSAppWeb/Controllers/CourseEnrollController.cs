using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class CourseEnrollController : Controller
    {
        StudentManager studentManager = new StudentManager();
        CourseEnrollManager courseEnrollManager = new CourseEnrollManager();
        
        public ActionResult EnrollCourse()
        {
            ViewBag.listOfStudentRegNo = studentManager.GetAllStudents.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(CourseEnroll courseEnroll)
        {
            ViewBag.listOfStudentRegNo = studentManager.GetAllStudents.ToList();
            ViewBag.message = courseEnrollManager.EnrollCourse(courseEnroll);
            ModelState.Clear();
            return View();
        }

        
        public JsonResult GetNameEmailDepartmentByStudentId(string studentId)
        {
            var student = studentManager.GetAllStudentByStudentId(studentId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCourseByStudentDepartmentID(int studentId)
        {
            var courses = courseEnrollManager.GetAllCourseFromStudentDepartmentNames(studentId);
            var courseList = courses.Where(x => x.StudentId == studentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        
	}
}
