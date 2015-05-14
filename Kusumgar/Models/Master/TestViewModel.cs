using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;

namespace Kusumgar.Models
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            Test = new TestInfo();
            TestGrid = new List<TestInfo>();
            EditMode = new TestEditMode();
            Filter = new TestFilter();
            FabricType = new List<FabricTypeInfo>();
            Pager = new PaginationInfo();
            Pager.PageSize = 7;
            Pager.IsPagingRequired = true;
            
        }

        public TestInfo Test { get; set; }

        public List<TestInfo> TestGrid { get; set; }

        public List<FabricTypeInfo> FabricType { get; set; }

        public TestEditMode EditMode { get; set; }
        public TestFilter Filter { get; set; }

        public PaginationInfo Pager { get; set; }
      
        public class TestEditMode
        {
            public int TestId { get; set; }

        }

        public class TestFilter
        {
            public int FabricTypeName { get; set; }

        }

    }
}