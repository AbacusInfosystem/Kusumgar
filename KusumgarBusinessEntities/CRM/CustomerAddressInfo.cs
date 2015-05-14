using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class CustomerAddressInfo
    {
        public CustomerAddressInfo()
        {
            Customer_Address_Entity = new Customer_Addresss();
        }

        public Customer_Addresss Customer_Address_Entity { get; set; }
    }
}
