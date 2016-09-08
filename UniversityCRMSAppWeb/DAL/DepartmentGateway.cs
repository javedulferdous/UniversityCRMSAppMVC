﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    internal class DepartmentGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveDepartment(DepartmentModel department)
        {
            int rowAffected;
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "INSERT INTO Depatment (DepartmentCode,Name,InsetDate) VALUES ('" + department.DepartmentCode + "','" + department.DepartmentName + "',GETDATE())";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public List<DepartmentModel> GetDepartment()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "SELECT DepartmentId,DepartmentCode,Name  FROM Depatment order by DepartmentCode ";
            SqlCommand cmd = new SqlCommand(query, con);
            List<DepartmentModel> departments = new List<DepartmentModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DepartmentModel department = new DepartmentModel();
                    department.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    department.DepartmentCode = reader["DepartmentCode"].ToString();
                    department.DepartmentName = reader["Name"].ToString();
                    departments.Add(department);
                }
                reader.Close();
            }
            con.Close();
            return departments;
        }

        public DepartmentModel GetDepartmentByDeptCode(string deptCode)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string query = "SELECT *FROM Depatment WHERE DepartmentCode='" + deptCode + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DepartmentModel department = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    department = new DepartmentModel();
                    department.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    department.DepartmentName = reader["Name"].ToString();
                    department.DepartmentCode = reader["DepartmentCode"].ToString();

                }
                reader.Close();
            }
            connection.Close();
            return department;
        }
    }
}