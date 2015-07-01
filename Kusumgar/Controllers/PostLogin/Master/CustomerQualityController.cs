using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;


namespace Kusumgar.Controllers
{
    public class CustomerQualityController : Controller
    {

        public CustomerQualityManager _customerqualityMan;

        public CustomerQualityController()
        {
            _customerqualityMan = new CustomerQualityManager();
        }

        public ActionResult Index(CustomerQualityViewModel cqViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;

                cqViewModel.Customer_Quality.Qualities = _customerqualityMan.Get_Qualities(ref pager);
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer quality Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            
            return View("Index", cqViewModel);
        }

        public ActionResult Search(CustomerQualityViewModel cqViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;

                cqViewModel.Customer_Quality.Qualities = _customerqualityMan.Get_Qualities(ref pager);

            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer quality Controller - Search " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search", cqViewModel);
        }

        public ActionResult Get_Customer_Qualities(CustomerQualityViewModel cqViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = cqViewModel.Pager;

                if (cqViewModel.Filter.Customer_Id != 0 && cqViewModel.Filter.Quality_Id != 0)
                {
                    cqViewModel.Customer_Qualities = _customerqualityMan.Get_Customer_Qualities_By_Customer_Id_By_Quality_Id(cqViewModel.Filter.Customer_Id, cqViewModel.Filter.Quality_Id, ref pager);
                }
                else if (cqViewModel.Filter.Customer_Id != 0)
                {
                    cqViewModel.Customer_Qualities = _customerqualityMan.Get_Customer_Qualities_By_Customer_Id(cqViewModel.Filter.Customer_Id, ref pager);
                }
                else if (cqViewModel.Filter.Quality_Id != 0)
                {
                    cqViewModel.Customer_Qualities = _customerqualityMan.Get_Customer_Qualities_By_Quality_Id(cqViewModel.Filter.Quality_Id, ref pager);
                }
                else
                {
                    cqViewModel.Customer_Qualities = _customerqualityMan.Get_Customer_Qualities(ref pager);
                }
                cqViewModel.Pager = pager;

                cqViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cqViewModel.Pager.TotalRecords, cqViewModel.Pager.CurrentPage + 1, cqViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Quality Controller - Get_Vendor_Contacts " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(cqViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert(CustomerQualityViewModel cqViewModel)
        {
            try
            {
                cqViewModel.Customer_Quality.CreatedOn = DateTime.Now;

                cqViewModel.Customer_Quality.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.UpdatedOn = DateTime.Now;

                cqViewModel.Customer_Quality.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.Customer_Quality_Id = _customerqualityMan.Insert_Customer_Quality(cqViewModel.Customer_Quality);

                //cqViewModel.Customer_Qualities = _customerqualityMan.Get_Customer_Quality_By_Id(cqViewModel.Customer_Quality.Customer_Quality_Id, ref pager);

                cqViewModel.Friendly_Message.Add(MessageStore.Get("CQ001"));
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer quality Controller - Insert " + ex.ToString());
            }

            return Json(cqViewModel);
        }

        //AutoComplete
        public JsonResult Get_Sample_No_AutoComplete(string sample_No)
        {
            List<AutocompleteInfo> customer_Quality = new List<AutocompleteInfo>();

            try
            {
                customer_Quality = _customerqualityMan.Get_Sample_No_AutoComplete(sample_No);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(customer_Quality, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update_Details(CustomerQualityViewModel cqViewModel)
        {
            try
            {
                cqViewModel.Customer_Quality.UpdatedOn = DateTime.Now;

                cqViewModel.Customer_Quality.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _customerqualityMan.Update_Customer_Quality(cqViewModel.Customer_Quality);
               
                cqViewModel.Friendly_Message.Add(MessageStore.Get("CQ002"));
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Quality Controller - Update " + ex.ToString());
            }

            return Json(cqViewModel);
        }

        public ActionResult Get_Customer_Quality_By_Id(CustomerQualityViewModel cqViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                cqViewModel.Customer_Quality = _customerqualityMan.Get_Customer_Quality_By_Id(cqViewModel.Customer_Quality.Customer_Quality_Id);

                pager.IsPagingRequired = false;

                cqViewModel.Customer_Quality.Qualities = _customerqualityMan.Get_Qualities(ref pager);

            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Quality Controller - Get_Customer_Quality_By_Id " + ex.ToString());
            }

            return View("Index", cqViewModel);
        }

        public ActionResult View_Customer_Quality(CustomerQualityViewModel cqViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            
            try
            {
                cqViewModel.Customer_Quality = _customerqualityMan.Get_Customer_Quality_By_Id(cqViewModel.Customer_Quality.Customer_Quality_Id);
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
       		Logger.Error("Customer Quality Controller - Search " + ex.ToString());
            }
            
            return View("View", cqViewModel);
        }
        
        public JsonResult Insert_Customer_Quality_Functional_Parameters(CustomerQualityViewModel cqViewModel)
        {
            try
            {
                cqViewModel.Customer_Quality.Customer_Quality_Functional_Parameter.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.Customer_Quality_Functional_Parameter.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.Customer_Quality_Functional_Parameter.CreatedOn = DateTime.Now;

                cqViewModel.Customer_Quality.Customer_Quality_Functional_Parameter.UpdatedOn = DateTime.Now;
            
                _customerqualityMan.Insert_Customer_Quality_Functional_Parameter(cqViewModel.Customer_Quality.Customer_Quality_Functional_Parameter);

                cqViewModel.Friendly_Message.Add(MessageStore.Get("EQ010"));
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Quality Controller - Insert_Customer_Quality_Functional_Parameters " + ex.ToString());
            }

            return Json(cqViewModel);
        }

        public JsonResult Insert_Customer_Quality_Visual_Parameters(CustomerQualityViewModel cqViewModel)
        {
            try
            {
                cqViewModel.Customer_Quality.Customer_Quality_Visual_Parameter.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.Customer_Quality_Visual_Parameter.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cqViewModel.Customer_Quality.Customer_Quality_Visual_Parameter.CreatedOn = DateTime.Now;

                cqViewModel.Customer_Quality.Customer_Quality_Visual_Parameter.UpdatedOn = DateTime.Now;

                _customerqualityMan.Insert_Customer_Quality_Visual_Parameter(cqViewModel.Customer_Quality.Customer_Quality_Visual_Parameter);

                cqViewModel.Friendly_Message.Add(MessageStore.Get("EQ012"));
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Quality Controller - Insert_Customer_Quality_Visual_Parameters " + ex.ToString());
            }

            return Json(cqViewModel);
        }

        //Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id
        public JsonResult Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id(int customer_Quality_Id)
        {
            List<CustomerQualityFunctionalParameterInfo> customer_Quality_Functional_Parameters = new List<CustomerQualityFunctionalParameterInfo>();

            try
            {
                customer_Quality_Functional_Parameters = _customerqualityMan.Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id(customer_Quality_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("CustomerQuality Controller - Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id " + ex.ToString());
            }

            return Json(new { customer_Quality_Functional_Parameters }, JsonRequestBehavior.AllowGet);
        }

        //Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id
        public JsonResult Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id(int customer_Quality_Id)
        {
            List<CustomerQualityVisualParameterInfo> customer_Quality_Visual_Parameters = new List<CustomerQualityVisualParameterInfo>();

            try
            {
                customer_Quality_Visual_Parameters = _customerqualityMan.Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id(customer_Quality_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("CustomerQuality Controller - Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id " + ex.ToString());
            }

            return Json(new { customer_Quality_Visual_Parameters }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Customer_Quality_Functional_Parameter_By_Id(int customer_Quality_Functional_Parameters_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _customerqualityMan.Delete_Customer_Quality_Functional_Parameter_By_Id(customer_Quality_Functional_Parameters_Id);

                Friendly_Message.Add(MessageStore.Get("EQ011"));
            }
            catch (Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("CustomerQuality Controller - Delete_Customer_Quality_Functional_Parameters_By_Id " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        //Delete_Customer_Quality_Visual_Parameters_By_Id
        public JsonResult Delete_Customer_Quality_Visual_Parameter_By_Id(int customer_Quality_Visual_Parameters_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _customerqualityMan.Delete_Customer_Quality_Visual_Parameter_By_Id(customer_Quality_Visual_Parameters_Id);

                Friendly_Message.Add(MessageStore.Get("EQ013"));
            }
            catch (Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("CustomerQuality Controller - Delete_Customer_Quality_Functional_Parameters_By_Id " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

public PartialViewResult Printable_Customer_Quality(int customer_Quality_Id)
        {
            ViewBag.Title = "KPCL ERP :: Print";
            CustomerQualityViewModel cqViewModel = new CustomerQualityViewModel();
            cqViewModel.Customer_Quality.Customer_Quality_Id = customer_Quality_Id;

            try
            {
                cqViewModel.Customer_Quality = _customerqualityMan.Get_Customer_Quality_By_Id(cqViewModel.Customer_Quality.Customer_Quality_Id);
            }
            catch (Exception ex)
            {
                cqViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Quality Controller - Search " + ex.ToString());
            }

            return PartialView("_PrintableView", cqViewModel);
        }
    }
}
