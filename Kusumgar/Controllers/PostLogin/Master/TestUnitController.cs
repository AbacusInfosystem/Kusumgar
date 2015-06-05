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
                tViewModel.Test_Unit.CreatedBy = ((UserInfo)Session["User"]).UserId;

                tViewModel.Test_Unit.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                tViewModel.Test_Unit.CreatedOn = DateTime.Now;

                tViewModel.Test_Unit.UpdatedOn = DateTime.Now;

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
                tViewModel.Test_Unit.UpdatedOn = DateTime.Now;

                tViewModel.Test_Unit.UpdatedBy = ((UserInfo)Session["User"]).UserId;

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

                if(!string.IsNullOrEmpty(tViewModel.Filter.Test_Unit_Name))
                {
                    tViewModel.Test_Unit_Grid = tMan.Get_Test_Unit_By_Name(tViewModel.Filter.Test_Unit_Name, ref pager);
                }
                else
                {
                    tViewModel.Test_Unit_Grid = tMan.Get_Test_Units(ref pager);
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
