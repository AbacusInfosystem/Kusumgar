using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

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
            List<VendorInfo> vendors = new List<VendorInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Vendors_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                vendors.Add(Get_Vendor_Values(dr));
            }

            return vendors;
        }

        private VendorInfo Get_Vendor_Values(DataRow dr)
        {
           VendorInfo vendor = new VendorInfo();
           vendor.Vendor_Name =  Convert.ToString(dr["Vendor_Name"]);
           vendor.HeadOfficeAddress =  Convert.ToString(dr["HeadOfficeAddress"]);
           vendor.Head_Office_State =  Convert.ToInt32(dr["Head_Office_State"]);
           vendor.Head_Office_ZipCode =  Convert.ToString(dr["Head_Office_ZipCode"]);
           vendor.Head_Office_Nation =  Convert.ToInt32(dr["Head_Office_Nation"]);
           vendor.Head_Office_Landline1 = Convert.ToString(dr["Head_Office_Landline1"]);
          
            if (dr["Head_Office_Landline2"] != DBNull.Value)
           {
               vendor.Head_Office_Landline2 = Convert.ToString(dr["Head_Office_Landline2"]);
           }
            if (dr["Head_Office_FaxNo"] != DBNull.Value)
            {
                vendor.Head_Office_FaxNo = Convert.ToString(dr["Head_Office_FaxNo"]);
            }
           vendor.Email =  Convert.ToString(dr["Email"]);
           vendor.Quality_Certification =  Convert.ToString(dr["Quality_Certification"]);
           if (dr["Quality_Certification_Year"] != DBNull.Value)
           {
               vendor.Quality_Certification_Year = Convert.ToInt32(dr["Quality_Certification_Year"]);
           }
           vendor.Quality_Certification_Category =  Convert.ToString(dr["Quality_Certification_Category"]);
           vendor.Performance_Certification =  Convert.ToString(dr["Performance_Certification"]);

           if (dr["Performance_Certification_Year"] != DBNull.Value)
           {
               vendor.Performance_Certification_Year = Convert.ToInt32(dr["Performance_Certification_Year"]);
           }
           vendor.Performance_Certification_Category =  Convert.ToString(dr["Performance_Certification_Category"]);
          
            if (dr["Remark_about_Supplier"] != DBNull.Value)
           {
               vendor.Remark_about_Supplier = Convert.ToString(dr["Remark_about_Supplier"]);
           }
           if (dr["Block_Payment"] != DBNull.Value)
           {
               vendor.Block_Payment = Convert.ToBoolean(dr["Block_Payment"]);
           }
           if (dr["Shipment_Methods"] != DBNull.Value)
           {
               vendor.Shipment_Methods = Convert.ToInt32(dr["Shipment_Methods"]);
           }
           if (dr["Flagged_Supplier"] != DBNull.Value)
           {
               vendor.Flagged_Supplier = Convert.ToString(dr["Flagged_Supplier"]);
           }
           if (dr["Delivary_Term_Code"] != DBNull.Value)
           {
               vendor.Delivary_Term_Code = Convert.ToString(dr["Delivary_Term_Code"]);
           }

           vendor.Is_Approved_By_Director = Convert.ToBoolean(dr["Is_Approved_By_Director"]);
          
            if (dr["Central_Excise_Registration_Details"] != DBNull.Value)
           {
               vendor.Central_Excise_Registration_Details = Convert.ToString(dr["Central_Excise_Registration_Details"]);
           }
           vendor.Registration_No =  Convert.ToString(dr["Registration_No"]);
           vendor.Range =  Convert.ToString(dr["Range"]);
           vendor.Division =  Convert.ToString(dr["Division"]);
           vendor.PAN =  Convert.ToString(dr["PAN"]);
           vendor.TAN =  Convert.ToString(dr["TAN"]);
           vendor.Tax_Excemption_Code =  Convert.ToString(dr["Tax_Excemption_Code"]);
           if (dr["Currency_Code"] != DBNull.Value)
           {
               vendor.Currency_Code = Convert.ToInt32(dr["Currency_Code"]);
           }

           vendor.VAT_Type =  Convert.ToString(dr["VAT_Type"]);

           if (dr["PaymentTerms"] != DBNull.Value)
           {
               vendor.PaymentTerms = Convert.ToInt32(dr["PaymentTerms"]);
           }
           vendor.Is_Active =  Convert.ToBoolean(dr["Is_Active"]);
          
           vendor.CreatedBy =  Convert.ToInt32(dr["CreatedBy"]);
           vendor.UpdatedBy =  Convert.ToInt32(dr["UpdatedBy"]);
           vendor.Vendor_Id =  Convert.ToInt32(dr["Vendor_Id"]);
           if (dr["Product_Category"] != DBNull.Value)
           { vendor.Product_Category = Convert.ToInt32(dr["Product_Category"]);
           }

           if (dr["Code"] != DBNull.Value)
           {
               vendor.Code = Convert.ToString(dr["Code"]);
           }
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
          
             sqlParamList.Add(new SqlParameter("@Vendor_Name", vendors.Vendor_Name));
             sqlParamList.Add(new SqlParameter("@HeadOfficeAddress", vendors.HeadOfficeAddress));
             sqlParamList.Add(new SqlParameter("@Head_Office_State", vendors.Head_Office_State));
             sqlParamList.Add(new SqlParameter("@Head_Office_ZipCode", vendors.Head_Office_ZipCode));
             sqlParamList.Add(new SqlParameter("@Head_Office_Nation", vendors.Head_Office_Nation));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline1", vendors.Head_Office_Landline1));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline2", vendors.Head_Office_Landline2));
             sqlParamList.Add(new SqlParameter("@Head_Office_FaxNo", vendors.Head_Office_FaxNo));
             sqlParamList.Add(new SqlParameter("@Email", vendors.Email));
             sqlParamList.Add(new SqlParameter("@Quality_Certification", vendors.Quality_Certification));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Year", vendors.Quality_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Category", vendors.Quality_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Performance_Certification", vendors.Performance_Certification));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Year", vendors.Performance_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Category", vendors.Performance_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Remark_about_Supplier", vendors.Remark_about_Supplier));
             sqlParamList.Add(new SqlParameter("@Block_Payment", vendors.Block_Payment));
             sqlParamList.Add(new SqlParameter("@Shipment_Methods", vendors.Shipment_Methods));
             sqlParamList.Add(new SqlParameter("@Flagged_Supplier", vendors.Flagged_Supplier));

            sqlParamList.Add(new SqlParameter("@Delivary_Term_Code", vendors.Delivary_Term_Code));

            sqlParamList.Add(new SqlParameter("@Is_Approved_By_Director", vendors.Is_Approved_By_Director));

            sqlParamList.Add(new SqlParameter("@Central_Excise_Registration_Details", vendors.Central_Excise_Registration_Details));

            sqlParamList.Add(new SqlParameter("@Registration_No", vendors.Registration_No));
            sqlParamList.Add(new SqlParameter("@Range", vendors.Range));
            sqlParamList.Add(new SqlParameter("@Division", vendors.Division));
            sqlParamList.Add(new SqlParameter("@PAN", vendors.PAN));
            sqlParamList.Add(new SqlParameter("@TAN", vendors.TAN));
            sqlParamList.Add(new SqlParameter("@Tax_Excemption_Code", vendors.Tax_Excemption_Code));
            sqlParamList.Add(new SqlParameter("@Currency_Code", vendors.Currency_Code));
            sqlParamList.Add(new SqlParameter("@VAT_Type", vendors.VAT_Type));
            sqlParamList.Add(new SqlParameter("@PaymentTerms", vendors.PaymentTerms));
            sqlParamList.Add(new SqlParameter("@Is_Active", vendors.Is_Active));
            sqlParamList.Add(new SqlParameter("@Product_Category", vendors.Product_Category));
            sqlParamList.Add(new SqlParameter("@Code", vendors.Code));

           if (vendors.Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", vendors.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", vendors.UpdatedBy));
            
            if (vendors.Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Vendor_Id", vendors.Vendor_Id));
            }

            return sqlParamList;
        }

        //public int Insert_Product_Services(ProductVendorInfo productVendors)
        //{
        //    int Product_Vendor_Id = 0;

        //    Product_Vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Product_Vendors(productVendors), StoredProcedures.Insert_Product_Vendors_sp.ToString(), CommandType.StoredProcedure));
            
        //    return Product_Vendor_Id;
        //}

        //private List<SqlParameter> Set_Values_In_Product_Vendors(ProductVendorInfo productVendorInfo)
        //{
        //    List<SqlParameter> sqlParamList = new List<SqlParameter>();
           
            //sqlParamList.Add(new SqlParameter("@Vendor_Id", productVendorInfo.Product_Vendor_Entity.Vendor_Id));
            //sqlParamList.Add(new SqlParameter("@Product_Type", productVendorInfo.Product_Vendor_Entity.Product_Type));
            //sqlParamList.Add(new SqlParameter("@Name", productVendorInfo.Product_Vendor_Entity.Name));
            //sqlParamList.Add(new SqlParameter("@Original_Manufacturer", productVendorInfo.Product_Vendor_Entity.Original_Manufacturer));
           
            //sqlParamList.Add(new SqlParameter("@Inspection_Facility", productVendorInfo.Product_Vendor_Entity.Inspection_Facility));
            //sqlParamList.Add(new SqlParameter("@Testing_Facility", productVendorInfo.Product_Vendor_Entity.Testing_Facility));

            //if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id == 0)
            //{
            //    sqlParamList.Add(new SqlParameter("@CreatedBy", productVendorInfo.Product_Vendor_Entity.CreatedBy));
            //}
            //sqlParamList.Add(new SqlParameter("@UpdatedBy", productVendorInfo.Product_Vendor_Entity.UpdatedBy));

        //    if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id != 0)
        //    {
        //        sqlParamList.Add(new SqlParameter("@Product_Vendor_Id", productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id));
        //    }

        //    return sqlParamList;
        //}

        public void Update_Vendor(VendorInfo vendors)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Vendor(vendors), StoredProcedures.Update_Vendor_sp.ToString(), CommandType.StoredProcedure);
        }

        //public void Update_Product_Services(ProductVendorInfo productVendors)
        //{
        //    _sqlRepo.ExecuteNonQuery(Set_Values_In_Product_Vendors(productVendors), StoredProcedures.Update_Product_Vendors_sp.ToString(), CommandType.StoredProcedure);
        //}

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

        //private ProductVendorInfo Get_Product_Vendor_Values(DataRow dr)
        //{
        //    ProductVendorInfo productVendors = new ProductVendorInfo();
            
        //    productVendors.Product_Vendor_Entity.Product_Vendor_Id = Convert.ToInt32(dr["Product_Vendor_Id"]);

            //productVendors.Product_Vendor_Entity.Product_Type = Convert.ToInt32(dr["Product_Type"]);
            //productVendors.Product_Vendor_Entity.Name = Convert.ToString(dr["Name"]);
            //productVendors.Product_Vendor_Entity.Original_Manufacturer = Convert.ToBoolean(dr["Original_Manufacturer"]);
            //productVendors.Product_Vendor_Entity.Inspection_Facility = Convert.ToString(dr["Inspection_Facility"]);
            //productVendors.Product_Vendor_Entity.Testing_Facility = Convert.ToString(dr["Testing_Facility"]);
            //productVendors.Product_Type_Name = LookupInfo.Get_Product_Service_Types()[productVendors.Product_Vendor_Entity.Product_Type];
        //    return productVendors;

        //}

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

        public List<VendorInfo> Get_Vendors_By_Vendor_Id_Material_Id(int vendor_Id, int material_Id, ref PaginationInfo pager)
        {
            List<VendorInfo> vendors = new List<VendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id)); ;

            sqlParams.Add(new SqlParameter("@Material_Id", material_Id)); ;

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendors_By_Vendor_Id_Material_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                vendors.Add(Get_Vendor_Values(dr));
            }

            return vendors;
        }

        public List<VendorInfo> Get_Vendors_By_Material_Id(int material_Id, ref PaginationInfo pager)
        {
            List<VendorInfo> vendors = new List<VendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Material_Id", material_Id)); ;

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendors_By_Material_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                vendors.Add(Get_Vendor_Values(dr));
            }

            return vendors;
        }

        //public void Delete_Product_Service_By_Id(int product_Vendor_Id)
        //{
        //    List<SqlParameter> sqlparam = new List<SqlParameter>();

        //    sqlparam.Add(new SqlParameter("@Product_Vendor_Id", product_Vendor_Id));

        //    _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Product_Service_By_Id.ToString(), CommandType.StoredProcedure);
        //}

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

        //public List<ProductVendorInfo> Get_Product_Vendor_By_Id(int vendor_Id)
        //{
        //    List<ProductVendorInfo> productVendors = new List<ProductVendorInfo>();

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

        //    DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Product_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);


        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        int count = 0;

        //        List<DataRow> drList = new List<DataRow>();

        //        drList = dt.AsEnumerable().ToList();

        //        count = drList.Count();

        //        foreach (DataRow dr in drList)
        //        {
        //            productVendors.Add(Get_Product_Vendor_Values(dr));
                
        //        }
        //    }

        //    return productVendors;

        //}

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

        public List<MaterialCategoryInfo> Get_Material_Category()
        {
            List<MaterialCategoryInfo> retVal = new List<MaterialCategoryInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Material_Categories_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    MaterialCategoryInfo MaterialCategoryInfo = new MaterialCategoryInfo();

                    MaterialCategoryInfo.Material_Category_Id = Convert.ToInt32(dr["Material_Category_Id"]);

                    MaterialCategoryInfo.Material_Category_Name = Convert.ToString(dr["Material_Category_Name"]);

                    retVal.Add(MaterialCategoryInfo);
                }

            }

            return retVal;
        }

        public int Insert_Attribute_Code(AttributeCodeInfo attributeCode)
        {
            int Attribute_Code_Id = 0;
           
            Attribute_Code_Id =Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Insert_Attribute_Code_sp.ToString(), CommandType.StoredProcedure));

            return Attribute_Code_Id;
        }

        private List<SqlParameter> Set_Values_In_Attribute_Code(AttributeCodeInfo attributeCodes)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

           sqlParamList.Add(new SqlParameter("@Status", attributeCodes.Status));

            sqlParamList.Add(new SqlParameter("@Attribute_Id", attributeCodes.Attribute_Id));

            sqlParamList.Add(new SqlParameter("@Attribute_Code_Name", attributeCodes.Attribute_Code_Name));

            sqlParamList.Add(new SqlParameter("@Code", attributeCodes.Code));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", attributeCodes.UpdatedBy));

            if (attributeCodes.Attribute_Code_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", attributeCodes.CreatedBy));
            }
            if (attributeCodes.Attribute_Code_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Attribute_Code_Id", attributeCodes.Attribute_Code_Id));
            }

            return sqlParamList;
        }

        //public void Update_Attribute_Code(AttributeCodeInfo attributeCode)
        //{
        //    _sqlRepo.ExecuteNonQuery(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Update_Attribute_Code_Name_sp.ToString(), CommandType.StoredProcedure);
         
        //}
   
 }
}
  