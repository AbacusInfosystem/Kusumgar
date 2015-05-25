using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
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

        public List<CustomerInfo> Get_Customers(ref PaginationInfo Pager)
        {
            return _customerRepo.Get_Customers(ref Pager);
        }

        public List<CustomerInfo> Get_Customers_By_Name(string Customer_Name, PaginationInfo Pager)
        {
            return _customerRepo.Get_Customers_By_Name(Customer_Name, ref Pager);
        }

        public CustomerInfo Get_Customer_By_Id(int Company_Id)
        {
            return _customerRepo.Get_Customer_By_Id(Company_Id);
        }

        public int Insert_Customer(CustomerInfo Customer)
        {
            return _customerRepo.Insert_Customer(Customer);
        }

        public void Update_Customer(CustomerInfo Customer)
        {
            _customerRepo.Update_Customer(Customer);
        }

        public void Insert_Customer_Address(CustomerAddressInfo Customer_Address)
        {
            _customerRepo.Insert_Customer_Address(Customer_Address);
        }

        public void Update_Customer_Address(CustomerAddressInfo Customer_Address)
        {
            _customerRepo.Update_Customer_Address(Customer_Address);
        }

        public void Insert_Bank_Details(BankDetailsInfo bank_Details)
        {
            _customerRepo.Insert_Bank_Details(bank_Details);
        }

        public void Update_Bank_Details(BankDetailsInfo bank_Details)
        {
            _customerRepo.Update_Bank_Details(bank_Details);
        }

        public void Delete_Customer_Address_By_Id(int Customer_Address_Id)
        {
            _customerRepo.Delete_Customer_Address_By_Id(Customer_Address_Id);
        }

        public bool Check_Existing_Customer(string Customer_Name)
        {
            return _customerRepo.Check_Existing_Customer(Customer_Name);
        }

        public List<CustomerInfo> Get_Customer_By_Email(string Email,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Email(Email,ref  Pager);
        }

        public List<CustomerInfo> Get_Customer_By_Turnover(string Turnover,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Turnover(Turnover, ref  Pager);
        }

        public List<CustomerInfo> Get_Customer_By_Turnover_Email(string Turnover, string Email,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Turnover_Email(Turnover,Email, ref  Pager);
        }

        public List<CustomerInfo> Get_Customer_By_Turnover_Name(string Turnover, string Customer_Name,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Turnover_Name(Turnover, Customer_Name, ref  Pager);
        }

        public List<CustomerInfo> Get_Customer_By_Email_Name(string Email, string Customer_Name,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Email_Name(Email, Customer_Name,ref  Pager);
        }

        public List<CustomerInfo> Get_Customer_By_Email_Name_Turnover(string Email, string Customer_Name, string Turnover,  PaginationInfo Pager)
        {
            return _customerRepo.Get_Customer_By_Email_Name_Turnover(Email,Customer_Name,Turnover, ref  Pager);
        }

    }
}
