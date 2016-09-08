using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class StudentRegisterController : Controller
    {
        private StudentRegisterManager studentRegisterManager = new StudentRegisterManager();
        private DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult StudentRegister()
        {
            ViewBag.Departments = departmentManager.GetDepartment();
            ViewBag.PostBack = false;
            return View();
        }

        [HttpPost]
        public ActionResult StudentRegister(StudentRegisterModel student)
        {
            string registrationNo="";
            string registerYear = studentRegisterManager.GetStudentRegisteryear(student.DepartmentId);
            string currentYear = DateTime.Now.Year.ToString();
            if (registerYear == currentYear)
            {

                string deppartmentCode = studentRegisterManager.GetDepartmentCode(student.DepartmentId);
                //generate registration number
                var code = deppartmentCode.Substring(0, 3);
                var year = DateTime.Now.Year;
                int no = studentRegisterManager.GetNo(student.DepartmentId);
                //int no = studentRegisterManager.GetNo(student);
                no = no + 1;
                registrationNo = (code + "-" + year + "-") + (no.ToString().PadLeft(3, '0'));
            }
            else
            {
                string deppartmentCode = studentRegisterManager.GetDepartmentCode(student.DepartmentId);
                //generate registration number
                var code = deppartmentCode.Substring(0, 3);
                var year = DateTime.Now.Year;
                int no = 0;
                    //studentRegisterManager.GetNo(student.DepartmentId);
                //int no = studentRegisterManager.GetNo(student);
                no = no + 1;
                registrationNo = (code + "-" + year + "-") + (no.ToString().PadLeft(3, '0'));
            }
            //-----------------------
            if (student.ContactNo.Length == 11)
            {
                studentRegisterManager.SaveStudent(student, registrationNo);
                ViewBag.message = "Saved Successfully";
                StudentRegisterViewModel allRegisterStudent = studentRegisterManager.GetAllStudentRegister(registrationNo);
                ViewBag.AllRegisterStudent = allRegisterStudent;
            }
            else
            {
                ViewBag.message = "Enter a valid 11 digit number";
            }

            ViewBag.Departments = departmentManager.GetDepartment();
            //ViewBag.PostBack = true;
            return View();
        }
    }
}