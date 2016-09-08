using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class CourseEnrollGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;

        public List<ViewStudentDetails> GetAllStudentDetails(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<ViewStudentDetails> viewStudentDetailses = new List<ViewStudentDetails>();
            string Query = "SELECT * FROM ViewStudentDetail where ID='" + studentId + "'";
            SqlCommand cmd = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ViewStudentDetails aViewStudentDetails = new ViewStudentDetails();
                aViewStudentDetails.Id = Convert.ToInt32(Reader["ID"]);
                aViewStudentDetails.StudentName = Reader["StudentName"].ToString();
                aViewStudentDetails.Email = Reader["Email"].ToString();
                aViewStudentDetails.DepartmentName = Reader["Name"].ToString();
                //aViewStudentDetails.RegNo = Reader["StudentReqId"].ToString();
                viewStudentDetailses.Add(aViewStudentDetails);
            }

            Reader.Close();
            connection.Close();
            return viewStudentDetailses;
        }


        public List<ViewCourseFromStudentDepartmentName> GetAllCourseFromStudentDepartmentNames(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<ViewCourseFromStudentDepartmentName> viewCourseFromStudentDepartment = new List<ViewCourseFromStudentDepartmentName>();
            string Query = "SELECT * FROM ViewCourseFromStudentDepartmentName where StudentId='" + studentId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCourseFromStudentDepartmentName aViewStudentDepartmentName = new ViewCourseFromStudentDepartmentName();
                aViewStudentDepartmentName.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aViewStudentDepartmentName.CourseName = Reader["CourseName"].ToString();
                aViewStudentDepartmentName.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aViewStudentDepartmentName.StudentId = Convert.ToInt32(Reader["StudentId"]);
                viewCourseFromStudentDepartment.Add(aViewStudentDepartmentName);
            }

            Reader.Close();
            connection.Close();
            return viewCourseFromStudentDepartment;
        }


        public int EnrollCourse(CourseEnroll courseEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "INSERT INTO EnrollInACourse(StudentId,CourseId,Date,Status) VALUES('" + courseEnroll.StudentId + "','" + courseEnroll.CourseId + "','" + courseEnroll.EnrollDate + "','True')";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


        public string FindSameCourseForAStudent(CourseEnroll courseEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM EnrollInACourse WHERE StudentId='" + courseEnroll.StudentId + "' AND CourseId='" + courseEnroll.CourseId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            string message = null;
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                message = "This Course Already Enroll by This Student";
            }
            Reader.Close();
            connection.Close();
            return message;
        }
    }
}