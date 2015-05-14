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

namespace Kusumgar.Controllers.PostLogin
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public RoleManager _roleMgr;

        public RoleAccessManager _roleAccessMgr;

        public RoleController()
        {
            _roleMgr = new RoleManager();

            _roleAccessMgr = new RoleAccessManager();
        }

        public ActionResult Index(RoleViewModel _roleViewModel)
        {
            try
            {
                _roleViewModel.Role_Access_List = _roleAccessMgr.Get_Access_List();

                _roleViewModel.Selecetd_Role_Access_List = _roleAccessMgr.Get_Role_Access_List_By_Role_Id(_roleViewModel.Role_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index", _roleViewModel);
        }

        public ActionResult Search(RoleViewModel _roleViewModel)
        {
            if (TempData["_roleViewModel"] != null)
            {
                _roleViewModel = (RoleViewModel)TempData["_roleViewModel"];
            }
            return View("Search", _roleViewModel);
        }

        public ActionResult Insert(RoleViewModel _roleViewModel)
        {
            try
            {
                int Role_Id = _roleMgr.Insert_Role(_roleViewModel.Role);

                _roleAccessMgr.Insert_Role_Access(Role_Id, _roleViewModel.Selected_Role_Access);

                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("RO001"));
            }
            catch (Exception ex)
            {
                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["_roleViewModel"] = _roleViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update(RoleViewModel _roleViewModel)
        {
            try
            {
                _roleMgr.Update_Role(_roleViewModel.Role);

                _roleAccessMgr.Insert_Role_Access(_roleViewModel.Role.RoleEntity.Role_Id, _roleViewModel.Selected_Role_Access);

                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("RO002"));
            }
            catch (Exception ex)
            {
                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["_roleViewModel"] = _roleViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Get_Role_By_Id(RoleViewModel _roleViewModel)
        {
            try
            {
                _roleViewModel.Role = _roleMgr.Get_Roles_By_Id(_roleViewModel.Role_Id);
            }
            catch (Exception ex)
            {
                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return Index(_roleViewModel);
        }

        public ActionResult Get_Roles(RoleViewModel _roleViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(_roleViewModel.Role_FilterVal.Role_Name))
                {
                    _roleViewModel.RoleList = _roleMgr.Get_Roles_By_Name(_roleViewModel.Role_FilterVal.Role_Name,_roleViewModel.Pager);
                }
                else
                {
                    _roleViewModel.RoleList = _roleMgr.Get_Roles(_roleViewModel.Pager);
                }

                _roleViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", _roleViewModel.Pager.TotalRecords, _roleViewModel.Pager.CurrentPage + 1, _roleViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                _roleViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_roleViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Check_Existing_Role(string Role_Name)
        {
            bool check = false;

            try
            {
                check = _roleMgr.Check_Existing_Role(Role_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

    }
}
