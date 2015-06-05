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

namespace Kusumgar.Controllers.PostLogin
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public RoleManager _roleMgr;

        public RoleAccessManager _roleAccessMan;

        public RoleController()
        {
            _roleMgr = new RoleManager();

            _roleAccessMan = new RoleAccessManager();
        }

        public ActionResult Index(RoleViewModel rViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            try
            {
                rViewModel.Role_Accesses = _roleAccessMan.Get_Access_List();

                rViewModel.Selecetd_Role_Accesses = _roleAccessMan.Get_Role_Access_List_By_Role_Id(rViewModel.Role_Id);
            }
            catch (Exception ex)
            {
                rViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Index " + ex.ToString());
            }

            return View("Index", rViewModel);
        }

        public ActionResult Search(RoleViewModel rViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["rViewModel"] != null)
            {
                rViewModel = (RoleViewModel)TempData["rViewModel"];
            }
            return View("Search", rViewModel);
        }

        public ActionResult Insert(RoleViewModel rViewModel)
        {
            try
            {
                rViewModel.Role.CreatedBy = ((UserInfo)Session["User"]).UserId;

                rViewModel.Role.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                int role_Id = _roleMgr.Insert_Role(rViewModel.Role);

                _roleAccessMan.Insert_Role_Access(role_Id, rViewModel.Selected_Role_Access);

                rViewModel.Friendly_Message.Add(MessageStore.Get("RO001"));
            }
            catch (Exception ex)
            {
                rViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Insert " + ex.ToString());
            }

            TempData["rViewModel"] = rViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update(RoleViewModel rViewModel)
        {
            try
            {
                rViewModel.Role.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _roleMgr.Update_Role(rViewModel.Role);

                _roleAccessMan.Insert_Role_Access(rViewModel.Role.Role_Id, rViewModel.Selected_Role_Access);

                rViewModel.Friendly_Message.Add(MessageStore.Get("RO002"));
            }
            catch (Exception ex)
            {
                rViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Update " + ex.ToString());
            }

            TempData["rViewModel"] = rViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Get_Role_By_Id(RoleViewModel rViewModel)
        {
            try
            {
                rViewModel.Role = _roleMgr.Get_Role_By_Id(rViewModel.Role_Id);
            }
            catch (Exception ex)
            {
                rViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Get_Role_By_Id " + ex.ToString());
            }
            return Index(rViewModel);
        }

        public JsonResult Get_Roles(RoleViewModel rViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = rViewModel.Pager;

                if (rViewModel.Filter.Role_Id != 0)
                {
                    rViewModel.Roles = _roleMgr.Get_Roles_By_Id(rViewModel.Filter.Role_Id,ref pager);
                }
                else
                {
                    rViewModel.Roles = _roleMgr.Get_Roles(ref pager);
                }

                rViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", rViewModel.Pager.TotalRecords, rViewModel.Pager.CurrentPage + 1, rViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                rViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Get_Roles " + ex.ToString());
            }

            return Json(rViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Existing_Role(string role_Name)
        {
            bool check = false;

            try
            {
                check = _roleMgr.Check_Existing_Role(role_Name);
            }
            catch (Exception ex)
            {
                Logger.Error("Role Controller - Check_Existing_Role " + ex.ToString());
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Roles_By_Name(string name)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _roleMgr.Get_Roles_By_Name(name);
            }
            catch (Exception ex)
            {
                Logger.Error("Role Controller - Get_Roles_By_Name " + ex.ToString());
            }


            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }

    }
}
