using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;

namespace UniversityCRMSAppWeb.DAL
{
    public class UnAssingTeacherController : Controller
    {
        //
        // GET: /UnAssingTeacher/
        UnassignTeacherManager unassignTeacher=new UnassignTeacherManager();
        public ActionResult UnAssignTeachers()
        {
            unassignTeacher.UnassignTeacher();
            return View();
        }
	}
}