using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class ClassScheduleManager
    {
        ClassScheduleGateway classScheduleGateway=new ClassScheduleGateway();


        public List<ClassScheduleViewModel> GetAllCoursesByDepartment(DepartmentModel depertmnet)
        {
            return classScheduleGateway.GetAllCoursesByDepartment(depertmnet);
        }

        public List<ClassScheduleViewModel> GetAllClassSheduleIntoList()
        {
            return classScheduleGateway.GetAllClassSheduleIntoList();
        }
    }
}