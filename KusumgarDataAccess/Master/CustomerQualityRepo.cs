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
    public class CustomerQualityRepo
    {
         SQLHelperRepo _sqlRepo;

         public CustomerQualityRepo()
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

         public int Insert_Customer_Quality(CustomerQualityInfo customer_Quality)
         {
             int customer_Quality_Id = 0;

             customer_Quality_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Customer_Quality(customer_Quality), StoredProcedures.Insert_Customer_Quality_Sp.ToString(), CommandType.StoredProcedure));

             return customer_Quality_Id;
         }

         private List<SqlParameter> Set_Values_In_Customer_Quality(CustomerQualityInfo customer_Quality)
         {
             List<SqlParameter> sqlparam = new List<SqlParameter>();

             if (customer_Quality.Customer_Quality_Id != 0)
             {
                 sqlparam.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality.Customer_Quality_Id));
             }
             sqlparam.Add(new SqlParameter("@Customer_Id", customer_Quality.Customer_Id));
             sqlparam.Add(new SqlParameter("@Quality_Id", customer_Quality.Quality_Id));
             sqlparam.Add(new SqlParameter("@Sample_Id", customer_Quality.Sample_Id));
             sqlparam.Add(new SqlParameter("@Is_Active", customer_Quality.Is_Active));

             if (customer_Quality.Customer_Quality_Id == 0)
             {
                 sqlparam.Add(new SqlParameter("@CreatedOn", customer_Quality.CreatedOn));
                 sqlparam.Add(new SqlParameter("@CreatedBy", customer_Quality.CreatedBy));
             }
             sqlparam.Add(new SqlParameter("@UpdatedOn", customer_Quality.UpdatedOn));
             sqlparam.Add(new SqlParameter("@UpdatedBy", customer_Quality.UpdatedBy));

             return sqlparam;
         }

         public void Update_Customer_Quality(CustomerQualityInfo customer_Quality)
         {
            _sqlRepo.ExecuteNonQuery(Set_Updated_Values_In_Customer_Quality(customer_Quality), StoredProcedures.Update_Customer_Quality_Sp.ToString(), CommandType.StoredProcedure);
           
         }

         private List<SqlParameter> Set_Updated_Values_In_Customer_Quality(CustomerQualityInfo customer_Quality)
         {
             List<SqlParameter> sqlparam = new List<SqlParameter>();

             if (customer_Quality.Customer_Quality_Id != 0)
             {
                 sqlparam.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality.Customer_Quality_Id));
             }
             sqlparam.Add(new SqlParameter("@Customer_Id", customer_Quality.Customer_Id));
             sqlparam.Add(new SqlParameter("@Quality_Id", customer_Quality.Quality_Id));
             sqlparam.Add(new SqlParameter("@Customer_Roll_Length", customer_Quality.Customer_Roll_Length));
             sqlparam.Add(new SqlParameter("@Storage", customer_Quality.Storage));
             sqlparam.Add(new SqlParameter("@Transport", customer_Quality.Transport));
             sqlparam.Add(new SqlParameter("@Lot_Testing", customer_Quality.Lot_Testing));
             sqlparam.Add(new SqlParameter("@End_Product_Criteria", customer_Quality.End_Product_Criteria));
             sqlparam.Add(new SqlParameter("@Testing_Requirements", customer_Quality.Testing_Requirements));
             sqlparam.Add(new SqlParameter("@Inspection_Requirements", customer_Quality.Inspection_Requirements));
             sqlparam.Add(new SqlParameter("@Process_Control", customer_Quality.Process_Control));
             //sqlparam.Add(new SqlParameter("@Sample_Id", customer_Quality.Customer_Sample_No));
             sqlparam.Add(new SqlParameter("@Sample_Id", customer_Quality.Sample_Id));
             sqlparam.Add(new SqlParameter("@Special_Care_Details", customer_Quality.Special_Care_Details));
             sqlparam.Add(new SqlParameter("@Special_Requirements_Material_Handling", customer_Quality.Special_Requirements_Material_Handling));
             sqlparam.Add(new SqlParameter("@Special_Requirements_Packaging", customer_Quality.Special_Requirements_Packaging));
             sqlparam.Add(new SqlParameter("@Special_Requirements_Defect_Defination", customer_Quality.Special_Requirements_Defect_Defination));
             sqlparam.Add(new SqlParameter("@Special_Requirements_Verdicting", customer_Quality.Special_Requirements_Verdicting));
             sqlparam.Add(new SqlParameter("@Is_Active", customer_Quality.Is_Active));

             if (customer_Quality.Customer_Quality_Id == 0)
             {
                 sqlparam.Add(new SqlParameter("@CreatedOn", customer_Quality.CreatedOn));
                 sqlparam.Add(new SqlParameter("@CreatedBy", customer_Quality.CreatedBy));
             }
             sqlparam.Add(new SqlParameter("@UpdatedOn", customer_Quality.UpdatedOn));
             sqlparam.Add(new SqlParameter("@UpdatedBy", customer_Quality.UpdatedBy));

             return sqlparam;
         }

        //Autocomplete
         public List<AutocompleteInfo> Get_Sample_No_AutoComplete(string sample_No)
         {
             List<AutocompleteInfo> vendors = new List<AutocompleteInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Sample_No", sample_No));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Sample_By_No_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {
                 List<DataRow> drList = new List<DataRow>();

                 drList = dt.AsEnumerable().ToList();

                 foreach (DataRow dr in drList)
                 {
                     AutocompleteInfo auto = new AutocompleteInfo();

                     auto.Label = Convert.ToString(dr["Sample_No"]);

                     auto.Value = Convert.ToInt32(dr["Sample_Id"]);

                     vendors.Add(auto);
                 }
             }

             return vendors;
         }

         public List<CustomerQualityInfo> Get_Customer_Qualities(ref PaginationInfo pager)
         {
             List<CustomerQualityInfo> customer_Qualities = new List<CustomerQualityInfo>();

             DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Customer_Qualities_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {

                 foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                 {
                     customer_Qualities.Add(Get_Customer_Quality_Values(dr));
                 }
             }

             return customer_Qualities;
         }

         public List<CustomerQualityInfo> Get_Customer_Qualities_By_Customer_Id(int customer_Id, ref PaginationInfo pager)
         {
             List<CustomerQualityInfo> customer_Qualities = new List<CustomerQualityInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Qualities_By_Customer_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 customer_Qualities.Add(Get_Customer_Quality_Values(dr));
             }

             return customer_Qualities;
         }

         public List<CustomerQualityInfo> Get_Customer_Qualities_By_Quality_Id(int quality_Id, ref PaginationInfo pager)
         {
             List<CustomerQualityInfo> customer_Qualities = new List<CustomerQualityInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Qualities_By_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 customer_Qualities.Add(Get_Customer_Quality_Values(dr));
             }

             return customer_Qualities;
         }

         public List<CustomerQualityInfo> Get_Customer_Qualities_By_Customer_Id_By_Quality_Id(int customer_Id, int quality_Id, ref PaginationInfo pager)
         {
             List<CustomerQualityInfo> customer_Qualities = new List<CustomerQualityInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

             sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Qualities_By_Customer_Id_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 customer_Qualities.Add(Get_Customer_Quality_Values(dr));
             }

             return customer_Qualities;
         }

         private CustomerQualityInfo Get_Customer_Quality_Values(DataRow dr)
         {
             CustomerQualityInfo customer_Quality = new CustomerQualityInfo();

             customer_Quality.Customer_Quality_Id = Convert.ToInt32(dr["Customer_Quality_Id"]);
             customer_Quality.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
             customer_Quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
             customer_Quality.Customer_Roll_Length = Convert.ToString(dr["Customer_Roll_Length"]);
             customer_Quality.Storage = Convert.ToString(dr["Storage"]);
             customer_Quality.Transport = Convert.ToString(dr["Transport"]);
             customer_Quality.Lot_Testing = Convert.ToString(dr["Lot_Testing"]);
             customer_Quality.End_Product_Criteria = Convert.ToString(dr["End_Product_Criteria"]);
             customer_Quality.Testing_Requirements = Convert.ToString(dr["Testing_Requirements"]);
             customer_Quality.Inspection_Requirements = Convert.ToString(dr["Inspection_Requirements"]);
             customer_Quality.Process_Control = Convert.ToString(dr["Process_Control"]);
             customer_Quality.Sample_Id = Convert.ToInt32(dr["Sample_Id"]);
             customer_Quality.Special_Care_Details = Convert.ToString(dr["Special_Care_Details"]);
             customer_Quality.Special_Requirements_Material_Handling = Convert.ToString(dr["Special_Requirements_Material_Handling"]);
             customer_Quality.Special_Requirements_Packaging = Convert.ToString(dr["Special_Requirements_Packaging"]);
             customer_Quality.Special_Requirements_Defect_Defination = Convert.ToString(dr["Special_Requirements_Defect_Defination"]);
             customer_Quality.Special_Requirements_Verdicting = Convert.ToString(dr["Special_Requirements_Verdicting"]);
             customer_Quality.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
             customer_Quality.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
             customer_Quality.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
             customer_Quality.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
             customer_Quality.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
             customer_Quality.Customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
             customer_Quality.Quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
             //customer_Quality.Sample.Sample_No = Convert.ToInt32(dr["Sample_No"]);

             return customer_Quality;
         }

         public CustomerQualityInfo Get_Customer_Quality_By_Id(int customer_Quality_Id)
         {
             CustomerQualityInfo customer_Quality = new CustomerQualityInfo();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality_Id));

             DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Customer_Quality_By_Id_Sp.ToString(), CommandType.StoredProcedure);

             DataTable dt = ds.Tables[0];

             if (dt != null && dt.Rows.Count > 0)
             {
                 List<DataRow> drList = new List<DataRow>();

                 drList = dt.AsEnumerable().ToList();

                 foreach (DataRow dr in drList)
                 {
                     customer_Quality = Get_Customer_Quality_Values_By_Id(dr);

                 }
             }

             return customer_Quality;
         }

         private CustomerQualityInfo Get_Customer_Quality_Values_By_Id(DataRow dr)
         {
             CustomerQualityInfo customer_Quality = new CustomerQualityInfo();

             customer_Quality.Customer_Quality_Id = Convert.ToInt32(dr["Customer_Quality_Id"]);
             customer_Quality.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
             customer_Quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
             customer_Quality.Customer_Roll_Length = Convert.ToString(dr["Customer_Roll_Length"]);
             customer_Quality.Storage = Convert.ToString(dr["Storage"]);
             customer_Quality.Transport = Convert.ToString(dr["Transport"]);
             customer_Quality.Lot_Testing = Convert.ToString(dr["Lot_Testing"]);
             customer_Quality.End_Product_Criteria = Convert.ToString(dr["End_Product_Criteria"]);
             customer_Quality.Testing_Requirements = Convert.ToString(dr["Testing_Requirements"]);
             customer_Quality.Inspection_Requirements = Convert.ToString(dr["Inspection_Requirements"]);
             customer_Quality.Process_Control = Convert.ToString(dr["Process_Control"]);
             customer_Quality.Sample_Id = Convert.ToInt32(dr["Sample_Id"]);
             customer_Quality.Special_Care_Details = Convert.ToString(dr["Special_Care_Details"]);
             customer_Quality.Special_Requirements_Material_Handling = Convert.ToString(dr["Special_Requirements_Material_Handling"]);
             customer_Quality.Special_Requirements_Packaging = Convert.ToString(dr["Special_Requirements_Packaging"]);
             customer_Quality.Special_Requirements_Defect_Defination = Convert.ToString(dr["Special_Requirements_Defect_Defination"]);
             customer_Quality.Special_Requirements_Verdicting = Convert.ToString(dr["Special_Requirements_Verdicting"]);
             customer_Quality.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
             customer_Quality.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
             customer_Quality.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
             customer_Quality.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
             customer_Quality.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
             customer_Quality.Customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
             customer_Quality.Quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
             //customer_Quality.Sample.Sample_No = Convert.ToInt32(dr["Sample_No"]);
             if (dr["Sample_No"] != DBNull.Value)
             {
                 customer_Quality.Sample.Sample_No = Convert.ToInt32(dr["Sample_No"]);
             }
             

             return customer_Quality;
         }

        //
         public void Insert_Customer_Quality_Functional_Parameter(CustomerQualityFunctionalParameterInfo customer_Quality_Functional_Parameter)
         {
             _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Quality_Functional_Parameter(customer_Quality_Functional_Parameter), StoredProcedures.Insert_Customer_Quality_Functional_Parameter_Sp.ToString(), CommandType.StoredProcedure);
         }

         private List<SqlParameter> Set_Values_In_Customer_Quality_Functional_Parameter(CustomerQualityFunctionalParameterInfo customer_Quality_Functional_Parameter)
         {
             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality_Functional_Parameter.Customer_Quality_Id));
             sqlParams.Add(new SqlParameter("@Test_Id", customer_Quality_Functional_Parameter.Test_Id));
             sqlParams.Add(new SqlParameter("@CreatedBy", customer_Quality_Functional_Parameter.CreatedBy));
             sqlParams.Add(new SqlParameter("@CreatedOn", customer_Quality_Functional_Parameter.CreatedOn));
             sqlParams.Add(new SqlParameter("@UpdatedBy", customer_Quality_Functional_Parameter.UpdatedBy));
             sqlParams.Add(new SqlParameter("@UpdatedOn", customer_Quality_Functional_Parameter.UpdatedOn));
             return sqlParams;
         }

         public List<CustomerQualityFunctionalParameterInfo> Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id(int customer_Quality_Id)
         {
             List<CustomerQualityFunctionalParameterInfo> customer_Quality_Functional_Parameters = new List<CustomerQualityFunctionalParameterInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Quality_Functional_Parameters_By_Customer_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

             List<DataRow> drList = new List<DataRow>();

             drList = dt.AsEnumerable().ToList();

             foreach (DataRow dr in drList)
             {
                 customer_Quality_Functional_Parameters.Add(Get_Customer_Quality_Functional_Parameters_Values(dr));
             }

             return customer_Quality_Functional_Parameters;
         }

         private CustomerQualityFunctionalParameterInfo Get_Customer_Quality_Functional_Parameters_Values(DataRow dr)
         {
             CustomerQualityFunctionalParameterInfo customer_Quality_Functional_Parameter = new CustomerQualityFunctionalParameterInfo();

             customer_Quality_Functional_Parameter.Customer_Quality_Functional_Parameter_Id = Convert.ToInt32(dr["Customer_Quality_Functional_Parameter_Id"]);
             customer_Quality_Functional_Parameter.Customer_Quality_Id = Convert.ToInt32(dr["Customer_Quality_Id"]);
             customer_Quality_Functional_Parameter.Test_Id = Convert.ToInt32(dr["Test_Id"]);
             customer_Quality_Functional_Parameter.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
             customer_Quality_Functional_Parameter.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
             customer_Quality_Functional_Parameter.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
             customer_Quality_Functional_Parameter.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
             customer_Quality_Functional_Parameter.Test_Name = Convert.ToString(dr["Test_Name"]);
             return customer_Quality_Functional_Parameter;
         }

         public void Delete_Customer_Quality_Functional_Parameter_By_Id(int customer_Quality_Functional_Parameters_Id)
         {
             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Functional_Parameter_Id", customer_Quality_Functional_Parameters_Id));

             _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Customer_Quality_Functional_Parameter_By_Id_Sp.ToString(), CommandType.StoredProcedure);
         }


         public void Insert_Customer_Quality_Visual_Parameter(CustomerQualityVisualParameterInfo customer_Quality_Visual_Parameter)
         {
             _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Quality_Visual_Parameter(customer_Quality_Visual_Parameter), StoredProcedures.Insert_Customer_Quality_Visual_Parameter_Sp.ToString(), CommandType.StoredProcedure);
         }

         private List<SqlParameter> Set_Values_In_Customer_Quality_Visual_Parameter(CustomerQualityVisualParameterInfo customer_Quality_Visual_Parameter)
         {
             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality_Visual_Parameter.Customer_Quality_Id));
             sqlParams.Add(new SqlParameter("@Defect_Id", customer_Quality_Visual_Parameter.Defect_Id));
             sqlParams.Add(new SqlParameter("@CreatedBy", customer_Quality_Visual_Parameter.CreatedBy));
             sqlParams.Add(new SqlParameter("@CreatedOn", customer_Quality_Visual_Parameter.CreatedOn));
             sqlParams.Add(new SqlParameter("@UpdatedBy", customer_Quality_Visual_Parameter.UpdatedBy));
             sqlParams.Add(new SqlParameter("@UpdatedOn", customer_Quality_Visual_Parameter.UpdatedOn));
             return sqlParams;
         }

         public List<CustomerQualityVisualParameterInfo> Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id(int customer_Quality_Id)
         {
             List<CustomerQualityVisualParameterInfo> customer_Quality_Visual_Parameters = new List<CustomerQualityVisualParameterInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Id", customer_Quality_Id));

             DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Quality_Visual_Parameters_By_Customer_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

             List<DataRow> drList = new List<DataRow>();

             drList = dt.AsEnumerable().ToList();

             foreach (DataRow dr in drList)
             {
                 customer_Quality_Visual_Parameters.Add(Get_Customer_Quality_Visual_Parameters_Values(dr));
             }

             return customer_Quality_Visual_Parameters;
         }

         private CustomerQualityVisualParameterInfo Get_Customer_Quality_Visual_Parameters_Values(DataRow dr)
         {
             CustomerQualityVisualParameterInfo customer_Quality_Visual_Parameter = new CustomerQualityVisualParameterInfo();

             customer_Quality_Visual_Parameter.Customer_Quality_Visual_Parameter_Id = Convert.ToInt32(dr["Customer_Quality_Visual_Parameter_Id"]);
             customer_Quality_Visual_Parameter.Customer_Quality_Id = Convert.ToInt32(dr["Customer_Quality_Id"]);
             customer_Quality_Visual_Parameter.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
             customer_Quality_Visual_Parameter.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
             customer_Quality_Visual_Parameter.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
             customer_Quality_Visual_Parameter.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
             customer_Quality_Visual_Parameter.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
             customer_Quality_Visual_Parameter.Defect_Name = Convert.ToString(dr["Defect_Name"]);
             return customer_Quality_Visual_Parameter;
         }

         public void Delete_Customer_Quality_Visual_Parameter_By_Id(int customer_Quality_Visual_Parameters_Id)
         {
             List<SqlParameter> sqlParams = new List<SqlParameter>();

             sqlParams.Add(new SqlParameter("@Customer_Quality_Visual_Parameter_Id", customer_Quality_Visual_Parameters_Id));

             _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Customer_Quality_Visual_Parameter_By_Id_Sp.ToString(), CommandType.StoredProcedure);
         }

    }
}
