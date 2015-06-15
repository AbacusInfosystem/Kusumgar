using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class CustomerQualityManager
    {
        public CustomerQualityRepo _customerqualityRepo;

        public CustomerQualityManager()
        {
            _customerqualityRepo = new CustomerQualityRepo();
        }

        public List<QualityInfo> Get_Qualities(ref PaginationInfo pager)
        {
            return _customerqualityRepo.Get_Qualities(ref pager);
        }

        public int Insert_Customer_Quality(CustomerQualityInfo customer_Quality)
        {
            return _customerqualityRepo.Insert_Customer_Quality(customer_Quality);
        }

        public CustomerQualityInfo Get_Customer_Quality_By_Id(int customer_Quality_Id)
        {
            return _customerqualityRepo.Get_Customer_Quality_By_Id(customer_Quality_Id);
        }

        public void Update_Customer_Quality(CustomerQualityInfo customer_Quality)
        {
            _customerqualityRepo.Update_Customer_Quality(customer_Quality);
        }

        public List<AutocompleteInfo> Get_Sample_No_AutoComplete(string sample_No)
        {
            return _customerqualityRepo.Get_Sample_No_AutoComplete(sample_No);
        }

        public List<CustomerQualityInfo> Get_Customer_Qualities(ref PaginationInfo pager)
        {
            return _customerqualityRepo.Get_Customer_Qualities(ref pager);
        }

        public List<CustomerQualityInfo> Get_Customer_Qualities_By_Customer_Id(int customer_Id, ref PaginationInfo pager)
        {
            return _customerqualityRepo.Get_Customer_Qualities_By_Customer_Id(customer_Id, ref pager);
        }

        public List<CustomerQualityInfo> Get_Customer_Qualities_By_Quality_Id(int quality_Id, ref PaginationInfo pager)
        {
            return _customerqualityRepo.Get_Customer_Qualities_By_Quality_Id(quality_Id, ref pager);
        }

        public List<CustomerQualityInfo> Get_Customer_Qualities_By_Customer_Id_By_Quality_Id(int customer_Id, int quality_Id, ref PaginationInfo pager)
        {
            return _customerqualityRepo.Get_Customer_Qualities_By_Customer_Id_By_Quality_Id(customer_Id, quality_Id, ref pager);
        }
    }
}
