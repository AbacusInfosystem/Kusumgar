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

        public ComplaintManager _complaintMan;        

        public ComplaintController()
        {
            _complaintMan = new ComplaintManager();            
        }

        public ActionResult Index(ComplaintViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager.IsPagingRequired = false;
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", cViewModel);
        }

        public ActionResult Search(ComplaintViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            if (TempData["_complaintViewModel"] != null)
            {
                cViewModel = (ComplaintViewModel)TempData["_complaintViewModel"];
            }
            pager = cViewModel.Pager;
            return View("Search", cViewModel);
        }

        public ActionResult Insert(ComplaintViewModel cViewModel)
        {
            try
            {
                cViewModel.Complaint.CreatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.Complaint.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.Complaint.CreatedOn = DateTime.Now;
                cViewModel.Complaint.UpdatedOn = DateTime.Now;
                _complaintMan.Insert_Complaint(cViewModel.Complaint);
                cViewModel.Friendly_Message.Add(MessageStore.Get("COM001"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["_complaintViewModel"] = cViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update(ComplaintViewModel cViewModel)
        {
            try
            {
                cViewModel.Complaint.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.Complaint.UpdatedOn = DateTime.Now;
                _complaintMan.Update_Complaint(cViewModel.Complaint);
                cViewModel.Friendly_Message.Add(MessageStore.Get("COM002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["_complaintViewModel"] = cViewModel;
            return RedirectToAction("Search");
        }

        public JsonResult Get_Complaints(ComplaintViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            pager = cViewModel.Pager;
            try
            {
                if(cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Complaints = _complaintMan.Get_Complaints_By_Cust_Id(cViewModel.Filter.Customer_Id, ref pager);
                }
                else
                {
                    cViewModel.Complaints = _complaintMan.Get_Complaints(ref pager);
                }
                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(cViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Complaint_By_Id(ComplaintViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                cViewModel.Complaint = _complaintMan.Get_Complaint_By_Id(cViewModel.Complaint_Id);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Index(cViewModel);
        }

        public JsonResult Get_Customer_Id(string customer_Name)
        {
            List<AutocompleteInfo> auto_List = new List<AutocompleteInfo>();
            auto_List = _complaintMan.Get_Customer_Id(customer_Name);
            return Json(auto_List, JsonRequestBehavior.AllowGet);
        }
    }
}
