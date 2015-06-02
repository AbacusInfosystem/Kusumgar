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

namespace Kusumgar.Controllers
{
    public class TestUnitController : Controller
    {
        public ActionResult Index(TestUnitViewModel tViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            return View("Index", tViewModel);
        }

        public ActionResult Search(TestUnitViewModel tViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

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

            }
            
        catch (Exception ex)
            {
                tViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            
               TempData["tViewModel"] = tViewModel;

              return View("Index", tViewModel);
            }
  
        public JsonResult Get_Test_Units(TestUnitViewModel tViewModel)
        {
            TestUnitManager tMan = new TestUnitManager();

            if (!string.IsNullOrEmpty(tViewModel.Filter.Test_Unit_Name))
            {
                tViewModel.Test_Unit_Grid = tMan.Get_Test_Unit_By_Name(tViewModel.Filter.Test_Unit_Name, tViewModel.Pager);
            }
            else
            {
                tViewModel.Test_Unit_Grid = tMan.Get_Test_Units(tViewModel.Pager);
            }

           tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            
           return Json(tViewModel, JsonRequestBehavior.AllowGet);
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
