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
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ProductManager _productMan;

        public ProductController()
        {
            _productMan = new ProductManager();
        }

        public ActionResult Index(ProductViewModel pViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager.IsPagingRequired = false;
                pViewModel.Product_Categories = _productMan.Get_Product_Categories(ref pager);
                pViewModel.Product_SubCategories = _productMan.Get_Product_SubCategories(pViewModel.Product.Product_Entity.Product_Category_Id, ref pager);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", pViewModel);
        }

        public ActionResult Search(ProductViewModel pViewModel)
        {

            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (ProductViewModel)TempData["pViewModel"];
            }
            pager = pViewModel.Pager;
            return View("Search", pViewModel);
        }

        public JsonResult Insert(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.Product.Product_Entity.Product_Id = _productMan.Insert_Product(pViewModel.Product);
                pViewModel.Friendly_Message.Add(MessageStore.Get("P001"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel);
        }

        public JsonResult Update(ProductViewModel pViewModel)
        {
            try
            {
                _productMan.Update_Product(pViewModel.Product);
                pViewModel.Friendly_Message.Add(MessageStore.Get("P002"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel);
        }

        public JsonResult Get_Products(ProductViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            pager = pViewModel.Pager;
            try
            {
                if (pViewModel.Filter.Product_Id != 0)
                {
                    pViewModel.Products = _productMan.Get_Products_By_Product_Id(pViewModel.Filter.Product_Id, ref pager);
                }
                else
                {
                    pViewModel.Products = _productMan.Get_Products(ref pager);
                }
                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Product_By_Id(ProductViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pViewModel.Product = _productMan.Get_Product_By_Id(pViewModel.Product_Id);
                pViewModel.Product_Vendors = _productMan.Get_Product_Vendors_By_Id(pViewModel.Product_Id, ref pager);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Index(pViewModel);
        }

        public JsonResult Get_Product_SubCategory_By_Category_Id(int product_Category_Id)
        {
            List<ProductSubCategoryInfo> product_SubCategories = new List<ProductSubCategoryInfo>();
            try
            {
                PaginationInfo pager = new PaginationInfo();
                pager.IsPagingRequired = false;
                product_SubCategories = _productMan.Get_Product_SubCategories(product_Category_Id, ref pager);
            }
            catch (Exception ex)
            {

            }
            return Json(product_SubCategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Products_By_Name_Autocomplete(string product_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = _productMan.Get_Products_By_Name_Autocomplete(product_Name);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert_Product_Vendor(ProductViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pViewModel.Product_Vendor.Product_Vendor_Entity.Product_Vendor_Id = _productMan.Insert_Product_Vendor(pViewModel.Product_Vendor);
                pViewModel.Friendly_Message.Add(MessageStore.Get("P003"));
                pViewModel.Product_Vendors = _productMan.Get_Product_Vendors_By_Id(pViewModel.Product_Vendor.Product_Vendor_Entity.Product_Id, ref pager);
                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Product_Vendor_By_Id(int product_Vendor_Id, ProductViewModel pViewModel)
        {
            try
            {
                _productMan.Delete_Product_Vendor_By_Id(product_Vendor_Id);
                pViewModel.Friendly_Message.Add(MessageStore.Get("P004"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }
            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Vendor_Autocomplete(string vendor_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            autoList = _productMan.Get_Vendor_Autocomplete(vendor_Name);
            return Json(autoList, JsonRequestBehavior.AllowGet);
        }
    }
}
