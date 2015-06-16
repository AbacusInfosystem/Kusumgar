using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities.Common;
using KusumgarBusinessEntities;
using System.Net;
namespace Kusumgar
{
    public class AuthorizeUserAttribute: AuthorizeAttribute, IAuthorizationFilter
    {
        public readonly AppFunction _appFunction;

        public AuthorizeUserAttribute(AppFunction appFunction)
        {
            _appFunction = appFunction;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            UserInfo userInfo = (UserInfo)HttpContext.Current.Session["User"];

            //check if user contains specified access function

            //if (userInfo != null && userInfo.Roles.Count() != 0 && userInfo.Roles.Any(r => r.RoleName == _appFunction.ToString()))
            if (userInfo != null && userInfo.Access_Functions.Count() != 0 && userInfo.Access_Functions.Any(r => r.Access_Function_Name == _appFunction.ToString()))
            {
                // Log Activity.
            }
            else
            {

                if (userInfo == null)
                {
                    //filterContext.RequestContext.HttpContext.Response.Redirect("/");
                    throw new Exception();
                }
                else
                {
                    // Log Activity

                    filterContext.Result = new HttpUnauthorizedResult();

                    /* check if request is ajax, then send unathorize status code.*/

                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        HttpContext.Current.Response.Clear();

                        HttpContext.Current.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        filterContext.RequestContext.HttpContext.Response.Redirect(string.Format("/system/unauthorize-access/{0}", HttpContext.Current.Request.Url.AbsolutePath));
                    }
                }
            }
        }
    }
}