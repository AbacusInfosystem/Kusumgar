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
    public class ConsumableMasterController : Controller
    {

        public ConsumableMasterManager consumablemasterMgr;

        public ConsumableMasterController()
        {
            consumablemasterMgr = new ConsumableMasterManager();
        }
        ConsumableMasterViewModel ConsumableMasterVM = new ConsumableMasterViewModel();
        
        public ActionResult Index(ConsumableMasterViewModel ConsumableMasterVM)
        {

            //ConsumableMasterManager consumablemasterMngr = new ConsumableMasterManager();

            ConsumableMasterVM.CategoryList = consumablemasterMgr.GetCategoryName();
            ConsumableMasterVM.SubCategoryList = consumablemasterMgr.GetSubCategoryName();

            return View( ConsumableMasterVM);
        }
        //public ActionResult Insert(ConsumableMasterViewModel ConsumableMasterVM)
        //{
        //    ConsumableMasterManager consumablemasterMngr = new ConsumableMasterManager();

        //    consumablemasterMngr.Insert_Consumable(ConsumableMasterVM.Consumable);

        //    return View("Index", ConsumableMasterVM);

        //}
        public ActionResult Insert(ConsumableMasterViewModel ConsumableMasterVM)
        {
            try
            {
                int Consumable_Id = consumablemasterMgr.Insert_Consumable(ConsumableMasterVM.Consumable);

                ConsumableMasterVM.Consumable.Consumable_Entity.Consumable_Id = Consumable_Id;

                ConsumableMasterVM.FriendlyMessage.Add(MessageStore.Get("CU001"));
            }
            catch (Exception ex)
            {
                ConsumableMasterVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableMasterVM);
        }

        public ActionResult Search(ConsumableMasterViewModel ConsumableMasterVM)
        {
            ConsumableMasterManager consumablemasterMngr = new ConsumableMasterManager();
            //ConsumableMasterVM.ConsumableMasterList = consumablemasterMngr.GetConsumableMaster();

            return View(ConsumableMasterVM);
        }
        public ActionResult Get_ConsumableMasters(ConsumableMasterViewModel ConsumableMasterVM)
        {
            try
            {
                //if (!string.IsNullOrEmpty(ConsumableMasterVM.Role_FilterVal.Role_Name))
                //{
                //    ConsumableMasterVM.ConsumableMasterList = consumablemasterMgr.Get_Roles_By_Name(ConsumableMasterVM.Role_FilterVal.Role_Name, ConsumableMasterVM.Pager);
                //}
                //else
                //{
                    ConsumableMasterVM.ConsumableMasterList = consumablemasterMgr.Get_ConsumableMasters(ConsumableMasterVM.Pager);
                //}

                ConsumableMasterVM.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", ConsumableMasterVM.Pager.TotalRecords, ConsumableMasterVM.Pager.CurrentPage + 1, ConsumableMasterVM.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                ConsumableMasterVM.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(ConsumableMasterVM, JsonRequestBehavior.AllowGet);
        }

        //Method For Autocomplete
        public JsonResult Get_Supplier_Name(string SupplierName)
        {
           
            List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();

            retVal = consumablemasterMgr.Get_Supplier_Name(SupplierName);

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }

    }
}
