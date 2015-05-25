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
    public class Y_ArticleRepo
    {
        SQLHelperRepo _sqlRepo;

        public Y_ArticleRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<YArticleInfo> Get_YArticles(ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Y_Articles_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public List<YArticleInfo> Get_YArticles_By_Full_Code(string full_Code, ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@full_Code", full_Code));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Articles_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public List<YArticleInfo> Get_YArticles_By_Full_Code(int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Articles_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public YArticleInfo Get_YArticle_Values(DataRow dr)
        {
            YArticleInfo yArticle = new YArticleInfo();

            yArticle.YArticle_Entity.Y_Article_Id = Convert.ToInt32(dr["Y_Article_Id"]);
            yArticle.YArticle_Entity.Denier_Id = Convert.ToInt32(dr["Denier_Id"]);
            yArticle.YArticle_Entity.Twist_Mingle_Id = Convert.ToInt32(dr["Twist_Mingle_Id"]);
            yArticle.YArticle_Entity.Twist_Type_Id = Convert.ToInt32(dr["Twist_Type_Id"]);
            yArticle.YArticle_Entity.Ply_Id = Convert.ToInt32(dr["Ply_Id"]);
            yArticle.YArticle_Entity.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
            yArticle.YArticle_Entity.Shade_Id = Convert.ToInt32(dr["Shade_Id"]);
            yArticle.YArticle_Entity.Filaments_Id = Convert.ToInt32(dr["Filaments_Id"]);
            yArticle.YArticle_Entity.Origin_Id = Convert.ToInt32(dr["Origin_Id"]);
            yArticle.YArticle_Entity.Shrinkage_Id = Convert.ToInt32(dr["Shrinkage_Id"]);
            yArticle.YArticle_Entity.Tenasity_Id = Convert.ToInt32(dr["Tenasity_Id"]);
            yArticle.YArticle_Entity.Chemical_Treatment_Id = Convert.ToInt32(dr["Chemical_Treatment_Id"]);
            yArticle.YArticle_Entity.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            yArticle.YArticle_Entity.Supplier_Id = Convert.ToInt32(dr["Supplier_Id"]);
            yArticle.YArticle_Entity.Full_Code = Convert.ToString(dr["Full_Code"]);
            yArticle.YArticle_Entity.Given_By_Id = Convert.ToInt32(dr["Given_By_Id"]);
            yArticle.YArticle_Entity.Validated_By_Id = Convert.ToInt32(dr["Validated_By_Id"]);
            yArticle.YArticle_Entity.Developed_Under_Id = Convert.ToInt32(dr["Developed_Under_Id"]);
            yArticle.YArticle_Entity.Lead_Time_To_Purchase = Convert.ToString(dr["Lead_Time_To_Purchase"]);
            yArticle.YArticle_Entity.Work_Center_Code = Convert.ToString(dr["Work_Center_Code"]);
            yArticle.YArticle_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            yArticle.YArticle_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            yArticle.YArticle_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            yArticle.YArticle_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            yArticle.YArticle_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            return yArticle;
        }

        public int Insert_YArticle(YArticleInfo yArticle)
        {
            int yArticle_Id = 0;

            yArticle_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_YArticle(yArticle), StoredProcedures.Insert_Y_Article_sp.ToString(), CommandType.StoredProcedure));

            return yArticle_Id;
        }

        public List<SqlParameter> Set_Values_In_YArticle(YArticleInfo yArticle)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (yArticle.YArticle_Entity.Y_Article_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Y_Article_Id", yArticle.YArticle_Entity.Y_Article_Id));
            }
            sqlparam.Add(new SqlParameter("@Denier_Id", yArticle.YArticle_Entity.Denier_Id));
            sqlparam.Add(new SqlParameter("@Twist_Mingle_Id", yArticle.YArticle_Entity.Twist_Mingle_Id));
            sqlparam.Add(new SqlParameter("@Twist_Type_Id", yArticle.YArticle_Entity.Twist_Type_Id));
            sqlparam.Add(new SqlParameter("@Ply_Id", yArticle.YArticle_Entity.Ply_Id));
            sqlparam.Add(new SqlParameter("@Yarn_Type_Id", yArticle.YArticle_Entity.Yarn_Type_Id));
            sqlparam.Add(new SqlParameter("@Shade_Id", yArticle.YArticle_Entity.Shade_Id));
            sqlparam.Add(new SqlParameter("@Filaments_Id", yArticle.YArticle_Entity.Filaments_Id));
            sqlparam.Add(new SqlParameter("@Origin_Id", yArticle.YArticle_Entity.Origin_Id));
            sqlparam.Add(new SqlParameter("@Shrinkage_Id", yArticle.YArticle_Entity.Shrinkage_Id));
            sqlparam.Add(new SqlParameter("@Tenasity_Id", yArticle.YArticle_Entity.Tenasity_Id));
            sqlparam.Add(new SqlParameter("@Chemical_Treatment_Id", yArticle.YArticle_Entity.Chemical_Treatment_Id));
            sqlparam.Add(new SqlParameter("@Colour_Id", yArticle.YArticle_Entity.Colour_Id));
            sqlparam.Add(new SqlParameter("@Supplier_Id", yArticle.YArticle_Entity.Supplier_Id));
            sqlparam.Add(new SqlParameter("@Full_Code", yArticle.YArticle_Entity.Full_Code));
            sqlparam.Add(new SqlParameter("@Given_By_Id", yArticle.YArticle_Entity.Given_By_Id));
            sqlparam.Add(new SqlParameter("@Validated_By_Id", yArticle.YArticle_Entity.Validated_By_Id));
            sqlparam.Add(new SqlParameter("@Developed_Under_Id", yArticle.YArticle_Entity.Developed_Under_Id));
            sqlparam.Add(new SqlParameter("@Lead_Time_To_Purchase", yArticle.YArticle_Entity.Lead_Time_To_Purchase));
            sqlparam.Add(new SqlParameter("@Work_Center_Code", yArticle.YArticle_Entity.Work_Center_Code));
            sqlparam.Add(new SqlParameter("@Is_Active", yArticle.YArticle_Entity.Is_Active));
            if (yArticle.YArticle_Entity.Y_Article_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", yArticle.YArticle_Entity.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", yArticle.YArticle_Entity.UpdatedBy));

            return sqlparam;
        }
    }
}
