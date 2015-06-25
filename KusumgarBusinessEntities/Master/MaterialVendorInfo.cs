using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KusumgarBusinessEntities
{
    public class MaterialVendorInfo
    {

        public MaterialVendorInfo()
        {
          //  Material_Vendor_Entity = new M_Material_Vendor();

        }

        //public M_Material_Vendor Material_Vendor_Entity { get; set; }

        public int Material_Vendor_Id { get; set; }

        public int Material_Id { get; set; }

        public int Vendor_Id { get; set; }

        public int Priority_Order { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        #region Additional Fields

        public string Vendor_Name { get; set; }

        public string Product_Type_Name { get; set; }

        #endregion
    }
}
