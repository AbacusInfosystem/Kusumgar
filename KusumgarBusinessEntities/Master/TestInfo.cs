using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
   public class TestInfo
    {
        public TestInfo()
        {
         //  TestEntity =new M_Test();
        }

       // public M_Test TestEntity { get; set; }

        public int Test_Id { get; set; }

        public int Process_Id { get; set; }

        public string Test_Name { get; set; }

        public int Test_Unit1 { get; set; }

        public int Test_Unit2 { get; set; }

        public int Test_Unit3 { get; set; }

        public int Test_Unit4 { get; set; }

        public int Test_Unit5 { get; set; }

        public int Test_Unit6 { get; set; }

        public int Test_Unit7 { get; set; }

        public int Test_Unit8 { get; set; }

        public int Test_Unit9 { get; set; }

        public int Test_Unit10 { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Process_Name { get; set; }
        
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

        #endregion
    }
}
