using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ContactInfo
    {
        public ContactInfo()
        {
           // contact_Entity = new Contact();

            Contact_Custom_Fields_List = new List<ContactCustomFieldsInfo>();

            Custom_Fields = new ContactCustomFieldsInfo();
        }

       // public Contact contact_Entity { get; set; }

        public int Contact_Id { get; set; }

        public int Contact_Type { get; set; }

        public int Customer_Id { get; set; }

        public int Customer_Contact_Type_Id { get; set; }

        public int Vendor_Id { get; set; }

        public string Contact_Name { get; set; }

        public string Designation { get; set; }

        public string Office_Address { get; set; }

        public string Office_Landline1 { get; set; }

        public string Office_Landline2 { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public string Official_Email { get; set; }

        public string Personal_Email { get; set; }

        public bool Is_Billing_Contact { get; set; }

        public int DMU_Status_Role { get; set; }

        public int DMU_Status_Influence { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        

        #region Additional Fields

        public List<ContactCustomFieldsInfo> Contact_Custom_Fields_List { get; set; }

        public ContactCustomFieldsInfo Custom_Fields { get; set; }

        public string Customer_Name { get; set; }

        public string DMU_Status_Influence_Str
        {
            get
            {
                return ((DMUStatusInfluence)DMU_Status_Influence).ToString();
            }
            set
            {
                DMU_Status_Influence_Str = value;
            }
        }

        public string DMU_Status_Role_Str
        {
            get
            {
                return ((DMUStatusRole)DMU_Status_Role).ToString();
            }
            set
            {
                DMU_Status_Role_Str = value;
            }
        }

        public string Customer_Contact_Type { get; set; }

        #endregion
    }
}
