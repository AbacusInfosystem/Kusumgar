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
using Kusumgar.Models;


namespace Kusumgar.Controllers.PostLogin.Master
{
    public class VendorController : Controller
    {
        //
        // GET: /Vendor/
         public VendorManager _vendorManager;

        public NationManager _nationManager;

        public StateManager _stateManager;

        public VendorController()
        {
            _vendorManager = new VendorManager();

            _nationManager = new NationManager();

            _stateManager = new StateManager();
        }


        public ActionResult Index(VendorViewModel vViewModel)
        {
            vViewModel.Pager.IsPagingRequired=false;
           
            vViewModel.Nation_List=_nationManager.Get_Nation_List(vViewModel.Pager);

            vViewModel.State_List = _stateManager.Get_State_List(Convert.ToInt32(vViewModel.Vendor.Vendor_Entity.Head_Office_Nation), vViewModel.Pager);

            //vViewModel.Vendor.Vendor_Entity.Performance_Certification_Year = GetYears();
            return View("Index", vViewModel);
        }

       
        public ActionResult Search(VendorViewModel vViewModel)
        {
            return View("Search", vViewModel);
        }

        public ActionResult Insert(VendorViewModel vViewModel)
        {
            try
            {
                int VendorId = _vendorManager.Insert_Vendor(vViewModel.Vendor);

                vViewModel.Vendor.Vendor_Entity.Vendor_Id = VendorId;

                vViewModel.Friendly_Message.Add(MessageStore.Get("CU001"));
            }
            catch (Exception ex)
            {
                vViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
            }

            return Json(vViewModel);
        }


        public ActionResult Get_State_by_Nation_Id(int Nation_Id)
        {
            List<StateInfo> StateList = new List<StateInfo>();

            StateManager _stateMgr = new StateManager();

            try
            {
                PaginationInfo Pager = new PaginationInfo();

                Pager.IsPagingRequired = false;

                StateList = _stateMgr.Get_State_List(Nation_Id, Pager);
            }
            catch (Exception ex)
            {

            }
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        //private int GetYears()
        //{
           
        //    List<int> Years = new List<int>();
        //    DateTime startYear = DateTime.Now;
        //    while (startYear.Year <= DateTime.Now.AddYears(3).Year)
        //    {
        //        Years.Add(startYear.Year);
        //        startYear = startYear.AddYears(1);
        //    }
        //  return  ViewBag.Years = Years;
            
        //} 

    }
}


