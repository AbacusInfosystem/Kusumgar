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
    public class PackingController : Controller
    {
        //
        // GET: /Packing/

        public PackingManager _packingMan;

        public PackingController()
        {
            _packingMan = new PackingManager();
        }

        public ActionResult Index(PackingViewModel pViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Packing Controller - Index " + ex.ToString());
            }
            return View("Index", pViewModel);
        }

        public ActionResult Search(PackingViewModel pViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            PaginationInfo pager = new PaginationInfo();
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (PackingViewModel)TempData["pViewModel"];
            }
            pager = pViewModel.Pager;
            return View("Search", pViewModel);
        }

        public ActionResult Insert(PackingViewModel pViewModel)
        {
            try
            {
                pViewModel.Packing.CreatedBy = ((UserInfo)Session["User"]).UserId;
                pViewModel.Packing.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                pViewModel.Packing.CreatedOn = DateTime.Now;
                pViewModel.Packing.UpdatedOn = DateTime.Now;
                _packingMan.Insert_Packing(pViewModel.Packing);
                pViewModel.Friendly_Message.Add(MessageStore.Get("PC001"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Packing Controller - Insert " + ex.ToString());
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update(PackingViewModel pViewModel)
        {
            try
            {
                pViewModel.Packing.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                pViewModel.Packing.UpdatedOn = DateTime.Now;
                _packingMan.Update_Packing(pViewModel.Packing);
                pViewModel.Friendly_Message.Add(MessageStore.Get("PC002"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Packing Controller - Update " + ex.ToString());
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search");
        }

        public JsonResult Get_Packing(PackingViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            pager = pViewModel.Pager;
            try
            {
                if (pViewModel.Filter.Packing_Id != 0)
                {
                    pViewModel.Packings = _packingMan.Get_Packing_By_Id(pViewModel.Filter.Packing_Id, ref pager);
                }
                else
                {
                    pViewModel.Packings = _packingMan.Get_Packings(ref pager);
                }
                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Packing Controller - Get_Packing " + ex.ToString());
            }
            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Packing_By_Packing_Id(PackingViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pViewModel.Packing = _packingMan.Get_Packing_By_Packing_Id(pViewModel.Packing_Id);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Packing Controller - Get_Packing_By_Packing_Id " + ex.ToString());
            }
            return Index(pViewModel);
        }

        public JsonResult Get_Packing_By_Name_Autocomplete(string packing_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = _packingMan.Get_Packing_By_Name_Autocomplete(packing_Name);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }

    }
}
