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
                AttributeCodeManager aMan = new AttributeCodeManager();

                aMan.Insert(aViewModel.Attribute_Code);

                aViewModel.FriendlyMessage.Add(MessageStore.Get("AC011"));
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return RedirectToAction("Search");
        }

        public ActionResult Update(AttributeCodeViewModel aViewModel)
        {
           try
            {
                AttributeCodeManager aMan = new AttributeCodeManager();

                aMan.Update(aViewModel.Attribute_Code);

                aViewModel.Attribute_Code.AttributeCodeEntity.Attribute_Id =0;

                aViewModel.FriendlyMessage.Add(MessageStore.Get("AC012"));
               
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
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

            if (aViewModel.Filter.Attribute_Id > 0)
            {
                aViewModel.Attribute_Code_Grid = aMan.Get_Attribute_Codes_By_Attribute_Name(aViewModel.Filter.Attribute_Id, aViewModel.Pager);
            }

            else
            {
                aViewModel.Attribute_Code_Grid = aMan.Get_Attribute_Codes(aViewModel.Pager);
            }

            aViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", aViewModel.Pager.TotalRecords, aViewModel.Pager.CurrentPage + 1, aViewModel.Pager.PageSize, 10, true);
           
            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Grid_By_Attribute_Name(AttributeCodeViewModel aViewModel)
        {
            AttributeCodeManager aMan = new AttributeCodeManager();

            if (aViewModel.Filter.Attribute_Id > 0)
            {
                aViewModel.Attribute_Code_Grid = aMan.Get_Attribute_Codes_By_Attribute_Name(aViewModel.Filter.Attribute_Id,aViewModel.Pager);
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
