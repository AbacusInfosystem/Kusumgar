using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using Kusumgar.Models;
using System.Configuration;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class DefectTypeViewModel
    {
        public DefectTypeViewModel()
        {
            DefectType = new DefectTypeInfo();

            DefectTypeGrid = new List<DefectTypeInfo>();
           
            EditMode = new DefectTypeEditMode();
           
            Filter = new DefectTypeFilter();
            
            Pager = new PaginationInfo();

            Pager.PageSize = 10;

            Pager.IsPagingRequired = true;
            
        }

        public DefectTypeInfo DefectType { get; set; }

        public List<DefectTypeInfo> DefectTypeGrid { get; set; }

        public List<DefectTypeInfo> DefectTypeByName { get; set; }

        public DefectTypeEditMode EditMode { get; set; }
       
        public DefectTypeFilter Filter { get; set; }

        public PaginationInfo Pager { get; set; }
      
        public class DefectTypeEditMode
        {
            public int DefectTypeId { get; set; }

        }

        public class DefectTypeFilter
        {
            public string DefectTypeName { get; set; }
  
        }

    }
}