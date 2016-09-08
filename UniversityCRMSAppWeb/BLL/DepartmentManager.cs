using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public int SaveDepartment(DepartmentModel department)
        {
            return departmentGateway.SaveDepartment(department);
        }

        public List<DepartmentModel> GetDepartment()
        {
            return departmentGateway.GetDepartment();
        }

        public bool IsDepartmentTestExists(DepartmentModel aDepartmentModel)
        {
            DepartmentModel existingDepartment = departmentGateway.GetDepartmentByDeptCode(aDepartmentModel.DepartmentCode);

            if (existingDepartment != null)
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