using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class SemestersGateway
    {
        private string connectionString =WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<SemesterModel> GetAllSemester()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Semester";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SemesterModel> semesterlist = new List<SemesterModel>();
            while (reader.Read())
            {

                SemesterModel semester = new SemesterModel();
                semester.SemesterId = Convert.ToInt32(reader["Id"].ToString());
                semester.Semester = reader["SemesterName"].ToString();
                semesterlist.Add(semester);
            }

            reader.Close();
            connection.Close();
            return semesterlist;
        }

      
    }
}