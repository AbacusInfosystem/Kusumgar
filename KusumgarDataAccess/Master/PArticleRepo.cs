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
    public class PArticleRepo
    {
            SQLHelperRepo _sqlRepo;

            public PArticleRepo()
            {
                _sqlRepo = new SQLHelperRepo();
            }

            public int Insert_PArticle(PArticleInfo pArticle)
            {
                int pArticle_Id = 0;

                pArticle_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_PArticle(pArticle),StoredProcedures. Insert_P_Article_Sp.ToString(), CommandType.StoredProcedure));

                return pArticle_Id;
            }

            public void Update_PArticle(PArticleInfo pArticle)
            {
                _sqlRepo.ExecuteNonQuery(Set_Values_In_PArticle(pArticle), StoredProcedures.Update_P_Article_Sp.ToString(), CommandType.StoredProcedure);
            }

            private List<SqlParameter> Set_Values_In_PArticle(PArticleInfo pArticle)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
              
                sqlParams.Add(new SqlParameter("@Quality_No", pArticle.Quality_No));
                sqlParams.Add(new SqlParameter("@Yarn_Type_Id", pArticle.Yarn_Type_Id));
                sqlParams.Add(new SqlParameter("@Weave_Id", pArticle.Weave_Id));
                sqlParams.Add(new SqlParameter("@Shade_Id", pArticle.Shade_Id));
                sqlParams.Add(new SqlParameter("@Chemical_Finish_Id", pArticle.Chemical_Finish_Id));
                sqlParams.Add(new SqlParameter("@Mechanical_Finish_Id", pArticle.Mechanical_Finish_Id));
                sqlParams.Add(new SqlParameter("@P_Finish_width", pArticle.P_Finish_width));
                sqlParams.Add(new SqlParameter("@Type_Id", pArticle.Type_Id));
                sqlParams.Add(new SqlParameter("@Full_Code", pArticle.Full_Code));
                sqlParams.Add(new SqlParameter("@Given_By_Id", pArticle.Given_By_Id));
                sqlParams.Add(new SqlParameter("@Validated_By_Id", pArticle.Validated_By_Id));
                sqlParams.Add(new SqlParameter("@Developed_Under_Id", pArticle.Developed_Under_Id));
                sqlParams.Add(new SqlParameter("@Batch", pArticle.Batch));
                sqlParams.Add(new SqlParameter("@Is_Active", pArticle.Is_Active));

                if (pArticle.P_Article_Id == 0)
                {
                    sqlParams.Add(new SqlParameter("@CreatedBy", pArticle.CreatedBy));
                    sqlParams.Add(new SqlParameter("@CreatedOn", pArticle.CreatedOn));

                }
                if (pArticle.P_Article_Id != 0)
                {
                    sqlParams.Add(new SqlParameter("@P_Article_Id", pArticle.P_Article_Id));
                }

                sqlParams.Add(new SqlParameter("@UpdatedBy", pArticle.UpdatedBy));
                sqlParams.Add(new SqlParameter("@UpdatedOn", pArticle.UpdatedOn));
               
                return sqlParams;
            }

            public List<PArticleInfo> Get_PArticles(ref PaginationInfo pager)
            {
                List<PArticleInfo> pArticles = new List<PArticleInfo>();

                DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_P_Article_Sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    pArticles.Add(Get_PArticle_Values(dr));
                }

                return pArticles;
            }

            public PArticleInfo Get_PArticles_By_Id(int pArticle_Id)
            {
                PArticleInfo pArticle = new PArticleInfo();

                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@pArticle_Id", pArticle_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_P_Article_By_Id_sp.ToString(), CommandType.StoredProcedure);

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    pArticle=Get_PArticle_Values(dr);
                }

                return pArticle;
            }
          
            private PArticleInfo Get_PArticle_Values(DataRow dr)
            {
                PArticleInfo pArticle = new PArticleInfo();

                pArticle.P_Article_Id = Convert.ToInt32(dr["P_Article_Id"]);
                pArticle.Quality_No = Convert.ToInt32(dr["Quality_No"]);
                pArticle.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
                pArticle.Weave_Id = Convert.ToInt32(dr["Weave_Id"]);
                pArticle.Shade_Id = Convert.ToInt32(dr["Shade_Id"]);
                pArticle.Chemical_Finish_Id = Convert.ToInt32(dr["Chemical_Finish_Id"]);
                pArticle.Mechanical_Finish_Id = Convert.ToInt32(dr["Mechanical_Finish_Id"]);
                pArticle.Type_Id = Convert.ToInt32(dr["Type_Id"]);
                pArticle.Full_Code = Convert.ToString(dr["Full_Code"]);
                pArticle.Given_By_Id = Convert.ToInt32(dr["Given_By_Id"]);
                pArticle.Validated_By_Id = Convert.ToInt32(dr["Validated_By_Id"]);
                pArticle.Developed_Under_Id = Convert.ToInt32(dr["Developed_Under_Id"]);
                pArticle.Batch = Convert.ToString(dr["Batch"]);
                pArticle.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                pArticle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                pArticle.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                pArticle.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                pArticle.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                pArticle.P_Finish_width = Convert.ToDecimal(dr["P_Finish_width"]);

                pArticle.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);
                pArticle.Weave_Name = Convert.ToString(dr["Weave_Name"]);
                pArticle.Shades_Name = Convert.ToString(dr["Shade_Name"]);

                pArticle.Developed_Under_Name = Convert.ToString(dr["Developed_Under_Name"]);
                pArticle.Validated_By_Name = Convert.ToString(dr["Validated_By_Name"]);
                pArticle.Given_By_Name = Convert.ToString(dr["Given_By_Name"]);

                pArticle.Quality_Nos = Convert.ToInt32(dr["Quality_Nos"]);
              
                return pArticle;
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

            private QualityInfo Get_Quality_Values(DataRow dr)
            {
                QualityInfo quality = new QualityInfo();

                quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
                quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
            
                return quality;
            }

            public List<AutocompleteInfo> Get_PArticles_By_Full_Code(string full_Code)
            {
                List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@full_Code", full_Code));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_P_Articles_By_Full_Code_sp.ToString(), CommandType.StoredProcedure);

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Value = Convert.ToInt32(dr["P_Article_Id"]);

                    auto.Label = Convert.ToString(dr["Full_Code"]);

                    autoCompletes.Add(auto);
                }

                return autoCompletes;
            }

            public List<PArticleInfo> Get_PArticles_By_Id(int pArticle_Id, ref PaginationInfo pager)
            {
                List<PArticleInfo> pArticleList = new List<PArticleInfo>();

                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@pArticle_Id", pArticle_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_P_Article_By_Id_sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    pArticleList.Add(Get_PArticle_Values(dr));
                }

                return pArticleList;
            }

            public List<PArticleInfo> Get_PArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
            {
                List<PArticleInfo> pArticleList = new List<PArticleInfo>();

                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_P_Articles_By_Yarn_Type_Id_sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    pArticleList.Add(Get_PArticle_Values(dr));
                }

                return pArticleList;
            }

            public List<PArticleInfo> Get_P_Articles_By_PArticle_Id_Yarn_Type(int pArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
            {
                List<PArticleInfo> pArticleList = new List<PArticleInfo>();

                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

                sqlparam.Add(new SqlParameter("@pArticle_Id", pArticle_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_P_Articles_By_PArticle_Id_Yarn_Type_sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    pArticleList.Add(Get_PArticle_Values(dr));
                }

                return pArticleList;
            }
        }
    }

