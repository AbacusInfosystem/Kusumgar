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
         SQLHelperRepo sqlRepo;

         public ContactRepo()
        {
            sqlRepo = new SQLHelperRepo();
        }
        
        public  List<ContactInfo> Get_Contact_List(ref PaginationInfo Pager)
         {
             List<ContactInfo> ContactList = new List<ContactInfo>();

             DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Contact_sp.ToString(), CommandType.StoredProcedure);

             //var tupleData = CommonMethods.GetRows(dt, Pager);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
             {
                 ContactList.Add(Get_Contact_Values(dr));
             }

             return ContactList;
         }

        public List<ContactInfo> Get_Contact_List_By_Name(int Customer_Id, ref PaginationInfo Pager)
        {
            List<ContactInfo> ContactList = new List<ContactInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Contact_By_Customer_Name_sp.ToString(), CommandType.StoredProcedure);

            //var tupleData = CommonMethods.GetRows(dt, Pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                ContactList.Add(Get_Contact_Values(dr));
            }

            return ContactList;
        }
        
        public ContactInfo Get_Contact_Values(DataRow dr)
        {
            ContactInfo contact = new ContactInfo();

            contact.contact_Entity.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            contact.contact_Entity.Contact_Type = Convert.ToInt32(dr["Contact_Type"]);
            contact.contact_Entity.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            contact.contact_Entity.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            contact.contact_Entity.Contact_Name = Convert.ToString(dr["Contact_Name"]);
            contact.contact_Entity.Designation = Convert.ToString(dr["Designation"]);
            contact.contact_Entity.Office_Address = Convert.ToString(dr["Office_Address"]);
            contact.contact_Entity.Office_Landline1 = Convert.ToString(dr["Office_Landline1"]);
            contact.contact_Entity.Office_Landline2 = Convert.ToString(dr["Office_Landline2"]);
            contact.contact_Entity.Mobile1 = Convert.ToString(dr["Mobile1"]);
            contact.contact_Entity.Mobile2 = Convert.ToString(dr["Mobile2"]);
            contact.contact_Entity.Official_Email = Convert.ToString(dr["Official_Email"]);
            contact.contact_Entity.Personal_Email = Convert.ToString(dr["Personal_Email"]);
            contact.contact_Entity.Is_Billing_Contact = Convert.ToBoolean(dr["Is_Billing_Contact"]);
            contact.contact_Entity.DMU_Status_Role = Convert.ToInt32(dr["DMU_Status_Role"]);
            contact.contact_Entity.DMU_Status_Influence = Convert.ToInt32(dr["DMU_Status_Influence"]);
            contact.contact_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            contact.contact_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            contact.contact_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            contact.contact_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            contact.contact_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            contact.Customer_Name = Convert.ToString(dr["Customer_Name"]);

            return contact;
        }
       
        public ContactInfo Get_Contact_By_Id(int Contact_Id)
        {
            ContactInfo contact = new ContactInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Contact_Id", Contact_Id));

            DataSet ds = sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Contact_by_Id_sp.ToString(), CommandType.StoredProcedure);

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

        public ContactCustomFieldsInfo Get_Contact_Custom_Fields_values(DataRow dr)
        {
            ContactCustomFieldsInfo customfields = new ContactCustomFieldsInfo();

            customfields.Custom_Fields_Entity.Contact_Custom_Field_Id = Convert.ToInt32(dr["Contact_Custom_Field_Id"]);
            customfields.Custom_Fields_Entity.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
            customfields.Custom_Fields_Entity.Field_Name = Convert.ToString(dr["Field_Name"]);
            customfields.Custom_Fields_Entity.Field_Value = Convert.ToString(dr["Field_Value"]);
            customfields.Custom_Fields_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            customfields.Custom_Fields_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            customfields.Custom_Fields_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            customfields.Custom_Fields_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            customfields.Custom_Fields_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);   

            return customfields;
        }

        public int Insert_Contact(ContactInfo contact)
        {
           int Contact_Id = 0;

           Contact_Id = Convert.ToInt32(sqlRepo.ExecuteScalerObj(Set_Values_In_Contact(contact), StoredProcedures.Insert_Contact_sp.ToString(), CommandType.StoredProcedure));

           return Contact_Id;
        }                #region Consumable

                FriendlyMessageInfo C011 = new FriendlyMessageInfo("C011", MessageType.Success, "Consumable has been added successfully.");
                hash.Add("C011", C011);

                FriendlyMessageInfo C012 = new FriendlyMessageInfo("C012", MessageType.Success, "Consumable has been updated successfully.");
                hash.Add("C012", C012);

                FriendlyMessageInfo CV011 = new FriendlyMessageInfo("CV011", MessageType.Success, " Vendor has been added successfully.");
                hash.Add("CV011", CV011);

                FriendlyMessageInfo CV012 = new FriendlyMessageInfo("CV012", MessageType.Success, "Vendor Deleted successfully.");
                hash.Add("CV012", CV012);

                FriendlyMessageInfo CU013 = new FriendlyMessageInfo("CU013", MessageType.Success, "Consumable has been updated successfully.");
                hash.Add("CU013", CU013);

                FriendlyMessageInfo CV014 = new FriendlyMessageInfo("CV014", MessageType.Success, " Vendor has been updated successfully.");
                hash.Add("CV014", CV014);

                #endregion

        public void Update_Contact(ContactInfo contact)
        {
            sqlRepo.ExecuteNonQuery(Set_Values_In_Contact(contact), StoredProcedures.Update_Contact_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Contact(ContactInfo contact)
        {
             List<SqlParameter> sqlparam = new List<SqlParameter>();

            if(contact.contact_Entity.Contact_Id != 0)
            {
            sqlparam.Add(new SqlParameter("@Contact_Id",contact.contact_Entity.Contact_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Type",contact.contact_Entity.Contact_Type));
            sqlparam.Add(new SqlParameter("@Customer_Id",contact.contact_Entity.Customer_Id));
            sqlparam.Add(new SqlParameter("@Vendor_Id", contact.contact_Entity.Vendor_Id));
            sqlparam.Add(new SqlParameter("                #region Consumable

                FriendlyMessageInfo C011 = new FriendlyMessageInfo("C011", MessageType.Success, "Consumable has been added successfully.");
                hash.Add("C011", C011);

                FriendlyMessageInfo C012 = new FriendlyMessageInfo("C012", MessageType.Success, "Consumable has been updated successfully.");
                hash.Add("C012", C012);

                FriendlyMessageInfo CV011 = new FriendlyMessageInfo("CV011", MessageType.Success, " Vendor has been added successfully.");
                hash.Add("CV011", CV011);

                FriendlyMessageInfo CV012 = new FriendlyMessageInfo("CV012", MessageType.Success, "Vendor Deleted successfully.");
                hash.Add("CV012", CV012);

                FriendlyMessageInfo CU013 = new FriendlyMessageInfo("CU013", MessageType.Success, "Consumable has been updated successfully.");
                hash.Add("CU013", CU013);

                FriendlyMessageInfo CV014 = new FriendlyMessageInfo("CV014", MessageType.Success, " Vendor has been updated successfully.");
                hash.Add("CV014", CV014);

                #endregion@Contact_Name",contact.contact_Entity.Contact_Name ));
            sqlparam.Add(new SqlParameter("@Designation",contact.contact_Entity.Designation ));
            sqlparam.Add(new SqlParameter("@Office_Address",contact.contact_Entity.Office_Address ));
            sqlparam.Add(new SqlParameter("@Office_Landline1",contact.contact_Entity.Office_Landline1));
            sqlparam.Add(new SqlParameter("@Office_Landline2",contact.contact_Entity.Office_Landline2 ));
            sqlparam.Add(new SqlParameter("@Mobile1",contact.contact_Entity.Mobile1)); 
            sqlparam.Add(new SqlParameter("@Mobile2",contact.contact_Entity.Mobile2));    
            sqlparam.Add(new SqlParameter("@Official_Email",contact.contact_Entity.Official_Email )); 
            sqlparam.Add(new SqlParameter("@Personal_Email",contact.contact_Entity.Personal_Email ));    
            sqlparam.Add(new SqlParameter("@Is_Billing_Contact",contact.contact_Entity.Is_Billing_Contact));
            sqlparam.Add(new SqlParameter("@DMU_Status_Role", contact.contact_Entity.DMU_Status_Role));
            sqlparam.Add(new SqlParameter("@DMU_Status_Influence", contact.contact_Entity.DMU_Status_Influence));
            sqlparam.Add(new SqlParameter("@Is_Active",contact.contact_Entity.Is_Active ));   
            if(contact.contact_Entity.Contact_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy",contact.contact_Entity.CreatedBy ));     
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy",contact.contact_Entity.UpdatedBy ));       

            return sqlparam;
        }

        public void Insert_Contact_Custom_Fields(ContactCustomFieldsInfo customfields)
        {
            sqlRepo.ExecuteNonQuery(Set_Values_In_Contact_Custom_Fields(customfields), StoredProcedures.Insert_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Contact_Custom_Fields(ContactCustomFieldsInfo customfields)
        {
            sqlRepo.ExecuteNonQuery(Set_Values_In_Contact_Custom_Fields(customfields), StoredProcedures.Update_Contact_Custom_Fields_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Contact_Custom_Fields(ContactCustomFieldsInfo customfields)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (customfields.Custom_Fields_Entity.Contact_Custom_Field_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", customfields.Custom_Fields_Entity.Contact_Custom_Field_Id));
            }
            sqlparam.Add(new SqlParameter("@Contact_Id", customfields.Custom_Fields_Entity.Contact_Id));
            sqlparam.Add(new SqlParameter("@Field_Name", customfields.Custom_Fields_Entity.Field_Name));
            sqlparam.Add(new SqlParameter("@Field_Value", customfields.Custom_Fields_Entity.Field_Value));
            sqlparam.Add(new SqlParameter("@Is_Active", customfields.Custom_Fields_Entity.Is_Active));
            if (customfields.Custom_Fields_Entity.Contact_Custom_Field_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", customfields.Custom_Fields_Entity.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", customfields.Custom_Fields_Entity.UpdatedBy));   

            return sqlparam;
        }

        public void Delete_Contact_Custom_Fields(int Contact_Custom_Field_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Contact_Custom_Field_Id", Contact_Custom_Field_Id));

            sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Contact_Custom_Fields_By_Id.ToString(), CommandType.StoredProcedure);
        }
    }
}
