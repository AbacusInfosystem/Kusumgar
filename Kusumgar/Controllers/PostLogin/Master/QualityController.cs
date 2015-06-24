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
    public class QualityController : Controller
    {
       public  QualityManager _qualityMan;

       public QualityController()
        {
            _qualityMan = new QualityManager();
         }

        public ActionResult Index(QualityViewModel qViewModel)
        {
            qViewModel.Yarn_Types = _qualityMan.Get_Yarn_Types();

            qViewModel.Weaves_Types = _qualityMan.Get_Weave_Types();

            return View(qViewModel);
        }

        public ActionResult Search(QualityViewModel qViewModel)
        {
            qViewModel.Yarn_Types = _qualityMan.Get_Yarn_Types();

            return View("Search",qViewModel);
        }

        public ActionResult Insert_Quality(QualityViewModel qViewModel)
        {
            try
            {
                qViewModel.Quality.CreatedBy = ((UserInfo)Session["User"]).UserId;

                qViewModel.Quality.CreatedBy = ((UserInfo)Session["User"]).UserId;

                qViewModel.Quality.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                qViewModel.Quality.CreatedOn = DateTime.Now;

                qViewModel.Quality.UpdatedOn = DateTime.Now;

                qViewModel.Quality.Quality_Id= _qualityMan.Insert_Quality(qViewModel.Quality);

                qViewModel.Friendly_Message.Add(MessageStore.Get("Q011"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Insert " + ex.ToString());
            }

            return Json(qViewModel);
        }

        public ActionResult Update_Quality(QualityViewModel qViewModel)
        {
            try
            {
                qViewModel.Quality.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                qViewModel.Quality.UpdatedOn = DateTime.Now;

               _qualityMan.Update_Quality(qViewModel.Quality);

               qViewModel.Friendly_Message.Add(MessageStore.Get("Q012"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Update" + ex.ToString());
            }

               return Json(qViewModel);
        }

        public ActionResult Get_Quality_By_Id(QualityViewModel qViewModel)
        {
            try
            {
                qViewModel.Quality = _qualityMan.Get_Quality_By_Id(qViewModel.Quality.Quality_Id);

                qViewModel.Quality_Application_Mapping_Grid = _qualityMan.Get_Quality_Application_By_Id(qViewModel.Quality.Quality_Id);

                qViewModel.Quality_Market_Segment_Mapping_Grid = _qualityMan.Get_Quality_Market_Segment_By_Id(qViewModel.Quality.Quality_Id);

                qViewModel.Yarn_Types = _qualityMan.Get_Yarn_Types();

                qViewModel.Weaves_Types = _qualityMan.Get_Weave_Types();
                
            }

            catch (Exception ex)
            {
                Logger.Error("Quality Controller - Get_Quality_By_Id " + ex.ToString());
            }
            
            return View("Index", qViewModel);
        }

        public JsonResult Get_Qualities(QualityViewModel qViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = qViewModel.Pager;

                if (qViewModel.Filter.Yarn_Type_Id > 0)
                {
                    qViewModel.Quality_Grid = _qualityMan.Get_Quality_By_Yarn_Types(qViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    qViewModel.Quality_Grid = _qualityMan.Get_Qualities(ref pager);
                }

                qViewModel.Pager = pager;

                qViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", qViewModel.Pager.TotalRecords, qViewModel.Pager.CurrentPage + 1, qViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Get_Qualities " + ex.ToString());
            }

            finally
            {
                pager = null;
            }
            return Json(qViewModel, JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult Get_Application_Name_AutoComplete(string applicationName)
        {
            List<AutocompleteInfo> applicationNames = new List<AutocompleteInfo>();

            applicationNames = _qualityMan.Get_Application_Name_AutoComplete(applicationName);

            return Json(applicationNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Quality_Application_By_Id(int quality_Application_Id, QualityViewModel qViewModel)
        {
            try
            {
                _qualityMan.Delete_Quality_Application_By_Id(quality_Application_Id);

                qViewModel.Friendly_Message.Add(MessageStore.Get("QA012"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Delete_Quality_Application_By_Id" + ex.ToString());

            }
            return Json(qViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Application(QualityViewModel qViewModel)
        {
            try
            {
                qViewModel.Quality_Application_Mapping.CreatedBy = 1;

                qViewModel.Quality_Application_Mapping.UpdatedBy = 1;

                _qualityMan.Insert_Application(qViewModel.Quality_Application_Mapping);

                qViewModel.Quality_Application_Mapping_Grid = _qualityMan.Get_Quality_Application_By_Id(qViewModel.Quality_Application_Mapping.Quality_Id);

                qViewModel.Friendly_Message.Add(MessageStore.Get("QA011"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Insert_Application " + ex.ToString());
            }

            return Json(qViewModel);
        }

        public JsonResult Get_Segment_Name_AutoComplete(string segmentName)
        {
            List<AutocompleteInfo> segmentNames = new List<AutocompleteInfo>();

            segmentNames = _qualityMan.Get_Segment_Name_AutoComplete(segmentName);

            return Json(segmentNames, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult Insert_Segment(QualityViewModel qViewModel)
        {
            try
            {
                qViewModel.Quality_Market_Segment_Mapping.CreatedBy = 1;

                qViewModel.Quality_Market_Segment_Mapping.UpdatedBy = 1;

                _qualityMan.Insert_Segment(qViewModel.Quality_Market_Segment_Mapping);

                qViewModel.Quality_Market_Segment_Mapping_Grid = _qualityMan.Get_Quality_Market_Segment_By_Id(qViewModel.Quality_Market_Segment_Mapping.Quality_Id);

                qViewModel.Friendly_Message.Add(MessageStore.Get("QS011"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Insert_Segment" + ex.ToString());
            }

            return Json(qViewModel);
        }

        public JsonResult Delete_Quality_Market_Segment_By_Id(int quality_Market_Segment_Id,QualityViewModel qViewModel)
        {
            try
            {
                _qualityMan.Delete_Quality_Market_Segment_By_Id(quality_Market_Segment_Id);

                qViewModel.Friendly_Message.Add(MessageStore.Get("QS012"));
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Delete_Quality_Market_Segment_By_Id" + ex.ToString());

            }
            return Json(qViewModel, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult Get_Grid_By_Yarn_Type(QualityViewModel qViewModel)
        {
            PaginationInfo Pager = new PaginationInfo();

            Pager.IsPagingRequired = false;

            if (qViewModel.Filter.Yarn_Type_Id > 0)
            {
                qViewModel.Quality_Grid = _qualityMan.Get_Grid_By_Yarn_Type(qViewModel.Filter.Yarn_Type_Id);
            }

            return Json(qViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Existing_Quality_No(int quality_No)
        {
            bool check = false;

            try
            {
                check = _qualityMan.Check_Existing_Quality_No(quality_No);
            }
            catch (Exception ex)
            {
                Logger.Error("Quality Controller - Check_Existing_Quality_No " + ex.ToString());
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Load_Quality(QualityViewModel qViewModel)
        {
            return PartialView("_Index",  qViewModel);
        }

        public ActionResult View_Quality(QualityViewModel qViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            try
            {
                qViewModel.Quality = _qualityMan.Get_Quality_By_Id(qViewModel.Quality.Quality_Id);
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Search " + ex.ToString());
            }

            return View("View", qViewModel);
        }
        
        public PartialViewResult Printable_Quality(int quality_Id)
        {
            ViewBag.Title = "KPCL ERP :: Print";

            QualityViewModel qViewModel = new QualityViewModel();
             
            qViewModel.Quality.Quality_Id = quality_Id;

            try
            {
                qViewModel.Quality = _qualityMan.Get_Quality_By_Id(qViewModel.Quality.Quality_Id);
            }
            catch (Exception ex)
            {
                qViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quality Controller - Search " + ex.ToString());
            }

            return PartialView("_PrintableView", qViewModel);
        }
    }
}
