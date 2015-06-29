using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class CustomerManager
    {

        CustomerRepo _customerRepo;

        public CustomerManager()
        {
            _customerRepo = new CustomerRepo();
        }

        public List<CustomerInfo> Get_Customers(ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers(ref pager);
        }

        public List<CustomerInfo> Get_Customers_By_Name(string Customer_Name, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Name(Customer_Name, ref pager);
        }

        public CustomerInfo Get_Customer_By_Id(int Customer_Id)
        {
            return _customerRepo.Get_Customer_By_Id(Customer_Id);
        }

        public int Insert_Customer(CustomerInfo customer)
        {
            return _customerRepo.Insert_Customer(customer);
        }

        public void Update_Customer(CustomerInfo customer)
        {
            _customerRepo.Update_Customer(customer);
        }

        public void Insert_Customer_Address(CustomerAddressInfo customer_Address)
        {
            _customerRepo.Insert_Customer_Address(customer_Address);
        }

        public void Update_Customer_Address(CustomerAddressInfo customer_Address)
        {
            _customerRepo.Update_Customer_Address(customer_Address);
        }

        public void Insert_Bank_Details(BankDetailsInfo bank_Details)
        {
            _customerRepo.Insert_Bank_Details(bank_Details);
        }

        public void Update_Bank_Details(BankDetailsInfo bank_Details)
        {
            _customerRepo.Update_Bank_Details(bank_Details);
        }

        public void Delete_Customer_Address_By_Id(int customer_Address_Id)
        {
            _customerRepo.Delete_Customer_Address_By_Id(customer_Address_Id);
        }

        public bool Check_Existing_Customer(string customer_Name)
        {
            return _customerRepo.Check_Existing_Customer(customer_Name);
        }

        public List<CustomerInfo> Get_Customers_By_Email(string email,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Email(email,ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Turnover(string turnover,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Turnover(turnover, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Email(string turnover, string email,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Turnover_Email(turnover,email, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Name(string Turnover, string Customer_Name,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Turnover_Name(Turnover, Customer_Name, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Email_Name(string email, string customer_Name,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Email_Name(email, customer_Name,ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Email_Name_Turnover(string email, string customer_Name, string turnover,  ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Email_Name_Turnover(email,customer_Name,turnover, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_by_Nation_Id_Turnover(string turnover, int nation_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_by_Nation_Id_Turnover(turnover, nation_Id, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_by_Nation_Id(int nation_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_by_Nation_Id(nation_Id, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Turnover_Customer_Id(string turnover, int customer_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Turnover_Customer_Id(turnover,customer_Id, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Customer_Id_Nation_Id(int nation_Id, int customer_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Customer_Id_Nation_Id(nation_Id,customer_Id, ref  pager);
        }

        public List<CustomerInfo> Get_Customers_By_Id(int Customer_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Id(Customer_Id, ref  pager);
        }

         public List<CustomerInfo> Get_Customers_By_Turnover_Customer_Id_Nation_Id(string turnover, int nation_Id, int customer_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customers_By_Turnover_Customer_Id_Nation_Id(turnover, nation_Id, customer_Id,ref  pager);
        }

         public List<AutocompleteInfo> Get_Customer_AutoComplete(string Customer_Name)
         {
             return _customerRepo.Get_Customer_AutoComplete(Customer_Name);
         }





         public List<CustomerInfo> Get_Customers_By_Status(ref PaginationInfo pager, int customer_Status_Id)
         {
             return _customerRepo.Get_Customers_By_Status(ref pager, customer_Status_Id);
         }

         public void Update_Customer_Block_Order(CustomerInfo customer)
         {
             _customerRepo.Update_Customer_Block_Order(customer);
         }
        //Advance Search
         public List<CustomerInfo> Get_Customers_By_Pin_Code_Nation_Id_State_Id_Customer_Id(string pin_Code, int nation_Id, int state_Id, int customer_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_Pin_Code_Nation_Id_State_Id_Customer_Id(pin_Code, nation_Id, state_Id, customer_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_Pin_Code_Customer_Id_Nation_Id(string pin_Code, int nation_Id, int customer_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_Pin_Code_Customer_Id_Nation_Id(pin_Code, nation_Id, customer_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_State_Id_Customer_Id_Nation_Id(int nation_Id, int state_Id, int customer_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_State_Id_Customer_Id_Nation_Id(nation_Id, state_Id, customer_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_Pin_Cide_Nation_Id_State_Id(string pin_Code, int nation_Id, int state_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_Pin_Cide_Nation_Id_State_Id(pin_Code, nation_Id, state_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_Pin_Code_Customer_Id(string pin_Code, int customer_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_Pin_Code_Customer_Id(pin_Code, customer_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_by_Nation_Id_Pin_Code(string pin_Code, int nation_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_by_Nation_Id_Pin_Code(pin_Code, nation_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_State_Id_Nation_Id(int nation_Id, int state_Id, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_State_Id_Nation_Id(nation_Id, state_Id, ref  pager);
         }

         public List<CustomerInfo> Get_Customers_By_Pin_Code(string pin_Code, ref PaginationInfo pager)
         {
             return _customerRepo.Get_Customers_By_Pin_Code(pin_Code, ref  pager);
         }
    

        public void Insert_Customer_Contact_Type(CustomerContactTypeInfo CustomerContactType)
        {
            _customerRepo.Insert_Customer_Contact_Type(CustomerContactType);
        }

        public List<CustomerContactTypeInfo> Get_Customer_Contact_Type_By_Id(int customer_Id, ref PaginationInfo pager)
        {
            return _customerRepo.Get_Customer_Contact_Type_By_Id(customer_Id, ref pager);
        }

        public void Delete_Customer_Contact_Type_By_Id(int customer_Contact_Type_Id)
        {
            _customerRepo.Delete_Customer_Contact_Type_By_Id(customer_Contact_Type_Id);
        }

        public void Update_Customer_Other(CustomerInfo customer)
        {
            _customerRepo.Update_Customer_Other(customer);
        }
    }
}
