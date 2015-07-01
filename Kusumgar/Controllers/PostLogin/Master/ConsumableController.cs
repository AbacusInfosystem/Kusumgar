using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarModel;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;


namespace Kusumgar.Controllers.PostLogin.Master
{
    public class ConsumableController : Controller
    {
        public ConsumableManager _consumableMan;

        public ConsumableController()
        {
            _consumableMan = new ConsumableManager();
        }

        public ActionResult Index(ConsumableViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            try
            {
                cViewModel.Categories = _consumableMan.Get_Category_Name(cViewModel.Pager);

                cViewModel.SubCategories = _consumableMan.Get_SubCategory_Name(cViewModel.Pager);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error(" Consumable Controller - Index " + ex.ToString());
            }

            return View("Index", cViewModel);
        }

        public ActionResult Search(ConsumableViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            try
            {

            cViewModel.Categories = _consumableMan.Get_Category_Name(cViewModel.Pager);

             }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error(" Consumable Controller - Index " + ex.ToString());
            }
           
            return View("Search", cViewModel);
        }

        public JsonResult Insert(ConsumableViewModel cViewModel)
        {
           
            try
            {

                int consumableId = _consumableMan.Insert_Consumable(cViewModel.Consumable);

                cViewModel.Consumable.Consumable_Id = consumableId;

                cViewModel.Friendly_Message.Add(MessageStore.Get("C011"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Json(cViewModel,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Consumables(ConsumableViewModel cViewModel)
        {
            try
            {

                if ((cViewModel.Filter.Category_Id > 0) && !string.IsNullOrEmpty(cViewModel.Filter.Material_Name))
                {
                    cViewModel.Consumables = _consumableMan.Get_Consumable_By_Category_Id_By_Material_Name(cViewModel.Filter.Category_Id, cViewModel.Filter.Material_Name, cViewModel.Pager);
                }
                else if (cViewModel.Filter.Category_Id > 0)
                {
                    cViewModel.Consumables = _consumableMan.Get_Consumable_By_Category_Id(cViewModel.Filter.Category_Id, cViewModel.Pager);
                }

                else if (!string.IsNullOrEmpty(cViewModel.Filter.Material_Name))
                {
                    cViewModel.Consumables = _consumableMan.Get_Consumable_By_Material_Name(cViewModel.Filter.Material_Name, cViewModel.Pager);
                }
                else
                {
                    cViewModel.Consumables = _consumableMan.Get_Consumables(cViewModel.Pager);
                }

                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Json(cViewModel, JsonRequestBehavior.AllowGet);
        }

        //Method For Autocomplete   
        public JsonResult Get_Vendor_AutoComplete(string vendor_Name)
        {
            List<AutocompleteInfo> consumables = new List<AutocompleteInfo>();

            try
            {
                consumables = _consumableMan.Get_Vendor_AutoComplete(vendor_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(consumables, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Consumable_Vendor(ConsumableViewModel cViewModel)
        {
            try
            {
                cViewModel.Consumable.Consumable_Vendor.Consumable_Vendor_Id = _consumableMan.Insert_Consumable_Vendor(cViewModel.Consumable);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CV011"));

                //cViewModel.Consumable.Consumable_Vendors = _consumableMan.Get_Consumable_Vendor_By_Consumable_Id(Convert.ToInt32(cViewModel.Consumable.Consumable_Id));
                cViewModel.Consumable.Consumable_Vendors = _consumableMan.Get_Consumable_Vendor_By_Consumable_Id(cViewModel.Consumable.Consumable_Id);

            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Json(cViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete_Vendor_By_Id(int consumable_Vendor_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _consumableMan.Delete_Vendor_By_Id(consumable_Vendor_Id);

                Friendly_Message.Add(MessageStore.Get("CV012"));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Consumable_By_Id(ConsumableViewModel cViewModel)
        {
            try
            {
                cViewModel.Consumable = _consumableMan.Get_Consumable_By_Id(cViewModel.Consumable.Consumable_Id);
                cViewModel.Categories = _consumableMan.Get_Category_Name(cViewModel.Pager);
                cViewModel.SubCategories = _consumableMan.Get_SubCategory_Name(cViewModel.Pager);
                cViewModel.Consumable.Consumable_Vendors = _consumableMan.Get_Consumable_Vendor_By_Consumable_Id(Convert.ToInt32(cViewModel.Consumable.Consumable_Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index", cViewModel);
        }

        public ActionResult Update(ConsumableViewModel cViewModel)
        {
            try
            {
                _consumableMan.Update_Consumable(cViewModel.Consumable);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU013"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Json(cViewModel);
        }

        public JsonResult Update_Consumable_Vendors(ConsumableViewModel cViewModel)
        {
            try
            {
                _consumableMan.Update_Consumable_Vendors(cViewModel.Consumable);

                cViewModel.Consumable.Consumable_Vendors = _consumableMan.Get_Consumable_Vendor_By_Consumable_Id(cViewModel.Consumable.Consumable_Id);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CV014"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

            }

            return Json(cViewModel);
        }
    }
}
