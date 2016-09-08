using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public IEnumerable<Student> GetAllStudents
        {
            get { return studentGateway.GetAllStudents(); }
        }


        //public ViewStudentDetails GetAllStudentByStudentId(int id) 
        //{
        //    return studentGateway.GetAllStudentsByStudentId(id);
        //}
        public ViewStudentDetails GetAllStudentByStudentId(string StudentRegId)
        {
            return studentGateway.GetAllStudentsByStudentId(StudentRegId);
        }

        public ViewStudentDetails GetAllStudentsByStudentRegId(string StudentRegId)
        {
            return studentGateway.GetAllStudentsByStudentRegId(StudentRegId);
        }


        public List<ViewResultDetail> GetCourseCodeNameGradeByStudentId(string StudentRegId)
        {
            return studentGateway.GetCourseCodeNameGradeByStudentId(StudentRegId);
        }
    }

   
}
