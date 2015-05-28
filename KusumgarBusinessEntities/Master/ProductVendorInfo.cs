using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ProductVendorInfo
    {
        public M_Product_Vendor Product_Vendor_Entity { get; set; }
        public string Vendor_Name { get; set; }

        public ProductVendorInfo()
        {
            Product_Vendor_Entity = new M_Product_Vendor();
        }
    }
}
