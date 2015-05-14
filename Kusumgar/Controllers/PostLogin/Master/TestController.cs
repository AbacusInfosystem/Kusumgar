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

namespace Kusumgar.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(TestViewModel tViewModel)
        {
           
            TestManager tMan = new TestManager();
           
            tViewModel.FabricType = tMan.GetFabricTypes();
            
            return View(tViewModel);
        }

        public ActionResult Search(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();
            
            tViewModel.FabricType = tMan.GetFabricTypes();
            
            return View("Search", tViewModel);
        }

        public ActionResult Insert(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();
           
            tMan.Insert(tViewModel.Test);
            
            return Search(tViewModel);

        }

        public ActionResult Update(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();
            
            tMan.Update(tViewModel.Test);
            
            return Search(tViewModel);
       
        }

        public ActionResult GetTestById(TestViewModel tViewModel)
        {
            try
            {
                TestManager tMan = new TestManager();

                tViewModel.Test = tMan.GetTestById(tViewModel.EditMode.TestId);
                
                //tViewModel.FabricType = tMan.GetFabricTypes();

                return View("Index", tViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetTests(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();

            if (tViewModel.Filter.FabricTypeName>0)
            {
                tViewModel.TestGrid = tMan.GetTestByFabricType(tViewModel.Filter.FabricTypeName);
            }
            else
            {
                tViewModel.TestGrid = tMan.GetTests();
            }

            if (tViewModel.TestGrid != null && tViewModel.TestGrid.Count() > 0)
            {
                tViewModel.Pager.TotalRecords = tViewModel.TestGrid.Count();

                if (tViewModel.Pager.IsPagingRequired)
                {
                    tViewModel.TestGrid = tViewModel.TestGrid.Skip(tViewModel.Pager.CurrentPage * tViewModel.Pager.PageSize).Take(tViewModel.Pager.PageSize).ToList<TestInfo>();
                }

                int pages = (tViewModel.Pager.TotalRecords + tViewModel.Pager.PageSize - 1) / tViewModel.Pager.PageSize;

                tViewModel.Pager.TotalPages = pages;

                tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            }

            return Json(tViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
