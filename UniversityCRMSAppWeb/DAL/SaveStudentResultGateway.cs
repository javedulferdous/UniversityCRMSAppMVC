using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class SaveStudentResultGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["UniverSityCRMS"].ConnectionString;

        public int SaveResult(StudentResultModel student)
        {
            int rowAffected;
            SqlConnection connection = new SqlConnection(connectionDB);
            string qurey = "INSERT INTO [StudentResult] (StudentId,CourseId,GradeLaterId,InsertDate) VALUES('" + student.StudentId + "','" + student.CourseId + "','" + student.GradeLaterId + "',GETDATE())";
            SqlCommand command=new SqlCommand(qurey,connection);
            connection.Open();
            rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<SaveResultViewModel> GetAllRegNo()
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT StudentId,StudentRegId FROM [Student.Register]";
            SqlCommand command = new SqlCommand(query, connection);
            List<SaveResultViewModel> RegNoList = new List<SaveResultViewModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {
                SaveResultViewModel registerStudent = new SaveResultViewModel();
                registerStudent.StudentId = int.Parse(reader["StudentId"].ToString());
                //registerStudent.GradeLaterId = Convert.ToInt32(reader["GradeLaterId"]);
                registerStudent.StudentRegId = reader["StudentRegId"].ToString();
                RegNoList.Add(registerStudent);
            }
            reader.Close();
            // }
            connection.Close();
            return RegNoList;
        }
        public SaveResultViewModel GetstudentRegNo(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = @"SELECT        StudentRegId FROM            [Student.Register] where StudentId= '"+studentId+"'";
            SqlCommand command = new SqlCommand(query, connection);
            SaveResultViewModel registerStudent = new SaveResultViewModel();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {                
                //registerStudent.StudentId = int.Parse(reader["StudentId"].ToString());
                //registerStudent.GradeLaterId = Convert.ToInt32(reader["GradeLaterId"]);
                registerStudent.StudentRegId = reader["StudentRegId"].ToString();
            }
            reader.Close();
            // }
            connection.Close();
            return registerStudent;
        }
        public List<GradeLaterModel> GetAllGadeLetter()
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT GradeLaterId,GradeLater FROM GradeLater";
            SqlCommand command = new SqlCommand(query, connection);
            List<GradeLaterModel> gradeList = new List<GradeLaterModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {
                GradeLaterModel saveGrade = new GradeLaterModel();
                //studentRegister.StudentId = int.Parse(reader["StudentId"].ToString());
                saveGrade.GradeLaterId =Convert.ToInt32( reader["GradeLaterId"]);
                saveGrade.GradeLater = reader["GradeLater"].ToString();
                gradeList.Add(saveGrade);
            }
            reader.Close();
            // }
            connection.Close();
            return gradeList;
        }
        public List<SaveResultViewModel> GetAllCoursesByRegNo(string StudentRegId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT *FROM SaveResultViewModel WHERE StudentRegId='" + StudentRegId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<SaveResultViewModel> courseList = new List<SaveResultViewModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
            while (reader.Read())
            {
                SaveResultViewModel courseModel = new SaveResultViewModel();

                courseModel.CourseId =Convert.ToInt32( reader["CourseId"]);
                courseModel.CourseName = reader["CourseName"].ToString();
                courseList.Add(courseModel);
            }
            reader.Close();
            }
            connection.Close();
            return courseList;
        }



    }
}