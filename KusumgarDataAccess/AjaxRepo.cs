using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

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

        #region Attachments

        public long Insert_Attachment(AttachmentsInfo attachment)
        {
            long attachemnt_Id = Convert.ToInt64(sqlRepo.ExecuteScalerObj(Set_Values_In_Attachment(attachment), StoredProcedures.Insert_Attachment_Sp.ToString(), CommandType.StoredProcedure));

            return attachemnt_Id;
        }

        public void Delete_Attachment_By_Id(long attachment_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attachment_Id", attachment_Id));

            sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Attachment_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public List<AttachmentsInfo> Get_Attachments_By_Ref_Type_Ref_Id(int ref_Type, int ref_Id)
        {
            List<AttachmentsInfo> attachments = new List<AttachmentsInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Ref_Type", ref_Type));

            sqlparam.Add(new SqlParameter("@Ref_Id", ref_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Attachments_By_Ref_Type_Ref_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                attachments.Add(Get_Attachments_Values(dr));
            }

            return attachments;
        }

        public AttachmentsInfo Get_Attachment_By_Id(long attachment_Id)
        {
            AttachmentsInfo attachments = new AttachmentsInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Attachment_Id", attachment_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Attachments_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                attachments = Get_Attachments_Values(dr);
            }

            return attachments;
        }

        private List<SqlParameter> Set_Values_In_Attachment(AttachmentsInfo attachment)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Ref_Id", attachment.Ref_Id));
            sqlParams.Add(new SqlParameter("@Ref_Type", attachment.Ref_Type));
            sqlParams.Add(new SqlParameter("@Document_Name", attachment.Document_Name));
            sqlParams.Add(new SqlParameter("@CreatedBy", attachment.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedOn", attachment.CreatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", attachment.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", attachment.UpdatedOn));
            sqlParams.Add(new SqlParameter("@Remark", attachment.Remark));    //

            return sqlParams;
        }

        private AttachmentsInfo Get_Attachments_Values(DataRow dr)
        {
            AttachmentsInfo attachments = new AttachmentsInfo();

            attachments.Attachment_Id = Convert.ToInt64(dr["Attachment_Id"]);
            attachments.Ref_Id = Convert.ToInt32(dr["Ref_Id"]);
            attachments.Ref_Type = Convert.ToInt32(dr["Ref_Type"]);
            attachments.Document_Name = Convert.ToString(dr["Document_Name"]);
            attachments.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            attachments.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            attachments.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            attachments.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            //attachments.Remark = Convert.ToString(dr["Remark"]);
            return attachments;
        }

        #endregion

    }
}
