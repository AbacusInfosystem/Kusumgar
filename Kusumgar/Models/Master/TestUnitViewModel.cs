using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;

namespace Kusumgar.Models
{
    public class TestUnitViewModel
    {
        public TestUnitViewModel()
        {
            TestUnit = new TestUnitInfo();

            TestUnitGrid = new List<TestUnitInfo>();
           
            EditMode = new TestUnitEditMode();
           
            Filter = new TestUnitFilter();
            
            Pager = new PaginationInfo();

            Pager.PageSize = 2;

            Pager.IsPagingRequired = true;
       }

        public TestUnitInfo TestUnit { get; set; }
       
        public List<TestUnitInfo> TestUnitGrid { get; set; }
       
        public TestUnitEditMode EditMode { get; set; }
       
        public TestUnitFilter Filter { get; set; }
       
        public PaginationInfo Pager { get; set; }
    
        public class TestUnitEditMode
        {
            public int TestUnitId { get; set; }

        }

        public class TestUnitFilter
        {
            public string TestUnitName { get; set; }

        }
    }
}