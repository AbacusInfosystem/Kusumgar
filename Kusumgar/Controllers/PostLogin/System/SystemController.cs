using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;
using Kusumgar.Models;
namespace Kusumgar.Controllers.PostLogin.Common
{
    public class SystemController : Controller
    {
        public ActionResult UnAuthorize(string returnURL)
        {
            try
            {
                Session["ReturnURL"] = returnURL;

                Logger.Debug("UnAuthorize Access to UserId" + ((UserInfo)Session["User"]).UserId + " on this URL: " + returnURL); 
            }
            catch (Exception ex)
            {
                Logger.Debug(ex.ToString()); 
            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Error(string message)
        {
            return View();
        }

        public ActionResult PrintableView(string page_String, int id)
        {
          SystemViewModel sViewModel = new SystemViewModel();

          sViewModel.page_String = page_String;

          sViewModel.id = id;

            return View(sViewModel);
        }
        
       
    }
}
