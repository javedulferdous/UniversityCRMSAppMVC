using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class ViewResultGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["UniverSityCRMS"].ConnectionString;


        public List<StudentRegisterModel> GetAllRegNo()
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT StudentRegId FROM [Student.Register]";
            SqlCommand command = new SqlCommand(query, connection);
            List<StudentRegisterModel> RegNoList = new List<StudentRegisterModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {
                StudentRegisterModel viewResult = new StudentRegisterModel();
                //studentRegister.StudentId = int.Parse(reader["StudentId"].ToString());
                //registerStudent.GradeLaterId = Convert.ToInt32(reader["GradeLaterId"]);
                viewResult.StudentRegId = reader["StudentRegId"].ToString();
                RegNoList.Add(viewResult);
            }
            reader.Close();
            // }
            connection.Close();
            return RegNoList;
        }

        //public List<EnrollCourse> GetEnrollCoursesByRegNo(string StudentRegId)
        //{
        //   SqlConnection connection=new SqlConnection(connectionDB);
        //   string queery = "SELECT Course FROM EnrollInACourse WHERE StudentRegId='"+StudentRegId+"'";
        //    SqlCommand command=new SqlCommand(queery,connection);
        //    List<EnrollCourse>enrollCoursesList=new List<EnrollCourse>();
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            EnrollCourse courseList=new EnrollCourse();
        //            courseList.Name = reader["Name"].ToString();
        //            enrollCoursesList.Add(courseList);
        //        }
        //        reader.Close();


        //    }
        //    connection.Close();
        //    return enrollCoursesList;

        //}

    }
}