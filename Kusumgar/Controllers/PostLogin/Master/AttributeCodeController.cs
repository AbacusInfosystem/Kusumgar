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

namespace Kusumgar.Controllers.PostLogin.Master
{
    public class AttributeCodeController : Controller
    { 
        public ActionResult Index(AttributeCodeViewModel aViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            return View(aViewModel);
        }

        public ActionResult Search(AttributeCodeViewModel aViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["aViewModel"] != null)
            {
                aViewModel = (AttributeCodeViewModel)TempData["aViewModel"];
            }
            return View("Search", aViewModel);
        }

        public ActionResult Insert(AttributeCodeViewModel aViewModel)
        {
            try
            { 
                aViewModel.Attribute_Code.CreatedBy = ((UserInfo)Session["User"]).UserId;

                aViewModel.Attribute_Code.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                aViewModel.Attribute_Code.CreatedOn = DateTime.Now;

                aViewModel.Attribute_Code.UpdatedOn = DateTime.Now;

                AttributeCodeManager aMan = new AttributeCodeManager();

                aMan.Insert(aViewModel.Attribute_Code);

                aViewModel.Friendly_Message.Add(MessageStore.Get("AC011"));
            }
            catch (Exception ex)
            {
                aViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Attribute Code Controller - Insert " + ex.ToString());
            }

            return RedirectToAction("Search");
        }

        public ActionResult Update(AttributeCodeViewModel aViewModel)
        {
           try
           {
               aViewModel.Attribute_Code.UpdatedOn = DateTime.Now;

               aViewModel.Attribute_Code.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                AttributeCodeManager aMan = new AttributeCodeManager();

                aMan.Update(aViewModel.Attribute_Code);

                aViewModel.Attribute_Code.Attribute_Id =0;

                aViewModel.Friendly_Message.Add(MessageStore.Get("AC012"));
               
            }
            catch (Exception ex)
            {
                aViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Attribute Code Controller - Update " + ex.ToString());
            }

            TempData["aViewModel"] = aViewModel;

            return RedirectToAction("Search");
  }

        public ActionResult Get_Attribute_Code_By_Id(AttributeCodeViewModel aViewModel)
        {
            try
            {
                AttributeCodeManager aMan = new AttributeCodeManager();

                aViewModel.Attribute_Code = aMan.Get_Attribute_Code_By_Id(aViewModel.Edit_Mode.Attribute_Code_Id);

                return View("Index", aViewModel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Get_Attribute_Codes(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = aViewModel.Pager;

                if (aViewModel.Filter.Attribute_Id > 0)
                {
                    aViewModel.Attribute_Code_Grid = aMan.Get_Attribute_Codes_By_Attribute_Name(aViewModel.Filter.Attribute_Id, ref pager);
                }

                else
                {
                    aViewModel.Attribute_Code_Grid = aMan.Get_Attribute_Codes(ref pager);
                }

                aViewModel.Pager = pager;

                aViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", aViewModel.Pager.TotalRecords, aViewModel.Pager.CurrentPage + 1, aViewModel.Pager.PageSize, 10, true);
            }
            
            catch (Exception ex)
            {
                aViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Attribute Code Controller - Get_Attribute_Codes " + ex.ToString());
            }

            finally
            {
                pager = null;
            }
            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Grid_By_Attribute_Name(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            PaginationInfo pager = new PaginationInfo();

            if (aViewModel.Filter.Attribute_Id > 0)
            {
                aViewModel.Attribute_Code_Grid = aMan.Get_Grid_By_Attrinute_Code_Name(aViewModel.Filter.Attribute_Id);
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
