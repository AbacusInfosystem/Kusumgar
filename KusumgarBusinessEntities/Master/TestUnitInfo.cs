using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public  class TestUnitInfo
    {
      public TestUnitInfo()
      {
            //TestUnitEntity =new M_Test_Unit();
       
       }
    //  public M_Test_Unit TestUnitEntity { get; set; }

      public int Test_Unit_Id { get; set; }

      public string Test_Unit_Name { get; set; }

      public bool Status { get; set; }

      public DateTime CreatedOn { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedOn { get; set; }

      public int UpdatedBy { get; set; }

      #region Additional Fields

      public string Label { get; set; }
        
        public int Value { get; set; }

      #endregion
    }
}
