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
    public class ComplaintRepo
    {
        SQLHelperRepo _sqlRepo;

        public ComplaintRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }        

        public int Insert_Complaint(ComplaintInfo complaintInfo)
        {
            int complaint_Id = 0;

            complaint_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Complaint(complaintInfo), StoredProcedures.Insert_Complaint_Sp.ToString(), CommandType.StoredProcedure));

            return complaint_Id;
        }
        
        public void Update_Complaint(ComplaintInfo complaintInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Complaint(complaintInfo), StoredProcedures.Update_Complaint_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Complaint(ComplaintInfo complaintInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (complaintInfo.Complaint_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Complaint_Id", complaintInfo.Complaint_Id));
            }
            sqlParamList.Add(new SqlParameter("@Customer_Id", complaintInfo.Customer_Id));
            sqlParamList.Add(new SqlParameter("@Order_Id", complaintInfo.Order_Id));
            sqlParamList.Add(new SqlParameter("@Challan_No", complaintInfo.Challan_No));
            sqlParamList.Add(new SqlParameter("@Description", complaintInfo.CDescription));
            if (complaintInfo.Complaint_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", complaintInfo.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", complaintInfo.UpdatedBy));
            return sqlParamList;
        }

        public List<ComplaintInfo> Get_Complaints(ref PaginationInfo pager)
        {
            List<ComplaintInfo> complaints = new List<ComplaintInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Complaints_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                complaints.Add(Get_Complaint_Values(dr));
            }
            return complaints;
        }

        private ComplaintInfo Get_Complaint_Values(DataRow dr)
        {
            ComplaintInfo complaint = new ComplaintInfo();
            complaint.Complaint_Id = Convert.ToInt32(dr["Complaint_Id"]);
            complaint.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            complaint.Order_Id = Convert.ToInt32(dr["Order_Id"]);
            complaint.Challan_No = Convert.ToInt32(dr["Challan_No"]);
            complaint.CDescription = Convert.ToString(dr["CDescription"]);
            return complaint;
        }

        public List<ComplaintInfo> Get_Complaints_By_Cust_Id(int customer_Id, ref PaginationInfo pager)
                {
            List<ComplaintInfo> complaints = new List<ComplaintInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Complaint_By_Cust_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {                    
                complaints.Add(Get_All_Complaint_Values(dr));
            }
            return complaints;
        }

        public ComplaintInfo Get_Complaint_By_Id(int complaint_Id)
        {
            ComplaintInfo complaint = new ComplaintInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Complaint_Id", complaint_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Complaint_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    complaint = Get_All_Complaint_Values(dr);
                }
            }
            return complaint;
                }

        private ComplaintInfo Get_All_Complaint_Values(DataRow dr)
        {
            ComplaintInfo complaint = new ComplaintInfo();
            complaint.Complaint_Id = Convert.ToInt32(dr["Complaint_Id"]);
            complaint.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            complaint.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            complaint.Order_Id = Convert.ToInt32(dr["Order_Id"]);
            complaint.Challan_No = Convert.ToInt32(dr["Challan_No"]);
            complaint.CDescription = Convert.ToString(dr["CDescription"]);
            return complaint;
        }

        public List<AutocompleteInfo> Get_Customer_Id(string customer_Name)
        {
            List<AutocompleteInfo> auto_List = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Customer_Name", customer_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_Customer_By_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Customer_Name"]);
                    auto.Value = Convert.ToInt32(dr["Customer_Id"]);
                    auto_List.Add(auto);
                }
            }
            return auto_List;
        }

        public void Insert_Complaint_Lot_Mapping(ComplaintLotMappingInfo complaint_Lot_Mapping)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Complaint_Lot_Mapping(complaint_Lot_Mapping), StoredProcedures.Insert_Complaint_Lot_Mapping_Sp.ToString(), CommandType.StoredProcedure);
        }

        public List<ComplaintLotMappingInfo> Get_Complaint_Lot_Mappings(int complaint_Id)
        {
            List<ComplaintLotMappingInfo> complaintlotmappings = new List<ComplaintLotMappingInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Complaint_Id", complaint_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Complaint_Lot_Mapping_By_Complaint_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                complaintlotmappings.Add(Get_Complaint_Lot_Mapping_Values(dr));
            }
            return complaintlotmappings;
        }

        private List<SqlParameter> Set_Values_In_Complaint_Lot_Mapping(ComplaintLotMappingInfo complaint_Lot_Mapping)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Complaint_Id", complaint_Lot_Mapping.Complaint_Id));

            sqlParams.Add(new SqlParameter("@Lot_No", complaint_Lot_Mapping.Lot_No));

            sqlParams.Add(new SqlParameter("@CreatedOn", complaint_Lot_Mapping.CreatedOn));

            sqlParams.Add(new SqlParameter("@CreatedBy", complaint_Lot_Mapping.CreatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedOn", complaint_Lot_Mapping.UpdatedOn));

            sqlParams.Add(new SqlParameter("@UpdatedBy", complaint_Lot_Mapping.UpdatedBy));

            return sqlParams;
        }

        private ComplaintLotMappingInfo Get_Complaint_Lot_Mapping_Values(DataRow dr)
        {
            ComplaintLotMappingInfo complaint_Lot_Mapping = new ComplaintLotMappingInfo();

            complaint_Lot_Mapping.Complaint_Lot_Id = Convert.ToInt32(dr["Complaint_Lot_Id"]);

            complaint_Lot_Mapping.Complaint_Id = Convert.ToInt32(dr["Complaint_Id"]);

            complaint_Lot_Mapping.Lot_No = Convert.ToInt32(dr["Lot_No"]);

            complaint_Lot_Mapping.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            complaint_Lot_Mapping.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            complaint_Lot_Mapping.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            complaint_Lot_Mapping.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return complaint_Lot_Mapping;
        }
    }
}
