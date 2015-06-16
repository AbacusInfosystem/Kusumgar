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
           // Customer_Address_Entity = new Customer_Addresss();
        }

       // public Customer_Addresss Customer_Address_Entity { get; set; }

        public int Customer_Address_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Address_Type { get; set; }

        public string Addresss { get; set; }

        public string Landline1 { get; set; }

        public string landline2 { get; set; }

        public string FaxNo { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

    }
}
