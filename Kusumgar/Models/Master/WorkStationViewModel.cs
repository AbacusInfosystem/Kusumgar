using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class WorkStationViewModel
    {
        public WorkStationViewModel()
        {
            Work_Station = new WorkStationInfo();

            Work_Stations = new List<WorkStationInfo>();

            //Factories = new List<WorkStationInfo>();

            //Work_Centers = new List<WorkStationInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new Work_Station_Filter();

        }

        public WorkStationInfo Work_Station { get; set; }

        public List<WorkStationInfo> Work_Stations { get; set; }

        //public List<WorkStationInfo> Factories { get; set; }

        //public List<WorkStationInfo> Work_Centers { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public Work_Station_Filter Filter { get; set; }

        public string Process_Names { get; set; }
        
    }

    public class Work_Station_Filter
    {
        public int Factory_Id { get; set; }

        public int Work_Center_Id { get; set; }

        public int Process_Id { get; set; }
    }
}