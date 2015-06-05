using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarModel;
using Kusumgar.Models;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers
{
    public class DefectTypeController : Controller
    {
        [AuthorizeUser(AppFunction.Defect_Type_Create)]
        public ActionResult Index(DefectTypeViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            return View("Index", dViewModel);
        }

        [AuthorizeUser(AppFunction.Defect_Type_Search)]
        public ActionResult Search(DefectTypeViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["dViewModel"] != null)
            {
                dViewModel = (DefectTypeViewModel)TempData["dViewModel"];
            }
            return View("Search", dViewModel);
        }

        [AuthorizeUser(AppFunction.Defect_Type_Create)]
        public ActionResult Insert(DefectTypeViewModel dViewModel)
        {
            try
            {  
                dViewModel.DefectType.CreatedBy = ((UserInfo)Session["User"]).UserId;

                dViewModel.DefectType.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                dViewModel.DefectType.CreatedOn = DateTime.Now;

                dViewModel.DefectType.UpdatedOn = DateTime.Now;

                DefectTypeManager dMan = new DefectTypeManager();

                dMan.Insert(dViewModel.DefectType);

                dViewModel.Friendly_Message.Add(MessageStore.Get("DT011"));
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Type Controller - Insert" + ex.ToString());
            }
            TempData["dViewModel"] = dViewModel;

            return RedirectToAction("Search");
     }

        [AuthorizeUser(AppFunction.Defect_Type_Edit)]
        public ActionResult Update(DefectTypeViewModel dViewModel)
        {
            try
            {
                dViewModel.DefectType.UpdatedOn = DateTime.Now;

                dViewModel.DefectType.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                DefectTypeManager dMan = new DefectTypeManager();

                dMan.Update(dViewModel.DefectType);

                dViewModel.Friendly_Message.Add(MessageStore.Get("DT012"));
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Type Controller - Update" + ex.ToString());
            }
            TempData["dViewModel"] = dViewModel;
            
            return RedirectToAction("Search");
        }

        [AuthorizeUser(AppFunction.Defect_Type_Edit)]
        public ActionResult Get_Defect_Type_By_Id(DefectTypeViewModel dViewModel)
        {
            try
            {
                DefectTypeManager dMan = new DefectTypeManager();

                dViewModel.DefectType = dMan.Get_Defect_Type_By_Id(dViewModel.EditMode.Defect_Type_Id);
            }

            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Type Controller -Get_Defect_Type_By_Id" + ex.ToString());
            }
            return View("Index", dViewModel);
        }

        [AuthorizeUser(AppFunction.Defect_Type_Search)]
        public JsonResult Get_Defect_Types(DefectTypeViewModel dViewModel)
        {
            DefectTypeManager dMan = new DefectTypeManager();

            PaginationInfo pager = new PaginationInfo();

            try
            {  
                pager = dViewModel.Pager;

                if (dViewModel.Filter.Defect_Type_Id != 0)
                {
                    dViewModel.DefectTypeGrid = dMan.Get_Defect_Types_By_Id(dViewModel.Filter.Defect_Type_Id,ref pager);
                }
                else
                {
                    dViewModel.DefectTypeGrid = dMan.Get_Defect_Types(ref pager);
                }

                dViewModel.Pager = pager;

                dViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", dViewModel.Pager.TotalRecords, dViewModel.Pager.CurrentPage + 1, dViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Type Controller - Get_Defect_Types " + ex.ToString());
            }

            finally
            {
                pager = null;
            }

            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult View_Defects(DefectTypeViewModel dViewModel)
        {
            try
            {
                TempData["DefectTypeId"] = (dViewModel.EditMode.Defect_Type_Id);
             }

            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return RedirectToAction("Search", "Defect");
        }

        public JsonResult Get_Defect_Type_AutoComplete(string defect_Type_Name)
        {
            DefectTypeManager dMan = new DefectTypeManager();

            List<AutocompleteInfo> defectTypeName = new List<AutocompleteInfo>();

            defectTypeName = dMan.Get_Defect_Type_AutoComplete(defect_Type_Name);

            return Json(defectTypeName, JsonRequestBehavior.AllowGet);
        }
     }
}

    