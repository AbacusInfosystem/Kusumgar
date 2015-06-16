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
    public class WArticleRepo
    {
        SQLHelperRepo _sqlRepo;

        public WArticleRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_WArticle(WArticleInfo wArticle)
        {
            int wArticle_Id = 0;
            _sqlRepo.ExecuteNonQuery(Set_Values_In_WArticle(wArticle), StoredProcedures.Insert_W_Article_Sp.ToString(), CommandType.StoredProcedure);
            return wArticle_Id;
        }

        public void Update_WArticle(WArticleInfo wArticle)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_WArticle(wArticle), StoredProcedures.Update_W_Article_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_WArticle(WArticleInfo wArticle)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (wArticle.W_Article_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@W_Article_Id", wArticle.W_Article_Id));
            }
            sqlParams.Add(new SqlParameter("@Quality_Id", wArticle.Quality_Id));
            sqlParams.Add(new SqlParameter("@Yarn_Type_Id", wArticle.Yarn_Type_Id));
            sqlParams.Add(new SqlParameter("@Reed_Space_Inch", wArticle.Reed_Space_Inch));
            sqlParams.Add(new SqlParameter("@Total_No_Of_Ends", wArticle.Total_No_Of_Ends));
            sqlParams.Add(new SqlParameter("@Full_Code", wArticle.Full_Code));
            sqlParams.Add(new SqlParameter("@Ideal_Beam", wArticle.Ideal_Beam));
            sqlParams.Add(new SqlParameter("@Is_Active", wArticle.Is_Active));
            if (wArticle.W_Article_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", wArticle.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", wArticle.CreatedOn));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", wArticle.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", wArticle.UpdatedOn));
            return sqlParams;
        }

        public List<WArticleInfo> Get_WArticles(ref PaginationInfo pager)
        {
            List<WArticleInfo> wArticles = new List<WArticleInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_W_Articles_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                wArticles.Add(Get_WArticle_Values(dr));
            }
            return wArticles;
        }
        public WArticleInfo Get_WArticle_By_Id(int wArticle_Id)
        {
            WArticleInfo wArticle = new WArticleInfo();
            List<SqlParameter> sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter("@wArticle_Id", wArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_W_Article_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                wArticle = Get_WArticle_Values(dr);
            }
            return wArticle;
        }

        public List<WArticleInfo> Get_WArticles_By_WArticle_Id(int wArticle_Id, ref PaginationInfo pager)
        {
            List<WArticleInfo> wArticles = new List<WArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@wArticle_Id", wArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_W_Article_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                wArticles.Add(Get_WArticle_Values(dr));
            }
            return wArticles;
        }

        public List<WArticleInfo> Get_WArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<WArticleInfo> wArticles = new List<WArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_W_Articles_By_Yarn_Type_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                wArticles.Add(Get_WArticle_Values(dr));
            }
            return wArticles;
        }

        public List<WArticleInfo> Get_W_Articles_By_WArticle_Id_Yarn_Type(int wArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<WArticleInfo> wArticles = new List<WArticleInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));
            sqlParam.Add(new SqlParameter("@wArticle_Id", wArticle_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_W_Articles_By_WArticle_Id_Yarn_Type_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                wArticles.Add(Get_WArticle_Values(dr));
            }
            return wArticles;
        }
        
        private WArticleInfo Get_WArticle_Values(DataRow dr)
        {
            WArticleInfo wArticle = new WArticleInfo();
            wArticle.W_Article_Id = Convert.ToInt32(dr["W_Article_Id"]);
            wArticle.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
            wArticle.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
            wArticle.Reed_Space_Inch = Convert.ToDecimal(dr["Reed_Space_Inch"]);
            wArticle.Total_No_Of_Ends = Convert.ToDecimal(dr["Total_No_Of_Ends"]);
            wArticle.Full_Code = Convert.ToString(dr["Full_Code"]);
            wArticle.Ideal_Beam = Convert.ToString(dr["Ideal_Beam"]);
            wArticle.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            wArticle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            wArticle.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            wArticle.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            wArticle.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            wArticle.Quality_No = Convert.ToInt32(dr["Quality_No"]);
            wArticle.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);
            return wArticle;
        }
               
        public List<AutocompleteInfo> Get_WArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@full_Code", full_Code));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_W_Articles_By_Full_Code_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo auto = new AutocompleteInfo();
                auto.Value = Convert.ToInt32(dr["W_Article_Id"]);
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
