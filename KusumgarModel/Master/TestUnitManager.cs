using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
   public class TestUnitManager
    {
      public List<TestUnitInfo> Get_Test_Units(PaginationInfo pager)
        {
            List<TestUnitInfo> testUnit = new List<TestUnitInfo>();

            TestUnitRepo tRepo = new TestUnitRepo();

            testUnit = tRepo.Get_Test_Units(pager);

            return testUnit;
        }

       public List<TestUnitInfo> Get_Test_Unit_By_Name(string testUnitName,PaginationInfo pager)
        {
            List<TestUnitInfo> testUnits = new List<TestUnitInfo>();

            TestUnitRepo tRepo = new TestUnitRepo();

            testUnits = tRepo.Get_Test_Unit_By_Name(testUnitName,pager);

            return testUnits;
       }

       public void Insert(TestUnitInfo testUnit)
        {
            TestUnitRepo tRepo = new TestUnitRepo();
            
            tRepo.Insert(testUnit);
        }

       public TestUnitInfo Get_Test_Unit_By_Id(int testUnitId)
        {
            TestUnitInfo testUnit = new TestUnitInfo();
            
            TestUnitRepo tRepo = new TestUnitRepo();
            
             testUnit = tRepo.Get_Test_Unit_By_Id(testUnitId);
            
             return testUnit;
        }

        public void Update(TestUnitInfo testUnit)
        {
            TestUnitRepo tRepo = new TestUnitRepo();
            
            tRepo.Update(testUnit);
        }
    }
}
