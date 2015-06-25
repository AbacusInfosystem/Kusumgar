using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Web;

namespace KusumgarDataAccess
{
  public  class TestUnitRepo
    {
        SQLHelperRepo _sqlRepo;

        public TestUnitRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<TestUnitInfo> Get_Test_Units(ref PaginationInfo pager)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Test_Units_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
               retVal.Add(Get_Test_Unit_Values(dr));
           }
               
            return retVal;
        }

        public void Insert(TestUnitInfo testUnit)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Test_Unit(testUnit), StoredProcedures.Insert_Test_Unit_sp.ToString(), CommandType.StoredProcedure);
        }

        public TestUnitInfo Get_Test_Unit_By_Id(int testUnitId)
        {
            TestUnitInfo retVal = new TestUnitInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Unit_Id", testUnitId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_Unit_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
               
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal = (Get_Test_Unit_Values(dr));
                }
            }
            return retVal;
        }

        public void Update(TestUnitInfo testUnit)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Test_Unit(testUnit), StoredProcedures.Update_Test_Unit_sp.ToString(), CommandType.StoredProcedure); 
        }

        private List<SqlParameter> Set_Values_In_Test_Unit(TestUnitInfo testUnitInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Test_Unit_Name", testUnitInfo.Test_Unit_Name));
            
            sqlParamList.Add(new SqlParameter("@Status", testUnitInfo.Status));
            
            sqlParamList.Add(new SqlParameter("@UpdatedBy", testUnitInfo.UpdatedBy));
            
            if (testUnitInfo.Test_Unit_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", testUnitInfo.CreatedBy));
            }
            if (testUnitInfo.Test_Unit_Id!= 0)
            {
                sqlParamList.Add(new SqlParameter("@Test_Unit_Id", testUnitInfo.Test_Unit_Id));

            }

            return sqlParamList;
        }

        public List<AutocompleteInfo> Get_Test_Unit_AutoComplete(string test_Unit_Name)
        {
            List<AutocompleteInfo> testUnitName = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Unit_Name", test_Unit_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_Unit_AutoComplete_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Test_Unit_Name"]);

                    auto.Value = Convert.ToInt32(dr["Test_Unit_Id"]);

                    testUnitName.Add(auto);
                }
            }

            return testUnitName;
        }

        private TestUnitInfo Get_Test_Unit_Values(DataRow dr)
        {
            TestUnitInfo testUnits = new TestUnitInfo();

            testUnits.Test_Unit_Id = Convert.ToInt32(dr["Test_Unit_Id"]);

            testUnits.Test_Unit_Name = Convert.ToString(dr["Test_Unit_Name"]);

            testUnits.Status = Convert.ToBoolean(dr["Status"]);

            testUnits.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            testUnits.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            testUnits.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            testUnits.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            return testUnits;
        }

        public List<TestUnitInfo> Get_Test_Unit_By_Name(string testUnit, ref PaginationInfo pager)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Unit_Name", testUnit));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_Unit_By_Name_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                  retVal.Add(Get_Test_Unit_Values(dr));
            }

           return retVal;
        }
  }
}
