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
 public class AjaxRepo
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

        public List<AutocompleteInfo> Get_Customer_AutoComplete(string Customer_Name)
        {
            List<AutocompleteInfo> customer_List = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Customer_Name"]);

                    auto.Value = Convert.ToInt32(dr["Customer_Id"]);

                    customer_List.Add(auto);
                }
            }

            return customer_List;
        }

        public List<AutocompleteInfo> Get_Customer_Id(string CustomerName)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Customer_Name", CustomerName));
            DataTable dt = sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_Customer_By_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Customer_Name"]);
                    auto.Value = Convert.ToInt32(dr["Customer_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public List<AutocompleteInfo> Get_Vendor_Autocomplete(string vendorName)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Vendor_Name", vendorName));
            DataTable dt = sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_Vendor_By_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Vendor_Name"]);
                    auto.Value = Convert.ToInt32(dr["Vendor_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string Vendor_Name)
        {
            List<AutocompleteInfo> VendorNames= new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Name", Vendor_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Vendor_Name"]);

                    auto.Value = Convert.ToInt32(dr["Vendor_Id"]);

                    VendorNames.Add(auto);
                }
            }

            return VendorNames;
        }

    }
}
