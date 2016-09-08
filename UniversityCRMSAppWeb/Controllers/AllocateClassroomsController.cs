using System.Linq;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class AllocateClassroomsController : Controller
    {
        //
        // GET: /AllocateClassrooms/
        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
        public ActionResult AllocateClassRoom()
        {
            ViewBag.Department = allocateClassroomManager.GetAllDepartment();
            ViewBag.RoomNo = allocateClassroomManager.GetallRoom();
            ViewBag.Day = allocateClassroomManager.GetAllDay();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassRoom(AllocateClassroomModel allocate)
        {
            var allocateClassRoom = allocateClassroomManager.GetScheduleTimeOverlape();
            if (allocateClassRoom != null)
            {
                var allocateRoomOverlapList =
                    allocateClassRoom.Where(a =>a.DayId == allocate.DayId ||(a.FromTime > allocate.FromTime && a.ToTime < allocate.ToTime)).ToList();
                    // if ((roomAllocation.StartTime >= allocation.StartTime && roomAllocation.StartTime < allocation.EndTime)
                        // || (roomAllocation.EndTime > allocation.StartTime && roomAllocation.EndTime <= allocation.EndTime) && roomAllocation.Status=="Allocated")
                    
                if (allocateRoomOverlapList.Count==0)
                {
                    if(allocateClassroomManager.AllocateClassroom(allocate)> 0)
                    {
                        ViewBag.message = "Allocate Successfully!";
                    }
                    else
                    {
                        ViewBag.message = "Failed to Allocate!";
                    }
                 
                }
                else
                {

                    ViewBag.message = "time Overlaped";
                }
            }
            else
            {
                ViewBag.message = "No course assgined!";
            }
            ViewBag.Department = allocateClassroomManager.GetAllDepartment();
            ViewBag.RoomNo = allocateClassroomManager.GetallRoom();
            ViewBag.Day = allocateClassroomManager.GetAllDay();
            return View();
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var course = allocateClassroomManager.GetAllCourse();
            var courseList = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetCourseByDepartmentId(int departmentId)
        //{
        //    var course = allocateClassroomManager.GetAllCourse();
        //    var courseList = course.Where(s => s.DepartmentId == departmentId).ToString();
        //    return Json(courseList, JsonRequestBehavior.AllowGet);
        //}



    }
}