using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
   public class TestInfo
    {
        public TestInfo()
        {
           TestEntity =new M_Test();
        }

        public M_Test TestEntity { get; set; }

        public string Fabric_Type_Name { get; set; }
        
        public int Test_Unit_Id { get; set; }
        
        public string Test_Unit_Name1 { get; set; }
        
        public string Test_Unit_Name2 { get; set; }
        
        public string Test_Unit_Name3 { get; set; }
        
        public string Test_Unit_Name4 { get; set; }
        
        public string Test_Unit_Name5 { get; set; }
        
        public string Test_Unit_Name6 { get; set; }
        
        public string Test_Unit_Name7 { get; set; }
        
        public string Test_Unit_Name8 { get; set; }
        
        public string Test_Unit_Name9 { get; set; }
        
        public string Test_Unit_Name10 { get; set; }
     }
}
