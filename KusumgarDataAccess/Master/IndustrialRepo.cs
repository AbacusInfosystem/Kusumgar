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
    public class IndustrialRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public IndustrialRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public void Insert_Industrial_Master(IndustrialInfo industrialInfo)
        {
            int IndustrialMasterId = 0;
            IndustrialMasterId = Convert.ToInt32(sqlRepo.ExecuteScalerObj(Set_Values_In_Industrial(industrialInfo), "", CommandType.StoredProcedure));
        }

        public void Update_Industrial_Master(IndustrialInfo industrialInfo)
        {
            sqlRepo.ExecuteNonQuery(Set_Values_In_Industrial(industrialInfo), "", CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Industrial(IndustrialInfo industrialInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (industrialInfo.IndustrialEntity.IndustrialMasterId != 0)
            {
                sqlParamList.Add(new SqlParameter("@IndustrialMasterId", industrialInfo.IndustrialEntity.IndustrialMasterId));
            }
            sqlParamList.Add(new SqlParameter("@IndustrialCategoryId", industrialInfo.IndustrialEntity.IndustrialCategoryId));
            sqlParamList.Add(new SqlParameter("@IndustrialGroupId", industrialInfo.IndustrialEntity.IndustrialGroupId));
            sqlParamList.Add(new SqlParameter("@IndustrialSubGroupName", industrialInfo.IndustrialEntity.IndustrialSubGrpName));
            sqlParamList.Add(new SqlParameter("@Size", industrialInfo.IndustrialEntity.Size));
            sqlParamList.Add(new SqlParameter("@COD", industrialInfo.IndustrialEntity.COD));
            if (industrialInfo.IndustrialEntity.IndustrialMasterId == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", industrialInfo.IndustrialEntity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", industrialInfo.IndustrialEntity.UpdatedBy));
            return sqlParamList;
        }

        public List<IndustrialInfo> GetIndustrialMaster(PaginationInfo Pager)
        {
            List<IndustrialInfo> IndustrialMasterList = new List<IndustrialInfo>();
            DataTable dt = sqlRepo.ExecuteDataTable(null, "", CommandType.StoredProcedure);
            var tupleData = GetRows(dt, Pager);

            foreach (DataRow dr in tupleData.Item1)            
            {
                IndustrialInfo industrial = new IndustrialInfo();
                industrial.IndustrialEntity.IndustrialMasterId =  Convert.ToInt32(dr["IndustrialMasterId"]);
                industrial.IndustrialCategoryName = Convert.ToString(dr["IndustrialCategoryName"]);
                industrial.IndustrialGroupName = Convert.ToString(dr["IndustrialGroupName"]);
                industrial.IndustrialEntity.IndustrialSubGrpName = Convert.ToString(dr["IndustrialSubGrpName"]);
                industrial.IndustrialEntity.Size = Convert.ToString(dr["Size"]);
                industrial.IndustrialEntity.COD = Convert.ToString(dr["COD"]);
                IndustrialMasterList.Add(industrial);
            }
            return IndustrialMasterList;
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

        public IndustrialInfo GetIndustrialMasterById(int IndustrialMasterId)
        {
            IndustrialInfo IndustrialInfo = new IndustrialInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@IndustrialMasterId", IndustrialMasterId));
            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, "", CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    IndustrialInfo.IndustrialEntity.IndustrialMasterId = Convert.ToInt32(dr["IndustrialMasterId"]);
                    IndustrialInfo.IndustrialEntity.IndustrialCategoryId = Convert.ToInt32(dr["IndustrialCategoryId"]);
                    IndustrialInfo.IndustrialEntity.IndustrialGroupId = Convert.ToInt32(dr["IndustrialGroupId"]);
                    IndustrialInfo.IndustrialCategoryName = Convert.ToString(dr["IndustrialCategoryName"]);
                    IndustrialInfo.IndustrialGroupName = Convert.ToString(dr["IndustrialGroupName"]);
                    IndustrialInfo.IndustrialEntity.IndustrialSubGrpName = Convert.ToString(dr["IndustrialSubGrpName"]);
                    IndustrialInfo.IndustrialEntity.Size = Convert.ToString(dr["Size"]);
                    IndustrialInfo.IndustrialEntity.COD = Convert.ToString(dr["COD"]);
                }
            }
            return IndustrialInfo;
        }
    }
}
