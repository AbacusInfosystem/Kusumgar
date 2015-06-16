using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
    public class VendorContactInfo:ContactInfo
    {

        public VendorContactInfo()
        {
           // Contact_Entity = new Contact();

            Vendor_Custom_Field = new VendorContactCustomFieldsInfo();

            Vendor_Custom_Fields = new List<VendorContactCustomFieldsInfo>();
        }

        //public Contact Contact_Entity { get; set; }

        #region Additional Fields

        public string Vendor_Name { get; set; }

        public VendorContactCustomFieldsInfo Vendor_Custom_Field { get; set; }

        public List<VendorContactCustomFieldsInfo> Vendor_Custom_Fields { get; set; }

        #endregion
    }
}
