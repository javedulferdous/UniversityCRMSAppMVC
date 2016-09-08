﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class CourseGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveCourse(CourseModel course)
        {
            int rowAffected;
            SqlConnection con = new SqlConnection(connectinDB);
            string query = @"INSERT INTO Course (DepartmentId,SemesterId,CourseCode,CourseName,Credit,Description,InsertDate)
                            VALUES ('" + course.DepartmentId + "','" + course.SemesterId + "','" + course.CourseCode + "','" + course.CourseName + "','" + course.Credit + "','" + course.Description + "',GETDATE())";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
        public List<DepartmentModel> GetAllDepartment()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "SELECT DepartmentId,Name FROM Depatment";
            SqlCommand cmd = new SqlCommand(query, con);
            List<DepartmentModel> departmentsList = new List<DepartmentModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DepartmentModel department = new DepartmentModel();
                    department.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    department.DepartmentName = reader["Name"].ToString();
                    departmentsList.Add(department);
                }
                reader.Close();
            }
            con.Close();
            return departmentsList;
        }
        public List<SemesterModel> GetAllSemester()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "SELECT SemesterId,SemisterName FROM Semester";
            SqlCommand cmd = new SqlCommand(query, con);
            List<SemesterModel> semesterlList = new List<SemesterModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SemesterModel semester = new SemesterModel();
                    semester.SemesterId = int.Parse(reader["SemesterId"].ToString());
                    semester.Semester = reader["SemisterName"].ToString();
                    semesterlList.Add(semester);
                }
                reader.Close();
            }
            con.Close();
            return semesterlList;
        }
        public CourseModel GetCourseByCode(string courseCode)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM Course WHERE CourseCode='" + courseCode + "'";
            SqlCommand command = new SqlCommand(query, connection);
            CourseModel courses = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    courses = new CourseModel();
                    courses.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    courses.SemesterId = int.Parse(reader["SemesterId"].ToString());
                    courses.CourseCode = reader["CourseCode"].ToString();
                    courses.CourseName = reader["CourseName"].ToString();
                    courses.Credit = Convert.ToInt32(reader["Credit"].ToString());
                    courses.Description = reader["Description"].ToString();

                }
                reader.Close();
            }
            connection.Close();
            return courses;
        }

        public List<CourseModel> GetAllCourses()
        {
            SqlConnection Connection = new SqlConnection(connectinDB);

            List<CourseModel> courses = new List<CourseModel>();
            string Query = "SELECT * FROM Course";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                CourseModel course = new CourseModel();
                course.CourseId = Convert.ToInt32(Reader["CourseId"]);
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
                course.Credit = Convert.ToDecimal(Reader["Credit"]);
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                courses.Add(course);
            }

            Reader.Close();
            Connection.Close();
            return courses;
        }
        public CourseModel GetCourseByName( string courseName)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM Course WHERE CourseName= '" + courseName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            CourseModel courses = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    courses = new CourseModel();
                    courses.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    courses.SemesterId = int.Parse(reader["SemesterId"].ToString());
                    courses.CourseCode = reader["CourseCode"].ToString();
                    courses.CourseName = reader["CourseName"].ToString();
                    courses.Credit = Convert.ToInt32(reader["Credit"].ToString());
                    courses.Description = reader["Description"].ToString();

                }
                reader.Close();
            }
            connection.Close();
            return courses;
        }

        public CourseModel GetCourseNameAndCreditByCourseId(int courseId)
        {
            SqlConnection Connection = new SqlConnection(connectinDB);

            CourseModel course = new CourseModel();
            string Query = "SELECT * FROM Course WHERE CourseId='" + courseId + "'";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {

                course.CourseId = Convert.ToInt32(Reader["CourseId"]);
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
                course.Credit = Convert.ToDecimal(Reader["Credit"]);
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

            }

            Reader.Close();
            Connection.Close();
            return course;
        }
    }
}