using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();
        public int SaveCourse(CourseModel course)
        {
            return courseGateway.SaveCourse(course);
        }
        public List<DepartmentModel> GetAllDepartment() //load depertment to department dropdown list
        {
            return courseGateway.GetAllDepartment();
        }

        public List<SemesterModel> GetAllSemester() //load semeter to semester dropdown list
        {
            return courseGateway.GetAllSemester();
        }

        public bool IsCourseNameExist(string courseName)
        {
            CourseModel isCodeAndNameExist = courseGateway.GetCourseByName(courseName);
            if (isCodeAndNameExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCourseCodeExist(string courseCode)
        {
            CourseModel isCodeAndNameExist = courseGateway.GetCourseByCode(courseCode);
            if (isCodeAndNameExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}