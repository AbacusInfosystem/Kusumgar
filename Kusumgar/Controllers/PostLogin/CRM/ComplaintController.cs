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
            if (TempData["cViewModel"] != null)
            {
                cViewModel = (ComplaintViewModel)TempData["cViewModel"];
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
                cViewModel.Complaint.Complaint_Id = _complaintMan.Insert_Complaint(cViewModel.Complaint);

                foreach (var item in cViewModel.Lot_No.Trim(',').Split(','))
                {
                    cViewModel.Complaint.ComplaintLots.Add(new ComplaintLotMappingInfo { Lot_No = Convert.ToInt32(item) });
                }

                foreach (var item in cViewModel.Complaint.ComplaintLots)
                {
                    item.Complaint_Id = cViewModel.Complaint.Complaint_Id;

                    item.CreatedBy = ((UserInfo)Session["User"]).UserId;

                    item.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                    item.CreatedOn = DateTime.Now;

                    item.UpdatedOn = DateTime.Now;

                    _complaintMan.Insert_Complaint_Lot_Mapping(item);
                }

                cViewModel.Friendly_Message.Add(MessageStore.Get("COM001"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["cViewModel"] = cViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update(ComplaintViewModel cViewModel)
        {
            try
            {
                cViewModel.Complaint.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.Complaint.UpdatedOn = DateTime.Now;
                _complaintMan.Update_Complaint(cViewModel.Complaint);

                foreach (var item in cViewModel.Lot_No.Trim(',').Split(','))
                {
                    cViewModel.Complaint.ComplaintLots.Add(new ComplaintLotMappingInfo { Lot_No = Convert.ToInt32(item) });
                }

                foreach (var item in cViewModel.Complaint.ComplaintLots)
                {
                    item.Complaint_Id = cViewModel.Complaint.Complaint_Id;

                    item.CreatedBy = ((UserInfo)Session["User"]).UserId;

                    item.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                    item.CreatedOn = DateTime.Now;

                    item.UpdatedOn = DateTime.Now;

                    _complaintMan.Insert_Complaint_Lot_Mapping(item);
                }

                cViewModel.Friendly_Message.Add(MessageStore.Get("COM002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            TempData["cViewModel"] = cViewModel;
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

                cViewModel.Complaint.ComplaintLots = _complaintMan.Get_Complaint_Lot_Mappings(cViewModel.Complaint_Id);
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

        public ActionResult Get_Complaint_Pre_Login(int customer_Id)
        {
            ComplaintViewModel cViewModel = new ComplaintViewModel();

            CustomerManager cMan = new CustomerManager();

            ComplaintManager _complaintMan = new ComplaintManager();

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            try
            {
                cViewModel.Complaint.Customer_Id = customer_Id;

                cViewModel.Complaint.Customer_Name = cMan.Get_Customer_By_Id(customer_Id).Customer_Name;

                cViewModel.Complaints = _complaintMan.Get_Complaints_By_Cust_Id(customer_Id, ref pager);

                if (TempData["cViewModel"] != null)
                {
                    cViewModel = (ComplaintViewModel)TempData["cViewModel"];

                    int Customer_Id = cViewModel.Complaint.Customer_Id;

                    string Customer_Name = cViewModel.Complaint.Customer_Name;

                    cViewModel.Complaint = new ComplaintInfo();

                    cViewModel.Complaint.Customer_Id = Customer_Id;

                    cViewModel.Complaint.Customer_Name = Customer_Name;
                }

            }
            catch(Exception ex)
            {
                   cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return View("PreLoginComplaint", cViewModel);
        }

        public ActionResult Insert_Complaint_Pre_Login(ComplaintViewModel cViewModel)
        {
            try
            {
               
                cViewModel.Complaint.CreatedOn = DateTime.Now;
                cViewModel.Complaint.UpdatedOn = DateTime.Now;
               cViewModel.Complaint.Complaint_Id = _complaintMan.Insert_Complaint(cViewModel.Complaint);

                foreach (var item in cViewModel.Lot_No.Trim(',').Split(','))
                {
                    cViewModel.Complaint.ComplaintLots.Add(new ComplaintLotMappingInfo { Lot_No = Convert.ToInt32(item) });
                }

                foreach (var item in cViewModel.Complaint.ComplaintLots)
                {
                    item.Complaint_Id = cViewModel.Complaint.Complaint_Id;

                    item.CreatedOn = DateTime.Now;

                    item.UpdatedOn = DateTime.Now;

                    _complaintMan.Insert_Complaint_Lot_Mapping(item);
                }

               // cViewModel.Complaint = new ComplaintInfo();


                cViewModel.Friendly_Message.Add(MessageStore.Get("COM001"));

                TempData["cViewModel"] = cViewModel;
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Get_Complaint_Pre_Login(cViewModel.Complaint.Customer_Id);
        }

        public ActionResult Get_Lot_No(string lot_No)
        {
            List<AutocompleteInfo> autoCompleteInfo = new List<AutocompleteInfo>();

            try
            {
                autoCompleteInfo.Add(new AutocompleteInfo
                {
                    Label = "lot001",
                    Value = 1
                });

                autoCompleteInfo.Add(new AutocompleteInfo
                {
                    Label = "lot002",
                    Value = 2
                });

                autoCompleteInfo.Add(new AutocompleteInfo
                {
                    Label = "lot003",
                    Value = 3
                });

                autoCompleteInfo.Add(new AutocompleteInfo
                {
                    Label = "lot004",
                    Value = 4
                });

                autoCompleteInfo.Add(new AutocompleteInfo
                {
                    Label = "lot005",
                    Value = 5
                });
            }
            catch(Exception ex)
            {

            }

            return Json(autoCompleteInfo, JsonRequestBehavior.AllowGet);
        }
        
    }
}
