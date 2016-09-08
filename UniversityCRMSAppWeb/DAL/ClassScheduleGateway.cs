using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class ClassScheduleGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        SqlConnection connection = new SqlConnection();

        public List<ClassScheduleViewModel> GetAllCoursesByDepartment(DepartmentModel depertmnet)
        {
            connection.ConnectionString = connectionString;

            string query = @"SELECT   AllocateRoom.DepartmnetId as dId, AllocateRoom.CourseId as cId, Course.CourseCode as cCode, Course.CourseName as cName, [ClassRoom.Day].DayName+' '+ ClassRoom.RoomNo+' '+ AllocateRoom.FromTime+'-'+  AllocateRoom.ToTime as ScheduleInfo
FROM         AllocateRoom INNER JOIN
                      Course ON AllocateRoom.CourseId = Course.CourseId INNER JOIN
                      ClassRoom ON AllocateRoom.ClassRoomId = ClassRoom.RoomId INNER JOIN
                      [ClassRoom.Day] ON AllocateRoom.DayId = [ClassRoom.Day].DayId
                            WHERE (DepartmentId='" + depertmnet.DepartmentId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            List<ClassScheduleViewModel> coursesCheduleList = new List<ClassScheduleViewModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassScheduleViewModel classSchedule = new ClassScheduleViewModel();
                    classSchedule.DepartmentId = Convert.ToInt32(reader["dId"].ToString());
                    classSchedule.CourseId = Convert.ToInt32(reader["cId"].ToString());
                    classSchedule.CourseCode = reader["cCode"].ToString();
                    classSchedule.CourseName = reader["cName"].ToString();
                    classSchedule.ScheduleInfo = reader["ScheduleInfo"].ToString();
                    //classSchedule.CourseCode = reader["CourseCode"].ToString();
                    //classSchedule.CourseName = reader["CourseName"].ToString();
                    //classSchedule.RoomNo = reader["RoomNo"].ToString();
                    //classSchedule.DayName = reader["DayName"].ToString();
                    //classSchedule.Totime = reader["ToTime"].ToString();
                    //classSchedule.FromTime = reader["FromTime"].ToString();
                    coursesCheduleList.Add(classSchedule);
                }
            }
            reader.Close();
            connection.Close();
            return coursesCheduleList;
        }


        public List<ClassScheduleViewModel> GetAllClassSheduleIntoList()
        {
            connection.ConnectionString = connectionString;
            List<ClassScheduleViewModel> sheduleIntoList = new List<ClassScheduleViewModel>();
            string query = "SELECT * FROM ClassSchedule";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                ClassScheduleViewModel classSheduleIntoModel = new ClassScheduleViewModel();
                classSheduleIntoModel.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                classSheduleIntoModel.CourseId = Convert.ToInt32(Reader["Id"].ToString());
                classSheduleIntoModel.CourseCode = Reader["Code"].ToString();
                classSheduleIntoModel.CourseName = Reader["Name"].ToString();
                classSheduleIntoModel.ScheduleInfo = Reader["ScheduleInfo"].ToString();
                sheduleIntoList.Add(classSheduleIntoModel);
            }
            Reader.Close();
            connection.Close();
            return sheduleIntoList;
        }
}
}