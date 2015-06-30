using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;


namespace Kusumgar.Controllers
{
    public class WorkStationController : Controller
    {
        public WorkStationManager _workStationMan;

        public WorkStationController()
        {
            _workStationMan = new WorkStationManager();
        }

        public ActionResult Index(WorkStationViewModel wcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;
               
                wcViewModel.Work_Station.Factories = _workStationMan.Get_Factories(ref pager);

                wcViewModel.Work_Station.Processes = _workStationMan.Get_Processes(ref pager);

            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return View("Index", wcViewModel);
        }

        public ActionResult Search(WorkStationViewModel wcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            if (TempData["wcViewModel"] != null)
            {
                wcViewModel = (WorkStationViewModel)TempData["wcViewModel"];
            }

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;

                wcViewModel.Work_Station.Factories = _workStationMan.Get_Factories(ref pager);

                wcViewModel.Work_Station.Work_Centers = _workStationMan.Get_Work_Centers(ref pager);

                wcViewModel.Work_Station.Processes = _workStationMan.Get_Processes(ref pager);
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Search " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search", wcViewModel);
        }

        public JsonResult Get_Work_Centers_By_Factory_Id(int factory_Id, WorkStationViewModel wcViewModel)
        {
           
            try
            {
                PaginationInfo pager = new PaginationInfo();

                pager.IsPagingRequired = false;

                wcViewModel.Work_Station.Work_Centers = _workStationMan.Get_Work_Centers_By_Factory_Id(factory_Id, ref pager);
            }
            catch (Exception ex)
            {
                Logger.Error("Work Station Controller - Get_Work_Centers_By_Factory_Id " + ex.ToString());
            }
            return Json(wcViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Work_Stations(WorkStationViewModel wcViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = wcViewModel.Pager;

                if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Work_Center_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Work_Center_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Work_Center_Id != 0))
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Work_Center_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Factory_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Factory_Id_By_Work_Process_Id(wcViewModel.Filter.Factory_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if ((wcViewModel.Filter.Work_Center_Id != 0) && (wcViewModel.Filter.Process_Id != 0))
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Work_Center_Id_By_Work_Process_Id(wcViewModel.Filter.Work_Center_Id, wcViewModel.Filter.Process_Id, ref pager);
                }
                else if (wcViewModel.Filter.Factory_Id != 0)
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Factory_Id(wcViewModel.Filter.Factory_Id, ref pager);
                }
                else if (wcViewModel.Filter.Work_Center_Id != 0)
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Work_Center_Id(wcViewModel.Filter.Work_Center_Id, ref pager);
                }
                else if (wcViewModel.Filter.Process_Id != 0)
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations_By_Process_Id(wcViewModel.Filter.Process_Id, ref pager);
                }
                else
                {
                    wcViewModel.Work_Stations = _workStationMan.Get_Work_Stations(ref pager);
                }
                wcViewModel.Pager = pager;

                wcViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", wcViewModel.Pager.TotalRecords, wcViewModel.Pager.CurrentPage + 1, wcViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Get_Work_Stations " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(wcViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(WorkStationViewModel wcViewModel)
        {
            try
            {
                wcViewModel.Work_Station.CreatedOn = DateTime.Now;

                wcViewModel.Work_Station.CreatedBy = ((UserInfo)Session["User"]).UserId;

                wcViewModel.Work_Station.UpdatedOn = DateTime.Now;

                wcViewModel.Work_Station.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                //wcViewModel.Work_Station.Work_Station_Id = _workStationMan.Insert_Work_Station(wcViewModel.Work_Station);

                _workStationMan.Insert_Work_Station(wcViewModel.Work_Station);

                wcViewModel.Friendly_Message.Add(MessageStore.Get("WC001"));
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Insert " + ex.ToString());
            }

            TempData["wcViewModel"] = wcViewModel;

            return RedirectToAction("Search"); 
        }

        public ActionResult Update(WorkStationViewModel wcViewModel)
        {
            try
            {
                wcViewModel.Work_Station.UpdatedOn = DateTime.Now;

                wcViewModel.Work_Station.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _workStationMan.Update_Work_Station(wcViewModel.Work_Station);

                wcViewModel.Friendly_Message.Add(MessageStore.Get("WC002"));
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Update " + ex.ToString());
            }

            TempData["wcViewModel"] = wcViewModel;

            return RedirectToAction("Search");
        }

        
        public ActionResult Get_Work_Stations_By_Work_Station_Id(WorkStationViewModel wcViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                wcViewModel.Work_Station = _workStationMan.Get_Work_Stations_By_Work_Station_Id(wcViewModel.Work_Station.Work_Station_Id);

                pager.IsPagingRequired = false;

                wcViewModel.Work_Station.Factories = _workStationMan.Get_Factories(ref pager);

                wcViewModel.Work_Station.Work_Centers = _workStationMan.Get_Work_Centers(ref pager);

                wcViewModel.Work_Station.Processes = _workStationMan.Get_Processes(ref pager);

                wcViewModel.Work_Station.Work_Station_Processes = _workStationMan.Get_Work_Station_Processes(wcViewModel.Work_Station.Work_Station_Id, ref pager);

            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Get_Work_Stations_By_Work_Station_Id " + ex.ToString());
            }

            return View("Index", wcViewModel);
        }

        // 
        public ActionResult View_Work_Station(WorkStationViewModel wcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                wcViewModel.Work_Station = _workStationMan.Get_Work_Stations_By_Work_Station_Id(wcViewModel.Work_Station.Work_Station_Id);

                wcViewModel.Work_Station.Work_Station_Processes = _workStationMan.Get_Work_Station_Processes(wcViewModel.Work_Station.Work_Station_Id, ref pager);

                //if(wcViewModel.Work_Station.Work_Station_Processes.Count > 0)
                //{
                    foreach (var item in wcViewModel.Work_Station.Work_Station_Processes)
                    {
                        wcViewModel.Process_Names += item.Process_Name +", ";
                    }
                //}
  
            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - View_Vendor " + ex.ToString());
            }

            return View("View", wcViewModel);
        }

        public PartialViewResult Printable_Work_Station(int work_Station_Id)
        {
            ViewBag.Title = "KPCL ERP :: Print";

            WorkStationViewModel wcViewModel = new WorkStationViewModel();

            wcViewModel.Work_Station.Work_Station_Id = work_Station_Id;

            PaginationInfo pager = new PaginationInfo();
            try
            {
                wcViewModel.Work_Station = _workStationMan.Get_Work_Stations_By_Work_Station_Id(wcViewModel.Work_Station.Work_Station_Id);

                wcViewModel.Work_Station.Work_Station_Processes = _workStationMan.Get_Work_Station_Processes(wcViewModel.Work_Station.Work_Station_Id, ref pager);

                //if(wcViewModel.Work_Station.Work_Station_Processes.Count > 0)
                //{
                foreach (var item in wcViewModel.Work_Station.Work_Station_Processes)
                {
                    wcViewModel.Process_Names += item.Process_Name + ", ";
                }
                //}

            }
            catch (Exception ex)
            {
                wcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Work Station Controller - Printable_Vendor " + ex.ToString());
            }

            return PartialView("_PrintableView", wcViewModel);
        }

    }
}
