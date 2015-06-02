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

            Material_Vendor_Grid = new List<MaterialVendorInfo>();

            Vendor = new VendorInfo();

            Material_Vendor = new MaterialVendorInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            States = new List<StateInfo>();

            Nations = new List<NationInfo>();

            Filter = new Vendor_Filter();

            Product_Category = new List<ProductCategoryInfo>();

            Is_Primary = false;

            Attribute_Code = new AttributeCodeInfo();

            Product_Category_Info = new ProductCategoryInfo();

        }

         public bool Is_Primary { get; set; }

         public List<VendorInfo> Vendor_Grid { get; set; }

         public List<MaterialVendorInfo> Material_Vendor_Grid { get; set; }

        public VendorInfo Vendor { get; set; }

        public MaterialVendorInfo Material_Vendor { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<StateInfo> States { get; set; }

        public List<NationInfo> Nations { get; set; }

        public Vendor_Filter Filter { get; set; }

        public List<ProductCategoryInfo> Product_Category { get; set; }

        public AttributeCodeInfo Attribute_Code { get; set; }

        public ProductCategoryInfo Product_Category_Info { get; set; }
       
    
    public class Vendor_Filter
    {
        public string Vendor_Name { get; set; }
        public int Vendor_Id { get; set; }
  
    }

    }
}