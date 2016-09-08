using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;

namespace UniversityCRMSAppWeb.DAL
{
    public class UnassignRoomController : Controller
    {
        UnAssignClassManager unAssignClass =new UnAssignClassManager();
        //
        // GET: /UnassignRoom/
        public ActionResult UnAssinClassRoom()
        {
            unAssignClass.UnassignClassRoom();
            return View();
        }
	}
}