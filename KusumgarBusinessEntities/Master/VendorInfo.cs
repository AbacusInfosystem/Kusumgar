using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
   public class VendorInfo
    {

        public VendorInfo()
      {
          Vendor_Entity = new M_Vendor();
          Product_Vendor_Entity = new M_Product_Vendors();
          
          Product_Vendor_Details = new ProductVendorInfo();
       
       }
        public M_Vendor Vendor_Entity { get; set; }
       
        public M_Product_Vendors Product_Vendor_Entity { get; set; }

        ProductVendorInfo Product_Vendor_Details { get; set; }
        
       public int Year { get; set; }
        
    }
}
