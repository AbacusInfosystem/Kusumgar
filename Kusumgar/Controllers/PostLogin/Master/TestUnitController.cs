using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarBusinessEntities;
using KusumgarModel;
using Kusumgar.Models;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;

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
            if (TempData["tViewModel"] != null)
            {
                tViewModel = (TestUnitViewModel)TempData["tViewModel"];
            }
            return View("Search", tViewModel);
        }

        public ActionResult Insert(TestUnitViewModel tViewModel)
        {
            try
            {
                TestUnitManager tMan = new TestUnitManager();

                tMan.Insert(tViewModel.Test_Unit);

                tViewModel.Friendly_Message.Add(MessageStore.Get("TU011"));

            }
            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Unit Controller - Insert_Test_Units " + ex.ToString());
           }
           
            TempData["tViewModel"] = tViewModel;
                
            return Search(tViewModel);
            }
       
        public  ActionResult  Update(TestUnitViewModel tViewModel)
        {
             try
            {
                TestUnitManager tMan = new TestUnitManager();
                
                 tMan.Update(tViewModel.Test_Unit);

                 tViewModel.Friendly_Message.Add(MessageStore.Get("TU012"));
             }
            
            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Unit Controller - Update_Test_Units " + ex.ToString());
            }
            TempData["tViewModel"] = tViewModel;
            
            return Search(tViewModel);
       }

        public ActionResult Get_Test_Unit_By_Id(TestUnitViewModel tViewModel)
        {
            try
            {
                TestUnitManager tMan = new TestUnitManager();

                tViewModel.Test_Unit = tMan.Get_Test_Unit_By_Id(tViewModel.Edit_Mode.Test_Unit_Id);

                tViewModel.Friendly_Message.Add(MessageStore.Get("DT011"));
            }
            
        catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Unit Controller - Get_Test_Unit_By_Id" + ex.ToString());
            }
            
               TempData["tViewModel"] = tViewModel;

              return View("Index", tViewModel);
            }
  
        public JsonResult Get_Test_Units(TestUnitViewModel tViewModel)
        {
            TestUnitManager tMan = new TestUnitManager();

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = tViewModel.Pager;
                
                if (tViewModel.Filter.Test_Unit_Id!=0)
                {
                    tViewModel.Test_Unit_Grid = tMan.Get_Test_Units_By_Id(tViewModel.Filter.Test_Unit_Id, tViewModel.Pager);
                }
                else
                {
                    tViewModel.Test_Unit_Grid = tMan.Get_Test_Units(tViewModel.Pager);
                }

                tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            }

            catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Unit Controller - Get_Test_Units " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
           return Json(tViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Test_Unit_AutoComplete(string test_Unit_Name)
        {
            TestUnitManager tMan = new TestUnitManager();

            List<AutocompleteInfo> testUnitName = new List<AutocompleteInfo>();

            testUnitName = tMan.Get_Test_Unit_AutoComplete(test_Unit_Name);

            return Json(testUnitName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewTests(TestUnitViewModel tViewModel)
        {
            try
            {
                TestUnitManager tMan = new TestUnitManager();

                TempData["FabricType"] = (tViewModel.Edit_Mode.Test_Unit_Id);

                return RedirectToAction("Search", "Test");
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
