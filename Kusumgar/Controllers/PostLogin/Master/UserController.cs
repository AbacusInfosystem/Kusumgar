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

namespace Kusumgar.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public UserManager _userMgr;

        public RoleManager _roleMgr;

        public UserController ()
        {
            _userMgr = new UserManager();

            _roleMgr = new RoleManager();
        }

        public ActionResult Index(UserViewModel _userViewModel)
        {
            try
            {
                _userViewModel.Pager.IsPagingRequired = false;

                _userViewModel.RoleInfoList = _roleMgr.Get_Roles(_userViewModel.Pager);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View("Index",_userViewModel);
        }

        public ActionResult Search(UserViewModel _userViewModel)
        {
            if (TempData["_userViewModel"] != null)
            {
                _userViewModel = (UserViewModel) TempData["_userViewModel"];
            }
            return View("Search",_userViewModel);
        }

        public ActionResult Insert(UserViewModel _userViewModel)
        {
            try
            {
                _userMgr.Insert_User(_userViewModel.User);

                _userViewModel.FriendlyMessage.Add(MessageStore.Get("UM002"));
            }
            catch (Exception ex)
            {
                _userViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["_userViewModel"] = _userViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update(UserViewModel _userViewModel)
        {
            try
            {
                _userMgr.Update_User(_userViewModel.User);

                _userViewModel.FriendlyMessage.Add(MessageStore.Get("UM003"));
            }
            catch (Exception ex)
            {
                _userViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["_userViewModel"] = _userViewModel;
      
            return RedirectToAction("Search");
        }

        public ActionResult Get_User_By_Id(UserViewModel _userViewModel)
        {
            try
            {
                _userViewModel.User = _userMgr.Get_User_By_UserId(_userViewModel.UserId);
            }
            catch (Exception ex)
            {
                _userViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return Index(_userViewModel);
        }

        public ActionResult Get_Users(UserViewModel _userViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(_userViewModel.FilterVal.FirstName))
                {
                    _userViewModel.UserList = _userMgr.Get_User_List_By_Name(_userViewModel.Pager, _userViewModel.FilterVal.FirstName);
                }
                else
                {
                    _userViewModel.UserList = _userMgr.Get_User_List(_userViewModel.Pager);
                }

                _userViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", _userViewModel.Pager.TotalRecords, _userViewModel.Pager.CurrentPage + 1, _userViewModel.Pager.PageSize, 10, true);
            }
            catch(Exception ex)
            {
                _userViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_userViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Check_Existing_User( string User_Name)
        {
            bool check = false; 

            try
            {
                check = _userMgr.Check_Existing_User(User_Name);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

    }
}
