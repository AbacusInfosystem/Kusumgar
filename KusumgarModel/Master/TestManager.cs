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
  public  class TestManager
    {
      public List<TestInfo> Get_Tests(ref PaginationInfo pager)
        {
            List<TestInfo> tests = new List<TestInfo>();

            TestRepo tRepo = new TestRepo();

            tests = tRepo.Get_Tests(ref pager);

            return tests;
       }

        public void Insert(TestInfo test)
        {
            TestRepo tRepo = new TestRepo();
            
            tRepo.Insert(test);
        }

        public TestInfo Get_Test_By_Id(int testId)
        {
            TestInfo test = new TestInfo();
            
            TestRepo tRepo = new TestRepo();
            
            test = tRepo.Get_Test_By_Id(testId);
            
            return test;
        }

        public void Update(TestInfo test)
        {
            TestRepo tRepo = new TestRepo();
            
            tRepo.Update(test);
        }

        public List<FabricTypeInfo> Get_Fabric_Types()
        {
            List<FabricTypeInfo> fabricTypes = new List<FabricTypeInfo>();
          
            TestRepo tRepo = new TestRepo();
            
            fabricTypes = tRepo.Get_Fabric_Types();
           
            return fabricTypes;
        }

        public List<TestInfo> Get_Test_By_Fabric_Type(int fabricTypeId, ref PaginationInfo pager)
        {
            List<TestInfo> fabricTypes = new List<TestInfo>();

            TestRepo tRepo = new TestRepo();

            fabricTypes = tRepo.Get_Test_By_Fabric_Type(fabricTypeId,ref pager);

            return fabricTypes;
        }

        public List<AutocompleteInfo> Get_Test_AutoComplete(string testUnitName)
        {
            TestRepo tRepo = new TestRepo();
            return tRepo.Get_Test_AutoComplete(testUnitName);
        }

    }
}
