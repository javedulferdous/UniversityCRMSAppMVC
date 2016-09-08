using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        DepartmentManager departmentManager=new DepartmentManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save()
        {        
            return View();
        }
        [HttpPost]
        public ActionResult Save(DepartmentModel department)
        {
            if (department.DepartmentCode.Length < 2 || department.DepartmentCode.Length > 7)
            {
               ViewBag.message="Department code must be 2 to 7 charecter long.";
            }
            else
            {
                if (departmentManager.IsDepartmentTestExists(department))
                {
                   
                    ViewBag.message="Department code alredy exist!";
                }
                else
                {
                    departmentManager.SaveDepartment(department);
                   ViewBag.message="Department save successfuly.!";
                }
            }
            return View();
        }

        public ActionResult GetAllDepartment()
        {
            List<DepartmentModel> departments = departmentManager.GetDepartment();
            return View(departments);
        }
	}
}