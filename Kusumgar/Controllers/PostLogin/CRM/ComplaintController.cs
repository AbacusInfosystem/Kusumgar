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
    public class ComplaintController : Controller
    {
        //
        // GET: /Complaint/

        public ComplaintManager _cMgr;
        public AjaxManager aMan;

        public ComplaintController()
        {
            _cMgr = new ComplaintManager();
            aMan = new AjaxManager();
        }

        public ActionResult Index(ComplaintViewModel _complaintViewModel)
        {
            try
            {
                _complaintViewModel.Pager.IsPagingRequired = false;
            }
            catch (Exception ex)
            {
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", _complaintViewModel);
        }

        public ActionResult Search(ComplaintViewModel _complaintViewModel)
        {
            if (TempData["_complaintViewModel"] != null)
            {
                _complaintViewModel = (ComplaintViewModel)TempData["_complaintViewModel"];
            }
            return View("Search", _complaintViewModel);
        }

        public ActionResult Insert(ComplaintViewModel _complaintViewModel)
        {
            try
            {
                _cMgr.Insert_Complaint(_complaintViewModel.Complaint);
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("CO001"));
            }
            catch (Exception ex)
            {
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["_complaintViewModel"] = _complaintViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update(ComplaintViewModel _complaintViewModel)
        {
            try
            {
                _cMgr.Update_Complaint(_complaintViewModel.Complaint);
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("CO002"));
            }
            catch (Exception ex)
            {
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["_complaintViewModel"] = _complaintViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult GetComplaintList(ComplaintViewModel _complaintViewModel)
        {
            try
            {
                if(!string.IsNullOrEmpty(_complaintViewModel.Complaint_Filter.CustomerName))
                {
                    _complaintViewModel.ComplaintList = _cMgr.Get_Complaints_By_CustName(_complaintViewModel.Complaint_Filter.CustomerName, _complaintViewModel.Pager);
                }
                else
                {
                    _complaintViewModel.ComplaintList = _cMgr.Get_Complaint_List(_complaintViewModel.Pager);
                }
                _complaintViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", _complaintViewModel.Pager.TotalRecords, _complaintViewModel.Pager.CurrentPage + 1, _complaintViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(_complaintViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComplaintById(ComplaintViewModel _complaintViewModel)
        {
            try
            {
                _complaintViewModel.Complaint = _cMgr.Get_Complaint_By_Id(_complaintViewModel.ComplaintId);
            }
            catch (Exception ex)
            {
                _complaintViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Index(_complaintViewModel);
        }

        public JsonResult GetCustomerId(string CustomerName)
        {
            AjaxManager aMan = new AjaxManager();
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = aMan.Get_Customer_Id(CustomerName);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }
    }
}
