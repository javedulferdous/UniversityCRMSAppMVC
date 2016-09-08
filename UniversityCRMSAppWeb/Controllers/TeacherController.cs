using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        TeacherManager teacherManager=new TeacherManager();
        public ActionResult SaveTeacher()
        {
            ViewBag.Department = teacherManager.GetAllDepartment();
            ViewBag.Designation = teacherManager.GetTeacherDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(TeacherModel teacher)
        {
            if (teacherManager.IsTeacherEmailExist(teacher.Email)==true)
            {
                ViewBag.message="Teacher email already exist!";
            }
            else
            {
                if (teacher.CreditToBeTaken < 0)
                {
                    ViewBag.message="Credit to be taken field must contain a non-negative value!";
                }
                else
                {
                    teacherManager.SaveTeacher(teacher);
                    ViewBag.message="Teacher save successful.";
                }
                
            }
           
            ViewBag.Department = teacherManager.GetAllDepartment();
            ViewBag.Designation = teacherManager.GetTeacherDesignation();
            return View();
        }
	}
}