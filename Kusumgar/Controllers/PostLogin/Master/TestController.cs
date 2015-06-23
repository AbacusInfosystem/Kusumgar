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

namespace Kusumgar.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(TestViewModel tViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            TestManager tMan = new TestManager();

            tViewModel.Processes = tMan.Get_Processes();
            
            return View(tViewModel);
        }

        public ActionResult Search(TestViewModel tViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            TestManager tMan = new TestManager();
            
            if (TempData["tViewModel"] != null)
            {
                tViewModel = (TestViewModel)TempData["tViewModel"];
            }

            tViewModel.Processes = tMan.Get_Processes();

            return View("Search", tViewModel);
        }

        public ActionResult Insert(TestViewModel tViewModel)
        {
            try
            {
                tViewModel.Test.CreatedBy = ((UserInfo)Session["User"]).UserId;

                tViewModel.Test.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                tViewModel.Test.CreatedOn = DateTime.Now;

                tViewModel.Test.UpdatedOn = DateTime.Now;

                TestManager tMan = new TestManager();

                tMan.Insert(tViewModel.Test);

                tViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }

            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                 Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            TempData["tViewModel"] = tViewModel;

            return RedirectToAction("Search");

        }

        public ActionResult Update(TestViewModel tViewModel)
        {
            try
            {
                tViewModel.Test.UpdatedOn = DateTime.Now;

                tViewModel.Test.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                TestManager tMan = new TestManager();

                tMan.Update(tViewModel.Test);

                tViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["tViewModel"] = tViewModel;

            return RedirectToAction("Search");
       
        }

        public ActionResult Get_Test_By_Id(TestViewModel tViewModel)
        {
            try
            {
                TestManager tMan = new TestManager();

                tViewModel.Test = tMan.Get_Test_By_Id(tViewModel.Edit_Mode.Test_Id);

                tViewModel.Processes = tMan.Get_Processes();
            }

            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }
            return View("Index", tViewModel);
        }

        public JsonResult Get_Tests(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();

            PaginationInfo pager = new PaginationInfo();
            
            try
            {
                pager = tViewModel.Pager;

                if (tViewModel.Filter.Process_Id > 0)
                {
                    tViewModel.Test_Grid = tMan.Get_Test_By_Process_Id(tViewModel.Filter.Process_Id, ref pager);
                }
                else
                {
                    tViewModel.Test_Grid = tMan.Get_Tests(ref pager);
                }

                tViewModel.Pager = pager;

                tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            }

            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            
            finally
            {
                pager = null;
            }
            return Json(tViewModel, JsonRequestBehavior.AllowGet);
        
       }

        public JsonResult Get_Test_Unit_AutoComplete(string testUnitName)
        {
            TestManager tMan = new TestManager();

            List<AutocompleteInfo> testUnitNames = new List<AutocompleteInfo>();

            testUnitNames = tMan.Get_Test_Unit_AutoComplete(testUnitName);

            return Json(testUnitNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Test_Autocomplete(string test_Name)
        {
            TestManager tMan = new TestManager();

            List<AutocompleteInfo> test_Names = new List<AutocompleteInfo>();

            test_Names = tMan.Get_Test_Autocomplete(test_Name);

            return Json(test_Names, JsonRequestBehavior.AllowGet);
        }
    }
 }

