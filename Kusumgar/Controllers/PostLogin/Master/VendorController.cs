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
            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            vViewModel.Nations = _nationMan.Get_Nations(ref pager);

            vViewModel.States = _stateMan.Get_States(Convert.ToInt32(vViewModel.Vendor.Vendor_Entity.Head_Office_Nation), ref pager);

            return View("Index", vViewModel);
        }

        public ActionResult Search(VendorViewModel vViewModel)
        {
            if (TempData["vViewModel"] != null)
            {
                vViewModel = (VendorViewModel)TempData["vViewModel"];
            }
            return View("Search", vViewModel);
        }

        public ActionResult Insert_Vendor(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Vendor.Vendor_Entity.Vendor_Id = _vendorMan.Insert_Vendor(vViewModel.Vendor);

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

        public ActionResult Insert_Product_Service(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Product_Vendor.Product_Vendor_Entity.Product_Vendor_Id= _vendorMan.Insert_Product_Services(vViewModel.Product_Vendor);

                vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Product_Vendor.Product_Vendor_Entity.Vendor_Id);

                vViewModel.Friendly_Message.Add(MessageStore.Get("PS011"));
            } 
            catch (Exception ex)
            {
                 vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                 Logger.Error("Vendor Controller - Insert_Product_Vendor_Details " + ex.ToString());
            }

            return Json(vViewModel);
        }

        public ActionResult Update_Vendor(VendorViewModel vViewModel)
        {
            try
            {
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

        public ActionResult Update_Product_Service(VendorViewModel vViewModel)
        {
            try
            {
                _vendorMan.Update_Product_Services(vViewModel.Product_Vendor);

                vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Product_Vendor.Product_Vendor_Entity.Vendor_Id);

                vViewModel.Friendly_Message.Add(MessageStore.Get("PS012"));

            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Update_Product_Vendor_Details " + ex.ToString());
            }

            return Json(vViewModel);
        }

        public ActionResult Get_Vendor_By_Id(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Vendor = _vendorMan.Get_Vendor_By_Id(vViewModel.Vendor.Vendor_Entity.Vendor_Id);
                
                vViewModel.Product_Vendor_Grid = _vendorMan.Get_Product_Vendor_By_Id(vViewModel.Vendor.Vendor_Entity.Vendor_Id);
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

                if (vViewModel.Filter.Vendor_Id != 0)
                {
                    vViewModel.Vendor_Grid = _vendorMan.Get_Vendors_By_Id(vViewModel.Filter.Vendor_Id, ref  pager);
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

        public JsonResult Delete_Product_Service_By_Id(int product_Vendor_Id, VendorViewModel vViewModel)
        {
            try
            {
               _vendorMan.Delete_Product_Service_By_Id(product_Vendor_Id);

               vViewModel.Friendly_Message.Add(MessageStore.Get("PS013"));
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Delete_Product_Service_By_Id" + ex.ToString());

            }
            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

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
    }
}




               
