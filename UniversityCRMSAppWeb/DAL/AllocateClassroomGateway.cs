using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class AllocateClassroomGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveAllocateClassroom(AllocateClassroomModel allocateClassroom)
        {
            int rowAffected;
            SqlConnection con = new SqlConnection(connectinDB);
            string query = @"INSERT INTO AllocateRoom (DepartmnetId,CourseId,ClassRoomId,DayId,FromTime,ToTime,RoomStatus,InsertDate)
                            VALUES ('" + allocateClassroom.DepartmentId + "','"+allocateClassroom.CourseId+"','" + allocateClassroom.RoomId + "','" + allocateClassroom.DayId + "','" + allocateClassroom.FromTime.ToString("hh:mm tt") +"','" + allocateClassroom.ToTime.ToString("hh:mm tt ") + "','True',GETDATE())";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
        public List<RoomModel> GetallRoom()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "SELECT RoomId,RoomNo FROM ClassRoom";
            SqlCommand cmd = new SqlCommand(query, con);
            List<RoomModel> roomlList = new List<RoomModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RoomModel room = new RoomModel();
                    room.RoomId = int.Parse(reader["RoomId"].ToString());
                    room.RoomNo = reader["RoomNo"].ToString();
                    roomlList.Add(room);
                }
                reader.Close();
            }
            con.Close();
            return roomlList;
        }

        public List<DayModel> GetAllDay()
        {
            SqlConnection con =new SqlConnection(connectinDB);
            string query = "SELECT DayId,DayName FROM [ClassRoom.Day]";
            SqlCommand cmd = new SqlCommand(query, con);
            List<DayModel> daylList = new List<DayModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DayModel day = new DayModel();
                    day.DayId = int.Parse(reader["DayId"].ToString());
                    day.DayName = reader["DayName"].ToString();
                    daylList.Add(day);
                }
                reader.Close();
            }
            con.Close();
            return daylList;
        }
        public List<CourseModel> GetAllCourse()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "select CourseCode,CourseId, DepartmentId,CourseName,Description from  Course";
            SqlCommand cmd = new SqlCommand(query, con);
            List<CourseModel> courselList = new List<CourseModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseModel course = new CourseModel();
                    course.CourseCode = reader["CourseCode"].ToString();
                    course.CourseId =Convert.ToInt32( (reader["CourseId"]));
                    course.DepartmentId = Convert.ToInt32((reader["DepartmentId"]));
                    course.CourseName = reader["CourseName"].ToString();
                    course.Description = reader["Description"].ToString();
                    courselList.Add(course);
                }
                reader.Close();
            }
            con.Close();
            return courselList;
        }
        public List<AllocateClassroomModel> GetScheduleTimeOverlape()
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string query = "SELECT *FROM AllocateRoom";
            SqlCommand command = new SqlCommand(query, connection);
            List< AllocateClassroomModel> allocateRooms =new List<AllocateClassroomModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllocateClassroomModel allocateRoom = new AllocateClassroomModel();
                    allocateRoom.DepartmentId = int.Parse(reader["DepartmnetId"].ToString());
                    allocateRoom.DayId = int.Parse(reader["DayId"].ToString());
                    allocateRoom.CourseId = int.Parse(reader["CourseId"].ToString());
                    allocateRoom.RoomId = int.Parse(reader["ClassRoomId"].ToString());
                    allocateRoom.FromTime = Convert.ToDateTime(reader["FromTime"].ToString());
                    allocateRoom.ToTime = Convert.ToDateTime(reader["ToTime"].ToString()); 
                    allocateRooms.Add(allocateRoom);
                }
                reader.Close();
            }
            connection.Close();
            return allocateRooms;
        }
    }
}