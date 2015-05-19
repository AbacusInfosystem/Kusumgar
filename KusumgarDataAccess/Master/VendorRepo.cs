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

      private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public VendorRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }
        public int Insert(VendorInfo vendors)
        {
            int Vendor_Id = 0;
            Vendor_Id=Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Vendor(vendors), StoredProcedures.Insert_Vendor_sp.ToString(), CommandType.StoredProcedure));
            
            return Vendor_Id;
        
        }

        private List<SqlParameter> Set_Values_In_Vendor(VendorInfo vendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
          
             sqlParamList.Add(new SqlParameter("@Vendor_Name", vendorInfo.Vendor_Entity.Vendor_Name));
             sqlParamList.Add(new SqlParameter("@HeadOfficeAddress", vendorInfo.Vendor_Entity.HeadOfficeAddress));
             sqlParamList.Add(new SqlParameter("@Head_Office_State", vendorInfo.Vendor_Entity.Head_Office_State));
             sqlParamList.Add(new SqlParameter("@Head_Office_ZipCode", vendorInfo.Vendor_Entity.Head_Office_ZipCode));
             sqlParamList.Add(new SqlParameter("@Head_Office_Nation", vendorInfo.Vendor_Entity.Head_Office_Nation));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline1", vendorInfo.Vendor_Entity.Head_Office_Landline1));
             sqlParamList.Add(new SqlParameter("@Head_Office_Landline2", vendorInfo.Vendor_Entity.Head_Office_Landline2));
             sqlParamList.Add(new SqlParameter("@Head_Office_FaxNo", vendorInfo.Vendor_Entity.Head_Office_FaxNo));
             sqlParamList.Add(new SqlParameter("@Email", vendorInfo.Vendor_Entity.Email));
             sqlParamList.Add(new SqlParameter("@Quality_Certification", vendorInfo.Vendor_Entity.Quality_Certification));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Year", vendorInfo.Vendor_Entity.Quality_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Quality_Certification_Category", vendorInfo.Vendor_Entity.Quality_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Performance_Certification", vendorInfo.Vendor_Entity.Performance_Certification));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Year", vendorInfo.Vendor_Entity.Performance_Certification_Year));
             sqlParamList.Add(new SqlParameter("@Performance_Certification_Category", vendorInfo.Vendor_Entity.Performance_Certification_Category));
             sqlParamList.Add(new SqlParameter("@Remark_about_Supplier", vendorInfo.Vendor_Entity.Remark_about_Supplier));
             sqlParamList.Add(new SqlParameter("@Block_Payment", vendorInfo.Vendor_Entity.Block_Payment));

             sqlParamList.Add(new SqlParameter("@Shipment_Methods", vendorInfo.Vendor_Entity.Shipment_Methods));

             sqlParamList.Add(new SqlParameter("@Flagged_Supplier", vendorInfo.Vendor_Entity.Flagged_Supplier));

            sqlParamList.Add(new SqlParameter("@Delivary_Term_Code", vendorInfo.Vendor_Entity.Delivary_Term_Code));

            sqlParamList.Add(new SqlParameter("@Is_Approved_By_Director", vendorInfo.Vendor_Entity.Is_Approved_By_Director));

            sqlParamList.Add(new SqlParameter("@Central_Excise_Registration_Details", vendorInfo.Vendor_Entity.Central_Excise_Registration_Details));

            sqlParamList.Add(new SqlParameter("@Registration_No", vendorInfo.Vendor_Entity.Registration_No));
            sqlParamList.Add(new SqlParameter("@Range", vendorInfo.Vendor_Entity.Range));
            sqlParamList.Add(new SqlParameter("@Division", vendorInfo.Vendor_Entity.Division));
            sqlParamList.Add(new SqlParameter("@PAN", vendorInfo.Vendor_Entity.PAN));
            sqlParamList.Add(new SqlParameter("@TAN", vendorInfo.Vendor_Entity.TAN));
            sqlParamList.Add(new SqlParameter("@Tax_Excemption_Code", vendorInfo.Vendor_Entity.Tax_Excemption_Code));
            sqlParamList.Add(new SqlParameter("@Currency_Code", vendorInfo.Vendor_Entity.Currency_Code));
            sqlParamList.Add(new SqlParameter("@VAT_Type", vendorInfo.Vendor_Entity.VAT_Type));
            sqlParamList.Add(new SqlParameter("@PaymentTerms", vendorInfo.Vendor_Entity.PaymentTerms));
            sqlParamList.Add(new SqlParameter("@Is_Active", vendorInfo.Vendor_Entity.Is_Active));
            sqlParamList.Add(new SqlParameter("@Tax_Excemption_Code", vendorInfo.Vendor_Entity.Tax_Excemption_Code));


            if (vendorInfo.Vendor_Entity.Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", vendorInfo.Vendor_Entity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", vendorInfo.Vendor_Entity.UpdatedBy));
            
            if (vendorInfo.Vendor_Entity.Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Vendor_Id", vendorInfo.Vendor_Entity.Vendor_Id));
            }

            return sqlParamList;
        }
        
       
       
    }
}
  