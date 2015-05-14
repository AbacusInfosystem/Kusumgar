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
  public  class TestUnitRepo
    {
       private string _sqlCon = string.Empty;

       public TestUnitRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["ProjectTestDB"].ToString();
        }

        public List<TestUnitInfo> GetTestUnits()
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestUnits_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestUnitInfo testUnitItem = new TestUnitInfo();

                                GetValuesFromDataReader(dataReader, testUnitItem);

                                retVal.Add(testUnitItem);
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

        private static void GetValuesFromDataReader(SqlDataReader dataReader, TestUnitInfo testUnit)
        {
            testUnit.TestUnitId = Convert.ToInt32(dataReader["TestUnitId"]);
            testUnit.TestUnitName = Convert.ToString(dataReader["TestUnitName"]);
            testUnit.Status = Convert.ToBoolean(dataReader["Status"]);

        }

        public List<TestUnitInfo> GetTestUnitByName(string testUnit)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestUnitByName_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TestUnitName", testUnit));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestUnitInfo testUnitItem = new TestUnitInfo();

                                GetValuesFromDataReader(dataReader, testUnitItem);

                                retVal.Add(testUnitItem);
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

        public void Insert(TestUnitInfo testUnit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("InsertTestUnit_sp", con))
                    {
                        SetValuesInTestUnit(command, testUnit, "Insert");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private SqlCommand SetValuesInTestUnit(SqlCommand command, TestUnitInfo testUnit, string mode)
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@TestUnitName", testUnit.TestUnitName));

            command.Parameters.Add(new SqlParameter("@Status", testUnit.Status));

            if (mode=="Update")
            {
                command.Parameters.Add(new SqlParameter("@TestUnitId", testUnit.TestUnitId));

            }

            return command;
        }

        public TestUnitInfo GetTestUnitById(int testUnitId)
        {
            TestUnitInfo retVal = new TestUnitInfo();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestUnitById_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TestUnitId", testUnitId));

                        SqlDataReader dataReader = command.ExecuteReader();


                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestUnitInfo testUnitItem = new TestUnitInfo();

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

        public void Update(TestUnitInfo testUnit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("UpdateTestUnit_sp", con))
                    {
                        SetValuesInTestUnit(command, testUnit, "Update");

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
