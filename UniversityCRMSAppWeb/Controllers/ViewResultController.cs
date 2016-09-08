using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;

namespace UniversityCRMSAppWeb.Controllers
{
    public class ViewResultController : Controller
    {
       StudentManager studentManager = new StudentManager();
      ViewResultManager viewResult=new ViewResultManager();
        public ActionResult ResultView()
        {
            ViewBag.regNo = viewResult.GetAllRegNo();
            return View();
        }
        [HttpPost]
        public ActionResult ResultView(string StudentRegId)
        {
            ViewBag.regNo = viewResult.GetAllRegNo();
            ViewBag.Result = studentManager.GetCourseCodeNameGradeByStudentId(StudentRegId);
            return View();
        }


        //public JsonResult GetAllCourseByRegNo(string StudentRegId)
        //{
        //   ViewResultManager viewResult=new ViewResultManager();
        //    var courses = viewResult.GetEnrollCoursesByRegNo(StudentRegId);
        //    var courseList = courses.Where(a => a.CourseId ==).ToList();
        //    return Json(courseList, JsonRequestBehavior.AllowGet);

        //}
        public JsonResult GetNameEmailDepartmentByStudentId(string StudentRegId)
        {
            var student = studentManager.GetAllStudentsByStudentRegId(StudentRegId);
            //var student = studentManager.GetAllStudentByStudentId(StudentRegId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseCodeNameGradeByStudentId(string StudentRegId)
        {
            var student = studentManager.GetCourseCodeNameGradeByStudentId(StudentRegId);

            return Json(student, JsonRequestBehavior.AllowGet);
        }

        
	}
}