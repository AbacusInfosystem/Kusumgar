using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Common;
using KusumgarBusinessEntities.Common;
namespace Kusumgar.Controllers
{
    public class DashboardController : Controller
    {
        [AuthorizeUser(AppFunction.EmployeeInsert)]

        public ActionResult Index()
        {
            return View();
        }

    }
}
