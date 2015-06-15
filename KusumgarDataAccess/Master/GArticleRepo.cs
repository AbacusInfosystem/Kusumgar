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
    public class GArticleRepo
    {
        SQLHelperRepo _sqlRepo;

        public GArticleRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

         public List<QualityInfo> Get_Qualities(ref PaginationInfo pager)
         {
             List<QualityInfo> qualities = new List<QualityInfo>();

             DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Qualities_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {

                 foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                 {
                     QualityInfo quality = new QualityInfo();

                     quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
                     quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);

                     qualities.Add(quality);
                 }
             }

             return qualities;
         }

         public List<VendorInfo> Get_Vendors(ref PaginationInfo pager)
         {
             List<VendorInfo> vendors = new List<VendorInfo>();

             DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Vendors_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {

                 foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                 {
                     VendorInfo vendor = new VendorInfo();

                     vendor.Vendor_Entity.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
                     vendor.Vendor_Entity.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                     vendors.Add(vendor);
                 }
             }

             return vendors;
         }

         public int Insert_G_Article(GArticleInfo gArticle)
         {
             int g_Article_Id = 0;

             g_Article_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_G_Article(gArticle), StoredProcedures.Insert_G_Article_Sp.ToString(), CommandType.StoredProcedure));

             return g_Article_Id;
         }

         public void Update_G_Article(GArticleInfo gArticle)
         {
             _sqlRepo.ExecuteNonQuery(Set_Values_In_G_Article(gArticle), StoredProcedures.Update_G_Article_Sp.ToString(), CommandType.StoredProcedure);
         }

         public List<SqlParameter> Set_Values_In_G_Article(GArticleInfo g_Article)
         {
             List<SqlParameter> sqlParams = new List<SqlParameter>();
             if (g_Article.G_Article_Id != 0)
             {
                 sqlParams.Add(new SqlParameter("@G_Article_Id", g_Article.G_Article_Id));
             }
             sqlParams.Add(new SqlParameter("@Quality_Id", g_Article.Quality_Id));
             sqlParams.Add(new SqlParameter("@Yarn_Type_Id", g_Article.Yarn_Type_Id));
             sqlParams.Add(new SqlParameter("@Weave_Id", g_Article.Weave_Id));
             sqlParams.Add(new SqlParameter("@Grey_with_Cms", g_Article.Grey_with_Cms));
             sqlParams.Add(new SqlParameter("@GSM", g_Article.GSM));
             sqlParams.Add(new SqlParameter("@Full_Code", g_Article.Full_Code));
             sqlParams.Add(new SqlParameter("@Warp_1", g_Article.Warp_1));
             sqlParams.Add(new SqlParameter("@Warp_2", g_Article.Warp_2));
             sqlParams.Add(new SqlParameter("@Warp_3", g_Article.Warp_3));
             sqlParams.Add(new SqlParameter("@Warp_4", g_Article.Warp_4));
             sqlParams.Add(new SqlParameter("@Weft_1", g_Article.Weft_1));
             sqlParams.Add(new SqlParameter("@Weft_2", g_Article.Weft_2));
             sqlParams.Add(new SqlParameter("@Weft_3", g_Article.Weft_3));
             sqlParams.Add(new SqlParameter("@Weft_4", g_Article.Weft_4));
             sqlParams.Add(new SqlParameter("@Reed", g_Article.Reed));
             sqlParams.Add(new SqlParameter("@Pick", g_Article.Pick));
             sqlParams.Add(new SqlParameter("@R_S", g_Article.R_S));
             sqlParams.Add(new SqlParameter("@G_W", g_Article.G_W));
             sqlParams.Add(new SqlParameter("@Total_Ends", g_Article.Total_Ends));
             sqlParams.Add(new SqlParameter("@Beam_Weight", g_Article.Beam_Weight));
             sqlParams.Add(new SqlParameter("@Beam_Roll", g_Article.Beam_Roll));
             sqlParams.Add(new SqlParameter("@Weave", g_Article.Weave));
             sqlParams.Add(new SqlParameter("@No_Of_Healds", g_Article.No_Of_Healds));
             sqlParams.Add(new SqlParameter("@Drawing_Sequence_Body", g_Article.Drawing_Sequence_Body));
             sqlParams.Add(new SqlParameter("@Drawing_Sequence_Selvedge", g_Article.Drawing_Sequence_Selvedge));
             sqlParams.Add(new SqlParameter("@Roll_Size", g_Article.Roll_Size));
             sqlParams.Add(new SqlParameter("@Warp_Yarn_Vendor", g_Article.Warp_Yarn_Vendor));
             sqlParams.Add(new SqlParameter("@Weft_Yarn_Vendor", g_Article.Weft_Yarn_Vendor));
             sqlParams.Add(new SqlParameter("@RSP", g_Article.RSP));
             sqlParams.Add(new SqlParameter("@Warping_Meters", g_Article.Warping_Meters));
             sqlParams.Add(new SqlParameter("@Draft", g_Article.Draft));
             sqlParams.Add(new SqlParameter("@Crimp_In_Percentage", g_Article.Crimp_In_Percentage));
             sqlParams.Add(new SqlParameter("@Peg_Plan_Rows", g_Article.Peg_Plan_Rows));
             sqlParams.Add(new SqlParameter("@Peg_Plan_Columns", g_Article.Peg_Plan_Columns));
             sqlParams.Add(new SqlParameter("@Is_Active", g_Article.Is_Active));
             if (g_Article.G_Article_Id == 0)
             {
                 sqlParams.Add(new SqlParameter("@CreatedOn", g_Article.CreatedOn));
                 sqlParams.Add(new SqlParameter("@CreatedBy", g_Article.CreatedBy));
             }
             sqlParams.Add(new SqlParameter("@UpdatedOn", g_Article.UpdatedOn));
             sqlParams.Add(new SqlParameter("@UpdatedBy", g_Article.UpdatedBy));
             return sqlParams;

         }

         public List<GArticleInfo> Get_G_Articles(ref PaginationInfo pager)
         {
             List<GArticleInfo> g_Grticles = new List<GArticleInfo>();

             DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_G_Articles_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 g_Grticles.Add(Get_G_Article_Values(dr));
             }
             return g_Grticles;
         }

         public List<GArticleInfo> Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id(int g_Article_Id, int yarn_Type_Id, ref PaginationInfo pager)
         {
             List<GArticleInfo> g_Grticles = new List<GArticleInfo>();

             List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@G_Article_Id", g_Article_Id));//

             sqlparam.Add(new SqlParameter("@Yarn_Type_Id", yarn_Type_Id));//

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 g_Grticles.Add(Get_G_Article_Values(dr));
             }

             return g_Grticles;
         }

         public List<GArticleInfo> Get_G_Articles_By_G_Article_Id(int g_Article_Id, ref PaginationInfo pager)
         {
             List<GArticleInfo> g_Grticles = new List<GArticleInfo>();

             List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@G_Article_Id", g_Article_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_G_Articles_By_G_Article_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 g_Grticles.Add(Get_G_Article_Values(dr));
             }

             return g_Grticles;
         }

         public List<GArticleInfo> Get_G_Articles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
         {
             List<GArticleInfo> g_Grticles = new List<GArticleInfo>();

             List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@yarn_Type_Id", yarn_Type_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_G_Articles_By_Yarn_Type_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 g_Grticles.Add(Get_G_Article_Values(dr));
             }

             return g_Grticles;
         }

         private GArticleInfo Get_G_Article_Values(DataRow dr)
         {
             GArticleInfo g_Grticle = new GArticleInfo();

             g_Grticle.G_Article_Id = Convert.ToInt32(dr["G_Article_Id"]);
             g_Grticle.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
             g_Grticle.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
             g_Grticle.Weave_Id = Convert.ToInt32(dr["Weave_Id"]);
             g_Grticle.Grey_with_Cms = Convert.ToInt32(dr["Grey_with_Cms"]);
             g_Grticle.GSM = Convert.ToInt32(dr["GSM"]);
             g_Grticle.Full_Code = Convert.ToString(dr["Full_Code"]);
             g_Grticle.Warp_1 = Convert.ToInt32(dr["Warp_1"]);
             g_Grticle.Warp_2 = Convert.ToInt32(dr["Warp_2"]);
             g_Grticle.Warp_3 = Convert.ToInt32(dr["Warp_3"]);
             g_Grticle.Warp_4 = Convert.ToInt32(dr["Warp_4"]);
             g_Grticle.Weft_1 = Convert.ToInt32(dr["Weft_1"]);
             g_Grticle.Weft_2 = Convert.ToInt32(dr["Weft_2"]);
             g_Grticle.Weft_3 = Convert.ToInt32(dr["Weft_3"]);
             g_Grticle.Weft_4 = Convert.ToInt32(dr["Weft_4"]);
             g_Grticle.Reed = Convert.ToString(dr["Reed"]);
             g_Grticle.Pick = Convert.ToString(dr["Pick"]);
             g_Grticle.R_S = Convert.ToString(dr["R_S"]);
             g_Grticle.G_W = Convert.ToString(dr["G_W"]);
             g_Grticle.Total_Ends = Convert.ToInt32(dr["Total_Ends"]);
             g_Grticle.Beam_Weight = Convert.ToDecimal(dr["Beam_Weight"]);
             g_Grticle.Beam_Roll = Convert.ToDecimal(dr["Beam_Roll"]);
             g_Grticle.Weave = Convert.ToDecimal(dr["Weave"]);
             g_Grticle.No_Of_Healds = Convert.ToDecimal(dr["No_Of_Healds"]);
             g_Grticle.Drawing_Sequence_Body = Convert.ToString(dr["Drawing_Sequence_Body"]);
             g_Grticle.Drawing_Sequence_Selvedge = Convert.ToString(dr["Drawing_Sequence_Selvedge"]);
             g_Grticle.Roll_Size = Convert.ToInt32(dr["Roll_Size"]);
             g_Grticle.Warp_Yarn_Vendor = Convert.ToInt32(dr["Warp_Yarn_Vendor"]);
             g_Grticle.Weft_Yarn_Vendor = Convert.ToInt32(dr["Weft_Yarn_Vendor"]);
             g_Grticle.RSP = Convert.ToInt32(dr["RSP"]);
             g_Grticle.Warping_Meters = Convert.ToInt32(dr["Warping_Meters"]);
             g_Grticle.Draft = Convert.ToString(dr["Draft"]);
             g_Grticle.Crimp_In_Percentage = Convert.ToInt32(dr["Crimp_In_Percentage"]);
             g_Grticle.Peg_Plan_Rows = Convert.ToInt32(dr["Peg_Plan_Rows"]);
             g_Grticle.Peg_Plan_Columns = Convert.ToInt32(dr["Peg_Plan_Columns"]);
             g_Grticle.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
             g_Grticle.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
             g_Grticle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
             g_Grticle.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
             g_Grticle.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

             g_Grticle.Quality_No = Convert.ToInt32(dr["Quality_No"]);
             g_Grticle.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);
             g_Grticle.Weave_Name = Convert.ToString(dr["Weave_Name"]);

             g_Grticle.Warp_Yarn_Vendor_Name = Convert.ToString(dr["Warp_Yarn_Vendor_Name"]);
             g_Grticle.Weft_Yarn_Vendor_Name = Convert.ToString(dr["Weft_Yarn_Vendor_Name"]);

             g_Grticle.Warp_Name_1 = Convert.ToString(dr["Warp_Name_1"]);
             g_Grticle.Warp_Name_2 = Convert.ToString(dr["Warp_Name_2"]);
             g_Grticle.Warp_Name_3 = Convert.ToString(dr["Warp_Name_3"]);
             g_Grticle.Warp_Name_4 = Convert.ToString(dr["Warp_Name_4"]);
             g_Grticle.Weft_Name_1 = Convert.ToString(dr["Weft_Name_1"]);
             g_Grticle.Weft_Name_2 = Convert.ToString(dr["Weft_Name_2"]);
             g_Grticle.Weft_Name_3 = Convert.ToString(dr["Weft_Name_3"]);
             g_Grticle.Weft_Name_4 = Convert.ToString(dr["Weft_Name_4"]);

             return g_Grticle;
         }

         public GArticleInfo Get_G_Article_By_Id(int g_Article_Id)
         {
             GArticleInfo g_Grticles = new GArticleInfo();

             List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@G_Article_Id", g_Article_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_G_Articles_By_G_Article_Id_Sp.ToString(), CommandType.StoredProcedure);

             List<DataRow> drList = new List<DataRow>();

             drList = dt.AsEnumerable().ToList();

             foreach (DataRow dr in drList)
             {
                 g_Grticles = Get_G_Article_Values(dr);
             }

             return g_Grticles;
         }

         public List<AutocompleteInfo> Get_G_Articles_By_Full_Code(string full_Code)
         {
             List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

             List<SqlParameter> sqlparam = new List<SqlParameter>();

             sqlparam.Add(new SqlParameter("@Full_Code", full_Code));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlparam, StoredProcedures.Get_G_Articles_By_Full_Code_Sp.ToString(), CommandType.StoredProcedure);

             List<DataRow> drList = new List<DataRow>();

             drList = dt.AsEnumerable().ToList();

             foreach (DataRow dr in drList)
             {
                 AutocompleteInfo auto = new AutocompleteInfo();

                 auto.Value = Convert.ToInt32(dr["G_Article_Id"]);

                 auto.Label = Convert.ToString(dr["Full_Code"]);

                 autoCompletes.Add(auto);
             }

             return autoCompletes;
         }


    }
}
