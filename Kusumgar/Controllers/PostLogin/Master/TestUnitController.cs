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
    public class TestUnitController : Controller
    {
        public ActionResult Index(TestUnitViewModel tViewModel)
        {
            return View("Index", tViewModel);
        }

        public ActionResult Search(TestUnitViewModel tViewModel)
        {
            return View("Search", tViewModel);
        }

        public ActionResult Insert(TestUnitViewModel tViewModel)
        {
            TestUnitManager tMan = new TestUnitManager();

            tMan.Insert(tViewModel.TestUnit);

            return Search(tViewModel);

        }

        public ActionResult Update(TestUnitViewModel tViewModel)
        {

            TestUnitManager tMan = new TestUnitManager();
            tMan.Update(tViewModel.TestUnit);

            return Search(tViewModel);
        }

        public ActionResult GetTestUnitById(TestUnitViewModel tViewModel)
        {
            try
            {
                TestUnitManager tMan = new TestUnitManager();

               
                tViewModel.TestUnit = tMan.GetTestUnitById(tViewModel.EditMode.TestUnitId);

                return View("Index", tViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetTestUnits(TestUnitViewModel tViewModel)
        {
            TestUnitManager tMan = new TestUnitManager();


            if (!string.IsNullOrEmpty(tViewModel.Filter.TestUnitName))
            {
                tViewModel.TestUnitGrid = tMan.GetTestUnitByName(tViewModel.Filter.TestUnitName);
            }
            else
            {
                tViewModel.TestUnitGrid = tMan.GetTestUnits();
            }



            if (tViewModel.TestUnitGrid != null && tViewModel.TestUnitGrid.Count() > 0)
            {
                tViewModel.Pager.TotalRecords = tViewModel.TestUnitGrid.Count();

                if (tViewModel.Pager.IsPagingRequired)
                {
                    tViewModel.TestUnitGrid = tViewModel.TestUnitGrid.Skip(tViewModel.Pager.CurrentPage * tViewModel.Pager.PageSize).Take(tViewModel.Pager.PageSize).ToList<TestUnitInfo>();
                }

                int pages = (tViewModel.Pager.TotalRecords + tViewModel.Pager.PageSize - 1) / tViewModel.Pager.PageSize;

                tViewModel.Pager.TotalPages = pages;


                tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            }




            return Json(tViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewTests(TestUnitViewModel tViewModel)
        {
            try
            {
                TestUnitManager tMan = new TestUnitManager();


                TempData["FabricType"] = (tViewModel.EditMode.TestUnitId);

                return RedirectToAction("Search", "Test");
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
