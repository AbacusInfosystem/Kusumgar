using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;
namespace Kusumgar.Models
{
    public class ProductVendorViewModel
    {
        public ProductVendorViewModel()
        {
            Product_Vendor_Grid = new List<ProductVendorInfo>();

            Product_Vendor = new ProductVendorInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

        }

        public List<ProductVendorInfo> Product_Vendor_Grid { get; set; }

        public ProductVendorInfo Product_Vendor { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }
 
    }
}