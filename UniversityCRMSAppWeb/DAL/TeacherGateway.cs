using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class TeacherGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveTeacher(TeacherModel teacher)
        {
            int rowAffected;
            SqlConnection con = new SqlConnection(connectinDB);
            string query = @"INSERT INTO Teacher (DesignationId,DepartmentId,TeacherName,Address,Email,ContactNo,TakenCredit,RemainingCredit,InsertDate)
                            VALUES ('" + teacher.DesignationId + "','" + teacher.DepartmentId + "','" + teacher.TacherName + "','" + teacher.Address + "','" + teacher.Email + "','" + teacher.ContactNo + "','" + teacher.CreditToBeTaken + "',0,GETDATE())";
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

        public List<DesignationModel> GetTeacherDesignation()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "SELECT DesignationId,DesignationName FROM [Teacher.Designaion]";
            SqlCommand cmd = new SqlCommand(query, con);
            List<DesignationModel> designationlList = new List<DesignationModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DesignationModel designation = new DesignationModel();
                    designation.Id = int.Parse(reader["DesignationId"].ToString());
                    designation.Designation = reader["DesignationName"].ToString();
                    designationlList.Add(designation);
                }
                reader.Close();
            }
            con.Close();
            return designationlList;
        }

        public TeacherModel IsTecherEamilExist(string email)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM Teacher WHERE Email='" + email + "'";
            SqlCommand command = new SqlCommand(query, connection);
            TeacherModel teachers = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teachers = new TeacherModel();
                    teachers.TeacherId = int.Parse(reader["DepartmentId"].ToString());
                    teachers.TacherName = reader["TeacherName"].ToString();
                    teachers.Email = reader["Email"].ToString();
                    teachers.Address = reader["Address"].ToString();
                    teachers.ContactNo = reader["ContactNo"].ToString();
                    teachers.CreditToBeTaken = Convert.ToInt32(reader["TakenCredit"].ToString());
                    teachers.DepartmentId =Convert.ToInt32( reader["DepartmentId"].ToString());
                    teachers.DesignationId =Convert.ToInt32( reader["DesignationId"].ToString());

                }
                reader.Close();
            }
            connection.Close();
            return teachers;
        }
        public List<TeacherModel> GetAllTeacher()
        {
            SqlConnection Connection = new SqlConnection(connectinDB);
            List<TeacherModel> teachers = new List<TeacherModel>();
            string Query = "SELECT * FROM Teacher";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                TeacherModel teacher = new TeacherModel();
                teacher.TeacherId = Convert.ToInt32(Reader["TeacherId"]);
                teacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                teacher.TacherName = Reader["TeacherName"].ToString();
                teacher.CreditToBeTaken = Convert.ToDecimal(Reader["TakenCredit"]);
                teacher.RemainingCredit = Convert.ToDecimal(Reader["RemainingCredit"]);
                teachers.Add(teacher);
            }

            Reader.Close();
            Connection.Close();
            return teachers;
        }
        
    }
}