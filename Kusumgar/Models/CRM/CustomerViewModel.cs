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
            Customer_List = new List<CustomerInfo>();

            Customer = new CustomerInfo();

            FriendlyMessage = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            State_List = new List<StateInfo>();

            Nation_List = new List<NationInfo>();

            Filter_Value = new CustomerFilter();
        }

        public List<CustomerInfo> Customer_List { get; set; }

        public CustomerInfo Customer { get; set; }

        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<StateInfo> State_List { get; set; }

        public List<NationInfo> Nation_List { get; set; }

        public CustomerFilter Filter_Value { get; set; }

    }

    public class CustomerFilter
    {
        public string Customer_Name { get; set; }

        public int Customer_Id { get; set; }

        public string Email { get; set; }

        public string Turnover { get; set; }

        public int Nation_Id { get; set; }
    }
}