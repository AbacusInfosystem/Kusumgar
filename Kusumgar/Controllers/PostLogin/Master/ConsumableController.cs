using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KusumgarModel;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Controllers.PostLogin.Master
{
    public class ConsumableController : Controller
    {

        public ConsumableManager consumableMgr;

        public ConsumableController()
        {
            consumableMgr = new ConsumableManager();
        }

        ConsumableViewModel ConsumableVM = new ConsumableViewModel();

        public ActionResult Index(ConsumableViewModel ConsumableVM)
        {

            ConsumableVM.CategoryList = consumableMgr.GetCategoryName();
            ConsumableVM.SubCategoryList = consumableMgr.GetSubCategoryName();

            return View(ConsumableVM);
        }

        public JsonResult Insert(ConsumableViewModel ConsumableVM)
        {
            try
            {
                int consumableId = consumableMgr.Insert_Consumable(ConsumableVM.Consumable);

                ConsumableVM.Consumable.Consumable_Entity.Consumable_Id = consumableId;

                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("C011"));
            }
            catch (Exception ex)
            {
                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableVM);
        }

        public ActionResult Search(ConsumableViewModel ConsumableVM)
        {

            ConsumableVM.CategoryList = consumableMgr.GetCategoryName();

            return View(ConsumableVM);
        }

        //
        public ActionResult Get_Consumables(ConsumableViewModel ConsumableVM)
        {
            try
            {
                //if (!string.IsNullOrEmpty(ConsumableVM.FilterVal.Material_Name))
                //{
                //    ConsumableVM.ConsumableList = consumableMgr.Get_Consumable_By_Name_(ConsumableVM.FilterVal.Material_Name, ConsumableVM.Pager);
                //}
                //else
                //{
                //ConsumableVM.ConsumableList = consumableMgr.Get_ConsumableMasters(ConsumableVM.Pager);
                //}
                if ((ConsumableVM.FilterVal.Category_Id > 0) && !string.IsNullOrEmpty(ConsumableVM.FilterVal.Material_Name) )
                {
                    ConsumableVM.ConsumableList = consumableMgr.Get_Consumable_By_Category_By_Material(ConsumableVM.FilterVal.Category_Id, ConsumableVM.FilterVal.Material_Name, ConsumableVM.Pager);
                }
                else if (ConsumableVM.FilterVal.Category_Id > 0)
                {
                    ConsumableVM.ConsumableList = consumableMgr.Get_Consumable_By_Category_Id(ConsumableVM.FilterVal.Category_Id, ConsumableVM.Pager);
                }

                else if (!string.IsNullOrEmpty(ConsumableVM.FilterVal.Material_Name))
                {
                    ConsumableVM.ConsumableList = consumableMgr.Get_Consumable_By_Material_Name(ConsumableVM.FilterVal.Material_Name, ConsumableVM.Pager);
                }
                else
                {
                    ConsumableVM.ConsumableList = consumableMgr.Get_ConsumableMasters(ConsumableVM.Pager);
                }

                ConsumableVM.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", ConsumableVM.Pager.TotalRecords, ConsumableVM.Pager.CurrentPage + 1, ConsumableVM.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableVM, JsonRequestBehavior.AllowGet);
        }

        //Method For Autocomplete
        //Found @ customer listing @ search txtbox
        public JsonResult Get_Supplier_Name(string SupplierName)
        {
           
            List<ConsumableInfo> retVal = new List<ConsumableInfo>();

            retVal = consumableMgr.Get_Supplier_Name(SupplierName);

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Consumable_Vendor(ConsumableViewModel ConsumableVM)
        {
            try
            {
                int Consumable_Vendor_Id = consumableMgr.Insert_Consumable_Vendor(ConsumableVM.Consumable);

                ConsumableVM.Consumable.Consumable_Vendors.Consumable_Vendor_Entity.Consumable_Vendor_Id = Consumable_Vendor_Id;

                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("CV011"));

                //int i = ConsumableVM.Consumable.Consumable_Entity.Consumable_Id;

                ConsumableVM.Consumable.Consumable_Vendor_List= consumableMgr.Get_Consumable_Vendor_By_Id(Convert.ToInt32(ConsumableVM.Consumable.Consumable_Entity.Consumable_Id));
               
            }
            catch (Exception ex)
            {
                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableVM, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete_Vendor_By_Id(int Consumable_Vendor_Id)
        {
            List<FriendlyMessageInfo> FriendlyMessage = new List<FriendlyMessageInfo>();

            try
            {
                consumableMgr.Delete_Vendor_By_Id(Consumable_Vendor_Id);

                FriendlyMessage.Add(MessageStore.Get("CV012"));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { FriendlyMessage }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Consumable_By_Id(ConsumableViewModel ConsumableVM)
        {
            try
            {
                ConsumableVM.Consumable = consumableMgr.Get_Consumable_By_Id(ConsumableVM.Consumable.Consumable_Entity.Consumable_Id);
                ConsumableVM.CategoryList = consumableMgr.GetCategoryName();
                ConsumableVM.SubCategoryList = consumableMgr.GetSubCategoryName();
                //ConsumableVM.Consumable.Consumable_Vendor_List = consumableMgr.Get_Consumable_Vendor_By_Id(Convert.ToInt32(ConsumableVM.Consumable.Consumable_Entity.Consumable_Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //ConsumableVM.CategoryList = consumableMgr.GetCategoryName();
            //ConsumableVM.SubCategoryList = consumableMgr.GetSubCategoryName();
            //ConsumableVM.Consumable.Consumable_Vendor_List = consumableMgr.Get_Consumable_Vendor_By_Id(Convert.ToInt32(ConsumableVM.Consumable.Consumable_Entity.Consumable_Id));

            return View("Index", ConsumableVM);
        }

        public ActionResult Update(ConsumableViewModel ConsumableVM)
        {
            try
            {
                consumableMgr.Update_Consumable(ConsumableVM.Consumable);

                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("CU013"));
            }
            catch (Exception ex)
            {
                ConsumableVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableVM);
        }

    }
}
