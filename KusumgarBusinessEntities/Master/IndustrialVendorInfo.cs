using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialVendorInfo
    {
        public M_Industrial_Vendors Industrial_Vendor_Entity { get; set; }
        public string Vendor_Name { get; set; }

        public IndustrialVendorInfo()
        {
            Industrial_Vendor_Entity = new M_Industrial_Vendors();
        }
    }
}
