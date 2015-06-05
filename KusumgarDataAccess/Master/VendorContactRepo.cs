using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class VendorContactRepo
    {

         SQLHelperRepo _sqlRepo;

         public VendorContactRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

         public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
         {
             List<AutocompleteInfo> vendors = new List<AutocompleteInfo>();

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

                     vendors.Add(auto);
                 }
             }

             return vendors;
         }


        public int Insert_Vendor_Contact(VendorContactInfo vendor_Contact)
        {
            int vendor_Id = 0;

            vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Vendor_Contact(vendor_Contact), StoredProcedures.Insert_Contact_sp.ToString(), CommandType.StoredProcedure));

            return vendor_Id;
        }

        public void Update_Vendor_Contact(VendorContactInfo vendorcontact)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Vendor_Contact(vendorcontact), StoredProcedures.Update_Contact_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Vendor_Contact(VendorContactInfo vendor_Contact)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (vendor_Contact.Contact_Entity.Contact_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Contact_Id", vendor_Contact.Contact_Entity.Contact_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Type", vendor_Contact.Contact_Entity.Contact_Type));
            sqlparam.Add(new SqlParameter("@Customer_Id", vendor_Contact.Contact_Entity.Customer_Id));
            sqlparam.Add(new SqlParameter("@Vendor_Id", vendor_Contact.Contact_Entity.Vendor_Id));
            sqlparam.Add(new SqlParameter("@Contact_Name", vendor_Contact.Contact_Entity.Contact_Name));
            sqlparam.Add(new SqlParameter("@Designation", vendor_Contact.Contact_Entity.Designation));
            sqlparam.Add(new SqlParameter("@Office_Address", vendor_Contact.Contact_Entity.Office_Address));
            sqlparam.Add(new SqlParameter("@Office_Landline1", vendor_Contact.Contact_Entity.Office_Landline1));
            sqlparam.Add(new SqlParameter("@Office_Landline2", vendor_Contact.Contact_Entity.Office_Landline2));
            sqlparam.Add(new SqlParameter("@Mobile1", vendor_Contact.Contact_Entity.Mobile1));
            sqlparam.Add(new SqlParameter("@Mobile2", vendor_Contact.Contact_Entity.Mobile2));
            sqlparam.Add(new SqlParameter("@Official_Email", vendor_Contact.Contact_Entity.Official_Email));
            sqlparam.Add(new SqlParameter("@Personal_Email", vendor_Contact.Contact_Entity.Personal_Email));
            sqlparam.Add(new SqlParameter("@Is_Billing_Contact", vendor_Contact.Contact_Entity.Is_Billing_Contact));
            sqlparam.Add(new SqlParameter("@DMU_Status_Role", vendor_Contact.Contact_Entity.DMU_Status_Role));
            sqlparam.Add(new SqlParameter("@DMU_Status_Influence", vendor_Contact.Contact_Entity.DMU_Status_Influence));
            sqlparam.Add(new SqlParameter("@Is_Active", vendor_Contact.Contact_Entity.Is_Active));

            if (vendor_Contact.Contact_Entity.Contact_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedOn", vendor_Contact.Contact_Entity.CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", vendor_Contact.Contact_Entity.CreatedBy));  
            }
            sqlparam.Add(new SqlParameter("@UpdatedOn", vendor_Contact.Contact_Entity.UpdatedOn));
            sqlparam.Add(new SqlParameter("@UpdatedBy", vendor_Contact.Contact_Entity.UpdatedBy));
           
            return sqlparam;
        }


        public void Insert_Vendor_Contact_Custom_Field(VendorContactCustomFieldsInfo vendor_Custom_Field)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Vendor_Contact_Custom_Field(vendor_Custom_Field), StoredProcedures.Insert_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Vendor_Contact_Custom_Field(VendorContactCustomFieldsInfo vendor_Custom_Field)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Vendor_Contact_Custom_Field(vendor_Custom_Field), StoredProcedures.Update_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Vendor_Contact_Custom_Field(VendorContactCustomFieldsInfo vendor_Custom_Field)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (vendor_Custom_Field.Contact_Custom_Field_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", vendor_Custom_Field.Contact_Custom_Field_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Id", vendor_Custom_Field.Contact_Id));
            sqlparam.Add(new SqlParameter("@Field_Name", vendor_Custom_Field.Field_Name));
            sqlparam.Add(new SqlParameter("@Field_Value", vendor_Custom_Field.Field_Value));
            sqlparam.Add(new SqlParameter("@Is_Active", vendor_Custom_Field.Is_Active));

            if (vendor_Custom_Field.Contact_Custom_Field_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedOn", vendor_Custom_Field.CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", vendor_Custom_Field.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedOn", vendor_Custom_Field.UpdatedOn));
            sqlparam.Add(new SqlParameter("@UpdatedBy", vendor_Custom_Field.UpdatedBy));

            return sqlparam;
        }


        public List<VendorContactInfo> Get_Vendor_Contacts(ref PaginationInfo pager)
        {
            List<VendorContactInfo> vendor_Contacts = new List<VendorContactInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Vendor_Contact_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    vendor_Contacts.Add(Get_Vendor_Contact_Values(dr));
                }
            }

            return vendor_Contacts;
        }

        private VendorContactInfo Get_Vendor_Contact_Values(DataRow dr)
        {
            VendorContactInfo vendor_Contact = new VendorContactInfo();

            vendor_Contact.Contact_Entity.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            vendor_Contact.Contact_Entity.Contact_Type = Convert.ToInt32(dr["Contact_Type"]);
            vendor_Contact.Contact_Entity.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            vendor_Contact.Contact_Entity.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            vendor_Contact.Contact_Entity.Contact_Name = Convert.ToString(dr["Contact_Name"]);
            vendor_Contact.Contact_Entity.Designation = Convert.ToString(dr["Designation"]);
            vendor_Contact.Contact_Entity.Office_Address = Convert.ToString(dr["Office_Address"]);
            vendor_Contact.Contact_Entity.Office_Landline1 = Convert.ToString(dr["Office_Landline1"]);
            vendor_Contact.Contact_Entity.Office_Landline2 = Convert.ToString(dr["Office_Landline2"]);
            vendor_Contact.Contact_Entity.Mobile1 = Convert.ToString(dr["Mobile1"]);
            vendor_Contact.Contact_Entity.Mobile2 = Convert.ToString(dr["Mobile2"]);
            vendor_Contact.Contact_Entity.Official_Email = Convert.ToString(dr["Official_Email"]);
            vendor_Contact.Contact_Entity.Personal_Email = Convert.ToString(dr["Personal_Email"]);
            vendor_Contact.Contact_Entity.Is_Billing_Contact = Convert.ToBoolean(dr["Is_Billing_Contact"]);
            vendor_Contact.Contact_Entity.DMU_Status_Role = Convert.ToInt32(dr["DMU_Status_Role"]);
            vendor_Contact.Contact_Entity.DMU_Status_Influence = Convert.ToInt32(dr["DMU_Status_Influence"]);
            vendor_Contact.Contact_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            vendor_Contact.Contact_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            vendor_Contact.Contact_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            vendor_Contact.Contact_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            vendor_Contact.Contact_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            vendor_Contact.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

            return vendor_Contact;
        }

        public List<VendorContactInfo> Get_Vendor_Contacts_By_Vendor_Name(int vendor_Id,  ref PaginationInfo pager)
        {
            List<VendorContactInfo> vendor_Contacts = new List<VendorContactInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_Contacts_By_Vendor_Name_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                vendor_Contacts.Add(Get_Vendor_Contact_Values(dr));
            }

            return vendor_Contacts;
        }

        public VendorContactInfo Get_Vendor_Contact_By_Id(int contact_Id)
        {
            VendorContactInfo vendor_Contact = new VendorContactInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Contact_Id", contact_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Vendor_Contact_By_Id_sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            DataTable dt1 = ds.Tables[1];

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    vendor_Contact = Get_Vendor_Contact_Values(dr);
                }
            }

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt1.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    vendor_Contact.Vendor_Custom_Fields.Add(Get_Vendor_Contact_Custom_Field_values(dr));
                }
            }

            return vendor_Contact;
        }

        private VendorContactCustomFieldsInfo Get_Vendor_Contact_Custom_Field_values(DataRow dr)
        {
            VendorContactCustomFieldsInfo vendor_Custom_Field = new VendorContactCustomFieldsInfo();

            vendor_Custom_Field.Contact_Custom_Field_Id = Convert.ToInt32(dr["Contact_Custom_Field_Id"]);
            vendor_Custom_Field.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            vendor_Custom_Field.Field_Name = Convert.ToString(dr["Field_Name"]);
            vendor_Custom_Field.Field_Value = Convert.ToString(dr["Field_Value"]);
            vendor_Custom_Field.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            vendor_Custom_Field.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            vendor_Custom_Field.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            vendor_Custom_Field.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            vendor_Custom_Field.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            return vendor_Custom_Field;
        }


        public void Delete_Vendor_Contact_Custom_Field(int contact_Custom_Field_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", contact_Custom_Field_Id));

            _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Vendor_Contact_Custom_Field_By_Id.ToString(), CommandType.StoredProcedure);
        }

    }
}
