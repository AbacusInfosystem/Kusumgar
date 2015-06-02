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
        public ActionResult Index(DefectViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            DefectManager dMan = new DefectManager();

            dViewModel.DefectType = dMan.Get_Defect_Types();

            return View(dViewModel);
        }

        public ActionResult Search(DefectViewModel dViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            DefectManager dMan = new DefectManager();

            if (TempData["DefectTypeId"] != null)
            {
                dViewModel.Filter.Defect_Type_Id = Convert.ToInt32(TempData["DefectTypeId"]);
            }

            if (TempData["dViewModel"] != null)
            {
                dViewModel = (DefectViewModel)TempData["dViewModel"];
            }

            dViewModel.DefectType = dMan.Get_Defect_Types();

            return View("Search", dViewModel);
        }

        public ActionResult Insert(DefectViewModel dViewModel)
        {
            try
            {
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

        public ActionResult Update(DefectViewModel dViewModel)
        {
            try
            {
                DefectManager dMan = new DefectManager();

                dMan.Update(dViewModel.Defect);
                
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

        public ActionResult Get_Defect_By_Id(DefectViewModel dViewModel)
        {
            try
            {
                DefectManager dMan = new DefectManager();

                dViewModel.Defect = dMan.Get_Defect_By_Id(dViewModel.EditMode.Defect_Id);

                dViewModel.DefectType = dMan.Get_Defect_Types();
             }

            catch (Exception ex)
            {
                Logger.Error("Defect Controller - Get_Defect_By_Id " + ex.ToString());
             }
            return View("Index", dViewModel);

        }

        public JsonResult Get_Defects(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = dViewModel.Pager;

                if ((dViewModel.Filter.Defect_Id != 0) && (dViewModel.Filter.Defect_Type_Id > 0))
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Type_By_Name(dViewModel.Filter.Defect_Type_Id, dViewModel.Filter.Defect_Id, ref pager);
                }
                else if (dViewModel.Filter.Defect_Type_Id > 0)
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Type(dViewModel.Filter.Defect_Type_Id, ref pager);
                }

                else if (dViewModel.Filter.Defect_Id != 0)
                {
                    dViewModel.DefectGrid = dMan.Get_Defect_By_Name(dViewModel.Filter.Defect_Id, ref pager);
                }
                else
                {
                    dViewModel.DefectGrid = dMan.Get_Defects(ref pager);
                }

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

        public JsonResult Get_Grid_By_Defect_Type(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            PaginationInfo Pager = new PaginationInfo();

            Pager.IsPagingRequired = false;

            if (dViewModel.Filter.Defect_Type_Id > 0)
            {
                dViewModel.DefectGrid = dMan.Get_Grid_By_Defect_Type(dViewModel.Filter.Defect_Type_Id);
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
 
