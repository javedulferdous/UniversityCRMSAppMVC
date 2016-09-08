using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class StudentRegisterGateway
    {
        string connectionDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveStudent(StudentRegisterModel student, string registrationNo)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = @"INSERT INTO [Student.Register] (StudentRegId,StudentName,Email,ContactNo,RegisterDate,Address,DepartmentId,InsertDate)
                          VALUES ('" + registrationNo + "','" + student.StudentName + "','" + student.Email + "','" + student.ContactNo + "','" + student.RegisterDate + "','" + student.Address + "','" + student.DepartmentId + "',GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public StudentRegisterViewModel GetAllRegisterStudent(string registrationNo)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = @"SELECT  [Student.Register].StudentRegId, [Student.Register].StudentName, Depatment.Name, [Student.Register].Email, [Student.Register].ContactNo, [Student.Register].RegisterDate, [Student.Register].Address
                            FROM Depatment INNER JOIN  [Student.Register] ON Depatment.DepartmentId = [Student.Register].DepartmentId
                            where StudentRegId='" + registrationNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            StudentRegisterViewModel studentRegister = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {
              studentRegister=  new StudentRegisterViewModel();
                studentRegister.StudentRegisterId = reader["StudentRegId"].ToString();
                studentRegister.StudentName = reader["StudentName"].ToString();
                studentRegister.ContactNo =Convert.ToInt32( reader["ContactNo"].ToString());
                studentRegister.Address = reader["Address"].ToString();
                studentRegister.Email = reader["Email"].ToString();
                studentRegister.DepartmentName = reader["Name"].ToString();
                studentRegister.RegisterDate =Convert.ToDateTime( reader["RegisterDate"].ToString());

                
            }
            reader.Close();
            connection.Close();
            return studentRegister;
        }
        
        public string GetDepartmentCode(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string departmentCode = "";
            string query = "select DepartmentCode from Depatment where DepartmentId='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string getCode = reader["DepartmentCode"].ToString();
                departmentCode = getCode;
            }
            reader.Close();
            connection.Close();
            return departmentCode;
        }
        //public bool CheckDeptId(int departmentId)
        //{
        //    SqlConnection connection = new SqlConnection(connectionDB);
        //    int departmentIdcheck = 0;
        //    string query = "select DepartmentId from [Student.Register] where DepartmentId='" + departmentId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        int getCode =Convert.ToInt32( reader["DepartmentId"].ToString());
        //        departmentIdcheck = getCode;
        //    }
        //    reader.Close();
        //    connection.Close();
        //    if (departmentIdcheck >0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public string GetStudentRegisteryear(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string registerYear = "";
            string query = "select distinct RegisterDate from [Student.Register] where RegisterDate=(SELECT MAX(RegisterDate) FROM [Student.Register] where DepartmentId='" + departmentId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string getYear =reader["RegisterDate"].ToString();
                    string[] splitWords = getYear.Split('/',' ',':');
                    registerYear = splitWords[2];
                }
            }
            reader.Close();
            connection.Close();
            return registerYear;
        }
        //public int GetNo( StudentRegisterModel student)
        //{
        //    int studentId=0;
        //    SqlConnection connection = new SqlConnection(connectionDB);
        //    string query = "select MAX (StudentRegId) from [Student.Register] where DepartmentId='" + student.DepartmentId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string getCode = reader["StudentRegId"].ToString();
        //        studentId =Convert.ToInt32( getCode.Substring(9, 3));
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return studentId;
        //}
        public int GetNo( int departmentId)
        {
            int studentId = 0;
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "select StudentRegId from [Student.Register] where StudentRegId=(SELECT MAX(StudentRegId) FROM [Student.Register] where DepartmentId='" + departmentId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string getCode = reader["StudentRegId"].ToString();
                //studentId = Convert.ToInt32(getCode.Substring(9, 3));

                string[] splitWords = getCode.Split('-');
                studentId = Convert.ToInt32(splitWords.Last());
            }
            reader.Close();
            connection.Close();
            return studentId;
        }
    }
}