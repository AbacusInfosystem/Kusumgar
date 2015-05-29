using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using KusumgarBusinessEntities;
using KusumgarModel;
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
                LoginManager lMan = new LoginManager();

                UserInfo user = lMan.AuthenticateUser(loginViewModel.User.UserEntity.User_Name, loginViewModel.User.UserEntity.Password);

                if (user.UserEntity.UserId != 0 && user.UserEntity.Is_Active == true)

                //if (loginViewModel.User.UserEntity.User_Name == "admin" && loginViewModel.User.UserEntity.Password == "admin")
                {

                    FormsAuthentication.SetAuthCookie(loginViewModel.User.UserEntity.User_Name, false);

                    //set values in Users Session object.

                    SetUsersSession(loginViewModel.User.UserEntity.User_Name, loginViewModel.User.UserEntity.Password);

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
                    if (loginViewModel.User.UserEntity.UserId != 0 && loginViewModel.User.UserEntity.Is_Active == false)
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

                loginViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

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
                LoginManager lMan = new LoginManager();

                loginViewModel.User = lMan.SetSession(username, password);

                //loginViewModel.User.UserEntity.UserId = 1;

                //loginViewModel.Employee.EmployeeName = "Shakti";

                //loginViewModel.Employee.UserName = "admin";

                //// you should not keep password in session object.

                //loginViewModel.Employee.IsActive = true;

                if (HttpContext.Session["User"] == null)
                {
                    HttpContext.Session.Add("User", loginViewModel.User);
                }
                else
                {
                    HttpContext.Session["User"] = loginViewModel.User;
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
