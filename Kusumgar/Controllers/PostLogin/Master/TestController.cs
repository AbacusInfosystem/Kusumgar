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
           
            tViewModel.Fabric_Type = tMan.Get_Fabric_Types();
            
            return View(tViewModel);
        }

        public ActionResult Search(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();
            
            if (TempData["tViewModel"] != null)
            {
                tViewModel = (TestViewModel)TempData["tViewModel"];
            }
            
            tViewModel.Fabric_Type = tMan.Get_Fabric_Types();

            return View("Search", tViewModel);
        }

        public ActionResult Insert(TestViewModel tViewModel)
        {
            try
            {
                TestManager tMan = new TestManager();

                tMan.Insert(tViewModel.Test);
                
                tViewModel.FriendlyMessage.Add(MessageStore.Get("T011"));
            }

            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["tViewModel"] = tViewModel;

            return RedirectToAction("Search");

        }

        public ActionResult Update(TestViewModel tViewModel)
        {
            try
            {
                TestManager tMan = new TestManager();

                tMan.Update(tViewModel.Test);
                
                tViewModel.FriendlyMessage.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
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

                tViewModel.Fabric_Type = tMan.Get_Fabric_Types();

                return View("Index", tViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Get_Tests(TestViewModel tViewModel)
        {
            TestManager tMan = new TestManager();

            if (tViewModel.Filter.Fabric_Type_Id>0)
            {
                tViewModel.Test_Grid = tMan.Get_Test_By_Fabric_Type(tViewModel.Filter.Fabric_Type_Id,tViewModel.Pager);
            }
            else
            {
                tViewModel.Test_Grid = tMan.Get_Tests(tViewModel.Pager);
            }

         tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
           
         return Json(tViewModel, JsonRequestBehavior.AllowGet);}

    }
 }

