using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CustomerInfo
    {
        public CustomerInfo()
        {
           // Customer_Entity = new Customer();

            Bank_Details = new BankDetailsInfo();

            Customer_Address_List = new List<CustomerAddressInfo>();

            Customer_Address = new CustomerAddressInfo();

            Customer_Contact_Types = new List<CustomerContactTypeInfo>();

            Customer_Contact_Type = new CustomerContactTypeInfo();
        }

      //  public Customer Customer_Entity { get; set; }

        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public string Company_Email { get; set; }

        public string Head_Office_Address { get; set; }

        public int Head_Office_State { get; set; }

        public string Head_Office_ZipCode { get; set; }

        public int Head_Office_Nation { get; set; }

        public string Head_Office_Landline1 { get; set; }

        public string Head_Office_Landline2 { get; set; }

        public string Head_Office_FaxNo { get; set; }

        public string Company_Turnover { get; set; }

        public bool Public_Private_Sector { get; set; }

        public bool Organised_UnOrganised_Sector { get; set; }

        public int Proprietary_Private_Limited { get; set; }

        public int Progressive_Stable_Turmoil { get; set; }

        public DateTime Expiration_Date_Of_Contract { get; set; }

        //public int Credit_limit { get; set; }

        public bool Auto_Mail_Delivery { get; set; }

        public int Order_Minimum_Value { get; set; }

        public int Order_Maximum_Value { get; set; }

        public bool Is_Approved_By_Director { get; set; }

        public bool Block_Order { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public bool Is_Domistic { get; set; }

        #region Additional Fields 

        public BankDetailsInfo Bank_Details { get; set; }

        public List<CustomerAddressInfo> Customer_Address_List { get; set; }

        public CustomerAddressInfo Customer_Address { get; set; }

        public string Nation_Name { get; set; }

        public List<CustomerContactTypeInfo> Customer_Contact_Types { get; set; }

        public CustomerContactTypeInfo Customer_Contact_Type { get; set; }

        #endregion
    }
}
