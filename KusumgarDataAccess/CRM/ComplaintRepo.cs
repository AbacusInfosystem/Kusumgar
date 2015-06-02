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
        private string _sqlCon = string.Empty;
        SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public ComplaintRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }        

        public void Insert_Complaint(ComplaintInfo complaintInfo)
        {
            int ComplaintId = 0;
            ComplaintId = Convert.ToInt32(sqlRepo.ExecuteScalerObj(Set_Values_In_Complaint(complaintInfo), StoredProcedures.Insert_Complaint_Sp.ToString(), CommandType.StoredProcedure));
        }
        
        public void Update_Complaint(ComplaintInfo complaintInfo)
        {
            sqlRepo.ExecuteNonQuery(Set_Values_In_Complaint(complaintInfo), StoredProcedures.Update_Complaint_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Complaint(ComplaintInfo complaintInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (complaintInfo.ComplaintEntity.Complaint_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@ComplaintId", complaintInfo.ComplaintEntity.Complaint_Id));
            }
            sqlParamList.Add(new SqlParameter("@CustomerId", complaintInfo.ComplaintEntity.Customer_Id));
            sqlParamList.Add(new SqlParameter("@OrderId", complaintInfo.ComplaintEntity.Order_Id));
            sqlParamList.Add(new SqlParameter("@OrderItemId", complaintInfo.ComplaintEntity.Order_Item_Id));
            sqlParamList.Add(new SqlParameter("@ChallanNo", complaintInfo.ComplaintEntity.Challan_No));
            sqlParamList.Add(new SqlParameter("@Description", complaintInfo.ComplaintEntity.CDescription));
            if (complaintInfo.ComplaintEntity.Complaint_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", complaintInfo.ComplaintEntity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", complaintInfo.ComplaintEntity.UpdatedBy));
            return sqlParamList;
        }

        public List<ComplaintInfo> Get_Complaint_List(PaginationInfo Pager)
        {
            List<ComplaintInfo> ComplaintList = new List<ComplaintInfo>();
            DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Complaint_List_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();
                count = drList.Count();
                
                if (Pager.IsPagingRequired)
                {
                    drList = drList.Skip(Pager.CurrentPage * Pager.PageSize).Take(Pager.PageSize).ToList();
                }

                Pager.TotalRecords = count;
                int pages = (Pager.TotalRecords + Pager.PageSize - 1) / Pager.PageSize;
                Pager.TotalPages = pages;

                foreach (DataRow dr in drList)
                {
                    ComplaintInfo complaint = new ComplaintInfo();
                    complaint.ComplaintEntity.Complaint_Id = Convert.ToInt32(dr["ComplaintId"]);
                    complaint.CustomerName = Convert.ToString(dr["Customer_Name"]);
                    complaint.ComplaintEntity.Order_Id = Convert.ToString(dr["OrderId"]);
                    complaint.ComplaintEntity.Order_Item_Id = Convert.ToString(dr["OrderItemId"]);
                    complaint.ComplaintEntity.Challan_No = Convert.ToString(dr["ChallanNo"]);
                    complaint.ComplaintEntity.CDescription = Convert.ToString(dr["CDescription"]);
                    ComplaintList.Add(complaint);
                }
            }
            return ComplaintList;
        }

        public List<ComplaintInfo> Get_Complaints_By_CustName(string CustomerName, PaginationInfo Pager)
        {
            List<ComplaintInfo> ComplaintInfoList = new List<ComplaintInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@CustomerName", CustomerName));
            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Complaint_By_CustName_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (Pager.IsPagingRequired)
                {
                    drList = drList.Skip(Pager.CurrentPage * Pager.PageSize).Take(Pager.PageSize).ToList();
                }

                Pager.TotalRecords = count;

                int pages = (Pager.TotalRecords + Pager.PageSize - 1) / Pager.PageSize;

                Pager.TotalPages = pages;

                foreach (DataRow dr in drList)
                {
                    ComplaintInfo complaint = new ComplaintInfo();
                    complaint.ComplaintEntity.Complaint_Id = Convert.ToInt32(dr["ComplaintId"]);
                    complaint.ComplaintEntity.Customer_Id = Convert.ToInt32(dr["CustomerId"]);
                    complaint.CustomerName = Convert.ToString(dr["Customer_Name"]);
                    complaint.ComplaintEntity.Order_Id = Convert.ToString(dr["OrderId"]);
                    complaint.ComplaintEntity.Order_Item_Id = Convert.ToString(dr["OrderItemId"]);
                    complaint.ComplaintEntity.Challan_No = Convert.ToString(dr["ChallanNo"]);
                    complaint.ComplaintEntity.CDescription = Convert.ToString(dr["CDescription"]);
                    ComplaintInfoList.Add(complaint);
                }
            }
            return ComplaintInfoList;
        }

        public ComplaintInfo Get_Complaint_By_Id(int ComplaintId)
        {
            ComplaintInfo ComplaintInfo = new ComplaintInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@ComplaintId", ComplaintId));
            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Complaint_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    ComplaintInfo.ComplaintEntity.Complaint_Id = Convert.ToInt32(dr["ComplaintId"]);
                    ComplaintInfo.ComplaintEntity.Customer_Id = Convert.ToInt32(dr["CustomerId"]);
                    ComplaintInfo.CustomerName = Convert.ToString(dr["Customer_Name"]);
                    ComplaintInfo.ComplaintEntity.Order_Id = Convert.ToString(dr["OrderId"]);
                    ComplaintInfo.ComplaintEntity.Order_Item_Id = Convert.ToString(dr["OrderItemId"]);
                    ComplaintInfo.ComplaintEntity.Challan_No = Convert.ToString(dr["ChallanNo"]);
                    ComplaintInfo.ComplaintEntity.CDescription = Convert.ToString(dr["CDescription"]);
                }
            }
            return ComplaintInfo;
        }
    }
}
