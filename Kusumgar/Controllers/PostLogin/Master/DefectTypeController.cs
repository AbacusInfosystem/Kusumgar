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

namespace Kusumgar.Controllers
{
    public class DefectTypeController : Controller
    {
        public ActionResult Index(DefectTypeViewModel dViewModel)
        {
            return View("Index", dViewModel);
        }

        public ActionResult Search(DefectTypeViewModel dViewModel)
        {

            if (TempData["dViewModel"] != null)
            {
                dViewModel = (DefectTypeViewModel)TempData["dViewModel"];
            }
            return View("Search", dViewModel);
        }

        public ActionResult Insert(DefectTypeViewModel dViewModel)
        {
            try
            {
                DefectTypeManager dMan = new DefectTypeManager();

                dMan.Insert(dViewModel.DefectType);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("DT011"));
            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            TempData["dViewModel"] = dViewModel;

            return RedirectToAction("Search");

        }

        public ActionResult Update(DefectTypeViewModel dViewModel)
        {
            try
            {
                DefectTypeManager dMan = new DefectTypeManager();

                dMan.Update(dViewModel.DefectType);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("DT012"));
            }
            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            TempData["dViewModel"] = dViewModel;
            
            return RedirectToAction("Search");
        }

        public ActionResult Get_Defect_Type_By_Id(DefectTypeViewModel dViewModel)
        {
            try
            {
                DefectTypeManager dMan = new DefectTypeManager();

                dViewModel.DefectType = dMan.Get_Defect_Type_By_Id(dViewModel.EditMode.Defect_Type_Id);
            }

            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", dViewModel);
        }

        public JsonResult Get_Defect_Types(DefectTypeViewModel dViewModel)
        {
            DefectTypeManager dMan = new DefectTypeManager();
 
            if (!string.IsNullOrEmpty(dViewModel.Filter.Defect_Type_Name))
            {
                dViewModel.DefectTypeGrid = dMan.Get_Defect_Type_By_Name(dViewModel.Filter.Defect_Type_Name, dViewModel.Pager);
            }
            else
            {
                dViewModel.DefectTypeGrid = dMan.Get_Defect_Types(dViewModel.Pager);
            }

            dViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", dViewModel.Pager.TotalRecords, dViewModel.Pager.CurrentPage + 1, dViewModel.Pager.PageSize, 10, true);

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
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return RedirectToAction("Search", "Defect");
        }

     }
}

    