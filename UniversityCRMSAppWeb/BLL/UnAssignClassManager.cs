using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;

namespace UniversityCRMSAppWeb.BLL
{
    public class UnAssignClassManager
    {
        UnAssignClassGateway unAssignClass=new UnAssignClassGateway();
        public void UnassignClassRoom()
        {
            unAssignClass.UnassignClassRoom();
        }

    }
}