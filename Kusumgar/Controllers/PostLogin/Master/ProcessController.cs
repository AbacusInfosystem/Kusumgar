using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;

namespace Kusumgar.Controllers
{
    public class ProcessController : Controller
    {
        public ProcessManager _processMan;

        public ProcessController()
        {
            _processMan = new ProcessManager();
        }

        public ActionResult Index(ProcessViewModel pViewModel)
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
            }
            return View("Index", pViewModel);
        }

        public ActionResult Search(ProcessViewModel pViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            PaginationInfo pager = new PaginationInfo();
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (ProcessViewModel)TempData["pViewModel"];
            }
            pager = pViewModel.Pager;
            return View("Search", pViewModel);
        }

        public ActionResult Insert(ProcessViewModel pViewModel)
        {
            try
            {
                pViewModel.Process.CreatedBy = ((UserInfo)Session["User"]).UserId;

                pViewModel.Process.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                pViewModel.Process.CreatedOn = DateTime.Now;

                pViewModel.Process.UpdatedOn = DateTime.Now;

                _processMan.Insert_Process(pViewModel.Process);

                pViewModel.Friendly_Message.Add(MessageStore.Get("P001"));
            }

            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            TempData["pViewModel"] = pViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update(ProcessViewModel pViewModel)
        {
            try
            {
                pViewModel.Process.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                pViewModel.Process.UpdatedOn = DateTime.Now;
                _processMan.Update_Process(pViewModel.Process);
                pViewModel.Friendly_Message.Add(MessageStore.Get("P002"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search");
        }

        public JsonResult Get_Process(ProcessViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            pager = pViewModel.Pager;
            try
            {
                if (pViewModel.Filter.Process_Id != 0)
                {
                    pViewModel.Processes = _processMan.Get_Process_By_Id(pViewModel.Filter.Process_Id, ref pager);
                }
                else
                {
                    pViewModel.Processes = _processMan.Get_Process(ref pager);
                }
                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Process_By_Process_Id(ProcessViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pViewModel.Process = _processMan.Get_Process_By_Process_Id(pViewModel.Process_Id);                
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Index(pViewModel);
        }

        public JsonResult Get_Process_By_Name_Autocomplete(string process_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = _processMan.Get_Process_By_Name_Autocomplete(process_Name);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }
    }
}
