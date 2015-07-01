using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ConsumableVendorInfo
    {
        public ConsumableVendorInfo()
        {
           // Consumable_Vendor_Entity = new M_Consumable_Vendors();

            Vendor_Entity = new VendorInfo();

        }

   // public M_Consumable_Vendors Consumable_Vendor_Entity { get; set; }

        public int Consumable_Vendor_Id { get; set; }

        public int Vendor_Id { get; set; }

        public int Consumable_Id { get; set; }

        public int Priority_Order { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }


    public VendorInfo Vendor_Entity { get; set; }


    }
}
