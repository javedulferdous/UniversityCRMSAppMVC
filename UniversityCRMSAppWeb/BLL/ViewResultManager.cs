using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    
    public class ViewResultManager
    {
        ViewResultGateway viewResult = new ViewResultGateway();
        public List<StudentRegisterModel> GetAllRegNo()
        {
            return viewResult.GetAllRegNo();
        }

        //public List<EnrollCourse> GetEnrollCoursesByRegNo(string StudentRegId)
        //{
        //    return viewResult.GetEnrollCoursesByRegNo(StudentRegId);
        //}
    }
}