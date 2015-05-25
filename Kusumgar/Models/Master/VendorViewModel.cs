using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class VendorViewModel
    {
         public VendorViewModel()
        {
            Vendor_Grid = new List<VendorInfo>();

            Product_Vendor_Grid = new List<ProductVendorInfo>();

            Vendor = new VendorInfo();

            Product_Vendor = new ProductVendorInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            States = new List<StateInfo>();

            Nations = new List<NationInfo>();

            Filter = new Vendor_Filter();

        }

         public List<VendorInfo> Vendor_Grid { get; set; }

         public List<ProductVendorInfo> Product_Vendor_Grid { get; set; }

        public VendorInfo Vendor { get; set; }

        public ProductVendorInfo Product_Vendor { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<StateInfo> States { get; set; }

        public List<NationInfo> Nations { get; set; }

        public Vendor_Filter Filter { get; set; }
    
    public class Vendor_Filter
    {
        public string Vendor_Name { get; set; }
        public int Vendor_Id { get; set; }
  
    }

    }
}