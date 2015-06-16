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
using System.Web.Security;

namespace Kusumgar.Controllers.PostLogin.Sales
{
    public class SchedulerController : Controller
    {
        //
        // GET: /Scheduler/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Schedule(DateTime? StartDate, DateTime? EndDate)
        {
            SchedulerViewModel SchedulerViewModel = new SchedulerViewModel();
            try
            {
                SchedulerViewModel.StartDate = Convert.ToDateTime(StartDate);
                SchedulerViewModel.EndDate = Convert.ToDateTime(EndDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView(SchedulerViewModel);
        }



        public ActionResult BindSchedule(SchedulerViewModel SchedulerViewModel)
        {
            //HomeModel HomeModel = new Models.HomeModel();
            SchedulerViewModel.MachineInfoList = new List<MachineInfo>();


            try
            {
                SchedulerViewModel.EndDate = SchedulerViewModel.EndDate.AddDays(5);

                if (SchedulerViewModel.hours == 0)
                {
                    SchedulerViewModel.hours = 3;
                }


                SchedulerViewModel.MachineInfoList.Add(
               new MachineInfo()
               {
                   MachineId = 1,
                   ProcessId = 1.1m,
                   EventId = 1,
                   EventName = "Job -1",
                   StartTime = new DateTime(2015, 04, 27, 12, 30, 00),
                   EndTime = DateTime.Now.AddHours(SchedulerViewModel.hours),
                   BufferTime = 300
               });

                SchedulerViewModel.MachineInfoList.Add(
              new MachineInfo()
              {
                  MachineId = 2,
                  EventId = 1,
                  EventName = "Job -2",
                  StartTime = DateTime.Now,
                  EndTime = DateTime.Now.AddHours(SchedulerViewModel.hours),
                  BufferTime = 20
              });


                List<Process> ProcessList = new List<Process>();
                ProcessList.Add(new Process()
                {
                    ProcessId = 1.1m,
                    ProcessName = "Process 1"
                });
                ProcessList.Add(new Process()
                {
                    ProcessId = 1.2m,
                    ProcessName = "Process 2"
                });
                ProcessList.Add(new Process()
                {
                    ProcessId = 1.3m,
                    ProcessName = "Process 3"
                });
                ProcessList.Add(new Process()
                {
                    ProcessId = 1.4m,
                    ProcessName = "Process 4"
                });


                SchedulerViewModel.MachineProcessList.Add(new Machine()
                {
                    MachineId = 1,
                    MachineName = "Machine 1",
                    IsExpanded = true,
                    ProcessList = ProcessList
                });

                SchedulerViewModel.MachineProcessList.Add(new Machine()
                {
                    MachineId = 2,
                    MachineName = "Machine 2"

                });

                SchedulerViewModel.MachineProcessList.Add(new Machine()
                {
                    MachineId = 3,
                    MachineName = "Machine 3"

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.Message = "Your app description page.";

            return Json(new { SchedulerViewModel });
        }

        public ActionResult PPC_Planning()
        {
            return View();
        }
    }
}
