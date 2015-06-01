using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KusumgarBusinessEntities.Common;
namespace Kusumgar.Controllers
{
    public class DashboardController : Controller
    {
        [AuthorizeUser(AppFunction.Dashboard)]

        public ActionResult Index()
        {
            return View();
        }

    }
}
