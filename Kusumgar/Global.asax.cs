using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Kusumgar.Controllers.PostLogin.Common;
using KusumgarCrossCutting.Logging;

namespace Kusumgar
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            /* This would clear default search location of view engine.
             * And would follow the view search location defined in CustomRazorViewEngine */
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomRazorViewEngine());
            /* Ends */

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "Error";
                        break;
                    case 500:
                        // server error
                        action = "Error";
                        break;
                    default:
                        action = "Error";
                        break;
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/System/{0}/?message={1}", action, exception.Message));
            }
            else
            {

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/System/Error/?message="));
            }
        }
    }
}