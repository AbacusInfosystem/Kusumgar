using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class IndustrialViewModel
    {
        public IndustrialInfo Industrial { get; set; }
        public IndustrialVendorInfo Industrial_Vendor { get; set; }
        public List<IndustrialInfo> Industrials { get; set; }
        public List<IndustrialVendorInfo> Industrial_Vendors { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<IndustrialCategoryInfo> Industrial_Categories { get; set; }
        public List<IndustrialGroupInfo> Industrial_Groups { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public IndustrialFilter Filter { get; set; }
        public int Industrial_Master_Id { get; set; }

        public IndustrialViewModel()
        {
            Industrial = new IndustrialInfo();
            Industrial_Vendor = new IndustrialVendorInfo();
            Industrials = new List<IndustrialInfo>();
            Industrial_Vendors = new List<IndustrialVendorInfo>();
            Pager = new PaginationInfo();
            Industrial_Categories = new List<IndustrialCategoryInfo>();
            Industrial_Groups = new List<IndustrialGroupInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Filter = new IndustrialFilter();
        }
    }

    public class IndustrialFilter
    {
        public int Industrial_Category_Id { get; set; }
        public int Industrial_Group_Id { get; set; }
    }
}