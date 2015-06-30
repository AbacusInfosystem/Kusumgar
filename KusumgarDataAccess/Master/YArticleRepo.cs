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
    public class Y_ArticleRepo
    {
        SQLHelperRepo _sqlRepo;

        public Y_ArticleRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<YArticleInfo> Get_YArticles(ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticles = new List<YArticleInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Y_Articles_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticles.Add(Get_YArticle_Values(dr));
            }

            return yArticles;
        }

        public List<YArticleInfo> Get_YArticles_By_Id(int yArticle_Id, ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@yArticle_Id", yArticle_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Article_By_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public List<YArticleInfo> Get_YArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Articles_By_Yarn_Type_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public List<YArticleInfo> Get_Y_Articles_By_YArticle_Id_Yarn_Type(int yArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            List<YArticleInfo> yArticleList = new List<YArticleInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

            sqlparam.Add(new SqlParameter("@yArticle_Id", yArticle_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Articles_By_YArticle_Id_Yarn_Type_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                yArticleList.Add(Get_YArticle_Values(dr));
            }

            return yArticleList;
        }

        public YArticleInfo Get_YArticle_By_Id(int yArticle_Id)
        {
            YArticleInfo yArticle = new YArticleInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@yArticle_Id", yArticle_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Article_By_Id_sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                yArticle = Get_YArticle_Values(dr);
            }

            return yArticle;
        }

        public YArticleInfo Get_YArticle_Values(DataRow dr)
        {
            YArticleInfo yArticle = new YArticleInfo();

            yArticle.Y_Article_Id = Convert.ToInt32(dr["Y_Article_Id"]);
            yArticle.Denier_Id = Convert.ToInt32(dr["Denier_Id"]); 
            yArticle.Twist_Mingle_Id = Convert.ToInt32(dr["Twist_Mingle_Id"]);   
            yArticle.Twist_Type_Id = Convert.ToInt32(dr["Twist_Type_Id"]);
            yArticle.Ply_Id = Convert.ToInt32(dr["Ply_Id"]);
            yArticle.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
            yArticle.Shade_Id = Convert.ToInt32(dr["Shade_Id"]);
            yArticle.Filaments_Id = Convert.ToInt32(dr["Filaments_Id"]);
            yArticle.Origin_Id = Convert.ToInt32(dr["Origin_Id"]);
            yArticle.Shrinkage_Id = Convert.ToInt32(dr["Shrinkage_Id"]);
            yArticle.Tenasity_Id = Convert.ToInt32(dr["Tenasity_Id"]);
            yArticle.Chemical_Treatment_Id = Convert.ToInt32(dr["Chemical_Treatment_Id"]);
            yArticle.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            yArticle.Supplier_Id = Convert.ToInt32(dr["Supplier_Id"]);
            yArticle.Full_Code = Convert.ToString(dr["Full_Code"]);
            yArticle.Given_By_Id = Convert.ToInt32(dr["Given_By_Id"]);
            yArticle.Validated_By_Id = Convert.ToInt32(dr["Validated_By_Id"]);
            yArticle.Developed_Under_Id = Convert.ToInt32(dr["Developed_Under_Id"]);
            yArticle.Lead_Time_To_Purchase = Convert.ToString(dr["Lead_Time_To_Purchase"]);
            yArticle.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
            yArticle.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            yArticle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            yArticle.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            yArticle.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            yArticle.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            
                yArticle.Denier_Name = Convert.ToString(dr["Denier_Name"]);
                yArticle.Twist_Mingle_Name = Convert.ToString(dr["Twist_Mingle_Name"]);
                yArticle.Twist_Type_Name = Convert.ToString(dr["Twist_Type_Name"]);
                yArticle.Ply_Name = Convert.ToString(dr["Ply_Name"]);
                yArticle.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);
                yArticle.Shade_Name = Convert.ToString(dr["Shade_Name"]);
                yArticle.Filaments_Name = Convert.ToString(dr["Filaments_Name"]);
                yArticle.Shrinkage_Name = Convert.ToString(dr["Shrinkage_Name"]);
                yArticle.Tenasity_Name = Convert.ToString(dr["Tenasity_Name"]);
                yArticle.Chemical_Treatment_Name = Convert.ToString(dr["Chemical_Treatment_Name"]);
                yArticle.Colour_Name = Convert.ToString(dr["Colour_Name"]);
                yArticle.Supplier_Name = Convert.ToString(dr["Supplier_Name"]);
                yArticle.Origin_Name = Convert.ToString(dr["Origin_Name"]);
               
           
                yArticle.Developed_Under_Name = Convert.ToString(dr["Developed_Under_Name"]);
                yArticle.Validated_By_Name = Convert.ToString(dr["Validated_By_Name"]);
                yArticle.Given_By_Name = Convert.ToString(dr["Given_By_Name"]);
                yArticle.Work_Center_Code = Convert.ToString(dr["Work_Center_Code"]);
            

            return yArticle;
        }

        public int Insert_YArticle(YArticleInfo yArticle)
        {
            int yArticle_Id = 0;

            yArticle_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_YArticle(yArticle), StoredProcedures.Insert_Y_Article_sp.ToString(), CommandType.StoredProcedure));

            return yArticle_Id;
        }

        public void Update_YArticle(YArticleInfo yArticle)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_YArticle(yArticle), StoredProcedures.Update_Y_Article_sp.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> Set_Values_In_YArticle(YArticleInfo yArticle)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (yArticle.Y_Article_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Y_Article_Id", yArticle.Y_Article_Id));
            }
            sqlparam.Add(new SqlParameter("@Denier_Id", yArticle.Denier_Id));
            sqlparam.Add(new SqlParameter("@Twist_Mingle_Id", yArticle.Twist_Mingle_Id));
            sqlparam.Add(new SqlParameter("@Twist_Type_Id", yArticle.Twist_Type_Id));
            sqlparam.Add(new SqlParameter("@Ply_Id", yArticle.Ply_Id));
            sqlparam.Add(new SqlParameter("@Yarn_Type_Id", yArticle.Yarn_Type_Id));
            sqlparam.Add(new SqlParameter("@Shade_Id", yArticle.Shade_Id));
            sqlparam.Add(new SqlParameter("@Filaments_Id", yArticle.Filaments_Id));
            sqlparam.Add(new SqlParameter("@Origin_Id", yArticle.Origin_Id));
            sqlparam.Add(new SqlParameter("@Shrinkage_Id", yArticle.Shrinkage_Id));
            sqlparam.Add(new SqlParameter("@Tenasity_Id", yArticle.Tenasity_Id));
            sqlparam.Add(new SqlParameter("@Chemical_Treatment_Id", yArticle.Chemical_Treatment_Id));
            sqlparam.Add(new SqlParameter("@Colour_Id", yArticle.Colour_Id));
            sqlparam.Add(new SqlParameter("@Supplier_Id", yArticle.Supplier_Id));
            sqlparam.Add(new SqlParameter("@Full_Code", yArticle.Full_Code));
            sqlparam.Add(new SqlParameter("@Given_By_Id", yArticle.Given_By_Id));
            sqlparam.Add(new SqlParameter("@Validated_By_Id", yArticle.Validated_By_Id));
            sqlparam.Add(new SqlParameter("@Developed_Under_Id", yArticle.Developed_Under_Id));
            sqlparam.Add(new SqlParameter("@Lead_Time_To_Purchase", yArticle.Lead_Time_To_Purchase));
            sqlparam.Add(new SqlParameter("@Work_Center_Id", yArticle.Work_Center_Id));
            sqlparam.Add(new SqlParameter("@Is_Active", yArticle.Is_Active));
            if (yArticle.Y_Article_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", yArticle.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", yArticle.UpdatedBy));

            return sqlparam;
        }

        public List<AutocompleteInfo> Get_YArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@full_Code", full_Code));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Y_Articles_By_Full_Code_sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                AutocompleteInfo auto = new AutocompleteInfo();

                auto.Value = Convert.ToInt32(dr["Y_Article_Id"]);

                auto.Label = Convert.ToString(dr["Full_Code"]);

                autoCompletes.Add(auto);
            }

            return autoCompletes;
        }

        public List<AutocompleteInfo> Get_Work_Centers_By_Code_Purpose(string work_Center_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@work_Center_Code", work_Center_Code));

            sqlparam.Add(new SqlParameter("@purpose", Convert.ToInt32(ArticleType.YArticle)));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_Work_Centers_By_Code_Purpose_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                AutocompleteInfo auto = new AutocompleteInfo();

                auto.Value = Convert.ToInt32(dr["Work_Center_Id"]);

                auto.Label = Convert.ToString(dr["Work_Center_Code"]);

                autoCompletes.Add(auto);
            }

            return autoCompletes;
        }
    }
}
