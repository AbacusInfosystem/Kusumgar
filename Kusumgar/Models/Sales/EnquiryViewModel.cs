using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kusumgar.Models.Sales
{
    public class EnquiryViewModel
    {
         public MachineInfo MachineInfo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public EnquiryViewModel()
        {
            MachineInfo = new MachineInfo();

            MachineInfoList = new List<MachineInfo>();

            MachineProcessList = new List<Machine>();

            CurrentDate = DateTime.Now;

            MondayDate = CurrentDate.AddDays(-((CurrentDate.DayOfWeek - System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 7) % 7)).Date; ;// (DayOfWeek.Monday);

            SundayDate = CurrentDate.AddDays(-((CurrentDate.DayOfWeek - System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek -6) % 7)).Date; ;// (DayOfWeek.Monday);
        }

        public List<MachineInfo> MachineInfoList { get; set; }

        public List<Machine> MachineProcessList { get; set; }

        public DateTime CurrentDate { get; set; }

        public DateTime SundayDate { get; set; }

        public DateTime MondayDate { get; set; }

        public string tempDate { get; set; }

        public int hours { get; set; }

        public int Days
        {
            get
            {
                return (int)(EndDate - StartDate).TotalDays;
            }
            set
            {
                Days = value;
            }
        }

        public string EndDateStr
        {
            get
            {
                string Month = "";
                if (EndDate.Month < 10)
                {
                    Month = "0" + EndDate.Month;
                }
                else
                {
                    Month = EndDate.Month.ToString();
                }
                string Day = "";
                if (EndDate.Day < 10)
                {
                    Day = "0" + EndDate.Day;
                }
                else
                {
                    Day = EndDate.Day.ToString();
                }

                return EndDate.Year + "-" + Month + "-" + Day;
            }
            set
            {
                EndDateStr = value;
            }
        }


        public string StartDateStr
        {
            get
            {
                string Month = "";
                if (StartDate.Month < 10)
                {
                    Month = "0" + StartDate.Month;
                }
                else
                {
                    Month = StartDate.Month.ToString();
                }
                string Day = "";
                if (StartDate.Day < 10)
                {
                    Day = "0" + StartDate.Day;
                }
                else
                {
                    Day = StartDate.Day.ToString();
                }

                return StartDate.Year + "-" + Month + "-" + Day;
            }
            set
            {
                StartDateStr = value;
            }
        }


        public string SundayDateStr
        {
            get
            {
                string Month = "";
                if (SundayDate.Month < 10)
                {
                    Month = "0" + SundayDate.Month;
                }
                else
                {
                    Month = SundayDate.Month.ToString();
                }
                string Day = "";
                if (SundayDate.Day < 10)
                {
                    Day = "0" + SundayDate.Day;
                }
                else
                {
                    Day = SundayDate.Day.ToString();
                }

                return SundayDate.Year + "-" + Month + "-" + Day;
            }
            set
            {
                SundayDateStr = value;
            }
        }


        public string MondayDateStr { 
            get 
            {
                string Month = "";
                if (MondayDate.Month < 10)
                {
                    Month = "0" + MondayDate.Month;
                }
                else
                {
                    Month =  MondayDate.Month.ToString();
                }
                string Day = "";
                if(MondayDate.Day < 10)
                {
                    Day = "0" + MondayDate.Day;
                }
                else
                {
                    Day =  MondayDate.Day.ToString();
                }

                return MondayDate.Year + "-" + Month + "-" + Day;
            }
            set
            {
                MondayDateStr = value;
            }
        }

        public string CurrentDateStr { 
            get 
            {
                string Month = "";
                if (CurrentDate.Month < 10)
                {
                    Month = "0" + CurrentDate.Month;
                }
                else
                {
                    Month = CurrentDate.Month.ToString();
                }
                string Day = "";
                if (CurrentDate.Day < 10)
                {
                    Day = "0" + CurrentDate.Day;
                }
                else
                {
                    Day = CurrentDate.Day.ToString();
                }

                return CurrentDate.Year + "-" + Month + "-" + Day;
            }
            set 
            {
                CurrentDateStr = value;
            }
        }

    }

    
    public class MachineInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventId { get; set; }
        public string MachineName { get; set; }
        public string EventName { get; set; }
        public int MachineId { get; set; }
        public decimal ProcessId { get; set; }
        public string ProcessName { get; set; }

        public int BufferTime { get; set; }

        public int Percentage
        {
            get
            {
                int Percentage;
                if (BufferTime != 0)
                {
                    TimeSpan varTime = EndTime - StartTime;
                    double fractionalMinutes = varTime.TotalMinutes;
                    int minutes = (int)fractionalMinutes;
                     Percentage = Convert.ToInt32((Convert.ToDecimal(BufferTime) / Convert.ToDecimal(minutes)) * 100);
                }
                else
                {
                    Percentage = 0;
                }

                return Percentage;
            }
            set
            {
                Percentage = value;
            }
        }

        public string StartTimeStr { 
            get
            {
                string month = "";
                if (StartTime.Month <10)
                {
                    month = "0" + StartTime.Month;
                }
                else
                {
                    month =  StartTime.Month.ToString();
                }

                string hour = "";
                if (StartTime.Hour < 10)
                {
                    hour = "0" + StartTime.Hour;
                }
                else
                {
                    hour =  StartTime.Hour.ToString();
                }

                string Minute = "";
                if (StartTime.Minute < 10)
                {
                    Minute = "0" + StartTime.Minute;
                }
                else
                {
                    Minute = StartTime.Minute.ToString();
                }

                string Day = "";
                if (StartTime.Day < 10)
                {
                    Day = "0" + StartTime.Day;
                }
                else
                {
                    Day = StartTime.Day.ToString();
                }
                return StartTime.Year + "-" + month + "-" + Day + "T" + hour + ":" + Minute + ":00";   
                //return "2015-04-22T00:00:00";
            }
            set 
            {
                StartTimeStr = value; 
            }
        }
        public string EndTimeStr
        {
            get
            {
                string month = "";
                if (EndTime.Month < 10)
                {
                    month = "0" + EndTime.Month;
                }
                else
                {
                    month = EndTime.Month.ToString();
                }

                string hour = "";
                if (EndTime.Hour < 10)
                {
                    hour = "0" + EndTime.Hour;
                }
                else
                {
                    hour = EndTime.Hour.ToString();
                }
                string Minute = "";
                if (EndTime.Minute < 10)
                {
                    Minute = "0" + EndTime.Minute;
                }
                else
                {
                    Minute = EndTime.Minute.ToString();
                }

                string Day = "";
                if (EndTime.Day < 10)
                {
                    Day = "0" + EndTime.Day;
                }
                else
                {
                    Day = EndTime.Day.ToString();
                }

                return EndTime.Year + "-" + month + "-" + Day + "T" + hour + ":" + Minute + ":00";   
               // return EndTime.Year + "-0" + EndTime.Month + "-" + EndTime.Day + "T" + EndTime.Hour + ":" + StartTime.Minute + ":00";   
              //  return "2015-04-22T12:00:00";
            }
            set
            {
                EndTimeStr = value;
            }
        }
    }

    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public bool IsExpanded { get; set; }
        public List<Process> ProcessList { get; set; }

        public Machine()
        {
            ProcessList = new List<Process>();
        }
    }
    public class Process
    {
        public Decimal ProcessId { get; set; }
        public string ProcessName { get; set; }

    }
    
}