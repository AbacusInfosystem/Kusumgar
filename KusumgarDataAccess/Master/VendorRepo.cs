using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Web;

namespace KusumgarDataAccess
{
 public class VendorRepo
    {
        SQLHelperRepo _sqlRepo;

        public VendorRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<VendorInfo> Get_Vendors(ref PaginationInfo pager)
        {
            List<VendorInfo> Vendors = new List<VendorInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Vendors_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Vendors.Add(Get_Vendor_Values(dr));
            }

            return Vendors;
        }

        private VendorInfo Get_Vendor_Values(DataRow dr)
        {
           VendorInfo vendor = new VendorInfo();
           vendor.Vendor_Entity.Vendor_Name =  Convert.ToString(dr["Vendor_Name"]);
           vendor.Vendor_Entity.HeadOfficeAddress =  Convert.ToString(dr["HeadOfficeAddress"]);
           vendor.Vendor_Entity.Head_Office_State =  Convert.ToInt32(dr["Head_Office_State"]);
           vendor.Vendor_Entity.Head_Office_ZipCode =  Convert.ToString(dr["Head_Office_ZipCode"]);
           vendor.Vendor_Entity.Head_Office_Nation =  Convert.ToInt32(dr["Head_Office_Nation"]);
           vendor.Vendor_Entity.Head_Office_Landline1 = Convert.ToString(dr["Head_Office_Landline1"]);
           vendor.Vendor_Entity.Head_Office_Landline2 =  Convert.ToString(dr["Head_Office_Landline2"]);
           vendor.Vendor_Entity.Head_Office_FaxNo =  Convert.ToString(dr["Head_Office_FaxNo"]);
           vendor.Vendor_Entity.Email =  Convert.ToString(dr["Email"]);
           vendor.Vendor_Entity.Quality_Certification =  Convert.ToString(dr["Quality_Certification"]);
           vendor.Vendor_Entity.Quality_Certification_Year = Convert.ToInt32(dr["Quality_Certification_Year"]);
           vendor.Vendor_Entity.Quality_Certification_Category =  Convert.ToString(dr["Quality_Certification_Category"]);
           vendor.Vendor_Entity.Performance_Certification =  Convert.ToString(dr["Performance_Certification"]);
           vendor.Vendor_Entity.Performance_Certification_Year = Convert.ToInt32(dr["Performance_Certification_Year"]);
           vendor.Vendor_Entity.Performance_Certification_Category =  Convert.ToString(dr["Performance_Certification_Category"]);
           vendor.Vendor_Entity.Remark_about_Supplier =  Convert.ToString(dr["Remark_about_Supplier"]);
           vendor.Vendor_Entity.Block_Payment =  Convert.ToBoolean(dr["Block_Payment"]);
           vendor.Vendor_Entity.Shipment_Methods = Convert.ToInt32(dr["Shipment_Methods"]);
           vendor.Vendor_Entity.Flagged_Supplier =  Convert.ToString(dr["Flagged_Supplier"]);
           vendor.Vendor_Entity.Delivary_Term_Code =  Convert.ToString(dr["Delivary_Term_Code"]);
           vendor.Vendor_Entity.Is_Approved_By_Director = Convert.ToBoolean(dr["Is_Approved_By_Director"]);
           vendor.Vendor_Entity.Central_Excise_Registration_Details =  Convert.ToString(dr["Central_Excise_Registration_Details"]);
           vendor.Vendor_Entity.Registration_No =  Convert.ToString(dr["Registration_No"]);
           vendor.Vendor_Entity.Range =  Convert.ToString(dr["Range"]);
           vendor.Vendor_Entity.Division =  Convert.ToString(dr["Division"]);
           vendor.Vendor_Entity.PAN =  Convert.ToString(dr["PAN"]);
           vendor.Vendor_Entity.TAN =  Convert.ToString(dr["TAN"]);
           vendor.Vendor_Entity.Tax_Excemption_Code =  Convert.ToString(dr["Tax_Excemption_Code"]);
           vendor.Vendor_Entity.Currency_Code =  Convert.ToInt32(dr["Currency_Code"]);
           vendor.Vendor_Entity.VAT_Type =  Convert.ToString(dr["VAT_Type"]);
           vendor.Vendor_Entity.PaymentTerms = Convert.ToInt32(dr["PaymentTerms"]);
           vendor.Vendor_Entity.Is_Active =  Convert.ToBoolean(dr["Is_Active"]);
           vendor.Vendor_Entity.Tax_Excemption_Code =  Convert.ToString(dr["Tax_Excemption_Code"]);
           vendor.Vendor_Entity.CreatedBy =  Convert.ToInt32(dr["CreatedBy"]);
           vendor.Vendor_Entity.UpdatedBy =  Convert.ToInt32(dr["UpdatedBy"]);
           vendor.Vendor_Entity.Vendor_Id =  Convert.ToInt32(dr["Vendor_Id"]);
           vendor.Vendor_Entity.Product_Category = Convert.ToInt32(dr["Product_Category"]);
          
            return vendor ;
        }

