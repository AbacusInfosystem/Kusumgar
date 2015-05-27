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
            
            Test_Grid = new List<TestInfo>();
            
            Edit_Mode = new Test_Edit_Mode();
            
            Filter = new Test_Filter();
            
            Fabric_Type = new List<FabricTypeInfo>();
            
            Pager = new PaginationInfo();
            
            Friendly_Message = new List<FriendlyMessageInfo>();
         }

        public TestInfo Test { get; set; }

        public List<TestInfo> Test_Grid { get; set; }

        public List<FabricTypeInfo> Fabric_Type { get; set; }

        public Test_Edit_Mode Edit_Mode { get; set; }
       
        public Test_Filter Filter { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
    
        public class Test_Edit_Mode
        {
            public int Test_Id { get; set; }

        }

        public class Test_Filter
        {
            public int Fabric_Type_Id{ get; set; }

        }

    }
}