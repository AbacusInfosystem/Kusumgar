using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Kusumgar.Models.PreLogin;
using Kusumgar.Common;


namespace Kusumgar.Controllers.PreLogin
{
    public class AuthenticationController : Controller
    {
        
        [HttpPost]
        public ActionResult Authenticate(LoginViewModel loginViewModel)
        {
            try
            {
                //LoginManager lMan = new LoginManager();

                //UserInfo user = lMan.AuthenticateUser(loginViewModel.Login.Username, loginViewModel.Login.Password);

                //if (user.UserId != 0 && user.IsActive == true)

                if (loginViewModel.Employee.UserName == "admin" && loginViewModel.Employee.Password == "admin")
                {

                    FormsAuthentication.SetAuthCookie(loginViewModel.Employee.UserName, false);

                    //set values in Users Session object.

                    SetUsersSession(loginViewModel.Employee.UserName, loginViewModel.Employee.Password);

                    if (Session["returnURL"] != null && !string.IsNullOrEmpty(Session["returnURL"].ToString()))
                    {
                        string returnURL = Session["returnURL"].ToString();

                        Session.Remove("returnURL");

                        Response.Redirect(returnURL);
                    }

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    if (loginViewModel.Employee.EmployeeId != 0 && loginViewModel.Employee.IsActive == false)
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS06");
                    }
                    else
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS03");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Clear();

                loginViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                return RedirectToAction("Index", "Home", loginViewModel);
            }
        }

        public ActionResult Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                LogoutUser();
            }
            catch (Exception ex)
            {
                //Logger.Error("HomeController - Logout: " + ex.ToString());
            }

            return View("Index", loginViewModel);
        }

        private void SetUsersSession(string username, string password)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                //LoginManager lMan = new LoginManager();

                //userViewModel.User = lMan.SetSession(username, password);

                loginViewModel.Employee.EmployeeId = 1;

                loginViewModel.Employee.EmployeeName = "Shakti";

                loginViewModel.Employee.UserName = "admin";

                // you should not keep password in session object.

                loginViewModel.Employee.IsActive = true;

                if (HttpContext.Session["User"] == null)
                {
                    HttpContext.Session.Add("User", loginViewModel.Employee);
                }
                else
                {
                    HttpContext.Session["User"] = loginViewModel.Employee;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Clear();

                //Logger.Error("HomeController - SetUsersSession: " + ex.ToString());
            }
        }

        private void LogoutUser()
        {
            Session["User"] = null;

            Session["ReturnURL"] = null;

            FormsAuthentication.SignOut();

            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Cache-Control", "no-cache");

            Response.Cache.SetNoStore();

            Response.AddHeader("Pragma", "no-cache");

            Response.Redirect("/");
        }
    }
}
