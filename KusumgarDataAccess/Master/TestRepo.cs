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

namespace KusumgarDataAccess
{
  public  class TestRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public TestRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<TestInfo> Get_Tests(ref PaginationInfo pager)
        {
            List<TestInfo> retVal = new List<TestInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Tests_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                retVal.Add(Get_Test_Values(dr));
            }

            return retVal;
        }

        public void Insert(TestInfo test)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Test(test), StoredProcedures.Insert_Test_sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update(TestInfo test)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Test(test), StoredProcedures.Update_Test_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Test(TestInfo testInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Fabric_Type_Id", testInfo.Fabric_Type_Id));
            sqlParamList.Add(new SqlParameter("@Status", testInfo.Status));
            sqlParamList.Add(new SqlParameter("@Test_Name", testInfo.Test_Name));
            sqlParamList.Add(new SqlParameter("@Test_Unit1", testInfo.Test_Unit1));
            sqlParamList.Add(new SqlParameter("@Test_Unit2", testInfo.Test_Unit2));
            sqlParamList.Add(new SqlParameter("@Test_Unit3", testInfo.Test_Unit3));
            sqlParamList.Add(new SqlParameter("@Test_Unit4", testInfo.Test_Unit4));
            sqlParamList.Add(new SqlParameter("@Test_Unit5", testInfo.Test_Unit5));
            sqlParamList.Add(new SqlParameter("@Test_Unit6", testInfo.Test_Unit6));
            sqlParamList.Add(new SqlParameter("@Test_Unit7", testInfo.Test_Unit7));

            sqlParamList.Add(new SqlParameter("@Test_Unit8", testInfo.Test_Unit8));

            sqlParamList.Add(new SqlParameter("@Test_Unit9", testInfo.Test_Unit9));

            sqlParamList.Add(new SqlParameter("@Test_Unit10", testInfo.Test_Unit10));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", testInfo.UpdatedBy));
            if (testInfo.Test_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", testInfo.CreatedBy));
            }
            if (testInfo.Test_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Test_Id", testInfo.Test_Id));

            }

            return sqlParamList;
        }

        public TestInfo Get_Test_By_Id(int testId)
        {
            TestInfo retVal = new TestInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Id", testId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal = Get_Test_Values(dr);
                }
           }
            return retVal;
        }

        public List<FabricTypeInfo> Get_Fabric_Types()
        {
            List<FabricTypeInfo> retVal = new List<FabricTypeInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Fabric_Types_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    FabricTypeInfo fabricTypes = new FabricTypeInfo();
                    fabricTypes.Fabric_Type_Id = Convert.ToInt32(dr["Fabric_Type_Id"]);
                    fabricTypes.Fabric_Type_Name = Convert.ToString(dr["Fabric_Type_Name"]);
                    retVal.Add(fabricTypes);
                }

            }

            return retVal;
        }

        public List<TestInfo> Get_Test_By_Fabric_Type(int fabricTypeId,ref PaginationInfo pager)
        {
            List<TestInfo> retVal = new List<TestInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Fabric_Type_Id",fabricTypeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Test_By_Fabric_Type_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {

                    retVal.Add(Get_Test_Values(dr));
           }
         return retVal;
        }

        public List<AutocompleteInfo> Get_Test_AutoComplete(string testUnitName)
        {
            List<AutocompleteInfo> testUnitNames = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Test_Unit_Name", testUnitName));

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

                    testUnitNames.Add(auto);
                }
            }

            return testUnitNames;
        }

        private TestInfo Get_Test_Values(DataRow dr)
        {
            TestInfo tests = new TestInfo();

            tests.Test_Id = Convert.ToInt32(dr["Test_Id"]);

            tests.Fabric_Type_Id = Convert.ToInt32(dr["Fabric_Type_Id"]);

            tests.Status = Convert.ToBoolean(dr["Status"]);

            tests.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            tests.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            tests.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            tests.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            tests.Test_Name = Convert.ToString(dr["Test_Name"]);

            if (dr["Test_Unit1"] != DBNull.Value)
            {
                tests.Test_Unit1 = Convert.ToInt32(dr["Test_Unit1"]);
            }
            else
            {
                tests.Test_Unit1 = 0;
            }

            if (dr["Test_Unit2"] != DBNull.Value)
            {
                tests.Test_Unit2 = Convert.ToInt32(dr["Test_Unit2"]);
            }
            else
            {
                tests.Test_Unit2 = 0;
            }

            if (dr["Test_Unit3"] != DBNull.Value)
            {
                tests.Test_Unit3 = Convert.ToInt32(dr["Test_Unit3"]);
            }
            else
            {
                tests.Test_Unit3 = 0;
            }

            if (dr["Test_Unit4"] != DBNull.Value)
            {
                tests.Test_Unit4 = Convert.ToInt32(dr["Test_Unit4"]);
            }
            else
            {
                tests.Test_Unit4 = 0;
            }

            if (dr["Test_Unit5"] != DBNull.Value)
            {
                tests.Test_Unit5 = Convert.ToInt32(dr["Test_Unit5"]);
            }
            else
            {
                tests.Test_Unit5 = 0;
            }

            if (dr["Test_Unit6"] != DBNull.Value)
            {
                tests.Test_Unit6 = Convert.ToInt32(dr["Test_Unit6"]);
            }
            else
            {
                tests.Test_Unit6 = 0;
            }

            if (dr["Test_Unit7"] != DBNull.Value)
            {
                tests.Test_Unit7 = Convert.ToInt32(dr["Test_Unit7"]);
            }
            else
            {
                tests.Test_Unit7 = 0;
            }

            if (dr["Test_Unit8"] != DBNull.Value)
            {
                tests.Test_Unit8 = Convert.ToInt32(dr["Test_Unit8"]);
            }
            else
            {
                tests.Test_Unit8 = 0;
            }

            if (dr["Test_Unit9"] != DBNull.Value)
            {
                tests.Test_Unit9 = Convert.ToInt32(dr["Test_Unit9"]);
            }
            else
            {
                tests.Test_Unit9 = 0;
            }

            if (dr["Test_Unit10"] != DBNull.Value)
            {
                tests.Test_Unit10 = Convert.ToInt32(dr["Test_Unit10"]);
            }
            else
            {
                tests.Test_Unit10 = 0;
            }

            tests.Fabric_Type_Name = Convert.ToString(dr["Fabric_Type_Name"]);
            tests.Test_Unit_Name1 = Convert.ToString(dr["Test_Unit_Name1"]);
            tests.Test_Unit_Name2 = Convert.ToString(dr["Test_Unit_Name2"]);
            tests.Test_Unit_Name3 = Convert.ToString(dr["Test_Unit_Name3"]);
            tests.Test_Unit_Name4 = Convert.ToString(dr["Test_Unit_Name4"]);
            tests.Test_Unit_Name5 = Convert.ToString(dr["Test_Unit_Name5"]);
            tests.Test_Unit_Name6 = Convert.ToString(dr["Test_Unit_Name6"]);
            tests.Test_Unit_Name7 = Convert.ToString(dr["Test_Unit_Name7"]);
            tests.Test_Unit_Name8 = Convert.ToString(dr["Test_Unit_Name8"]);
            tests.Test_Unit_Name9 = Convert.ToString(dr["Test_Unit_Name9"]);
            tests.Test_Unit_Name10 = Convert.ToString(dr["Test_Unit_Name10"]);

            return tests;
        }
    }
}
