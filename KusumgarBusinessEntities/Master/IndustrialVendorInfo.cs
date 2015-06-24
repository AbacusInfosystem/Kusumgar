using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialVendorInfo
    {
        //public M_Industrial_Vendors Industrial_Vendor_Entity { get; set; }
       

        public IndustrialVendorInfo()
        {
           // Industrial_Vendor_Entity = new M_Industrial_Vendors();
        }

        public int Industrial_Vendor_Id { get; set; }

        public int Industrial_Master_Id { get; set; }

        public int Vendor_Id { get; set; }

        public int Priority_Order { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }

        #region Additional Fields

        public string Vendor_Name { get; set; }

        #endregion
    }
}
