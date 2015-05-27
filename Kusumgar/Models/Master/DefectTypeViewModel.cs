using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;

namespace Kusumgar.Models
{
    public class DefectTypeViewModel
    {
        public DefectTypeViewModel()
        {
            DefectType = new DefectTypeInfo();

            DefectTypeGrid = new List<DefectTypeInfo>();
           
            EditMode = new Defect_Type_Edit_Mode();
           
            Filter = new Defect_Type_Filter();

            Pager = new PaginationInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();
            
        }

        public DefectTypeInfo DefectType { get; set; }

        public List<DefectTypeInfo> DefectTypeGrid { get; set; }

        public Defect_Type_Edit_Mode EditMode { get; set; }
       
        public Defect_Type_Filter Filter { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
      
        public class Defect_Type_Edit_Mode
        {
            public int Defect_Type_Id { get; set; }

        }

        public class Defect_Type_Filter
        {
            public string Defect_Type_Name { get; set; }
  
        }

    }
}

