using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
    public class ProductVendorInfo
    {

        public ProductVendorInfo()
        {
            Product_Vendor_Entity = new M_Product_Vendor();

        }

        public M_Product_Vendor Product_Vendor_Entity { get; set; }

        public string Vendor_Name { get; set; }

        public string Product_Type_Name { get; set; }
    }
}
