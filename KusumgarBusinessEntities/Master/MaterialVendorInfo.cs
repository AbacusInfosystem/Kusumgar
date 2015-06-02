using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
    public class MaterialVendorInfo
    {

        public MaterialVendorInfo()
        {
            Material_Vendor_Entity = new M_Material_Vendor();

        }

        public M_Material_Vendor Material_Vendor_Entity { get; set; }

        public string Vendor_Name { get; set; }

        public string Product_Type_Name { get; set; }
    }
}
