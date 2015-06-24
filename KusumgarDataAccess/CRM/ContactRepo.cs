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
    public class ContactRepo
    {
         SQLHelperRepo _sqlRepo;

         public ContactRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

         public List<ContactInfo> Get_Contacts(ref PaginationInfo pager)
         {
             List<ContactInfo> contacts = new List<ContactInfo>();

             DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Contact_sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 contacts.Add(Get_Contact_Values(dr));
             }

             return contacts;
         }

         public List<ContactInfo> Get_Contacts_By_Name(int customer_Id, ref PaginationInfo pager)
        {
            List<ContactInfo> Contacts = new List<ContactInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Id", customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Contact_By_Customer_Name_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                Contacts.Add(Get_Contact_Values(dr));
            }

            return Contacts;
        }
        
         private ContactInfo Get_Contact_Values(DataRow dr)
        {
            ContactInfo contact = new ContactInfo();

            contact.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            contact.Contact_Type = Convert.ToInt32(dr["Contact_Type"]);
            contact.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            contact.Customer_Contact_Type_Id = Convert.ToInt32(dr["Customer_Contact_Type_Id"]);
            contact.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            contact.Contact_Name = Convert.ToString(dr["Contact_Name"]);
            contact.Designation = Convert.ToString(dr["Designation"]);
            contact.Office_Address = Convert.ToString(dr["Office_Address"]);
            contact.Office_Landline1 = Convert.ToString(dr["Office_Landline1"]);
            contact.Office_Landline2 = Convert.ToString(dr["Office_Landline2"]);
            contact.Mobile1 = Convert.ToString(dr["Mobile1"]);
            contact.Mobile2 = Convert.ToString(dr["Mobile2"]);
            contact.Official_Email = Convert.ToString(dr["Official_Email"]);
            contact.Personal_Email = Convert.ToString(dr["Personal_Email"]);
            contact.Is_Billing_Contact = Convert.ToBoolean(dr["Is_Billing_Contact"]);
            contact.DMU_Status_Role = Convert.ToInt32(dr["DMU_Status_Role"]);
            contact.DMU_Status_Influence = Convert.ToInt32(dr["DMU_Status_Influence"]);
            contact.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            contact.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            contact.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            contact.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            contact.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            contact.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            contact.Customer_Contact_Type = Convert.ToString(dr["Customer_Contact_Type"]);
            foreach (var item in LookupInfo.Get_DMU_Status_Role())
            {
                if (contact.DMU_Status_Role == item.Key)
                {
                    contact.DMU_Status_Role_Str = item.Value;
                }
            }
            return contact;
        }
       
        public ContactInfo Get_Contact_By_Id(int Contact_Id)
        {
            ContactInfo contact = new ContactInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Contact_Id", Contact_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Contact_by_Id_sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            DataTable dt1 = ds.Tables[1];

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    contact = Get_Contact_Values(dr);
                }
            }

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt1.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    contact.Contact_Custom_Fields_List.Add(Get_Contact_Custom_Fields_values(dr));
                }
            }

            return contact;
        }

        private ContactCustomFieldsInfo Get_Contact_Custom_Fields_values(DataRow dr)
        {
            ContactCustomFieldsInfo customfields = new ContactCustomFieldsInfo();

            customfields.Contact_Custom_Field_Id = Convert.ToInt32(dr["Contact_Custom_Field_Id"]);
            customfields.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            customfields.Field_Name = Convert.ToString(dr["Field_Name"]);
            customfields.Field_Value = Convert.ToString(dr["Field_Value"]);
            customfields.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            customfields.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            customfields.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            customfields.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            customfields.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);   

            return customfields;
        }

        public int Insert_Contact(ContactInfo contact)
        {
           int Contact_Id = 0;

           Contact_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Contact(contact), StoredProcedures.Insert_Contact_sp.ToString(), CommandType.StoredProcedure));

           return Contact_Id;
        }

        public void Update_Contact(ContactInfo contact)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Contact(contact), StoredProcedures.Update_Contact_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Contact(ContactInfo contact)
        {
             List<SqlParameter> sqlparam = new List<SqlParameter>();

            if(contact.Contact_Id != 0)
            {
            sqlparam.Add(new SqlParameter("@Contact_Id",contact.Contact_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Type",contact.Contact_Type));
            sqlparam.Add(new SqlParameter("@Customer_Id",contact.Customer_Id));
            sqlparam.Add(new SqlParameter("@Customer_Contact_Type_Id", contact.Customer_Contact_Type_Id));
            sqlparam.Add(new SqlParameter("@Vendor_Id", contact.Vendor_Id));
            sqlparam.Add(new SqlParameter("@Contact_Name",contact.Contact_Name ));
            sqlparam.Add(new SqlParameter("@Designation",contact.Designation ));
            sqlparam.Add(new SqlParameter("@Office_Address",contact.Office_Address ));
            sqlparam.Add(new SqlParameter("@Office_Landline1",contact.Office_Landline1));
            sqlparam.Add(new SqlParameter("@Office_Landline2",contact.Office_Landline2 ));
            sqlparam.Add(new SqlParameter("@Mobile1",contact.Mobile1)); 
            sqlparam.Add(new SqlParameter("@Mobile2",contact.Mobile2));    
            sqlparam.Add(new SqlParameter("@Official_Email",contact.Official_Email )); 
            sqlparam.Add(new SqlParameter("@Personal_Email",contact.Personal_Email ));    
            sqlparam.Add(new SqlParameter("@Is_Billing_Contact",contact.Is_Billing_Contact));
            sqlparam.Add(new SqlParameter("@DMU_Status_Role", contact.DMU_Status_Role));
            sqlparam.Add(new SqlParameter("@DMU_Status_Influence", contact.DMU_Status_Influence));
            sqlparam.Add(new SqlParameter("@Is_Active",contact.Is_Active ));   
            if(contact.Contact_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy",contact.CreatedBy ));
                sqlparam.Add(new SqlParameter("@CreatedOn", contact.CreatedOn));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy",contact.UpdatedBy ));
            sqlparam.Add(new SqlParameter("@UpdatedOn", contact.UpdatedOn));

            return sqlparam;
        }

        public void Insert_Contact_Custom_Fields(ContactCustomFieldsInfo custom_Fields)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Contact_Custom_Fields(custom_Fields), StoredProcedures.Insert_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Contact_Custom_Fields(ContactCustomFieldsInfo custom_Fields)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Contact_Custom_Fields(custom_Fields), StoredProcedures.Update_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Contact_Custom_Fields(ContactCustomFieldsInfo custom_Fields)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (custom_Fields.Contact_Custom_Field_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", custom_Fields.Contact_Custom_Field_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Id", custom_Fields.Contact_Id));
            sqlparam.Add(new SqlParameter("@Field_Name", custom_Fields.Field_Name));
            sqlparam.Add(new SqlParameter("@Field_Value", custom_Fields.Field_Value));
            sqlparam.Add(new SqlParameter("@Is_Active", custom_Fields.Is_Active));
            if (custom_Fields.Contact_Custom_Field_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", custom_Fields.CreatedBy));
                sqlparam.Add(new SqlParameter("@CreatedOn", custom_Fields.CreatedOn));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", custom_Fields.UpdatedBy));
            sqlparam.Add(new SqlParameter("@UpdatedOn", custom_Fields.UpdatedOn));

            return sqlparam;
        }

        public void Delete_Contact_Custom_Fields(int contact_Custom_Field_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", contact_Custom_Field_Id));

            _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Contact_Custom_Fields_By_Id.ToString(), CommandType.StoredProcedure);
        }
    }
}
