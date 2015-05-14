using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public  class TestUnitInfo
    {
      public TestUnitInfo()
      {
            TestUnitEntity =new M_Test_Unit();
       
       }
      public M_Test_Unit TestUnitEntity { get; set; }
      
        public string Label { get; set; }
        
        public int Value { get; set; }
    }
}
