using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Customers = new List<CustomerInfo>();

            Customer = new CustomerInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            States = new List<StateInfo>();

            Nations = new List<NationInfo>();

            Filter = new CustomerFilter();
        }

        public List<CustomerInfo> Customers { get; set; }

        public CustomerInfo Customer { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<StateInfo> States { get; set; }

        public List<NationInfo> Nations { get; set; }

        public CustomerFilter Filter { get; set; }

    }

    public class CustomerFilter
    {
        public string Customer_Name { get; set; }

        public int Customer_Id { get; set; }

        public string Email { get; set; }

        public string Turnover { get; set; }

        public int Nation_Id { get; set; }

        public int Status_Id { get; set; }

        public int State_Id { get; set; }

        public string Pin_Code { get; set; }
        
    }
}