using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;

namespace UniversityCRMSAppWeb.BLL
{
    public class CourseAssingManager
    {
        CourseAssignGateway courseAssignGateway = new CourseAssignGateway();

        public String Save(int did, int tid, int cid,decimal remainingCredit)
        {
            if (!courseAssignGateway.OverlapCourse(tid, cid))
            {
                if (!courseAssignGateway.AssignCourse(cid))
                {
                    if (courseAssignGateway.Save(did, tid, cid,remainingCredit) > 0)
                    {
                        return "Save Successfully";
                    }
                    else
                    {
                        return "Sorry! Save Failed";
                    }
                }
                return "Course Already Assing";
            }
            return "Overlape Course";

        }

        public string UpdateTeacherId(int departmentId, int teacherId, int CourseId)
        {
            return courseAssignGateway.UpdateTeacherId(departmentId, teacherId, CourseId);
        }
    }
}