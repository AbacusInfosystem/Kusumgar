using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;

namespace Kusumgar.Controllers
{
    public class IndustrialController : Controller
    {
        //
        // GET: /Industrial/

        public IndustrialManager _industrialMan;

        public IndustrialController()
        {
            _industrialMan = new IndustrialManager();
        }

        public ActionResult Index(IndustrialViewModel iViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager.IsPagingRequired = false;
                iViewModel.Industrial_Categories = _industrialMan.Get_Industrial_Categories(ref pager);
                iViewModel.Industrial_Groups = _industrialMan.Get_Industrial_Groups(iViewModel.Industrial.Industrial_Entity.Industrial_Category_Id, ref pager);
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", iViewModel);
        }

        public ActionResult Search(IndustrialViewModel iViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            if(TempData["iViewModel"] != null)
            {
                iViewModel = (IndustrialViewModel)TempData["industrialViewModel"];
            }
            pager = iViewModel.Pager;
            iViewModel.Industrial_Categories = _industrialMan.Get_Industrial_Categories(ref pager);
            iViewModel.Industrial_Groups = _industrialMan.Get_Industrial_Groups(iViewModel.Industrial.Industrial_Entity.Industrial_Category_Id, ref pager);          
            return View("Search", iViewModel);
        }

        public JsonResult Insert(IndustrialViewModel iViewModel)
        {
            try
            {
                iViewModel.Industrial.Industrial_Entity.Industrial_Master_Id = _industrialMan.Insert_Industrial(iViewModel.Industrial);

                iViewModel.Friendly_Message.Add(MessageStore.Get("IND001"));
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }            
            return Json(iViewModel);
        }

        public JsonResult Update(IndustrialViewModel iViewModel)
        {
            try
            {
                _industrialMan.Update_Industrial(iViewModel.Industrial);
                iViewModel.Friendly_Message.Add(MessageStore.Get("IND002"));
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }            
            return Json(iViewModel);
        }

        public JsonResult Get_Industrial_Masters(IndustrialViewModel iViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            pager = iViewModel.Pager;
            try
            {
                if (iViewModel.Filter.Industrial_Category_Id != 0 && iViewModel.Filter.Industrial_Group_Id != 0)
                {
                    iViewModel.Industrials = _industrialMan.Get_Industrials_By_Industrial_Category_Id_Group_Name(iViewModel.Filter.Industrial_Category_Id, iViewModel.Filter.Industrial_Group_Id, ref pager);
                }
                else if (iViewModel.Filter.Industrial_Category_Id != 0)
                {
                    iViewModel.Industrials = _industrialMan.Get_Industrials_By_Industrial_Category_Name(iViewModel.Filter.Industrial_Category_Id, ref pager);
                }
                else
                {
                    iViewModel.Industrials = _industrialMan.Get_Industrials(ref pager);
                }
                iViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", iViewModel.Pager.TotalRecords, iViewModel.Pager.CurrentPage + 1, iViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(iViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Industrial_Master_By_Id(IndustrialViewModel iViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                iViewModel.Industrial = _industrialMan.Get_Industrial_Master_By_Id(iViewModel.Industrial_Master_Id);
                iViewModel.Industrial_Vendors = _industrialMan.Get_Industrial_Vendors_By_Id(iViewModel.Industrial_Master_Id, ref pager);
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Index(iViewModel);
        }        

        public JsonResult Get_Group_By_CategoryId(int industrial_Category_Id)
        {
            List<IndustrialGroupInfo> industrial_Groups = new List<IndustrialGroupInfo>();            
            try
            {
                PaginationInfo pager = new PaginationInfo();
                pager.IsPagingRequired = false;
                industrial_Groups = _industrialMan.Get_Industrial_Groups(industrial_Category_Id, ref pager);
            }
            catch (Exception ex)
            {

            }
            return Json(industrial_Groups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert_Industrial_Vendor(IndustrialViewModel iViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                iViewModel.Industrial_Vendor.Industrial_Vendor_Entity.Industrial_Vendor_Id = _industrialMan.Insert_Industrial_Vendor(iViewModel.Industrial_Vendor);                 
                iViewModel.Friendly_Message.Add(MessageStore.Get("IND003"));
                iViewModel.Industrial_Vendors = _industrialMan.Get_Industrial_Vendors_By_Id(iViewModel.Industrial_Vendor.Industrial_Vendor_Entity.Industrial_Master_Id, ref pager);
                iViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", iViewModel.Pager.TotalRecords, iViewModel.Pager.CurrentPage + 1, iViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(iViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Industrial_Vendor_By_Id(int industrial_Vendor_Id, IndustrialViewModel iViewModel)
        {
            try
            {
                _industrialMan.Delete_Industrial_Vendor_By_Id(industrial_Vendor_Id);
                iViewModel.Friendly_Message.Add(MessageStore.Get("IND004"));
            }
            catch (Exception ex)
            {
                iViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(iViewModel, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Get_Vendor_Autocomplete(string vendor_Name)
        {
            AjaxManager ajaxMan = new AjaxManager();
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = ajaxMan.Get_Vendor_AutoComplete(vendor_Name);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }
    }
}
