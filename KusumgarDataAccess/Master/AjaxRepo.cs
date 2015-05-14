using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
 public   class AjaxRepo
    {
     
        SQLHelperRepo sqlRepo;

        private string _sqlCon = string.Empty;

        public AjaxRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();

            sqlRepo = new SQLHelperRepo();
        }

        public List<TestUnitInfo> GetTestUnit(string testUnitName)
        {
            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetTestUnitAutoComplete_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TestUnitName", testUnitName));
                       
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                TestUnitInfo testUnit = new TestUnitInfo();
                                testUnit.Label = Convert.ToString(dataReader["TestUnitName"]);
                                testUnit.Value = Convert.ToInt32(dataReader["TestUnitId"]);
                                retVal.Add(testUnit);
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

        public List<AutoCompleteInfo> Get_Customer_AutoComplete(string Customer_Name)
        {
            List<AutoCompleteInfo> customer_List = new List<AutoCompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutoCompleteInfo auto = new AutoCompleteInfo();

                    auto.Label = Convert.ToString(dr["Customer_Name"]);

                    auto.Value = Convert.ToInt32(dr["Company_Id"]);

                    customer_List.Add(auto);
                }
            }

            return customer_List;
        }
    }
}
