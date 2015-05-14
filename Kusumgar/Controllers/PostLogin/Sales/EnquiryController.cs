using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models.Sales;

namespace Kusumgar.Controllers
{
    public class EnquiryController : Controller
    {
        //
        // GET: /Enquiry/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PPC_Checkpoint()
        {
            return View();
        }

        public ActionResult Quality_Checkpoint()
        {
            return View();
        }

        public ActionResult QualitySet_Checkpoint()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Search_PPC_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_W_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_P_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_C_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_Quality_Manager_Checkpoint()
        {
            return View();
        }

        public ActionResult Search_Planned()
        {
            return View();
        }

        //
        public ActionResult Search_PPC_Planning()
        {
            return View();
        }

        public ActionResult PPC_Planning()
        {
            return View();
        }

        public ActionResult _Schedule(DateTime? StartDate, DateTime? EndDate)
        {
            EnquiryViewModel EnquiryViewModel = new EnquiryViewModel();
            try
            {
                EnquiryViewModel.StartDate = Convert.ToDateTime(StartDate);
                EnquiryViewModel.EndDate = Convert.ToDateTime(EndDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView( EnquiryViewModel);
        }



        public ActionResult BindSchedule(EnquiryViewModel EnquiryViewModel)
        {
            //HomeModel HomeModel = new Models.HomeModel();
            EnquiryViewModel.MachineInfoList = new List<MachineInfo>();


            try
            {
               EnquiryViewModel.EndDate =  EnquiryViewModel.EndDate.AddDays(5);

                if (EnquiryViewModel.hours == 0)
                {
                    EnquiryViewModel.hours = 3;
                }


                EnquiryViewModel.MachineInfoList.Add(
               new MachineInfo()
               {
                   MachineId = 1,
                   ProcessId = 1.1m,
                   EventId = 1,
                   EventName = "Job -1",
                   StartTime = new DateTime(2015, 04, 27, 12, 30, 00),
                   EndTime = DateTime.Now.AddHours(EnquiryViewModel.hours),
                   BufferTime = 300
               });

                EnquiryViewModel.MachineInfoList.Add(
              new MachineInfo()
              {
                  MachineId = 2,
                  EventId = 1,
                  EventName = "Job -2",
                  StartTime = DateTime.Now,
                  EndTime = DateTime.Now.AddHours(EnquiryViewModel.hours),
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


                EnquiryViewModel.MachineProcessList.Add(new Machine()
                {
                    MachineId = 1,
                    MachineName = "Machine 1",
                    IsExpanded = true,
                    ProcessList = ProcessList
                });

                EnquiryViewModel.MachineProcessList.Add(new Machine()
                {
                    MachineId = 2,
                    MachineName = "Machine 2"

                });

                EnquiryViewModel.MachineProcessList.Add(new Machine()
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

            return Json(new { EnquiryViewModel });
        }
    }
}
