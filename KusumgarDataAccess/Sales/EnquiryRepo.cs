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
    public class EnquiryRepo
    {

        SQLHelperRepo _sqlRepo;

        public EnquiryRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        #region Enquiry

        public void Insert_Enquiry(ref EnquiryInfo enquiry)
        {
            DataTable dt = _sqlRepo.ExecuteDataTable(Set_Values_In_Enquiry(enquiry), StoredProcedures.Insert_Enquiry_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                enquiry.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);

                enquiry.Enquiry_No = Convert.ToString(dr["Enquiry_No"]);
            }
        }

        public void Update_Enquiry(EnquiryInfo enquiry)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Enquiry(enquiry), StoredProcedures.Update_Enquiry_Sp.ToString(), CommandType.StoredProcedure);
        }

        public List<EnquiryInfo> Get_Enquiries(ref PaginationInfo pager)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Enquiries_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }
            return enquiries;
        }

        public List<EnquiryInfo> Get_Enquiries_By_Status(ref PaginationInfo pager, int enquiry_Status_Id)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Status_Id", enquiry_Status_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_By_Status_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }
            return enquiries;
        }

        public EnquiryInfo Get_Enquiry_By_Id(int enquiry_Id)
        {
            EnquiryInfo enquiry = new EnquiryInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiry_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                enquiry = Get_Enquiry_Values(dr);
            }
            return enquiry;
        }

        private List<SqlParameter> Set_Values_In_Enquiry(EnquiryInfo enquiry)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (enquiry.Enquiry_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry.Enquiry_Id));
            }
            sqlParams.Add(new SqlParameter("@Enquiry_No", enquiry.Enquiry_No));
            sqlParams.Add(new SqlParameter("@Enquiry_Type_Id", enquiry.Enquiry_Type_Id));
            sqlParams.Add(new SqlParameter("@Enquiry_Status_Id", enquiry.Enquiry_Status_Id));
            sqlParams.Add(new SqlParameter("@Customer_Id", enquiry.Customer_Id));
            sqlParams.Add(new SqlParameter("@Quality_Id", enquiry.Quality_Id));
            sqlParams.Add(new SqlParameter("@PPC_Article_Type_Id", enquiry.PPC_Article_Type_Id));
            sqlParams.Add(new SqlParameter("@Quality_Set_Id", enquiry.Quality_Set_Id));
            sqlParams.Add(new SqlParameter("@Is_Active", enquiry.Is_Active));
            if (enquiry.Enquiry_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", enquiry.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", enquiry.CreatedOn));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", enquiry.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", enquiry.UpdatedOn));
            return sqlParams;
        }

        private EnquiryInfo Get_Enquiry_Values(DataRow dr)
        {
            EnquiryInfo enquiry = new EnquiryInfo();

            enquiry.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            enquiry.Enquiry_No = Convert.ToString(dr["Enquiry_No"]);
            enquiry.Enquiry_Type_Id = Convert.ToInt32(dr["Enquiry_Type_Id"]);
            enquiry.Enquiry_Status_Id = Convert.ToInt32(dr["Enquiry_Status_Id"]);
            enquiry.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            enquiry.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
            enquiry.PPC_Article_Type_Id = Convert.ToInt32(dr["PPC_Article_Type_Id"]);
            enquiry.Quality_Set_Id = Convert.ToInt32(dr["Quality_Set_Id"]);
            enquiry.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            enquiry.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            enquiry.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            enquiry.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            enquiry.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            enquiry.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            enquiry.Quality_No = Convert.ToString(dr["Quality_No"]);
            return enquiry;
        }

        public List<EnquiryInfo> Get_Enquiries_By_Customer_Id(int customer_Id, ref PaginationInfo pager)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_By_Customer_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }
            return enquiries;
        }

        public List<EnquiryInfo> Get_Enquiries_By_Customer_Id_Quality_Id(int customer_Id,int quality_Id, ref PaginationInfo pager)
        {
             List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

             List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_By_Customer_Id_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }

            return enquiries;
        }

        public List<EnquiryInfo> Get_Enquiries_By_Quality_Id(int quality_Id, ref PaginationInfo pager)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_By_Quality_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }

            return enquiries;
        }

        //public void Update_Enquiry_Quality_Id_Status(EnquiryInfo enquiry)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    sqlParams.Add(new SqlParameter("@Enquiry_Status_Id", enquiry.Enquiry_Status_Id));

        //}

        public List<EnquiryInfo> Get_Enquiries_By_Status_Ids(string enquiry_Status_Ids, ref PaginationInfo pager)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Status_Ids", enquiry_Status_Ids));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_By_Status_Ids_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }
            return enquiries;
        }
        


        #endregion

        #region Staggered Order

        public void Insert_Staggered_Order(StaggeredOrderInfo staggeredorder)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Staggered_Order(staggeredorder), StoredProcedures.Insert_Staggered_Order_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Staggered_Order(StaggeredOrderInfo staggeredorder)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Staggered_Order(staggeredorder), StoredProcedures.Update_Staggered_Order_Sp.ToString(), CommandType.StoredProcedure);
        }

        public List<StaggeredOrderInfo> Get_Staggered_Orders(ref PaginationInfo pager)
        {
            List<StaggeredOrderInfo> staggered_Orders = new List<StaggeredOrderInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Staggered_Order_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                staggered_Orders.Add(Get_Staggered_Order_Values(dr));
            }

            return staggered_Orders;
        }

        public List<StaggeredOrderInfo> Get_Staggered_Orders_By_Enquiry_Id(int enquiry_Id,ref PaginationInfo pager)
        {
            List<StaggeredOrderInfo> staggered_Orders = new List<StaggeredOrderInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Staggered_Order_By_Enquiry_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                staggered_Orders.Add(Get_Staggered_Order_Values(dr));
            }

            return staggered_Orders;
        }

        public StaggeredOrderInfo Get_Staggered_Order_By_Id(int staggered_Order_Id)
        {
            StaggeredOrderInfo staggered_Order = new StaggeredOrderInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Staggered_Order_Id", staggered_Order_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Staggered_Order_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                staggered_Order = Get_Staggered_Order_Values(dr);
            }
            return staggered_Order;
        }

        private List<SqlParameter> Set_Values_In_Staggered_Order(StaggeredOrderInfo staggered_Order)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (staggered_Order.Staggered_Order_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Staggered_Order_Id", staggered_Order.Staggered_Order_Id));
            }
            sqlParams.Add(new SqlParameter("@Enquiry_Id", staggered_Order.Enquiry_Id));
            sqlParams.Add(new SqlParameter("@Order_No", staggered_Order.Order_No));
            sqlParams.Add(new SqlParameter("@Order_Status", staggered_Order.Order_Status));
            sqlParams.Add(new SqlParameter("@Quantity", staggered_Order.Quantity));
            sqlParams.Add(new SqlParameter("@Delivery_Date", staggered_Order.Delivery_Date));
            sqlParams.Add(new SqlParameter("@Is_Active", staggered_Order.Is_Active));
            if (staggered_Order.Staggered_Order_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", staggered_Order.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", staggered_Order.CreatedOn));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", staggered_Order.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", staggered_Order.UpdatedOn));
            return sqlParams;
        }

        private StaggeredOrderInfo Get_Staggered_Order_Values(DataRow dr)
        {
            StaggeredOrderInfo staggered_Order = new StaggeredOrderInfo();

            staggered_Order.Staggered_Order_Id = Convert.ToInt32(dr["Staggered_Order_Id"]);
            staggered_Order.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            staggered_Order.Order_No = Convert.ToString(dr["Order_No"]);
            staggered_Order.Order_Status = Convert.ToInt32(dr["Order_Status"]);
            staggered_Order.Quantity = Convert.ToInt32(dr["Quantity"]);
            staggered_Order.Delivery_Date = Convert.ToDateTime(dr["Delivery_Date"]);
            staggered_Order.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            staggered_Order.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            staggered_Order.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            staggered_Order.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            staggered_Order.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            return staggered_Order;
        }

        public void Delete_Staggered_Order_By_Id(int staggered_Order_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Staggered_Order_Id", staggered_Order_Id));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Staggered_Order_By_Id.ToString(), CommandType.StoredProcedure);
        }

        #endregion

        #region Supporting Details

        public void Insert_Supporting_Details(SupportingDetailsInfo supporting_Details)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Supporting_Details(supporting_Details), StoredProcedures.Insert_Supporting_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Supporting_Details(SupportingDetailsInfo supporting_Details)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Supporting_Details(supporting_Details), StoredProcedures.Update_Supporting_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        public SupportingDetailsInfo Get_Supporting_Details_By_Enquiry_Id(int enquiry_Id)
        {
            SupportingDetailsInfo supporting_Details = new SupportingDetailsInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Supporting_Details_By_Enquiry_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                supporting_Details = Get_Supporting_Details_Values(dr);
            }
            return supporting_Details;
        }

        private List<SqlParameter> Set_Values_In_Supporting_Details(SupportingDetailsInfo supporting_Details)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (supporting_Details.Supporting_Details_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Supporting_Details_Id", supporting_Details.Supporting_Details_Id));
            }
            sqlParams.Add(new SqlParameter("@Enquiry_Id", supporting_Details.Enquiry_Id));
            sqlParams.Add(new SqlParameter("@Rate", supporting_Details.Rate));
            sqlParams.Add(new SqlParameter("@Customer_Roll_Length", supporting_Details.Customer_Roll_Length));
            sqlParams.Add(new SqlParameter("@Packing", supporting_Details.Packing));
            sqlParams.Add(new SqlParameter("@Dispatch", supporting_Details.Dispatch));
            sqlParams.Add(new SqlParameter("@Additional_Customer_Prop", supporting_Details.Additional_Customer_Prop));
            sqlParams.Add(new SqlParameter("@Source_Of_Enquiry", supporting_Details.Source_Of_Enquiry));
            sqlParams.Add(new SqlParameter("@Is_Active", supporting_Details.Is_Active));
            if (supporting_Details.Supporting_Details_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", supporting_Details.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", supporting_Details.CreatedOn));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", supporting_Details.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", supporting_Details.UpdatedOn));
            sqlParams.Add(new SqlParameter("@Piece_Length_Max", supporting_Details.Piece_Length_Max));
            sqlParams.Add(new SqlParameter("@Piece_Length_Min", supporting_Details.Piece_Length_Min));
            sqlParams.Add(new SqlParameter("@Two_Part", supporting_Details.Two_Part));

            return sqlParams;
        }

        private SupportingDetailsInfo Get_Supporting_Details_Values(DataRow dr)
        {
            SupportingDetailsInfo supportingdetails = new SupportingDetailsInfo();

            supportingdetails.Supporting_Details_Id = Convert.ToInt32(dr["Supporting_Details_Id"]);
            supportingdetails.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            supportingdetails.Rate = Convert.ToInt32(dr["Rate"]);
            supportingdetails.Customer_Roll_Length = Convert.ToInt32(dr["Customer_Roll_Length"]);
            supportingdetails.Packing = Convert.ToInt32(dr["Packing"]);
            supportingdetails.Dispatch = Convert.ToInt32(dr["Dispatch"]);
            supportingdetails.Additional_Customer_Prop = Convert.ToString(dr["Additional_Customer_Prop"]);
            supportingdetails.Source_Of_Enquiry = Convert.ToString(dr["Source_Of_Enquiry"]);
            supportingdetails.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            supportingdetails.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            supportingdetails.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            supportingdetails.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            supportingdetails.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            if (DBNull.Value != dr["Piece_Length_Max"])
            {
                supportingdetails.Piece_Length_Max = Convert.ToDecimal(dr["Piece_Length_Max"]);
            }

            if (DBNull.Value != dr["Piece_Length_Min"])
            {
                supportingdetails.Piece_Length_Min = Convert.ToDecimal(dr["Piece_Length_Min"]);
            }

            if (DBNull.Value != dr["Two_Part"])
            {
                supportingdetails.Two_Part = Convert.ToDecimal(dr["Two_Part"]);
            }
            return supportingdetails;
        }

        #endregion

        #region Temp Customer Quality Details

        public void Insert_Temp_Customer_Quality_Details(TempCustomerQualityDetailsInfo temp_Customer_Quality_Details)
        {
            string mode = "insert";

            _sqlRepo.ExecuteNonQuery(Set_Values_In_Temp_Customer_Quality_Details(temp_Customer_Quality_Details,mode), StoredProcedures.Insert_Temp_Customer_Quality_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Temp_Customer_Quality_Details(TempCustomerQualityDetailsInfo temp_Customer_Quality_Details)
        {
            string mode = "update";

            _sqlRepo.ExecuteNonQuery(Set_Values_In_Temp_Customer_Quality_Details(temp_Customer_Quality_Details, mode), StoredProcedures.Update_Supporting_Details_Sp.ToString(), CommandType.StoredProcedure);
        }

        public TempCustomerQualityDetailsInfo Get_Temp_Customer_Quality_Details_By_Id(int enquiry_Id)
        {
            TempCustomerQualityDetailsInfo temp_Customer_Quality_Details = new TempCustomerQualityDetailsInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Temp_Customer_Quality_Details_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                temp_Customer_Quality_Details = Get_Temp_Customer_Quality_Details_Values(dr);
            }
            return temp_Customer_Quality_Details;
        }

        private List<SqlParameter> Set_Values_In_Temp_Customer_Quality_Details(TempCustomerQualityDetailsInfo tempcustomerqualitydetails,string mode)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Enquiry_Id", tempcustomerqualitydetails.Enquiry_Id));
            sqlParams.Add(new SqlParameter("@Width_Of_Fabric", tempcustomerqualitydetails.Width_Of_Fabric));
            sqlParams.Add(new SqlParameter("@Coating", tempcustomerqualitydetails.Coating));
            sqlParams.Add(new SqlParameter("@Applications", tempcustomerqualitydetails.Applications));
            sqlParams.Add(new SqlParameter("@Physical_Appearance", tempcustomerqualitydetails.Physical_Appearance));
            sqlParams.Add(new SqlParameter("@Shades", tempcustomerqualitydetails.Shades));
            sqlParams.Add(new SqlParameter("@Finish", tempcustomerqualitydetails.Finish));
            sqlParams.Add(new SqlParameter("@Prints", tempcustomerqualitydetails.Prints));
            sqlParams.Add(new SqlParameter("@Customer_Approved_Sample", tempcustomerqualitydetails.Customer_Approved_Sample));
            sqlParams.Add(new SqlParameter("@Market_Segment", tempcustomerqualitydetails.Market_Segment));
            sqlParams.Add(new SqlParameter("@Lable_Tagging", tempcustomerqualitydetails.Lable_Tagging));
            sqlParams.Add(new SqlParameter("@CreatedBy", tempcustomerqualitydetails.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedOn", tempcustomerqualitydetails.CreatedOn));
            sqlParams.Add(new SqlParameter("@Wrap_Count", tempcustomerqualitydetails.Wrap_Count));
            sqlParams.Add(new SqlParameter("@Weft_Count", tempcustomerqualitydetails.Weft_Count));
            sqlParams.Add(new SqlParameter("@Ends_Per_Inch", tempcustomerqualitydetails.Ends_Per_Inch));
            sqlParams.Add(new SqlParameter("@Pick_Per_Inch", tempcustomerqualitydetails.Pick_Per_Inch));
            if (mode != "update")
            {
                sqlParams.Add(new SqlParameter("@UpdatedBy", tempcustomerqualitydetails.UpdatedBy));
                sqlParams.Add(new SqlParameter("@UpdatedOn", tempcustomerqualitydetails.UpdatedOn));
            }
            return sqlParams;
        }

        private TempCustomerQualityDetailsInfo Get_Temp_Customer_Quality_Details_Values(DataRow dr)
        {
            TempCustomerQualityDetailsInfo tempcustomerqualitydetails = new TempCustomerQualityDetailsInfo();

            tempcustomerqualitydetails.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            tempcustomerqualitydetails.Width_Of_Fabric = Convert.ToString(dr["Width_Of_Fabric"]);
            tempcustomerqualitydetails.Coating = Convert.ToString(dr["Coating"]);
            tempcustomerqualitydetails.Applications = Convert.ToString(dr["Applications"]);
            tempcustomerqualitydetails.Physical_Appearance = Convert.ToString(dr["Physical_Appearance"]);
            tempcustomerqualitydetails.Shades = Convert.ToInt32(dr["Shades"]);
            tempcustomerqualitydetails.Finish = Convert.ToString(dr["Finish"]);
            tempcustomerqualitydetails.Prints = Convert.ToString(dr["Prints"]);
            tempcustomerqualitydetails.Customer_Approved_Sample = Convert.ToInt32(dr["Customer_Approved_Sample"]);
            tempcustomerqualitydetails.Market_Segment = Convert.ToString(dr["Market_Segment"]);
            tempcustomerqualitydetails.Lable_Tagging = Convert.ToString(dr["Lable_Tagging"]);
            tempcustomerqualitydetails.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            tempcustomerqualitydetails.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            tempcustomerqualitydetails.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            tempcustomerqualitydetails.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            if (DBNull.Value != dr["Wrap_Count"])
            {
                tempcustomerqualitydetails.Wrap_Count = Convert.ToDecimal(dr["Wrap_Count"]);
            }

            if (DBNull.Value != dr["Weft_Count"])
            {
                tempcustomerqualitydetails.Weft_Count = Convert.ToDecimal(dr["Weft_Count"]);
            }

            if (DBNull.Value != dr["Ends_Per_Inch"])
            {
                tempcustomerqualitydetails.Ends_Per_Inch = Convert.ToDecimal(dr["Ends_Per_Inch"]);
            }

            if (DBNull.Value != dr["Pick_Per_Inch"])
            {
                tempcustomerqualitydetails.Pick_Per_Inch = Convert.ToDecimal(dr["Pick_Per_Inch"]);
            }

            tempcustomerqualitydetails.Sample_No = Convert.ToString(dr["Sample_No"]);
            tempcustomerqualitydetails.Shade_Name = Convert.ToString(dr["Shade_Name"]);

            return tempcustomerqualitydetails;
        }

        #endregion

        #region Temp Functional Visual Parameters

        public void Insert_Temp_Functional_Parameters(TempFunctionalParametersInfo temp_Functional_Parameters)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Temp_Functional_Parameters(temp_Functional_Parameters), StoredProcedures.Insert_Temp_Functional_Parameters_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Insert_Temp_Visual_Parameters(TempVisualParametersInfo temp_Visual_Parameters)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Temp_Visual_Parameters(temp_Visual_Parameters), StoredProcedures.Insert_Temp_Visual_Parameters_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Delete_Temp_Functional_Parameters_By_Id(int temp_Functional_Parameters_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Temp_Functional_Parameters_Id", temp_Functional_Parameters_Id));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Temp_Functional_Parameters_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public void Delete_Temp_Visual_Parameters_By_Id(int temp_Visual_Parameters_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Temp_Visual_Parameters_Id", temp_Visual_Parameters_Id));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Temp_Visual_Parameters_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public List<TempFunctionalParametersInfo> Get_Temp_Functional_Parameters_By_Enquiry_Id(int enquiry_Id)
        {
            List<TempFunctionalParametersInfo> temp_Functional_Parameters = new List<TempFunctionalParametersInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Temp_Functional_Parameters_By_Enquiry_Id.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                temp_Functional_Parameters.Add(Get_Temp_Functional_Parameters_Values(dr));
            }

            return temp_Functional_Parameters;
        }

        public List<TempVisualParametersInfo> Get_Temp_Visual_Parameters_By_Enquiry_Id(int enquiry_Id)
        {
            List<TempVisualParametersInfo> temp_Visual_Parameters = new List<TempVisualParametersInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Temp_Visual_Parameters_By_Enquiry_Id.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                temp_Visual_Parameters.Add(Get_Temp_Visual_Parameters_Values(dr));
            }


            return temp_Visual_Parameters;
        }

        private List<SqlParameter> Set_Values_In_Temp_Functional_Parameters(TempFunctionalParametersInfo temp_Functional_Parameters)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", temp_Functional_Parameters.Enquiry_Id));
            sqlParams.Add(new SqlParameter("@Test_Id", temp_Functional_Parameters.Test_Id));
            sqlParams.Add(new SqlParameter("@CreatedBy", temp_Functional_Parameters.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedOn", temp_Functional_Parameters.CreatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", temp_Functional_Parameters.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", temp_Functional_Parameters.UpdatedOn));
            return sqlParams;
        }

        private TempFunctionalParametersInfo Get_Temp_Functional_Parameters_Values(DataRow dr)
        {
            TempFunctionalParametersInfo temp_Functional_Parameters = new TempFunctionalParametersInfo();

            temp_Functional_Parameters.Temp_Functional_Parameters_Id = Convert.ToInt32(dr["Temp_Functional_Parameters_Id"]);
            temp_Functional_Parameters.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            temp_Functional_Parameters.Test_Id = Convert.ToInt32(dr["Test_Id"]);
            temp_Functional_Parameters.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            temp_Functional_Parameters.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            temp_Functional_Parameters.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            temp_Functional_Parameters.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            temp_Functional_Parameters.Test_Name = Convert.ToString(dr["Test_Name"]);
            return temp_Functional_Parameters;
        }

        private TempVisualParametersInfo Get_Temp_Visual_Parameters_Values(DataRow dr)
        {
            TempVisualParametersInfo temp_Visual_Parameters = new TempVisualParametersInfo();

            temp_Visual_Parameters.Temp_Visual_Parameters_Id = Convert.ToInt32(dr["Temp_Visual_Parameters_Id"]);
            temp_Visual_Parameters.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);
            temp_Visual_Parameters.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
            temp_Visual_Parameters.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            temp_Visual_Parameters.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            temp_Visual_Parameters.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            temp_Visual_Parameters.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            temp_Visual_Parameters.Defect_Name = Convert.ToString(dr["Defect_Name"]);
            return temp_Visual_Parameters;
        }

        private List<SqlParameter> Set_Values_In_Temp_Visual_Parameters(TempVisualParametersInfo temp_Visual_Parameters)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            
            sqlParams.Add(new SqlParameter("@Enquiry_Id", temp_Visual_Parameters.Enquiry_Id));
            sqlParams.Add(new SqlParameter("@Defect_Id", temp_Visual_Parameters.Defect_Id));
            sqlParams.Add(new SqlParameter("@CreatedBy", temp_Visual_Parameters.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedOn", temp_Visual_Parameters.CreatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", temp_Visual_Parameters.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", temp_Visual_Parameters.UpdatedOn));
            return sqlParams;
        }
 

        #endregion


        #region Quality Details

        public List<AutocompleteInfo> Get_Quality_Autocomplete(string quality_No)
        {
            List<AutocompleteInfo> qualities = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Quality_No", quality_No));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_Autocomplete.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Quality_No"]);

                    auto.Value = Convert.ToInt32(dr["Quality_Id"]);

                    qualities.Add(auto);
                }
            }

            return qualities;
        }

        private QualityInfo Get_Quality_Values(DataRow dr)
        {
            QualityInfo quality = new QualityInfo();

            quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);
            quality.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
            quality.Reed = Convert.ToString(dr["Reed"]);
            quality.Pick = Convert.ToString(dr["Pick"]);
            if (DBNull.Value != dr["Weave"])
            {
                quality.Weave = Convert.ToInt32(dr["Weave"]);
            }
            if (DBNull.Value != dr["Minimum_Order_Size"])
            {
                quality.Minimum_Order_Size = Convert.ToInt32(dr["Minimum_Order_Size"]);
            }
            if (DBNull.Value != dr["Ideal_Roll_Length"])
            {
                quality.Ideal_Roll_Length = Convert.ToInt32(dr["Ideal_Roll_Length"]);
            }
            if (DBNull.Value != dr["Our_Sample_No"])
            {
                quality.Our_Sample_No = Convert.ToInt32(dr["Our_Sample_No"]);
            }
            if (DBNull.Value != dr["Quality_No"])
            {
                quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
            }
            quality.Status = Convert.ToBoolean(dr["Status"]);
            quality.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            quality.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            quality.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            quality.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            quality.Weave_Name = Convert.ToString(dr["Weave_Name"]);
            quality.Yarn_Type_Name = Convert.ToString(dr["Yarn_Type_Name"]);

            return quality;
        } 

        public QualityInfo Get_Quality_By_Id(int quality_Id)
        {
            QualityInfo quality = new QualityInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_Details_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                quality = Get_Quality_Values(dr);
            }
            return quality;
        }

        #endregion

        #region PPC Checklist 

        public List<EnquiryInfo> Get_Enquiries_For_PPC_Checkpoint(string enquiry_Status_Ids, ref PaginationInfo pager)
        {
            List<EnquiryInfo> enquiries = new List<EnquiryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Status_Ids", enquiry_Status_Ids));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Enquiries_For_PPC_Checkpoint_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                enquiries.Add(Get_Enquiry_Values(dr));
            }
            return enquiries;
        }

        public void Update_Enquiry_PPC_Checkpoint(EnquiryInfo enquiry)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Enquiry_Id", enquiry.Enquiry_Id));

            sqlParams.Add(new SqlParameter("@PPC_Article_Type_Id", enquiry.PPC_Article_Type_Id));

            sqlParams.Add(new SqlParameter("@Enquiry_Status_Id", enquiry.Enquiry_Status_Id));

            sqlParams.Add(new SqlParameter("@Quality_Id", enquiry.Quality_Id));

            sqlParams.Add(new SqlParameter("@UpdatedBy", enquiry.UpdatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedOn", enquiry.UpdatedOn));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Update_Enquiry_PPC_Checkpoint_Sp.ToString(), CommandType.StoredProcedure);
        }
        

        #endregion

    }
}
