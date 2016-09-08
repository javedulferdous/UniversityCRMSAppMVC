using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class StudentRegisterManager
    {
      StudentRegisterGateway studentRegisterGateway=new StudentRegisterGateway();

        public int SaveStudent(StudentRegisterModel student,string registrationNo)
        {
            return studentRegisterGateway.SaveStudent(student, registrationNo);
        }

        public StudentRegisterViewModel GetAllStudentRegister(string registrationNo)
        {
            return studentRegisterGateway.GetAllRegisterStudent(registrationNo);
        }

        public string GetDepartmentCode(int departmentId)
        {
          return  studentRegisterGateway.GetDepartmentCode(departmentId);
        }

        public string GetStudentRegisteryear(int departmentId)
        {
            return studentRegisterGateway.GetStudentRegisteryear(departmentId);
        }

        //public int GetNo(StudentRegisterModel student)
        //{
        //    return studentRegisterGateway.GetNo(student);
        //}

        public int GetNo(int departmentId)
        {
            return studentRegisterGateway.GetNo(departmentId);
        }

        //public bool CheckDeptId(int departmentId)
        //{
        //   return studentRegisterGateway.CheckDeptId(departmentId);
        //}
    }
}