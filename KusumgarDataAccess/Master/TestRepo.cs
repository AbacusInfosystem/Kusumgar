using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace KusumgarDataAccess
{
  public  class TestRepo
    {
       private string _sqlCon = string.Empty;

       public TestRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["ProjectTestDB"].ToString();
        }

        public List<TestInfo> GetTests()
        {
            List<TestInfo> retVal = new List<TestInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTests_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestInfo testItem = new TestInfo();

                                GetValuesFromDataReader(dataReader, testItem);

                                retVal.Add(testItem);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }

        private static void GetValuesFromDataReader(SqlDataReader dataReader, TestInfo test)
        {
            test.TestId = Convert.ToInt32(dataReader["TestId"]);
            test.FabricTypeId = Convert.ToInt32(dataReader["FabricTypeId"]);
            test.FabricTypeName = Convert.ToString(dataReader["FabricTypeName"]);
            test.TestName = Convert.ToString(dataReader["TestName"]);
            test.TestUnit1 = Convert.ToInt32(dataReader["TestUnit1"]);
            test.TestUnit2 = Convert.ToInt32(dataReader["TestUnit2"]);
            test.TestUnit3 = Convert.ToInt32(dataReader["TestUnit3"]);
            test.TestUnit4 = Convert.ToInt32(dataReader["TestUnit4"]);
            test.TestUnit5 = Convert.ToInt32(dataReader["TestUnit5"]);
            test.TestUnit6 = Convert.ToInt32(dataReader["TestUnit6"]);
            test.TestUnit7 = Convert.ToInt32(dataReader["TestUnit7"]);
            test.TestUnit8= Convert.ToInt32(dataReader["TestUnit8"]);
            test.TestUnit9 = Convert.ToInt32(dataReader["TestUnit9"]);
            test.TestUnit10 = Convert.ToInt32(dataReader["TestUnit10"]);
            test.Status = Convert.ToBoolean(dataReader["Status"]);
            test.TestUnitName1 = Convert.ToString(dataReader["TestUnitName1"]);
            test.TestUnitName2 = Convert.ToString(dataReader["TestUnitName2"]);
            test.TestUnitName3 = Convert.ToString(dataReader["TestUnitName3"]);
            test.TestUnitName4 = Convert.ToString(dataReader["TestUnitName4"]);
            test.TestUnitName5 = Convert.ToString(dataReader["TestUnitName5"]);
            test.TestUnitName6 = Convert.ToString(dataReader["TestUnitName6"]);
            test.TestUnitName7 = Convert.ToString(dataReader["TestUnitName7"]);
            test.TestUnitName8 = Convert.ToString(dataReader["TestUnitName8"]);
            test.TestUnitName9 = Convert.ToString(dataReader["TestUnitName9"]);
            test.TestUnitName10 = Convert.ToString(dataReader["TestUnitName10"]);

        }

        public void Insert(TestInfo test)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("InsertTest_sp", con))
                    {
                        SetValuesInTest(command, test, "Insert");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private SqlCommand SetValuesInTest(SqlCommand command, TestInfo test, string mode)
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@FabricTypeName", test.FabricTypeName));

            command.Parameters.Add(new SqlParameter("@Status", test.Status));
            command.Parameters.Add(new SqlParameter("@TestName", test.TestName));
            command.Parameters.Add(new SqlParameter("@TestUnit1", test.TestUnit1));
            command.Parameters.Add(new SqlParameter("@TestUnit2", test.TestUnit2));
            command.Parameters.Add(new SqlParameter("@TestUnit3", test.TestUnit3));
            command.Parameters.Add(new SqlParameter("@TestUnit4", test.TestUnit4));
            command.Parameters.Add(new SqlParameter("@TestUnit5", test.TestUnit5));
            command.Parameters.Add(new SqlParameter("@TestUnit6", test.TestUnit6));
            command.Parameters.Add(new SqlParameter("@TestUnit7", test.TestUnit7));
            command.Parameters.Add(new SqlParameter("@TestUnit8", test.TestUnit8));
            command.Parameters.Add(new SqlParameter("@TestUnit9", test.TestUnit9));
            command.Parameters.Add(new SqlParameter("@TestUnit10", test.TestUnit10));

            if (mode=="Update")
            {
                command.Parameters.Add(new SqlParameter("@TestId", test.TestId));

            }

            return command;
        }

        public TestInfo GetTestById(int testId)
        {
            TestInfo retVal = new TestInfo();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestById_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TestId", testId));

                        SqlDataReader dataReader = command.ExecuteReader();


                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestInfo testItem = new TestInfo();

                                GetValuesFromDataReader(dataReader, retVal);

                            }
                        }

                        dataReader.Close();

                    }
                }

            }
            catch (Exception ex)
            {


                throw ex;
            }

            return retVal;
        }

        public void Update(TestInfo test)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("UpdateTest_sp", con))
                    {
                        SetValuesInTest(command, test, "Update");

                        command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<FabricTypeInfo> GetFabricTypes()
        {
            List<FabricTypeInfo> retVal = new List<FabricTypeInfo>();
            using (SqlConnection con = new SqlConnection(_sqlCon))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("GetFabricTypes_sp", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            FabricTypeInfo fabricType = new FabricTypeInfo();
                            fabricType.FabricTypeId = Convert.ToInt32(dataReader["FabricTypeId"]);
                            fabricType.FabricTypeName = Convert.ToString(dataReader["FabricTypeName"]);
                            retVal.Add(fabricType);

                        }
                    }

                    dataReader.Close();
                }
            }
            return retVal;
        }

        public List<TestInfo> GetTestByFabricType(int fabricType)
        {
            List<TestInfo> retVal = new List<TestInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestByFabricType_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@FabricTypeName", fabricType));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestInfo testItem = new TestInfo();

                                GetValuesFromDataReader(dataReader, testItem);

                                retVal.Add(testItem);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }
    }
}
