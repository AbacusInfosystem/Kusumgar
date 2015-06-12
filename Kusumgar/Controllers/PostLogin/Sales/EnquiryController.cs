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
using System.IO;

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

                if (eViewModel.Filter.Customer_Id != 0 && eViewModel.Filter.Quality_Id != 0)
                {
                    eViewModel.Enquiries = _enquiryMan.Get_Enquiries_By_Customer_Id_Quality_Id(eViewModel.Filter.Customer_Id,eViewModel.Filter.Quality_Id, ref pager);
                }
                else if (eViewModel.Filter.Customer_Id != 0)
                {
                    eViewModel.Enquiries = _enquiryMan.Get_Enquiries_By_Customer_Id(eViewModel.Filter.Customer_Id,ref pager);
                }
                else if (eViewModel.Filter.Quality_Id != 0)
                {
                    eViewModel.Enquiries = _enquiryMan.Get_Enquiries_By_Quality_Id(eViewModel.Filter.Quality_Id,ref pager);
                }
                else 
                {
                  //  eViewModel.Enquiries = _enquiryMan.Get_Enquiries_By_Status(ref pager, Convert.ToInt32(EnquiryStatus.Enquiry_Arrived));

                    eViewModel.Enquiries = _enquiryMan.Get_Enquiries(ref pager);
                }

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
            AttributeCodeManager attrCodeMan = new AttributeCodeManager();

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            try
            {
                eViewModel.Enquiry = _enquiryMan.Get_Enquiry_By_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Enquiry.Supporting_Details = _enquiryMan.Get_Supporting_Details_By_Enquiry_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Enquiry.Temp_Customer_Quality_Details = _enquiryMan.Get_Temp_Customer_Quality_Details_By_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Attribute_Codes = attrCodeMan.Get_Attribute_Codes(ref pager);

            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Enquiry_By_Id " + ex.ToString());
            }

            return Index(eViewModel);
        }

        public ActionResult Get_Customer_Quality_Details_By_Id(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Temp_Customer_Quality_Details = _enquiryMan.Get_Temp_Customer_Quality_Details_By_Id(eViewModel.Enquiry.Enquiry_Id);
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Customer_Quality_Details " + ex.ToString());
            }

            return Json(eViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Supporting_Details_By_Enquiry_Id(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Supporting_Details = _enquiryMan.Get_Supporting_Details_By_Enquiry_Id(eViewModel.Enquiry.Enquiry_Id);
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Get_Supporting_Details_By_Enquiry_Id " + ex.ToString());
            }

            return Json(eViewModel, JsonRequestBehavior.AllowGet);
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

        #region Supporting Details

        public JsonResult Insert_Supporting_Details(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Supporting_Details.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Supporting_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Supporting_Details.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.Supporting_Details.UpdatedOn = DateTime.Now;

                _enquiryMan.Insert_Supporting_Details(eViewModel.Enquiry.Supporting_Details);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ006"));

            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Supporting_Details " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Update_Supporting_Details(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Supporting_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Supporting_Details.UpdatedOn = DateTime.Now;

                _enquiryMan.Update_Supporting_Details(eViewModel.Enquiry.Supporting_Details);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ007"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Update_Supporting_Details " + ex.ToString());
            }

            return Json(eViewModel);
        }

        //public JsonResult Get_Supporting_Details(EnquiryViewModel eViewModel)
        //{
        //    try
        //    {
        //      eViewModel.Enquiry.Supporting_Details = _enquiryMan.Get_Supporting_Details_By_Enquiry_Id(eViewModel.Enquiry.Enquiry_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Enquiry Controller - Get_Supporting_Details " + ex.ToString());
        //    }

        //    return Json(eViewModel);
        //}

        #endregion

        #region Temp Customer Quality Details

        public JsonResult Insert_Temp_Customer_Quality_Details(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Temp_Customer_Quality_Details.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Customer_Quality_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Customer_Quality_Details.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.Temp_Customer_Quality_Details.UpdatedOn = DateTime.Now;

                _enquiryMan.Insert_Temp_Customer_Quality_Details(eViewModel.Enquiry.Temp_Customer_Quality_Details);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ006"));

            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Temp_Customer_Quality_Details " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Update_Temp_Customer_Quality_Details(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Temp_Customer_Quality_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Customer_Quality_Details.UpdatedOn = DateTime.Now;

                _enquiryMan.Update_Temp_Customer_Quality_Details(eViewModel.Enquiry.Temp_Customer_Quality_Details);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ007"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Update_Supporting_Details " + ex.ToString());
            }

            return Json(eViewModel);
        }

        #endregion

        #region Temp Functional Visual Parameters

        public JsonResult Insert_Temp_Functional_Parameters(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Temp_Functional_Parameters.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Functional_Parameters.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Functional_Parameters.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.Temp_Functional_Parameters.UpdatedOn = DateTime.Now;

                _enquiryMan.Insert_Temp_Functional_Parameters(eViewModel.Enquiry.Temp_Functional_Parameters);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ010"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Temp_Functional_Parameters " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Insert_Temp_Visual_Parameters(EnquiryViewModel eViewModel)
        {
            try
            {
                eViewModel.Enquiry.Temp_Visual_Parameters.CreatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Visual_Parameters.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                eViewModel.Enquiry.Temp_Visual_Parameters.CreatedOn = DateTime.Now;

                eViewModel.Enquiry.Temp_Visual_Parameters.UpdatedOn = DateTime.Now;

                _enquiryMan.Insert_Temp_Visual_Parameters(eViewModel.Enquiry.Temp_Visual_Parameters);

                eViewModel.Friendly_Message.Add(MessageStore.Get("EQ012"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Temp_Visual_Parameters " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Delete_Temp_Functional_Parameters_By_Id(int temp_Functional_Parameters_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _enquiryMan.Delete_Temp_Functional_Parameters_By_Id(temp_Functional_Parameters_Id);

                Friendly_Message.Add(MessageStore.Get("EQ011"));
            }
            catch(Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Temp_Visual_Parameters " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Temp_Visual_Parameters_By_Id(int temp_Visual_Parameters_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _enquiryMan.Delete_Temp_Visual_Parameters_By_Id(temp_Visual_Parameters_Id);

                Friendly_Message.Add(MessageStore.Get("EQ013"));
            }
            catch (Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert_Temp_Visual_Parameters " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Temp_Functional_Parameters_By_Enquiry_Id(int enquiry_Id)
        {
            List<TempFunctionalParametersInfo> temp_Functional_Parameters = new List<TempFunctionalParametersInfo>();

            try
            {
                temp_Functional_Parameters = _enquiryMan.Get_Temp_Functional_Parameters_By_Enquiry_Id(enquiry_Id);
            }
            catch(Exception ex)
            {
                Logger.Error("Enquiry Controller - Get_Temp_Functional_Parameters " + ex.ToString());
            }

            return Json(new { temp_Functional_Parameters }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Temp_Visual_Parameters_By_Enquiry_Id(int enquiry_Id)
        {
            List<TempVisualParametersInfo> temp_Visual_Parameters = new List<TempVisualParametersInfo>();

            try
            {
                temp_Visual_Parameters = _enquiryMan.Get_Temp_Visual_Parameters_By_Enquiry_Id(enquiry_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("Enquiry Controller - Get_Temp_Functional_Parameters " + ex.ToString());
            }

            return Json(new { temp_Visual_Parameters }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public JsonResult Get_Quality_By_Id(int quality_Id)
        {
            QualityInfo quality = new QualityInfo();
            
            try
            {
                quality = _enquiryMan.Get_Quality_By_Id(quality_Id);
            }
            catch(Exception ex)
            {
                Logger.Error("Enquiry Controller - Get_Quality_By_Id " + ex.ToString());
            }

            return Json(new { quality }, JsonRequestBehavior.AllowGet);
        }

        //

        #region PPC Check Point

        public ActionResult Search_PPC_Checkpoint(EnquiryViewModel eViewModel)
        {
         

            try
            {
              
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Search_PPC_Checkpoint " + ex.ToString());
            }

            return View(eViewModel);
        }

        public ActionResult PPC_Checkpoint(EnquiryViewModel eViewModel)
        {
            AjaxManager ajaxMan = new AjaxManager();

            try
            {
                eViewModel.Enquiry = _enquiryMan.Get_Enquiry_By_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Enquiry.Supporting_Details = _enquiryMan.Get_Supporting_Details_By_Enquiry_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Enquiry.Temp_Customer_Quality_Details = _enquiryMan.Get_Temp_Customer_Quality_Details_By_Id(eViewModel.Enquiry.Enquiry_Id);

                eViewModel.Enquiry.Attachments = ajaxMan.Get_Attachments_By_Ref_Type_Ref_Id(Convert.ToInt32(RefType.Enquiry), eViewModel.Enquiry.Enquiry_Id);
            }
            catch(Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - PPC_Checkpoint " + ex.ToString());
            }

            return View(eViewModel);
        }

        #endregion

        public ActionResult Quality_Checkpoint()
        {
            return View();
        }

        public ActionResult QualitySet_Checkpoint()
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
