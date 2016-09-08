using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;

namespace UniversityCRMSAppWeb.BLL
{
    public class UnassignTeacherManager
    {
        UnAssignTeacherGateway unAssignTeacher=new UnAssignTeacherGateway();
        public void UnassignTeacher()
        {
            unAssignTeacher.UnassignTeacher();
        }
    }
}