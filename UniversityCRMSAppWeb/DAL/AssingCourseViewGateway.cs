using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCRMSAppWeb.DAL
{
    public class AssingCourseViewGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;

        public decimal GetTakenCredit(int dId, int tId)
        {
            SqlConnection Connection = new SqlConnection(connectinDB);

            decimal takenCredit = 0;
            string Query = "SELECT * FROM CourseAssigneView WHERE DepartmentId=" + dId + " AND TeacherId=" + tId + "";
            SqlCommand Command = new SqlCommand(Query, Connection);
            
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                takenCredit += Convert.ToDecimal(Reader["Credit"]);
            }
            Connection.Close();
            Reader.Close();
            return takenCredit;
        }
    }
}