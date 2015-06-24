using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ConsumableInfo
    {

        public int Consumable_Id { get; set; }

        public int Category_Id { get; set; }

        public int SubCategory_Id { get; set; }

        public string Material_Name { get; set; }

        public string Material_Code { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }


        public ConsumableInfo()
        {
            // Consumable_Entity = new M_Consumable();

            Consumable_Vendors = new List<ConsumableVendorInfo>();

            Consumable_Vendor = new ConsumableVendorInfo();

        }

        #region Additional Fields

        //public int Category_Id { get; set; }

        public string Category_Name { get; set; }

       // public int SubCategory_Id { get; set; }

        public string SubCategory_Name { get; set; }

       // public M_Consumable Consumable_Entity { get; set; }

        public int Supplier_Id { get; set; }

        public string Supplier_Name { get; set; }

        public List<ConsumableVendorInfo> Consumable_Vendors { get; set; }

        public ConsumableVendorInfo Consumable_Vendor { get; set; }


        #endregion

    }
}
