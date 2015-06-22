using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using Kusumgar.Models;
using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers.PostLogin
{
    public class DefectController : Controller
    {
        [AuthorizeUser(AppFunction.Defect_Create)]
        public ActionResult Index(DefectViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            DefectManager dMan = new DefectManager();

            dViewModel.Processes = dMan.Get_Processes();

            return View(dViewModel);
        }

        [AuthorizeUser(AppFunction.Defect_Search)]
        public ActionResult Search(DefectViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            DefectManager dMan = new DefectManager();

            if (TempData["DefectTypeId"] != null)
            {
                dViewModel.Filter.Process_Id = Convert.ToInt32(TempData["ProcessId"]);
            }

            if (TempData["dViewModel"] != null)
            {
                dViewModel = (DefectViewModel)TempData["dViewModel"];
            }

            dViewModel.Processes = dMan.Get_Processes();

            return View("Search", dViewModel);
        }

        [AuthorizeUser(AppFunction.Defect_Create)]
        public ActionResult Insert(DefectViewModel dViewModel)
        {
            try
            {
                dViewModel.Defect.CreatedBy = ((UserInfo)Session["User"]).UserId;

                dViewModel.Defect.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                dViewModel.Defect.CreatedOn = DateTime.Now;

                dViewModel.Defect.UpdatedOn = DateTime.Now;

                DefectManager dMan = new DefectManager();

                dMan.Insert(dViewModel.Defect);

                dViewModel.Friendly_Message.Add(MessageStore.Get("D011"));
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Controller - Insert " + ex.ToString());
            }

            TempData["dViewModel"] = dViewModel;

            return RedirectToAction("Search");
        }

        [AuthorizeUser(AppFunction.Defect_Edit)]
        public ActionResult Update(DefectViewModel dViewModel)
        {
            try
            {
                dViewModel.Defect.UpdatedOn = DateTime.Now;

                dViewModel.Defect.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                DefectManager dMan = new DefectManager();

                dMan.Update(dViewModel.Defect);

                dViewModel.Defect.Process_Id = 0;
                
                dViewModel.Friendly_Message.Add(MessageStore.Get("D012"));
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Controller - Update" + ex.ToString());
            }
           
            TempData["dViewModel"] = dViewModel;
            
            return RedirectToAction("Search");
        }

        [AuthorizeUser(AppFunction.Defect_Edit)]
        public ActionResult Get_Defect_By_Id(DefectViewModel dViewModel)
        {
            try
            {
                DefectManager dMan = new DefectManager();

                dViewModel.Defect = dMan.Get_Defect_By_Id(dViewModel.EditMode.Defect_Id);

                dViewModel.Processes = dMan.Get_Processes();
             }

            catch (Exception ex)
            {
                Logger.Error("Defect Controller - Get_Defect_By_Id " + ex.ToString());
             }
            return View("Index", dViewModel);

        }

        [AuthorizeUser(AppFunction.Defect_Search)]
        public JsonResult Get_Defects(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = dViewModel.Pager;

                if ((dViewModel.Filter.Defect_Id != 0) && (dViewModel.Filter.Process_Id > 0))
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Defect_Id_By_Process_Id(dViewModel.Filter.Process_Id, dViewModel.Filter.Defect_Id, ref pager);
                }
                else if (dViewModel.Filter.Process_Id > 0)
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Process_Id(dViewModel.Filter.Process_Id, ref pager);
                }

                else if (dViewModel.Filter.Defect_Id != 0)
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Name(dViewModel.Filter.Defect_Id, ref pager);
                }
                else
                {
                    dViewModel.DefectGrid = dMan.Get_Defects(ref pager);
                }

                dViewModel.Pager = pager;

                dViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", dViewModel.Pager.TotalRecords, dViewModel.Pager.CurrentPage + 1, dViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                dViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Defect Controller - Get_Defects " + ex.ToString());
            }

            finally
            {
                pager = null;
            }
            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Grid_By_Process_Id(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            PaginationInfo Pager = new PaginationInfo();

            Pager.IsPagingRequired = false;

            if (dViewModel.Filter.Process_Id > 0)
            {
                dViewModel.DefectGrid = dMan.Get_Grid_By_Process_Id(dViewModel.Filter.Process_Id);
            }
           
            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Defect_AutoComplete(string defect_Name)
        {
            DefectManager dMan = new DefectManager();

            List<AutocompleteInfo> defectNames = new List<AutocompleteInfo>();

            defectNames = dMan.Get_Defect_AutoComplete(defect_Name);

            return Json(defectNames, JsonRequestBehavior.AllowGet);

           
        }
   }
}
 
