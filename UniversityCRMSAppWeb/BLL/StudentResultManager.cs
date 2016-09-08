using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class StudentResultManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();
        public List<DepartmentModel> GetDepartment()
        {
            return departmentGateway.GetDepartment();
        }
    }
}