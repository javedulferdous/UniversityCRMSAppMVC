using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;

namespace UniversityCRMSAppWeb.BLL
{
    public class AssingCourseViewManager
    {
        AssingCourseViewGateway assingCourseViewGateway = new AssingCourseViewGateway();
        public decimal GetTakenCredit(int dId, int tId)
        {
            return assingCourseViewGateway.GetTakenCredit(dId, tId);
        }
    }
}