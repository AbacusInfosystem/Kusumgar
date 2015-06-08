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
using System.Web.Security;

namespace Kusumgar.Controllers
{
    public class EnquiryController : Controller
    {
        //
        // GET: /Enquiry/

        public EnquiryManager _enquiryMan;

        public EnquiryController()
        {
            _enquiryMan = new EnquiryManager();
        }

        #region Enquiry

        public ActionResult Index(EnquiryViewModel eViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            try
            {

            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Index " + ex.ToString());
            }

            return View("Index", eViewModel);
        }

        public ActionResult Search(EnquiryViewModel eViewModel)
        {
            //PaginationInfo pager = new PaginationInfo();

            //try
            //{
            //    pager = eViewModel.Pager;

            //    eViewModel.Enquires = _enquiryMan.Get_Enquiries_By_Status(ref pager, Convert.ToInt32(EnquiryStatus.Enquiry_Arrived));
            //}
            //catch(Exception ex)
            //{

            //}

            return View(eViewModel);
        }

        public JsonResult Insert(EnquiryViewModel eViewModel)
        {
            EnquiryInfo enquiry = new EnquiryInfo();

            try
            {
                eViewModel.Enquiry.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.UpdatedOn = DateTime.Now;

                enquiry = eViewModel.Enquiry;

                _enquiryMan.Insert_Enquiry(ref enquiry);

                eViewModel.Enquiry = enquiry;

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ001"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert " + ex.ToString());
            }
            finally
            {
                enquiry = null;
            }

            return Json(eViewModel);
        }

        public JsonResult Update(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.UpdatedOn = DateTime.Now;

                _enquiryMan.Update_Enquiry(eViewModel.Enquiry);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ002"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Update " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Get_Enquiries(EnquiryViewModel eViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = eViewModel.Pager;

                //if (eViewModel.Filter.Customer_Id != 0)
                //{
                //    eViewModel.Contacts = eViewModel.Get_Contacts_By_Name(eViewModel.Filter.Customer_Id, ref pager);
                //}
                //else
                //{

                eViewModel.Enquiries = _enquiryMan.Get_Enquiries_By_Status(ref pager, Convert.ToInt32(EnquiryStatus.Enquiry_Arrived));
              //  }

                eViewModel.Pager = pager;

                eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Enquiries " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(eViewModel);
        }

        public JsonResult Get_Quality_Autocomplete(string quality_No)
        {
            List<AutocompleteInfo> qualities = new List<AutocompleteInfo>();

            try
            {
                qualities = _enquiryMan.Get_Quality_Autocomplete(quality_No);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(qualities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Enquiry_By_Id(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry = _enquiryMan.Get_Enquiry_By_Id(eViewModel.Enquiry.Enquiry_Id);
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Enquiry_By_Id " + ex.ToString());
            }

            return Index(eViewModel);
        }

        #endregion

        #region Staggered Order

        public JsonResult Get_Staggered_Orders(EnquiryViewModel eViewModel)
        {
            try
            {
                PaginationInfo pager = new PaginationInfo();

                pager.IsPagingRequired = false;

                if (eViewModel.Enquiry.Staggered_Order.Enquiry_Id != 0)
                {
                    eViewModel.Enquiry.Staggered_Orders = _enquiryMan.Get_Staggered_Orders_By_Enquiry_Id(eViewModel.Enquiry.Staggered_Order.Enquiry_Id,ref pager);
                }
                else
                {
                    eViewModel.Enquiry.Staggered_Orders = _enquiryMan.Get_Staggered_Orders(ref pager);
                }
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Staggered_Orders " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Insert_Staggered_Order(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Staggered_Order.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Staggered_Order.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Staggered_Order.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.Staggered_Order.UpdatedOn = DateTime.Now;

                _enquiryMan.Insert_Staggered_Order(eViewModel.Enquiry.Staggered_Order);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ003"));
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Staggered_Order " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Update_Staggered_Order(EnquiryViewModel eViewModel)
        {
            try
            {
                _enquiryMan.Update_Staggered_Order(eViewModel.Enquiry.Staggered_Order);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ004"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Update_Staggered_Order " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Delete_Staggered_Order_By_Id(int staggered_Order_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _enquiryMan.Delete_Staggered_Order_By_Id(staggered_Order_Id);

                Friendly_Message.Add(MessageStore.Get("EQ005"));
            }
            catch(Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Delete_Staggered_Order_By_Id " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //

        public ActionResult PPC_Checkpoint()
        {
            return View();
        }

        public ActionResult Quality_Checkpoint()
        {
            return View();
        }

        public ActionResult QualitySet_Checkpoint()
        {
            return View();
        }

        

        public ActionResult Search_PPC_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_W_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_P_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_C_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_Quality_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_Planned()
        {
            return View();
        }

        //
        public ActionResult Search_PPC_Planning()
        {
            return View();
        }

        //public ActionResult PPC_Planning()
        //{
        //    return View();
        //}

        
    }
}
