using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class DefectViewModel
    {
        public DefectViewModel()
        {
            Defect = new DefectInfo();

            DefectGrid = new List<DefectInfo>();
            
            EditMode = new DefectEditMode();
           
            Filter = new DefectFilter();

            Processes = new List<ProcessInfo>();
            
            Pager = new PaginationInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public DefectInfo Defect { get; set; }

        public List<DefectInfo> DefectGrid { get; set; }

        public List<ProcessInfo> Processes { get; set; }

        public PaginationInfo Pager { get; set; }

        public DefectEditMode EditMode { get; set; }

        public DefectFilter Filter { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public class DefectEditMode
        {
            public int Defect_Id { get; set; }

        }

        public class DefectFilter
        {
            public int Process_Id { get; set; }
           
            public string Defect_Name{get;set;}

            public int Defect_Id { get; set; }

         }

    }
}
