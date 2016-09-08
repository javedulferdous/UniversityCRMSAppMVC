using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{ 
   
    public class SaveStudentResultManager
    {
        SaveStudentResultGateway StudentResultGateway = new SaveStudentResultGateway();
        public int SaveResult(StudentResultModel student)
        {
            return StudentResultGateway.SaveResult(student);
        }
        SaveStudentResultGateway studentResultGateway=new SaveStudentResultGateway();
        public List<SaveResultViewModel> GetAllCoursesByRegNo(string StudentRegId)
     {
         return studentResultGateway.GetAllCoursesByRegNo(StudentRegId);
     }

        DepartmentGateway departmentGateway = new DepartmentGateway();
        public int SaveDepartment(DepartmentModel department)
        {
            return departmentGateway.SaveDepartment(department);
        }

        CourseGateway courseGateway = new CourseGateway();
        public int SaveCourse(CourseModel course)
        {
            return courseGateway.SaveCourse(course);
        }

        public List<GradeLaterModel> GetAllGradeLetter()
        {
            return StudentResultGateway.GetAllGadeLetter();
        }
        //StudentRegisterGateway studentRegisterGateway = new StudentRegisterGateway();
        //public List<StudentRegisterModel> GetAllRegisterStudent()
        //{
        //    return studentRegisterGateway.GetAllRegisterStudent();
        //}
      SaveStudentResultGateway saveStudentResultGateway=new SaveStudentResultGateway();

      public List<SaveResultViewModel> GetAllRegNo()
        {
            return saveStudentResultGateway.GetAllRegNo();
        }

      public SaveResultViewModel GetstudentRegNo(int studentId)
        {
            return saveStudentResultGateway.GetstudentRegNo(studentId);
        }
    }
}