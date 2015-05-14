using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities;
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
            return View("Search", dViewModel);
        }

        public ActionResult Insert(DefectTypeViewModel dViewModel)
        {
            DefectTypeManager dMan = new DefectTypeManager();

            dMan.Insert(dViewModel.DefectType);

            return Search(dViewModel);

        }

        public ActionResult Update(DefectTypeViewModel dViewModel)
        {
            DefectTypeManager dMan = new DefectTypeManager();

            dMan.Update(dViewModel.DefectType);

            return Search(dViewModel);
        }

        public ActionResult GetDefectTypeById(DefectTypeViewModel dViewModel)
        {
            try
            {
                DefectTypeManager dMan = new DefectTypeManager();

                dViewModel.DefectType = dMan.GetDefectTypeById(dViewModel.EditMode.DefectTypeId);

                return View("Index", dViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetDefectTypes(DefectTypeViewModel dViewModel)
        {
            DefectTypeManager dMan = new DefectTypeManager();
 
            if (!string.IsNullOrEmpty(dViewModel.Filter.DefectTypeName))
            {
                dViewModel.DefectTypeGrid = dMan.GetDefectTypeByName(dViewModel.Filter.DefectTypeName);
            }
            else
            {
                dViewModel.DefectTypeGrid = dMan.GetDefectTypes();
            }

            if (dViewModel.DefectTypeGrid != null && dViewModel.DefectTypeGrid.Count() > 0)
            {
                dViewModel.Pager.TotalRecords = dViewModel.DefectTypeGrid.Count();

                if (dViewModel.Pager.IsPagingRequired)
                {
                    dViewModel.DefectTypeGrid = dViewModel.DefectTypeGrid.Skip(dViewModel.Pager.CurrentPage * dViewModel.Pager.PageSize).Take(dViewModel.Pager.PageSize).ToList<DefectTypeInfo>();
                }

                int pages = (dViewModel.Pager.TotalRecords + dViewModel.Pager.PageSize - 1) / dViewModel.Pager.PageSize;

                dViewModel.Pager.TotalPages = pages;

                dViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", dViewModel.Pager.TotalRecords, dViewModel.Pager.CurrentPage + 1, dViewModel.Pager.PageSize, 10, true);
            }

            return Json(dViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewDefects(DefectTypeViewModel dViewModel)
        {
            try
            {
                TempData["DefectTypeId"] = (dViewModel.EditMode.DefectTypeId);

                return RedirectToAction("Search", "Defect");
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

     }
}

    