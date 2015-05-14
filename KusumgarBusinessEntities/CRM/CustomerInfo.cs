using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            Customer_Entity = new Customer();

            Bank_Details = new BankDetailsInfo();

            Customer_Address_List = new List<CustomerAddressInfo>();

            Customer_Address = new CustomerAddressInfo();
        }

        public Customer Customer_Entity { get; set; }

        public BankDetailsInfo Bank_Details { get; set; }

        public List<CustomerAddressInfo> Customer_Address_List { get; set; }

        public CustomerAddressInfo Customer_Address { get; set; }
    }
}
