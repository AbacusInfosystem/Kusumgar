using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class ProcessViewModel
    {
        public KusumgarBusinessEntities.ProcessInfo Process { get; set; }
        public List<KusumgarBusinessEntities.ProcessInfo> Processes { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public ProcessFilter Filter { get; set; }
        public int Process_Id { get; set; }

        public ProcessViewModel()
        {
            Process = new KusumgarBusinessEntities.ProcessInfo();
            Processes = new List<KusumgarBusinessEntities.ProcessInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Pager = new PaginationInfo();
            Filter = new ProcessFilter();
        }
    }

    public class ProcessFilter
    {
        public string Process_Name { get; set; }
        public int Process_Id { get; set; }
    }
}