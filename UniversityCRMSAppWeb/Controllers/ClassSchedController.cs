using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;
namespace UniversityCRMSAppWeb.Controllers 
{
    public class ClassSchedController : Controller
    {
        //
        // GET: /ClassSchedule/
       DepartmentManager departmentManager=new DepartmentManager();
        ClassScheduleManager classScheduleManager=new ClassScheduleManager();
        public ActionResult ClassSchedule()  
        {
            ViewBag.Department = departmentManager.GetDepartment();
            //ViewBag.PostBack = false;
            return View();
        }
        [HttpPost]
        public ActionResult ClassSchedule(DepartmentModel department)
        {
             List<ClassScheduleViewModel> courClassScheduleList =classScheduleManager.GetAllCoursesByDepartment(department);
             List<ClassScheduleViewModel> classScheduleList = classScheduleManager.GetAllCoursesByDepartment(department);
            var scheduleList =
                courClassScheduleList.Select(a => new {a.CourseCode, a.CourseName}).Distinct();
            var schedule = classScheduleList;
             ViewBag.classSchedule = scheduleList;
            //List<ClassScheduleViewModel> courClassScheduleList = classScheduleManager.GetAllClassSheduleIntoList();
            //var scheduleList = courClassScheduleList.Where(a => a.DepartmentId == department.DepartmentId);
            //ViewBag.classSchedule = scheduleList;

            ViewBag.Department = departmentManager.GetDepartment();

            //ViewBag.PostBack = true;
            return View();
        }

        //public JsonResult GetCourseByDepartmentId(int deptId)
        //{
        //    var classSchedule = classScheduleManager.GetAllCoursesByDepartment();
        //    var courseList = classSchedule.Where(a => a.DepartmentId == deptId).ToList();
        //    return Json(courseList, JsonRequestBehavior.AllowGet);
        //}
	}
}