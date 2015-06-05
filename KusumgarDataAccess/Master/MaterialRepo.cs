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
    public class MaterialRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public MaterialRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert_Material(MaterialInfo MaterialInfo)
        {
            int Material_Id = 0;
            Material_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Material(MaterialInfo), StoredProcedures.Insert_Material_Sp.ToString(), CommandType.StoredProcedure));
            return Material_Id;
        }

        public void Update_Material(MaterialInfo MaterialInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Material(MaterialInfo), StoredProcedures.Update_Material_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Material(MaterialInfo MaterialInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (MaterialInfo.Material_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Material_Id", MaterialInfo.Material_Id));
            }
            sqlParamList.Add(new SqlParameter("@Material_Code", MaterialInfo.Material_Code));
            sqlParamList.Add(new SqlParameter("@Material_Category_Id", MaterialInfo.Material_Category_Id));
            sqlParamList.Add(new SqlParameter("@Material_SubCategory_Id", MaterialInfo.Material_SubCategory_Id));
            sqlParamList.Add(new SqlParameter("@Material_Name", MaterialInfo.Material_Name));
            sqlParamList.Add(new SqlParameter("@Size", MaterialInfo.Size));
            sqlParamList.Add(new SqlParameter("@COD", MaterialInfo.COD));
            sqlParamList.Add(new SqlParameter("@Material_Type", MaterialInfo.Material_Type));
            sqlParamList.Add(new SqlParameter("@Original_Manufacturer", MaterialInfo.Original_Manufacturer));
            sqlParamList.Add(new SqlParameter("@Inspection_Facility", MaterialInfo.Inspection_Facility));
            sqlParamList.Add(new SqlParameter("@Testing_Facility", MaterialInfo.Testing_Facility));
            if (MaterialInfo.Material_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", MaterialInfo.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", MaterialInfo.UpdatedBy));
            return sqlParamList;
        }

        public List<MaterialInfo> Get_Materials(ref PaginationInfo pager)
        {
            List<MaterialInfo> Materials = new List<MaterialInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Materials_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Materials.Add(Get_Material_Values(dr));
            }
            return Materials;
        }

        public List<MaterialInfo> Get_Materials_By_Id(int Material_Id, ref PaginationInfo pager)
        {
            List<MaterialInfo> Materials = new List<MaterialInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Id", Material_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Materials_By_Material_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Materials.Add(Get_Material_Values(dr));
            }
            return Materials;
        }

        private MaterialInfo Get_Material_Values(DataRow dr)
        {
            MaterialInfo Material = new MaterialInfo();
            Material.Material_Id = Convert.ToInt32(dr["Material_Id"]);
            Material.Material_Code = Convert.ToString(dr["Material_Code"]);
            Material.Material_Category_Name = Convert.ToString(dr["Material_Category_Name"]);
            Material.Material_SubCategory_Name = Convert.ToString(dr["Material_SubCategory_Name"]);
            Material.Material_Name = Convert.ToString(dr["Material_Name"]);
            Material.Size = Convert.ToString(dr["Size"]);
            Material.COD = Convert.ToString(dr["COD"]);
            Material.Material_Type = Convert.ToInt32(dr["Material_Type"]);
            Material.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            Material.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            Material.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            return Material;
        }

        public List<AutocompleteInfo> Get_Materials_By_Name_Autocomplete(string material_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Name", material_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Materials_By_Material_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Material_Name"]);
                    auto.Value = Convert.ToInt32(dr["Material_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public MaterialInfo Get_Material_By_Id(int Material_Id)
        {
            MaterialInfo Material = new MaterialInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Id", Material_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Material_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    Material = Get_Material_Values_By_Id(dr);
                }
            }
            return Material;
        }

        private MaterialInfo Get_Material_Values_By_Id(DataRow dr)
        {
            MaterialInfo Material = new MaterialInfo();
            Material.Material_Id = Convert.ToInt32(dr["Material_Id"]);
            Material.Material_Code = Convert.ToString(dr["Material_Code"]);
            Material.Material_Category_Id = Convert.ToInt32(dr["Material_Category_Id"]);
            Material.Material_SubCategory_Id = Convert.ToInt32(dr["Material_SubCategory_Id"]);
            Material.Material_Category_Name = Convert.ToString(dr["Material_Category_Name"]);
            Material.Material_SubCategory_Name = Convert.ToString(dr["Material_SubCategory_Name"]);
            Material.Material_Name = Convert.ToString(dr["Material_Name"]);
            Material.Size = Convert.ToString(dr["Size"]);
            Material.COD = Convert.ToString(dr["COD"]);
            Material.Material_Type = Convert.ToInt32(dr["Material_Type"]);
            Material.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            Material.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            Material.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            return Material;
        }

        public List<MaterialCategoryInfo> Get_Material_Categories(ref PaginationInfo pager)
        {
            List<MaterialCategoryInfo> Material_Categories = new List<MaterialCategoryInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Material_Categories_sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Material_Categories.Add(Get_Material_Category_Values(dr));
            }
            return Material_Categories;
        }

        private MaterialCategoryInfo Get_Material_Category_Values(DataRow dr)
        {
            MaterialCategoryInfo Material_Category = new MaterialCategoryInfo();
            Material_Category.Material_Category_Id = Convert.ToInt32(dr["Material_Category_Id"]);
            Material_Category.Material_Category_Name = Convert.ToString(dr["Material_Category_Name"]);
            return Material_Category;
        }

        public List<MaterialSubCategoryInfo> Get_Material_SubCategories(int Material_Category_Id, ref PaginationInfo pager)
        {
            List<MaterialSubCategoryInfo> Material_SubCategories = new List<MaterialSubCategoryInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Category_Id", Material_Category_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Material_SubCategory_By_CategoryId_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Material_SubCategories.Add(Get_Material_SubCategory_Values(dr));
            }
            return Material_SubCategories;
        }

        private MaterialSubCategoryInfo Get_Material_SubCategory_Values(DataRow dr)
        {
            MaterialSubCategoryInfo Material_SubCategory = new MaterialSubCategoryInfo();
            Material_SubCategory.Material_SubCategory_Id = Convert.ToInt32(dr["Material_SubCategory_Id"]);
            Material_SubCategory.Material_SubCategory_Name = Convert.ToString(dr["Material_SubCategory_Name"]);
            Material_SubCategory.Material_Category_Id = Convert.ToInt32(dr["Material_Category_Id"]);
            Material_SubCategory.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            Material_SubCategory.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            Material_SubCategory.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            Material_SubCategory.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return Material_SubCategory;
        }

        public int Insert_Material_Vendor(MaterialVendorInfo MaterialVendorInfo)
        {
            int Material_Vendor_Id = 0;
            Material_Vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Material_Vendor(MaterialVendorInfo), StoredProcedures.Insert_Material_Vendor_Sp.ToString(), CommandType.StoredProcedure));
            return Material_Vendor_Id;
        }

        public void Update_Material_Vendor(MaterialVendorInfo MaterialVendorInfo)
        {

        }

        public void Delete_Material_Vendor_By_Id(int Material_Vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Vendor_Id", Material_Vendor_Id));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Material_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Material_Vendor(MaterialVendorInfo MaterialVendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (MaterialVendorInfo.Material_Vendor_Entity.Material_Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Material_Vendor_Id", MaterialVendorInfo.Material_Vendor_Entity.Material_Vendor_Id));
            }
            sqlParamList.Add(new SqlParameter("@Material_Id", MaterialVendorInfo.Material_Vendor_Entity.Material_Id));
            sqlParamList.Add(new SqlParameter("@Vendor_Id", MaterialVendorInfo.Material_Vendor_Entity.Vendor_Id));
            sqlParamList.Add(new SqlParameter("@Priority_Order", MaterialVendorInfo.Material_Vendor_Entity.Priority_Order));
            if (MaterialVendorInfo.Material_Vendor_Entity.Material_Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", MaterialVendorInfo.Material_Vendor_Entity.CreatedBy));
            }            
            return sqlParamList;
        }

        public List<MaterialVendorInfo> Get_Material_Vendors_By_Id(int Material_Id, ref PaginationInfo pager)
        {
            List<MaterialVendorInfo> Material_Vendors = new List<MaterialVendorInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Material_Id", Material_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Material_Vendors_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Material_Vendors.Add(Get_Material_Vendor_Values(dr));
            }
            return Material_Vendors;
        }

        private MaterialVendorInfo Get_Material_Vendor_Values(DataRow dr)
        {
            MaterialVendorInfo Material_vendor = new MaterialVendorInfo();
            Material_vendor.Material_Vendor_Entity.Material_Vendor_Id = Convert.ToInt32(dr["Material_Vendor_Id"]);
            Material_vendor.Material_Vendor_Entity.Material_Id = Convert.ToInt32(dr["Material_Id"]);
            Material_vendor.Material_Vendor_Entity.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            Material_vendor.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            Material_vendor.Material_Vendor_Entity.Priority_Order = Convert.ToInt32(dr["Priority_Order"]);
            return Material_vendor;
        }

        public List<AutocompleteInfo> Get_Vendor_Autocomplete(string vendor_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Vendor_Name", vendor_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.Get_Vendor_By_Name_Sp.ToString(), CommandType.StoredProcedure);
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
    }
}
