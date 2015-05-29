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
    public class ProductRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public ProductRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert_Product(ProductInfo productInfo)
        {
            int product_Id = 0;
            product_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Product(productInfo), StoredProcedures.Insert_Product_Sp.ToString(), CommandType.StoredProcedure));
            return product_Id;
        }

        public void Update_Product(ProductInfo productInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Product(productInfo), StoredProcedures.Update_Product_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Product(ProductInfo productInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (productInfo.Product_Entity.Product_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Product_Id", productInfo.Product_Entity.Product_Id));
            }
            sqlParamList.Add(new SqlParameter("@Product_Code", productInfo.Product_Entity.Product_Code));
            sqlParamList.Add(new SqlParameter("@Product_Category_Id", productInfo.Product_Entity.Product_Category_Id));
            sqlParamList.Add(new SqlParameter("@Product_SubCategory_Id", productInfo.Product_Entity.Product_SubCategory_Id));
            sqlParamList.Add(new SqlParameter("@Product_Name", productInfo.Product_Entity.Product_Name));
            sqlParamList.Add(new SqlParameter("@Size", productInfo.Product_Entity.Size));
            sqlParamList.Add(new SqlParameter("@COD", productInfo.Product_Entity.COD));
            sqlParamList.Add(new SqlParameter("@Product_Type", productInfo.Product_Entity.Product_Type));
            sqlParamList.Add(new SqlParameter("@Original_Manufacturer", productInfo.Product_Entity.Original_Manufacturer));
            sqlParamList.Add(new SqlParameter("@Inspection_Facility", productInfo.Product_Entity.Inspection_Facility));
            sqlParamList.Add(new SqlParameter("@Testing_Facility", productInfo.Product_Entity.Testing_Facility));
            if (productInfo.Product_Entity.Product_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", productInfo.Product_Entity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", productInfo.Product_Entity.UpdatedBy));
            return sqlParamList;
        }

        public List<ProductInfo> Get_Products(ref PaginationInfo pager)
        {
            List<ProductInfo> products = new List<ProductInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Products_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                products.Add(Get_Product_Values(dr));
            }
            return products;
        }

        public List<ProductInfo> Get_Products_By_Id(int product_Id, ref PaginationInfo pager)
        {
            List<ProductInfo> products = new List<ProductInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Id", product_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Products_By_Product_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                products.Add(Get_Product_Values(dr));
            }
            return products;
        }

        private ProductInfo Get_Product_Values(DataRow dr)
        {
            ProductInfo product = new ProductInfo();
            product.Product_Entity.Product_Id = Convert.ToInt32(dr["Product_Id"]);
            product.Product_Entity.Product_Code = Convert.ToString(dr["Product_Code"]);
            product.Product_Category_Name = Convert.ToString(dr["Product_Category_Name"]);
            product.Product_SubCategory_Name = Convert.ToString(dr["Product_SubCategory_Name"]);
            product.Product_Entity.Product_Name = Convert.ToString(dr["Product_Name"]);
            product.Product_Entity.Size = Convert.ToString(dr["Size"]);
            product.Product_Entity.COD = Convert.ToString(dr["COD"]);
            product.Product_Entity.Product_Type = Convert.ToInt32(dr["Product_Type"]);
            product.Product_Entity.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            product.Product_Entity.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            product.Product_Entity.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            return product;
        }

        public List<AutocompleteInfo> Get_Products_By_Name_Autocomplete(string product_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Name", product_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Products_By_Product_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Product_Name"]);
                    auto.Value = Convert.ToInt32(dr["Product_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public ProductInfo Get_Product_By_Id(int product_Id)
        {
            ProductInfo product = new ProductInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Id", product_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Product_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    product = Get_Product_Values_By_Id(dr);
                }
            }
            return product;
        }

        private ProductInfo Get_Product_Values_By_Id(DataRow dr)
        {
            ProductInfo product = new ProductInfo();
            product.Product_Entity.Product_Id = Convert.ToInt32(dr["Product_Id"]);
            product.Product_Entity.Product_Code = Convert.ToString(dr["Product_Code"]);
            product.Product_Entity.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);
            product.Product_Entity.Product_SubCategory_Id = Convert.ToInt32(dr["Product_SubCategory_Id"]);
            product.Product_Category_Name = Convert.ToString(dr["Product_Category_Name"]);
            product.Product_SubCategory_Name = Convert.ToString(dr["Product_SubCategory_Name"]);
            product.Product_Entity.Product_Name = Convert.ToString(dr["Product_Name"]);
            product.Product_Entity.Size = Convert.ToString(dr["Size"]);
            product.Product_Entity.COD = Convert.ToString(dr["COD"]);
            product.Product_Entity.Product_Type = Convert.ToInt32(dr["Product_Type"]);
            product.Product_Entity.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            product.Product_Entity.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            product.Product_Entity.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            return product;
        }

        public List<ProductCategoryInfo> Get_Product_Categories(ref PaginationInfo pager)
        {
            List<ProductCategoryInfo> product_Categories = new List<ProductCategoryInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Product_Categories_sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                product_Categories.Add(Get_Product_Category_Values(dr));
            }
            return product_Categories;
        }

        private ProductCategoryInfo Get_Product_Category_Values(DataRow dr)
        {
            ProductCategoryInfo product_Category = new ProductCategoryInfo();
            product_Category.Product_Category_Entity.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);
            product_Category.Product_Category_Entity.Product_Category_Name = Convert.ToString(dr["Product_Category_Name"]);
            return product_Category;
        }

        public List<ProductSubCategoryInfo> Get_Product_SubCategories(int product_Category_Id, ref PaginationInfo pager)
        {
            List<ProductSubCategoryInfo> product_SubCategories = new List<ProductSubCategoryInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Category_Id", product_Category_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Product_SubCategory_By_CategoryId_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                product_SubCategories.Add(Get_Product_SubCategory_Values(dr));
            }
            return product_SubCategories;
        }

        private ProductSubCategoryInfo Get_Product_SubCategory_Values(DataRow dr)
        {
            ProductSubCategoryInfo product_SubCategory = new ProductSubCategoryInfo();
            product_SubCategory.Product_SubCategory_Entity.Product_SubCategory_Id = Convert.ToInt32(dr["Product_SubCategory_Id"]);
            product_SubCategory.Product_SubCategory_Entity.Product_SubCategory_Name = Convert.ToString(dr["Product_SubCategory_Name"]);
            product_SubCategory.Product_SubCategory_Entity.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);
            product_SubCategory.Product_SubCategory_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            product_SubCategory.Product_SubCategory_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            product_SubCategory.Product_SubCategory_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            product_SubCategory.Product_SubCategory_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return product_SubCategory;
        }

        public int Insert_Product_Vendor(ProductVendorInfo productVendorInfo)
        {
            int product_Vendor_Id = 0;
            product_Vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Product_Vendor(productVendorInfo), StoredProcedures.Insert_Product_Vendor_Sp.ToString(), CommandType.StoredProcedure));
            return product_Vendor_Id;
        }

        public void Update_Product_Vendor(ProductVendorInfo productVendorInfo)
        {

        }

        public void Delete_Product_Vendor_By_Id(int product_Vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Vendor_Id", product_Vendor_Id));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Product_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Product_Vendor(ProductVendorInfo productVendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Product_Vendor_Id", productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id));
            }
            sqlParamList.Add(new SqlParameter("@Product_Id", productVendorInfo.Product_Vendor_Entity.Product_Id));
            sqlParamList.Add(new SqlParameter("@Vendor_Id", productVendorInfo.Product_Vendor_Entity.Vendor_Id));
            sqlParamList.Add(new SqlParameter("@Priority_Order", productVendorInfo.Product_Vendor_Entity.Priority_Order));
            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", productVendorInfo.Product_Vendor_Entity.CreatedBy));
            }            
            return sqlParamList;
        }

        public List<ProductVendorInfo> Get_Product_Vendors_By_Id(int product_Id, ref PaginationInfo pager)
        {
            List<ProductVendorInfo> product_Vendors = new List<ProductVendorInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Id", product_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Product_Vendors_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                product_Vendors.Add(Get_Product_Vendor_Values(dr));
            }
            return product_Vendors;
        }

        private ProductVendorInfo Get_Product_Vendor_Values(DataRow dr)
        {
            ProductVendorInfo product_vendor = new ProductVendorInfo();
            product_vendor.Product_Vendor_Entity.Product_Vendor_Id = Convert.ToInt32(dr["Product_Vendor_Id"]);
            product_vendor.Product_Vendor_Entity.Product_Id = Convert.ToInt32(dr["Product_Id"]);
            product_vendor.Product_Vendor_Entity.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            product_vendor.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            product_vendor.Product_Vendor_Entity.Priority_Order = Convert.ToInt32(dr["Priority_Order"]);
            return product_vendor;
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
