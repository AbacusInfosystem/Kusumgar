using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public UserManager _userMan;

        public RoleManager _roleMan;

        public UserController ()
        {
            _userMan = new UserManager();

            _roleMan = new RoleManager();
        }

        public ActionResult Index(UserViewModel uViewModel)
        {

            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager.IsPagingRequired = false;

                uViewModel.RoleInfoList = _roleMan.Get_Roles(ref pager);
            }
            catch(Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Index " + ex.ToString());
            }

            return View("Index", uViewModel);
        }

        public ActionResult Search(UserViewModel uViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["uViewModel"] != null)
            {
                uViewModel = (UserViewModel)TempData["uViewModel"];
            }
            return View("Search", uViewModel);
        }

        public ActionResult Insert(UserViewModel uViewModel)
        {
            try
            {
                uViewModel.User.UserEntity.CreatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                uViewModel.User.UserEntity.UpdatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                _userMan.Insert_User(uViewModel.User);

                uViewModel.Friendly_Message.Add(MessageStore.Get("UM002"));
            }
            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Insert " + ex.ToString());
            }

            TempData["uViewModel"] = uViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update(UserViewModel uViewModel)
        {
            try
            {

                uViewModel.User.UserEntity.UpdatedBy = 1;

                _userMan.Update_User(uViewModel.User);

                uViewModel.Friendly_Message.Add(MessageStore.Get("UM003"));
            }
            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Update " + ex.ToString());
            }

            TempData["_userViewModel"] = uViewModel;
      
            return RedirectToAction("Search");
        }

        public ActionResult Get_User_By_Id(UserViewModel uViewModel)
        {
            try
            {
                uViewModel.User = _userMan.Get_User_By_User_Id(uViewModel.UserId);
            }
            catch (Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Get_User_By_Id " + ex.ToString());
            }
            return Index(uViewModel);
        }

        public JsonResult Get_Users(UserViewModel uViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = uViewModel.Pager;

                if (uViewModel.Filter.User_Id != 0)
                {
                    uViewModel.UserList.Add(_userMan.Get_User_By_User_Id(uViewModel.Filter.User_Id));

                    pager.TotalPages = 1;

                    pager.TotalRecords = 1;
                }
                else
                {
                    uViewModel.UserList = _userMan.Get_Users(ref pager);
                }

                uViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", uViewModel.Pager.TotalRecords, uViewModel.Pager.CurrentPage + 1, uViewModel.Pager.PageSize, 10, true);
            }
            catch(Exception ex)
            {
                uViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Get_Users " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(uViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Existing_User(string user_Name)
        {
            bool check = false; 

            try
            {
                check = _userMan.Check_Existing_User(user_Name);
            }
            catch(Exception ex)
            {
                Logger.Error("User Controller - Check_Existing_User " + ex.ToString());
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Roles_By_Name(string name)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _userMan.Get_Users_By_Name(name);
            }
            catch(Exception ex)
            {
                Logger.Error("User Controller - Check_Existing_User " + ex.ToString());
            }


            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }


    }
}
