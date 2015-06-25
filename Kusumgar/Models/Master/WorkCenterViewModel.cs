using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class WorkCenterViewModel
    {
        public WorkCenterViewModel()
        {
            Work_Center = new WorkCenterInfo();

            Work_Centers = new List<WorkCenterInfo>();

            //Factories = new List<WorkCenterInfo>();

            //Work_Stations = new List<WorkCenterInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new Work_Center_Filter();

        }

        public WorkCenterInfo Work_Center { get; set; }

        public List<WorkCenterInfo> Work_Centers { get; set; }

        //public List<WorkCenterInfo> Factories { get; set; }

        //public List<WorkCenterInfo> Work_Stations { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public Work_Center_Filter Filter { get; set; }

        public string Process_Names { get; set; }
        
    }

    public class Work_Center_Filter
    {
        public int Factory_Id { get; set; }

        public int Work_Station_Id { get; set; }

        public int Process_Id { get; set; }
    }
}