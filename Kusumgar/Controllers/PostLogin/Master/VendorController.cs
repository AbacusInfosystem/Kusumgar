using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers.PostLogin.Master
{
    public class VendorController : Controller
    {
        public VendorManager _vendorMan;

        public NationManager _nationMan;

        public StateManager _stateMan;

        public VendorController()
        {
            _vendorMan = new VendorManager();

            _nationMan = new NationManager();

            _stateMan = new StateManager();
        }

        public ActionResult Index(VendorViewModel vViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            vViewModel.Is_Primary = true;

            return View("Index", vViewModel);
        }

        public ActionResult Search(VendorViewModel vViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["vViewModel"] != null)
            {
                vViewModel = (VendorViewModel)TempData["vViewModel"];
            }
            return View("Search", vViewModel);
        }

        public ActionResult Insert_Vendor(VendorViewModel vViewModel)
        {
            try
            {   vViewModel.Vendor.CreatedBy = ((UserInfo)Session["User"]).UserId;

                vViewModel.Vendor.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                vViewModel.Vendor.CreatedOn = DateTime.Now;

                vViewModel.Vendor.UpdatedOn = DateTime.Now;

                vViewModel.Attribute_Code.Attribute_Code_Name = vViewModel.Vendor.Vendor_Name;

                vViewModel.Vendor.Vendor_Id = _vendorMan.Insert_Vendor(vViewModel.Vendor);

                vViewModel.Attribute_Code.Attribute_Id = Convert.ToInt32(AttributeName.Supplier);

                if (vViewModel.Vendor.Material_Category_Entity.Material_Category_Name == "YarnCategory")
                {
                    vViewModel.Attribute_Code.Status = true;

                    vViewModel.Attribute_Code.Attribute_Code_Id = _vendorMan.Insert_Attribute_Code(vViewModel.Attribute_Code);
                }
              
               vViewModel.Friendly_Message.Add(MessageStore.Get("V011"));
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
               
                Logger.Error("Vendor Controller - Insert " + ex.ToString());
            }

            return Json(vViewModel);
        }

        public ActionResult Get_State_by_Nation_Id(int nation_Id)
        {
            List<StateInfo> States = new List<StateInfo>();

            StateManager _stateMgr = new StateManager();

            try
            {
                PaginationInfo Pager = new PaginationInfo();

                Pager.IsPagingRequired = false;

                States = _stateMgr.Get_States(nation_Id, ref Pager);
            }
            catch (Exception ex)
            {
                Logger.Error("Vendor Controller - Get_State_by_Nation_Id " + ex.ToString());
            }
            return Json(States, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Insert_Product_Service(VendorViewModel vViewModel)
        //{
        //    try
        //    {
        //        //vViewModel.Product_Vendor.Product_Vendor_Entity.CreatedBy = 1;

        //        //vViewModel.Product_Vendor.Product_Vendor_Entity.UpdatedBy = 1;

        //        vViewModel.Product_Vendor.Product_Vendor_Entity.Product_Vendor_Id= _vendorMan.Insert_Product_Services(vViewModel.Product_Vendor);

        //        vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Product_Vendor.Product_Vendor_Entity.Vendor_Id);

        //        vViewModel.Friendly_Message.Add(MessageStore.Get("PS011"));
        //    } 
        //    catch (Exception ex)
        //    {
        //         vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //         Logger.Error("Vendor Controller - Insert_Product_Vendor_Details " + ex.ToString());
        //    }

        //    return Json(vViewModel);
        //}

        public ActionResult Update_Vendor(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Vendor.UpdatedOn = DateTime.Now;

                vViewModel.Vendor.UpdatedBy = ((UserInfo)Session["User"]).UserId;
              
                _vendorMan.Update_Vendor(vViewModel.Vendor);

                vViewModel.Friendly_Message.Add(MessageStore.Get("V012"));
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Update_Vendor_Details " + ex.ToString());
            }

            return Json(vViewModel);
        }

        //public ActionResult Update_Product_Service(VendorViewModel vViewModel)
        //{
        //    try
        //    {
        //        //vViewModel.Product_Vendor.Product_Vendor_Entity.UpdatedBy = 1;

        //        _vendorMan.Update_Product_Services(vViewModel.Product_Vendor);

        //        vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Product_Vendor.Product_Vendor_Entity.Vendor_Id);

        //        vViewModel.Friendly_Message.Add(MessageStore.Get("PS012"));

        //    }
        //    catch (Exception ex)
        //    {
        //        vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Vendor Controller - Update_Product_Vendor_Details " + ex.ToString());
        //    }

        //    return Json(vViewModel);
        //}

        public ActionResult Get_Vendor_By_Id(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Vendor = _vendorMan.Get_Vendor_By_Id(vViewModel.Vendor.Vendor_Id);
                
                //vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Vendor.Vendor_Id);
            }
            catch(Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Get_Vendor_By_Id " + ex.ToString());
            }

            return Index(vViewModel);
        }

        public ActionResult Get_Vendors(VendorViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
           
            try
            {
                pager = vViewModel.Pager;

                if (vViewModel.Filter.Vendor_Id != 0 && vViewModel.Filter.Material_Id != 0)
                {
                    vViewModel.Vendor_Grid = _vendorMan.Get_Vendors_By_Vendor_Id_Material_Id(vViewModel.Filter.Vendor_Id, vViewModel.Filter.Material_Id, ref  pager);
                }
                else if (vViewModel.Filter.Vendor_Id != 0)
                {
                    vViewModel.Vendor_Grid = _vendorMan.Get_Vendors_By_Id(vViewModel.Filter.Vendor_Id, ref  pager);
                }
                else if (vViewModel.Filter.Material_Id != 0)
                {
                    vViewModel.Vendor_Grid = _vendorMan.Get_Vendors_By_Material_Id(vViewModel.Filter.Material_Id, ref  pager);
                }
                else
                {
                    vViewModel.Vendor_Grid = _vendorMan.Get_Vendors(ref pager);
                }

                vViewModel.Pager = pager;

                vViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", vViewModel.Pager.TotalRecords, vViewModel.Pager.CurrentPage + 1, vViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Get_Vendors " + ex.ToString());
            }
           
            finally
            {
                pager = null;
            }

            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Delete_Product_Service_By_Id(int product_Vendor_Id, VendorViewModel vViewModel)
        //{
        //    try
        //    {
        //       _vendorMan.Delete_Product_Service_By_Id(product_Vendor_Id);

        //       vViewModel.Friendly_Message.Add(MessageStore.Get("PS013"));
        //    }
        //    catch (Exception ex)
        //    {
        //        vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Vendor Controller - Delete_Product_Service_By_Id" + ex.ToString());

        //    }
        //    return Json(vViewModel, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult Get_Vendor_Autocomplete(string vendor_Name)
        {
            List<AutocompleteInfo> vendorNames = new List<AutocompleteInfo>();

            vendorNames = _vendorMan.Get_Vendor_AutoComplete(vendor_Name);

            return Json(vendorNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Existing_Vendor(string vendor_Name)
        {
            bool check = false;

            try
            {
                check = _vendorMan.Check_Existing_Vendor(vendor_Name);
            }
            catch (Exception ex)
            {
                Logger.Error("Vendor Controller - Check_Existing_Vendor " + ex.ToString());
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Load_Vendor(VendorViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;
            
            vViewModel.Material_Category = _vendorMan.Get_Material_Category();

            vViewModel.Nations = _nationMan.Get_Nations(ref pager);

            vViewModel.States = _stateMan.Get_States(Convert.ToInt32(vViewModel.Vendor.Head_Office_Nation), ref pager);

            return PartialView("_Vendor", vViewModel);
        }

        //View_Vendor
        public ActionResult View_Vendor(VendorViewModel vViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                vViewModel.Vendor = _vendorMan.Get_Vendor_By_Id(vViewModel.Vendor.Vendor_Id);

                MaterialManager _materialMan = new MaterialManager();

                vViewModel.Materials = _materialMan.Get_Materials_By_Vendor_Id(vViewModel.Vendor.Vendor_Id, ref pager);

            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - View_Vendor " + ex.ToString());
            }

            return View("View", vViewModel);
        }

        public PartialViewResult Printable_Vendor(int vendor_Id)
        {
            ViewBag.Title = "KPCL ERP :: Print";

            VendorViewModel vViewModel = new VendorViewModel();

            vViewModel.Vendor.Vendor_Id = vendor_Id;

            PaginationInfo pager = new PaginationInfo();
            try
            {
                vViewModel.Vendor = _vendorMan.Get_Vendor_By_Id(vViewModel.Vendor.Vendor_Id);

                MaterialManager _materialMan = new MaterialManager();

                vViewModel.Materials = _materialMan.Get_Materials_By_Vendor_Id(vViewModel.Vendor.Vendor_Id, ref pager);
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Printable_Vendor " + ex.ToString());
            }

            return PartialView("_PrintableView", vViewModel);
        }

    }
}




               
