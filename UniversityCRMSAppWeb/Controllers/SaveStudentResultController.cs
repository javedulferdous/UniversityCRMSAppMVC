using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class SaveStudentResultController : Controller
    {
        StudentManager studentManager = new StudentManager();
        SaveStudentResultManager StudentResultManager = new SaveStudentResultManager();
        //DepartmentManager departmentManager = new DepartmentManager();
        //CourseEnrollManager courseEnrollManager = new CourseEnrollManager();
        public ActionResult StudentResult()
        {

            ViewBag.RegNo = StudentResultManager.GetAllRegNo();
            //ViewBag.Courses = StudentResultManager.GetAllCoursesByRegNo(StudentRegId);
            //ViewBag.Departments = departmentManager.GetDepartment();
            ViewBag.GetAllGradeLater = StudentResultManager.GetAllGradeLetter();
            ViewBag.PostBack = false;
            return View();
        }
        [HttpPost]
        public ActionResult StudentResult(StudentResultModel student)
        {
             
            ViewBag.RegNo = StudentResultManager.GetAllRegNo();
            //ViewBag.Courses = StudentResultManager.GetAllCoursesByRegNo( StudentRegId);           
            ViewBag.GetAllGradeLater = StudentResultManager.GetAllGradeLetter();
            if (StudentResultManager.SaveResult(student) > 0)
            {
                ViewBag.message = "Saved";
            }
            //ViewBag.Departments = departmentManager.GetDepartment();
            ViewBag.PostBack = true;
            return View();
        }

        public JsonResult GetAllCourseByRegNo(int StudentRegId)
        {
            var   studentRegistrauinId = StudentResultManager.GetstudentRegNo(StudentRegId);
            var courses = StudentResultManager.GetAllCoursesByRegNo(studentRegistrauinId.StudentRegId);
            //var courseList = courses.Where(a =>a.StudentRegId == StudentRegId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult GetNameEmailDepartmentByStudentId(int StudentRegId)
        {
            var studentRegistrauinId = StudentResultManager.GetstudentRegNo(StudentRegId);
            var student = studentManager.GetAllStudentsByStudentRegId(studentRegistrauinId.StudentRegId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
      
    }
}