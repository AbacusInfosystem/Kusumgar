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
    public class CArticleRepo
    {
        SQLHelperRepo _sqlRepo;

        public CArticleRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_CArticle(CArticleInfo cArticle)
        {
            int cArticle_Id = 0;
            _sqlRepo.ExecuteNonQuery(Set_Values_In_CArticle(cArticle), StoredProcedures.Insert_C_Article_Sp.ToString(), CommandType.StoredProcedure);
            return cArticle_Id;
        }

        public void Update_CArticle(CArticleInfo cArticle)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_CArticle(cArticle), StoredProcedures.Update_C_Article_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_CArticle(CArticleInfo cArticle)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (cArticle.C_Article_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@C_Article_Id", cArticle.C_Article_Id));
            }
            sqlParams.Add(new SqlParameter("@Quality_Id", cArticle.Quality_Id));
            sqlParams.Add(new SqlParameter("@Yarn_Type_Id", cArticle.Yarn_Type_Id));
            sqlParams.Add(new SqlParameter("@Weave_Id", cArticle.Weave_Id));
            sqlParams.Add(new SqlParameter("@Shade_Id", cArticle.Shade_Id));
            sqlParams.Add(new SqlParameter("@Chemical_Finish_Id", cArticle.Chemical_Finish_Id));
            sqlParams.Add(new SqlParameter("@Mechanical_Finish_Id", cArticle.Mechanical_Finish_Id));
            sqlParams.Add(new SqlParameter("@Type_Id", cArticle.Type_Id));
            sqlParams.Add(new SqlParameter("@C_Finish_Width", cArticle.C_Finish_Width));
            sqlParams.Add(new SqlParameter("@Coat", cArticle.Coat));
            sqlParams.Add(new SqlParameter("@C_gsm", cArticle.C_gsm));
            sqlParams.Add(new SqlParameter("@Full_Code", cArticle.Full_Code));
            sqlParams.Add(new SqlParameter("@Batch", cArticle.Batch));
            sqlParams.Add(new SqlParameter("@Is_Active", cArticle.Is_Active));
            if (cArticle.C_Article_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", cArticle.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", cArticle.CreatedOn));

            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", cArticle.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", cArticle.UpdatedOn));
            return sqlParams;
        }

        public List<CArticleInfo> Get_CArticles(ref PaginationInfo pager)
        {
            List<CArticleInfo> cArticles = new List<CArticleInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_C_Articles_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                cArticles.Add(Get_CArticle_Values(dr));
            }
            return cArticles;
        }
        public CArticleInfo Get_CArticle_By_Id(int cArticle_Id)
        {
            CArticleInfo cArticle = new CArticleInfo();
            List<SqlParameter> sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter("@cArticle_Id", cArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_C_Article_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                cArticle = Get_CArticle_Values(dr);
            }
            return cArticle;
        }

        public List<CArticleInfo> Get_CArticles_By_CArticle_Id(int cArticle_Id, ref PaginationInfo pager)
        {
            List<CArticleInfo> cArticles = new List<CArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@cArticle_Id", cArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_C_Article_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                cArticles.Add(Get_CArticle_Values(dr));
            }
            return cArticles;
        }

        public List<CArticleInfo> Get_CArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<CArticleInfo> cArticles = new List<CArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_C_Articles_By_Yarn_Type_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                cArticles.Add(Get_CArticle_Values(dr));
            }
            return cArticles;
        }

        public List<CArticleInfo> Get_C_Articles_By_CArticle_Id_Yarn_Type(int cArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<CArticleInfo> cArticles = new List<CArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));
            sqlParam.Add(new SqlParameter("@cArticle_Id", cArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_C_Articles_By_CArticle_Id_Yarn_Type_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                cArticles.Add(Get_CArticle_Values(dr));
            }
            return cArticles;
        }

        private CArticleInfo Get_CArticle_Values(DataRow dr)
        {
            CArticleInfo cArticle = new CArticleInfo();
            cArticle.C_Article_Id = Convert.ToInt32(dr["C_Article_Id"]);
            cArticle.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
            cArticle.Quality_No = Convert.ToInt32(dr["Quality_No"]);
            cArticle.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
            cArticle.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);
            cArticle.Weave_Id = Convert.ToInt32(dr["Weave_Id"]);
            cArticle.Weave_Name = Convert.ToString(dr["Weave_Name"]);
            cArticle.Shade_Id = Convert.ToInt32(dr["Shade_Id"]);
            cArticle.Shade_Name = Convert.ToString(dr["Shade_Name"]);
            cArticle.Chemical_Finish_Id = Convert.ToInt32(dr["Chemical_Finish_Id"]);
            cArticle.Chemical_Finish_Name = Convert.ToString(dr["Chemical_Finish_Name"]);              
            cArticle.Mechanical_Finish_Id = Convert.ToInt32(dr["Mechanical_Finish_Id"]);
            cArticle.Mechanical_Finish_Name = Convert.ToString(dr["Mechanical_Finish_Name"]);
            cArticle.Type_Id = Convert.ToInt32(dr["Type_Id"]);
            cArticle.Type_Name = Convert.ToString(dr["CType_Name"]);
            cArticle.C_Finish_Width = Convert.ToDecimal(dr["C_Finish_Width"]);
            cArticle.Coat = Convert.ToString(dr["Coat"]);
            cArticle.C_gsm = Convert.ToString(dr["C_gsm"]);
            cArticle.Full_Code = Convert.ToString(dr["Full_Code"]);
            cArticle.Batch = Convert.ToString(dr["Batch"]);
            cArticle.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            cArticle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            cArticle.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            cArticle.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            cArticle.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            return cArticle;
        }

        public List<AutocompleteInfo> Get_CArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@full_Code", full_Code));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_C_Articles_By_Full_Code_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo auto = new AutocompleteInfo();
                auto.Value = Convert.ToInt32(dr["C_Article_Id"]);
                auto.Label = Convert.ToString(dr["Full_Code"]);
                autoCompletes.Add(auto);
            }
            return autoCompletes;
        }

        public List<QualityInfo> Get_Quality(ref PaginationInfo pager)
        {
            List<QualityInfo> qualities = new List<QualityInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Qualities_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                qualities.Add(Get_Quality_Values(dr));
            }
            return qualities;
        }

        public QualityInfo Get_Quality_Values(DataRow dr)
        {
            QualityInfo quality = new QualityInfo();
            quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
            quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
            return quality;
        }
    }
}
