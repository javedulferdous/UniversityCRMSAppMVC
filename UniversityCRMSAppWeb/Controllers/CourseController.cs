using System;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        CourseManager courseManager = new CourseManager();
        public ActionResult SaveCourse()
        {
            ViewBag.Department = courseManager.GetAllDepartment();
            ViewBag.Semister = courseManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(CourseModel course)
        {
            if (course.SemesterId == 0 || course.DepartmentId == 0)
            {
               ViewBag.message="Please select departmnet and semester!";
            }
            else
            {
                if (courseManager.IsCourseCodeExist(course.CourseCode))
                {
                    ViewBag.message="Course code alredy exixt!";
                }
                if (courseManager.IsCourseNameExist( course.CourseName))
                {
                    ViewBag.message="Course name alredy exixt!";
                }
                else
                {
                    if (course.CourseName.Length < 5 )
                    {
                       ViewBag.message="Course  name must be at least 5 charecter long!";
                    }
                    else
                    {

                        if (course.Credit >Convert.ToDecimal( 0.5) && course.Credit < Convert.ToDecimal(5.1))
                        {
                            courseManager.SaveCourse(course);
                            ViewBag.message = "Course save successfuly.";
                        }
                        else
                        {
                            ViewBag.message = "Course failed to save.";
                        }
                        
                    }
                }
            }
            ViewBag.Department = courseManager.GetAllDepartment();
            ViewBag.Semister = courseManager.GetAllSemester();
            return View();
        }
    }
}