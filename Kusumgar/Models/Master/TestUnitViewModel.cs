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
            Test_Unit = new TestUnitInfo();

            Test_Unit_Grid = new List<TestUnitInfo>();
           
            Edit_Mode = new Test_Unit_Edit_Mode();
           
            Filter = new Test_Unit_Filter();

            Pager = new PaginationInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();
       }

        public TestUnitInfo Test_Unit { get; set; }
       
        public List<TestUnitInfo> Test_Unit_Grid { get; set; }
       
        public Test_Unit_Edit_Mode Edit_Mode { get; set; }
       
        public Test_Unit_Filter Filter { get; set; }
       
        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
    
        public class Test_Unit_Edit_Mode
        {
            public int Test_Unit_Id { get; set; }

        }

        public class Test_Unit_Filter
        {
            public string Test_Unit_Name { get; set; }

        }
    }
}