        public int Insert_Vendor(VendorInfo vendors)
        {
            int Vendor_Id = 0;

            Vendor_Id=Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Vendor(vendors), StoredProcedures.Insert_Vendor_sp.ToString(), CommandType.StoredProcedure));
            
            return Vendor_Id;
        
        }

        private List<SqlParameter> Set_Values_In_Vendor(VendorInfo vendors)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
          
             sqlParamList.Add(new SqlParameter("@Vendor_Name", vendors.Vendor_Entity.Vendor_Name));
             sqlParamList.Add(new SqlParameter("@HeadOfficeAddress", vendors.Vendor_Entity.HeadOfficeAddress));
             sqlParamList.Add(new SqlParameter("@Head_Office_State", vendors.Vendor_Entity.Head_Office_State));
             sqlParamList.Add(new SqlParameter("@Head_Office_ZipCode", vendors.Vendor_Entity.Head_Office_ZipCode));
             sqlParamList.Add(new SqlParameter("@Head_Office_Nation", vendors.Vendor_Entity.Head_Office_Nation));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline1", vendors.Vendor_Entity.Head_Office_Landline1));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline2", vendors.Vendor_Entity.Head_Office_Landline2));
             sqlParamList.Add(new SqlParameter("@Head_Office_FaxNo", vendors.Vendor_Entity.Head_Office_FaxNo));
             sqlParamList.Add(new SqlParameter("@Email", vendors.Vendor_Entity.Email));
             sqlParamList.Add(new SqlParameter("@Quality_Certification", vendors.Vendor_Entity.Quality_Certification));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Year", vendors.Vendor_Entity.Quality_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Category", vendors.Vendor_Entity.Quality_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Performance_Certification", vendors.Vendor_Entity.Performance_Certification));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Year", vendors.Vendor_Entity.Performance_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Category", vendors.Vendor_Entity.Performance_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Remark_about_Supplier", vendors.Vendor_Entity.Remark_about_Supplier));
             sqlParamList.Add(new SqlParameter("@Block_Payment", vendors.Vendor_Entity.Block_Payment));
             sqlParamList.Add(new SqlParameter("@Shipment_Methods", vendors.Vendor_Entity.Shipment_Methods));
             sqlParamList.Add(new SqlParameter("@Flagged_Supplier", vendors.Vendor_Entity.Flagged_Supplier));

            sqlParamList.Add(new SqlParameter("@Delivary_Term_Code", vendors.Vendor_Entity.Delivary_Term_Code));

            sqlParamList.Add(new SqlParameter("@Is_Approved_By_Director", vendors.Vendor_Entity.Is_Approved_By_Director));

            sqlParamList.Add(new SqlParameter("@Central_Excise_Registration_Details", vendors.Vendor_Entity.Central_Excise_Registration_Details));

            sqlParamList.Add(new SqlParameter("@Registration_No", vendors.Vendor_Entity.Registration_No));
            sqlParamList.Add(new SqlParameter("@Range", vendors.Vendor_Entity.Range));
            sqlParamList.Add(new SqlParameter("@Division", vendors.Vendor_Entity.Division));
            sqlParamList.Add(new SqlParameter("@PAN", vendors.Vendor_Entity.PAN));
            sqlParamList.Add(new SqlParameter("@TAN", vendors.Vendor_Entity.TAN));
            sqlParamList.Add(new SqlParameter("@Tax_Excemption_Code", vendors.Vendor_Entity.Tax_Excemption_Code));
            sqlParamList.Add(new SqlParameter("@Currency_Code", vendors.Vendor_Entity.Currency_Code));
            sqlParamList.Add(new SqlParameter("@VAT_Type", vendors.Vendor_Entity.VAT_Type));
            sqlParamList.Add(new SqlParameter("@PaymentTerms", vendors.Vendor_Entity.PaymentTerms));
            sqlParamList.Add(new SqlParameter("@Is_Active", vendors.Vendor_Entity.Is_Active));
            sqlParamList.Add(new SqlParameter("@Product_Category", vendors.Vendor_Entity.Product_Category));
            
            if (vendors.Vendor_Entity.Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", vendors.Vendor_Entity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", vendors.Vendor_Entity.UpdatedBy));
            
            if (vendors.Vendor_Entity.Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Vendor_Id", vendors.Vendor_Entity.Vendor_Id));
            }

            return sqlParamList;
        }

        public int Insert_Product_Services(ProductVendorInfo productVendors)
        {
            int Product_Vendor_Id = 0;

            Product_Vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Product_Vendors(productVendors), StoredProcedures.Insert_Product_Vendors_sp.ToString(), CommandType.StoredProcedure));
            
            return Product_Vendor_Id;
        }

        private List<SqlParameter> Set_Values_In_Product_Vendors(ProductVendorInfo productVendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
           
            sqlParamList.Add(new SqlParameter("@Vendor_Id", productVendorInfo.Product_Vendor_Entity.Vendor_Id));
            sqlParamList.Add(new SqlParameter("@Product_Type", productVendorInfo.Product_Vendor_Entity.Product_Type));
            sqlParamList.Add(new SqlParameter("@Name", productVendorInfo.Product_Vendor_Entity.Name));
            sqlParamList.Add(new SqlParameter("@Original_Manufacturer", productVendorInfo.Product_Vendor_Entity.Original_Manufacturer));
           
            sqlParamList.Add(new SqlParameter("@Inspection_Facility", productVendorInfo.Product_Vendor_Entity.Inspection_Facility));
            sqlParamList.Add(new SqlParameter("@Testing_Facility", productVendorInfo.Product_Vendor_Entity.Testing_Facility));

            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", productVendorInfo.Product_Vendor_Entity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", productVendorInfo.Product_Vendor_Entity.UpdatedBy));

            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Product_Vendor_Id", productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id));
            }

            return sqlParamList;
        }

        public void Update_Vendor(VendorInfo vendors)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Vendor(vendors), StoredProcedures.Update_Vendor_sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Product_Services(ProductVendorInfo productVendors)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Product_Vendors(productVendors), StoredProcedures.Update_Product_Vendors_sp.ToString(), CommandType.StoredProcedure);
        }

        public VendorInfo Get_Vendor_By_Id(int vendor_Id)
        {
            VendorInfo vendors = new VendorInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();
                
                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    vendors = Get_Vendor_Values(dr); // To bind vendor data 
                }
            }

            return vendors;
        }

        private ProductVendorInfo Get_Product_Vendor_Values(DataRow dr)
        {
            ProductVendorInfo productVendors = new ProductVendorInfo();
            
            productVendors.Product_Vendor_Entity.Product_Vendor_Id = Convert.ToInt32(dr["Product_Vendor_Id"]);

            productVendors.Product_Vendor_Entity.Product_Type = Convert.ToInt32(dr["Product_Type"]);
            productVendors.Product_Vendor_Entity.Name = Convert.ToString(dr["Name"]);
            productVendors.Product_Vendor_Entity.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            productVendors.Product_Vendor_Entity.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            productVendors.Product_Vendor_Entity.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            productVendors.Product_Type_Name = LookupInfo.Get_Product_Service_Types()[productVendors.Product_Vendor_Entity.Product_Type];
            return productVendors;

        }

        public List<VendorInfo> Get_Vendors_By_Id(int vendor_Id, ref PaginationInfo pager)
        {
            List<VendorInfo> vendors = new List<VendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id)); ;

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                vendors.Add(Get_Vendor_Values(dr));
            }

            return vendors;
        }

        public void Delete_Product_Service_By_Id(int product_Vendor_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Product_Vendor_Id", product_Vendor_Id));

            _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Product_Service_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
        {
            List<AutocompleteInfo> VendorNames = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Name", vendor_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Vendor_Name"]);

                    auto.Value = Convert.ToInt32(dr["Vendor_Id"]);

                    VendorNames.Add(auto);
                }
            }

            return VendorNames;
        }

        public List<ProductVendorInfo> Get_Product_Vendor_By_Id(int vendor_Id)
        {
            List<ProductVendorInfo> productVendors = new List<ProductVendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Product_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    productVendors.Add(Get_Product_Vendor_Values(dr));
                
                }
            }

            return productVendors;

        }

        public bool Check_Existing_Vendor(string vendor_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Name", vendor_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Check_Existing_Vendor_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Vendor"]);
                }
            }

            return check;
        }

        public List<ProductCategoryInfo> Get_Product_Category()
        {
            List<ProductCategoryInfo> retVal = new List<ProductCategoryInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Product_Categories_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    ProductCategoryInfo productCategoryInfo = new ProductCategoryInfo();

                    productCategoryInfo.Product_Category_Entity.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

                    productCategoryInfo.Product_Category_Entity.Product_Category_Name = Convert.ToString(dr["Product_Category_Name"]);

                    retVal.Add(productCategoryInfo);
                }

            }

            return retVal;
        }
    }
}
  