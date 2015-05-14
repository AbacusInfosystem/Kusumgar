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

namespace Kusumgar.Controllers.PostLogin.Master
{
    public class AttributeCodeController : Controller
    { 
        public ActionResult Index(AttributeCodeViewModel aViewModel)
        {
            return View(aViewModel);
        }

        public ActionResult Search(AttributeCodeViewModel aViewModel)
        {
            return View("Search", aViewModel);
        }

        public ActionResult Insert(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            aMan.Insert(aViewModel.AttributeCode);

            return Search(aViewModel);

        }

        public ActionResult Update(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            aMan.Update(aViewModel.AttributeCode);

            //aViewModel.AttributeCode.AttributeNameId = 0;

            return Search(aViewModel);
        }

        public ActionResult GetAttributeCodeById(AttributeCodeViewModel aViewModel)
        {
            try
            {
                AttributeCodeManager aMan = new AttributeCodeManager();

                aViewModel.AttributeCode = aMan.GetAttributeCodeById(aViewModel.EditMode.AttributeCodeId);

                return View("Index", aViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetAttributeCodes(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            if (aViewModel.Filter.AttributeId > 0)
            {
                aViewModel.AttributeCodeGrid = aMan.GetAttributeCodesByAttributeId(aViewModel.Filter.AttributeId);
            }

            else
            {
                aViewModel.AttributeCodeGrid = aMan.GetAttributeCodes();
            }

            if (aViewModel.AttributeCodeGrid != null && aViewModel.AttributeCodeGrid.Count() > 0)
            {
                aViewModel.Pager.TotalRecords = aViewModel.AttributeCodeGrid.Count();

                if (aViewModel.Pager.IsPagingRequired)
                {
                    aViewModel.AttributeCodeGrid = aViewModel.AttributeCodeGrid.Skip(aViewModel.Pager.CurrentPage * aViewModel.Pager.PageSize).Take(aViewModel.Pager.PageSize).ToList<AttributeCodeInfo>();
                }

                int pages = (aViewModel.Pager.TotalRecords + aViewModel.Pager.PageSize - 1) / aViewModel.Pager.PageSize;

                aViewModel.Pager.TotalPages = pages;

                aViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", aViewModel.Pager.TotalRecords, aViewModel.Pager.CurrentPage + 1, aViewModel.Pager.PageSize, 10, true);
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGridByAttributeName(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            if (aViewModel.Filter.AttributeId > 0)
            {
                aViewModel.AttributeCodeGrid = aMan.GetAttributeCodesByAttributeId(aViewModel.Filter.AttributeId);
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
