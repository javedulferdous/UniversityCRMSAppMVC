using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class StudentGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public IEnumerable<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM [Student.Register]";
            SqlCommand Command=new SqlCommand(Query,connection);
            List<Student> students = new List<Student>();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student();

                aStudent.Id = Convert.ToInt32(Reader["StudentId"].ToString());
                aStudent.RegNo = Reader["StudentRegId"].ToString();
                aStudent.Name = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = Convert.ToDateTime(Reader["InsertDate"].ToString());
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());

                students.Add(aStudent);
            }
            Reader.Close();
            connection.Close();
            return students;
        }

        public ViewStudentDetails GetAllStudentsByStudentId(string StudentRegId)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM ViewStudentDetail where ID='" + StudentRegId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            ViewStudentDetails aStudent = new ViewStudentDetails();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {

                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentName = Reader["Name"].ToString();


            }
            Reader.Close();
            connection.Close();
            return aStudent;
        }
        public ViewStudentDetails GetAllStudentsByStudentRegId(string StudentRegId)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM ViewStudentDetail where StudentRegId='" + StudentRegId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            ViewStudentDetails aStudent = new ViewStudentDetails();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {

                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentName = Reader["Name"].ToString();


            }
            Reader.Close();
            connection.Close();
            return aStudent;
        }
       
        public List<ViewResultDetail> GetCourseCodeNameGradeByStudentId(string StudentRegId)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM ViewResultInfo where StudentRegId='" + StudentRegId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            List<ViewResultDetail> studentResultList = new List<ViewResultDetail>();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewResultDetail studentResult = new ViewResultDetail();
                studentResult.CourseCode = Reader["CourseCode"].ToString();
                studentResult.CourseName = Reader["CourseName"].ToString();
                studentResult.GradeLater = Reader["GradeLater"].ToString();
                studentResultList.Add(studentResult);


            }
            Reader.Close();
            connection.Close();
            return studentResultList;
        }

    }
}
