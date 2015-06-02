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

          Material_Vendor_Details = new MaterialVendorInfo();
       
       }
        public M_Vendor Vendor_Entity { get; set; }
       
        public M_Product_Vendors Product_Vendor_Entity { get; set; }

        MaterialVendorInfo Material_Vendor_Details { get; set; }

        public M_Product_Category Product_Category_Entity { get; set; }
       
        public string PreviousCategoryName {get;set;}
    }
}
