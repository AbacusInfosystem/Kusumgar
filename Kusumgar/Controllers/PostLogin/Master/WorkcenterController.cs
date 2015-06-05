using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;


namespace Kusumgar.Controllers
{
    public class WorkCenterController : Controller
    {
        public WorkCenterManager _workcenterMan;

        public WorkCenterController()
        {
            _workcenterMan = new WorkCenterManager();
        }

        public ActionResult Index(WorkCenterViewModel wcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;
               
                wcViewModel.Work_Center.Factories = _workcenterMan.Get_Factories(ref pager);

                wcViewModel.Work_Center.Processes = _workcenterMan.Get_Processes(ref pager);

            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return View("Index", wcViewModel);
        }

        public ActionResult Search(WorkCenterViewModel wcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["wcViewModel"] != null)
            {
                wcViewModel = (WorkCenterViewModel)TempData["wcViewModel"];
            }

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;

                wcViewModel.Work_Center.Factories = _workcenterMan.Get_Factories(ref pager);

                wcViewModel.Work_Center.Work_Stations = _workcenterMan.Get_Work_Stations(ref pager);

                wcViewModel.Work_Center.Processes = _workcenterMan.Get_Processes(ref pager);
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Search " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search", wcViewModel);
        }

        public JsonResult Get_Work_Stations_By_Factory_Id(int factory_Id, WorkCenterViewModel wcViewModel)
        {
           
            try
            {
                PaginationInfo pager = new PaginationInfo();

                pager.IsPagingRequired = false;

                wcViewModel.Work_Center.Work_Stations = _workcenterMan.Get_Work_Stations_By_Factory_Id(factory_Id, ref pager);
            }
            catch (Exception ex)
            {
                Logger.Error("Work Center Controller - Get_Work_Stations_By_Factory_Id " + ex.ToString());
            }
            return Json(wcViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Work_Centers(WorkCenterViewModel wcViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = wcViewModel.Pager;

                if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Work_Station_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_By_Process_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Work_Station_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Work_Station_Id != 0))
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Work_Station_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Factory_Id_By_Work_Process_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Work_Station_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Work_Station_Id_By_Work_Process_Id(wcViewModel.Filter.Work_Station_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if (wcViewModel.Filter.Factory_Id != 0)
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Factory_Id(wcViewModel.Filter.Factory_Id, ref pager);
                }
                else if (wcViewModel.Filter.Work_Station_Id != 0)
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Work_Station_Id(wcViewModel.Filter.Work_Station_Id, ref pager);
                }
                else if (wcViewModel.Filter.Process_Id != 0)
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers_By_Process_Id(wcViewModel.Filter.Process_Id, ref pager);
                }
                else
                {
                    wcViewModel.Work_Centers = _workcenterMan.Get_Work_Centers(ref pager);
                }
                wcViewModel.Pager = pager;

                wcViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", wcViewModel.Pager.TotalRecords, wcViewModel.Pager.CurrentPage + 1, wcViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Get_Work_Centers " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(wcViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(WorkCenterViewModel wcViewModel)
        {
            try
            {
                wcViewModel.Work_Center.Work_Center_Entity.CreatedOn = DateTime.Now;

                wcViewModel.Work_Center.Work_Center_Entity.CreatedBy = ((UserInfo)Session["User"]).UserId;

                wcViewModel.Work_Center.Work_Center_Entity.UpdatedOn = DateTime.Now;

                wcViewModel.Work_Center.Work_Center_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                //wcViewModel.Work_Center.Work_Center_Entity.Work_Center_Id = _workcenterMan.Insert_Work_Center(wcViewModel.Work_Center);

                _workcenterMan.Insert_Work_Center(wcViewModel.Work_Center);

                wcViewModel.Friendly_Message.Add(MessageStore.Get("WC001"));
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Insert " + ex.ToString());
            }

            TempData["wcViewModel"] = wcViewModel;

            return RedirectToAction("Search"); 
        }

        public ActionResult Update(WorkCenterViewModel wcViewModel)
        {
            try
            {
                wcViewModel.Work_Center.Work_Center_Entity.UpdatedOn = DateTime.Now;

                wcViewModel.Work_Center.Work_Center_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _workcenterMan.Update_Work_Center(wcViewModel.Work_Center);

                wcViewModel.Friendly_Message.Add(MessageStore.Get("WC002"));
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Update " + ex.ToString());
            }

            TempData["wcViewModel"] = wcViewModel;

            return RedirectToAction("Search");
        }

        
        public ActionResult Get_Work_Centers_By_Work_Center_Id(WorkCenterViewModel wcViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                wcViewModel.Work_Center = _workcenterMan.Get_Work_Centers_By_Work_Center_Id(wcViewModel.Work_Center.Work_Center_Entity.Work_Center_Id);

                pager.IsPagingRequired = false;

                wcViewModel.Work_Center.Factories = _workcenterMan.Get_Factories(ref pager);

                wcViewModel.Work_Center.Work_Stations = _workcenterMan.Get_Work_Stations(ref pager);

                wcViewModel.Work_Center.Processes = _workcenterMan.Get_Processes(ref pager);

            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Center Controller - Get_Work_Centers_By_Work_Center_Id " + ex.ToString());
            }

            return View("Index", wcViewModel);
        }


    }
}
