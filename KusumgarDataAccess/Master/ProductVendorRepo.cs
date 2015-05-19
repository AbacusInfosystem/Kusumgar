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
   public class ProductVendorRepo
    {

       private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public ProductVendorRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }



        public void Insert(ProductVendorInfo productVendors)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Product_Vendors(productVendors), StoredProcedures.Insert_Product_Vendors_sp.ToString(), CommandType.StoredProcedure);

        }

        private List<SqlParameter> Set_Values_In_Product_Vendors(ProductVendorInfo productVendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Product_Type", productVendorInfo.Product_Vendor_Entity.Product_Type));
            sqlParamList.Add(new SqlParameter("@Name", productVendorInfo.Product_Vendor_Entity.Name));
            sqlParamList.Add(new SqlParameter("@Original_Manufacturer", productVendorInfo.Product_Vendor_Entity.Original_Manufacturer));
            sqlParamList.Add(new SqlParameter("@Is_Active", productVendorInfo.Product_Vendor_Entity.Is_Active));

            sqlParamList.Add(new SqlParameter("@Inspection_Facility", productVendorInfo.Product_Vendor_Entity.Inspection_Facility));
            sqlParamList.Add(new SqlParameter("@Testing_Facility", productVendorInfo.Product_Vendor_Entity.Testing_Facility));

            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", productVendorInfo.Product_Vendor_Entity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", productVendorInfo.Product_Vendor_Entity.UpdatedBy));

            if (productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Vendor_Id", productVendorInfo.Product_Vendor_Entity.Product_Vendor_Id));
            }

            return sqlParamList;
        }
    }
}
