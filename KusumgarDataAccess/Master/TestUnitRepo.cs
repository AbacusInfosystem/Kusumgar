using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Web;

namespace KusumgarDataAccess
{
  public  class TestUnitRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public TestUnitRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<TestUnitInfo> Get_Test_Units(PaginationInfo pager)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Test_Units_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, pager);

            foreach (DataRow dr in tupleData.Item1)
            {
                TestUnitInfo testUnits = new TestUnitInfo();

                testUnits.TestUnitEntity.Test_Unit_Id = Convert.ToInt32(dr["Test_Unit_Id"]);

                testUnits.TestUnitEntity.Test_Unit_Name = Convert.ToString(dr["Test_Unit_Name"]);

                testUnits.TestUnitEntity.Status = Convert.ToBoolean(dr["Status"]);

                testUnits.TestUnitEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                testUnits.TestUnitEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                testUnits.TestUnitEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                testUnits.TestUnitEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                retVal.Add(testUnits);

            }
                return retVal;
        }

        private Tuple<List<DataRow>, PaginationInfo> GetRows(DataTable dt, PaginationInfo pager)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (pager.IsPagingRequired)
                {
                    drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                }

                pager.TotalRecords = count;

                int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

                pager.TotalPages = pages;
            }

            return new Tuple<List<DataRow>, PaginationInfo>(drList, pager);
        }
      
        public List<TestUnitInfo> Get_Test_Units_By_Id(int test_Unit_Id,PaginationInfo pager)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Unit_Id",test_Unit_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_Unit_By_Id_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, pager);

             foreach (DataRow dr in tupleData.Item1)
                {
                    TestUnitInfo testUnits = new TestUnitInfo();

                    testUnits.TestUnitEntity.Test_Unit_Id = Convert.ToInt32(dr["Test_Unit_Id"]);

                    testUnits.TestUnitEntity.Test_Unit_Name = Convert.ToString(dr["Test_Unit_Name"]);

                    testUnits.TestUnitEntity.Status = Convert.ToBoolean(dr["Status"]);

                    testUnits.TestUnitEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    testUnits.TestUnitEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                    testUnits.TestUnitEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    testUnits.TestUnitEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    retVal.Add(testUnits);

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
                    retVal.TestUnitEntity.Test_Unit_Id = Convert.ToInt32(dr["Test_Unit_Id"]);
                    
                    retVal.TestUnitEntity.Test_Unit_Name = Convert.ToString(dr["Test_Unit_Name"]);
                    
                    retVal.TestUnitEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    retVal.TestUnitEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    retVal.TestUnitEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    retVal.TestUnitEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                    
                    retVal.TestUnitEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
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

            sqlParamList.Add(new SqlParameter("@Test_Unit_Name", testUnitInfo.TestUnitEntity.Test_Unit_Name));
            
            sqlParamList.Add(new SqlParameter("@Status", testUnitInfo.TestUnitEntity.Status));
            
            sqlParamList.Add(new SqlParameter("@UpdatedBy", testUnitInfo.TestUnitEntity.UpdatedBy));
            
            if (testUnitInfo.TestUnitEntity.Test_Unit_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", testUnitInfo.TestUnitEntity.CreatedBy));
            }
            if (testUnitInfo.TestUnitEntity.Test_Unit_Id!= 0)
            {
                sqlParamList.Add(new SqlParameter("@Test_Unit_Id", testUnitInfo.TestUnitEntity.Test_Unit_Id));

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
    }
}
