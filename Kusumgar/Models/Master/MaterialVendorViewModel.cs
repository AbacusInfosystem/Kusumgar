using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class MaterialVendorViewModel
    {
        public MaterialVendorViewModel()
        {
            Material_Vendor_Grid = new List<MaterialVendorInfo>();

            Material_Vendor = new MaterialVendorInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

        }

        public List<MaterialVendorInfo> Material_Vendor_Grid { get; set; }

        public MaterialVendorInfo Material_Vendor { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }
 
    }
}