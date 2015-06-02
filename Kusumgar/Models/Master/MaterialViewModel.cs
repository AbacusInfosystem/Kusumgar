using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class MaterialViewModel
    {
        public MaterialInfo Material { get; set; }
        public MaterialVendorInfo Material_Vendor { get; set; }
        public List<MaterialInfo> Materials { get; set; }
        public List<MaterialVendorInfo> Material_Vendors { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<MaterialCategoryInfo> Material_Categories { get; set; }
        public List<MaterialSubCategoryInfo> Material_SubCategories { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public MaterialFilter Filter { get; set; }
        public int Material_Id { get; set; }

        public MaterialViewModel()
        {
            Material = new MaterialInfo();
            Material_Vendor = new MaterialVendorInfo();
            Materials = new List<MaterialInfo>();
            Material_Vendors = new List<MaterialVendorInfo>();
            Pager = new PaginationInfo();
            Material_Categories = new List<MaterialCategoryInfo>();
            Material_SubCategories = new List<MaterialSubCategoryInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Filter = new MaterialFilter();
        }
    }

    public class MaterialFilter
    {
        public string Material_Name { get; set; }
        public int Material_Id { get; set; }
    }
}