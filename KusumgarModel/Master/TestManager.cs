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

        public List<ProcessInfo> Get_Processes()
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();

            TestRepo tRepo = new TestRepo();

            processes = tRepo.Get_Processes();

            return processes;
        }

        public List<TestInfo> Get_Test_By_Process_Id(int processId, ref PaginationInfo pager)
        {
            List<TestInfo> fabricTypes = new List<TestInfo>();

            TestRepo tRepo = new TestRepo();

            fabricTypes = tRepo.Get_Test_By_Process_Id(processId, ref pager);

            return fabricTypes;
        }

        public List<AutocompleteInfo> Get_Test_Unit_AutoComplete(string testUnitName)
        {
            TestRepo tRepo = new TestRepo();
            return tRepo.Get_Test_Unit_AutoComplete(testUnitName);
        }

        public List<AutocompleteInfo> Get_Test_Autocomplete(string test_Name)
        {
            TestRepo tRepo = new TestRepo();
            return tRepo.Get_Test_Autocomplete(test_Name);
        }

    }
}
