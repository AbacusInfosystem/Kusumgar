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

namespace Kusumgar.Controllers.PostLogin
{
    public class DefectController : Controller
    {
        public ActionResult Index(DefectViewModel dViewModel)
        {
             DefectManager dMan = new DefectManager();
             
            dViewModel.DefectType = dMan.GetDefectTypes();
            
            return View(dViewModel);
        }

        public ActionResult Search(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            dViewModel.DefectType = dMan.GetDefectTypes();

            if (TempData["DefectTypeId"] != null)
            {
                dViewModel.Filter.DefectTypeName = Convert.ToInt32(TempData["DefectTypeId"]);
            }

            return View("Search", dViewModel);
        }
    
        public ActionResult Insert(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            dMan.Insert(dViewModel.Defect);

            return Search(dViewModel);

        }

        public ActionResult Update(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            dMan.Update(dViewModel.Defect);

            return Search(dViewModel);
        }

        public ActionResult GetDefectById(DefectViewModel dViewModel)
        {
            try
            {
                DefectManager dMan = new DefectManager();
               
                dViewModel.Defect = dMan.GetDefectById(dViewModel.EditMode.DefectId);
                
                dViewModel.DefectType = dMan.GetDefectTypes();

                return View("Index", dViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetDefects(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            if (!string.IsNullOrEmpty(dViewModel.Filter.DefectName) && (dViewModel.Filter.DefectTypeName>0))
            {
                dViewModel.DefectGrid = dMan.GetDefectByTypeByName(dViewModel.Filter.DefectTypeName, dViewModel.Filter.DefectName);
            }
            else if (dViewModel.Filter.DefectTypeName>0)
            {
                dViewModel.DefectGrid = dMan.GetDefectByType(dViewModel.Filter.DefectTypeName);
            }

            else if (!string.IsNullOrEmpty(dViewModel.Filter.DefectName))
            {
                dViewModel.DefectGrid = dMan.GetDefectByName(dViewModel.Filter.DefectName);
            }
            else
            {
                dViewModel.DefectGrid = dMan.GetDefects();
            }
       
            if (dViewModel.DefectGrid != null && dViewModel.DefectGrid.Count() > 0)
            {
                dViewModel.Pager.TotalRecords = dViewModel.DefectGrid.Count();

                if (dViewModel.Pager.IsPagingRequired)
                {
                    dViewModel.DefectGrid = dViewModel.DefectGrid.Skip(dViewModel.Pager.CurrentPage * dViewModel.Pager.PageSize).Take(dViewModel.Pager.PageSize).ToList<DefectInfo>();
                }

                int pages = (dViewModel.Pager.TotalRecords + dViewModel.Pager.PageSize - 1) / dViewModel.Pager.PageSize;

                dViewModel.Pager.TotalPages = pages;

                dViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", dViewModel.Pager.TotalRecords, dViewModel.Pager.CurrentPage + 1, dViewModel.Pager.PageSize, 10, true);
            }

            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGridByDefectType(DefectViewModel dViewModel)
        {
            DefectManager dMan = new DefectManager();

            if (dViewModel.Filter.DefectTypeName > 0)
            {
                dViewModel.DefectGrid = dMan.GetDefectByType(dViewModel.Filter.DefectTypeName);
            }

            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}
