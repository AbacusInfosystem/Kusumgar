using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
   public class TestUnitManager
    {

       public List<TestUnitInfo> GetTestUnits()
        {
            List<TestUnitInfo> testUnit = new List<TestUnitInfo>();

            TestUnitRepo tRepo = new TestUnitRepo();

            testUnit = tRepo.GetTestUnits();

            return testUnit;

        }

       public List<TestUnitInfo> GetTestUnitByName(string TestUnitName)
        {
            List<TestUnitInfo> testUnits = new List<TestUnitInfo>();

            TestUnitRepo tRepo = new TestUnitRepo();

            testUnits = tRepo.GetTestUnitByName(TestUnitName);

            return testUnits;

        }

       public void Insert(TestUnitInfo testUnit)
        {
            TestUnitRepo tRepo = new TestUnitRepo();
            tRepo.Insert(testUnit);
        }

       public TestUnitInfo GetTestUnitById(int testUnitId)
        {
            TestUnitInfo testUnit = new TestUnitInfo();
            TestUnitRepo tRepo = new TestUnitRepo();
            testUnit = tRepo.GetTestUnitById(testUnitId);
            return testUnit;
        }

        public void Update(TestUnitInfo testUnit)
        {
            TestUnitRepo tRepo = new TestUnitRepo();
            tRepo.Update(testUnit);
        }

    }
}
