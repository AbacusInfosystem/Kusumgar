using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class ProductViewModel
    {
        public ProductInfo Product { get; set; }
        public ProductVendorInfo Product_Vendor { get; set; }
        public List<ProductInfo> Products { get; set; }
        public List<ProductVendorInfo> Product_Vendors { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<ProductCategoryInfo> Product_Categories { get; set; }
        public List<ProductSubCategoryInfo> Product_SubCategories { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public ProductFilter Filter { get; set; }
        public int Product_Id { get; set; }

        public ProductViewModel()
        {
            Product = new ProductInfo();
            Product_Vendor = new ProductVendorInfo();
            Products = new List<ProductInfo>();
            Product_Vendors = new List<ProductVendorInfo>();
            Pager = new PaginationInfo();
            Product_Categories = new List<ProductCategoryInfo>();
            Product_SubCategories = new List<ProductSubCategoryInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Filter = new ProductFilter();
        }
    }

    public class ProductFilter
    {
        public string Product_Name { get; set; }
        public int Product_Id { get; set; }
    }
}