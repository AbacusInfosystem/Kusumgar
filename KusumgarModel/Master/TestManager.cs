using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
  public  class TestManager
    {
      public List<TestInfo> GetTests()
        {
            List<TestInfo> tests = new List<TestInfo>();

            TestRepo tRepo = new TestRepo();

            tests = tRepo.GetTests();

            return tests;

        }

        public void Insert(TestInfo test)
        {
            TestRepo tRepo = new TestRepo();
            tRepo.Insert(test);
        }

        public TestInfo GetTestById(int testId)
        {
            TestInfo test = new TestInfo();
            TestRepo tRepo = new TestRepo();
            test = tRepo.GetTestById(testId);
            return test;
        }

        public void Update(TestInfo test)
        {
            TestRepo tRepo = new TestRepo();
            tRepo.Update(test);
        }

        public List<FabricTypeInfo> GetFabricTypes()
        {
            List<FabricTypeInfo> fabricTypes = new List<FabricTypeInfo>();
          
            TestRepo tRepo = new TestRepo();
            
            fabricTypes = tRepo.GetFabricTypes();
           
            return fabricTypes;
        }

        public List<TestInfo> GetTestByFabricType(int fabricType)
        {
            List<TestInfo> fabricTypes = new List<TestInfo>();

            TestRepo tRepo = new TestRepo();

            fabricTypes = tRepo.GetTestByFabricType(fabricType);

            return fabricTypes;

        }
    }
}
