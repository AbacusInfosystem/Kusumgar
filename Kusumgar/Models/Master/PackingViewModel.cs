using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class PackingViewModel
    {
        public PackingInfo Packing { get; set; }
        public List<PackingInfo> Packings { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public PackingFilter Filter { get; set; }
        public int Packing_Id { get; set; }

        public PackingViewModel()
        {
            Packing = new PackingInfo();
            Packings = new List<PackingInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Pager = new PaginationInfo();
            Filter = new PackingFilter();
        }
    }

    public class PackingFilter
    {
        public string Packing_Name { get; set; }
        public int Packing_Id { get; set; }
    }
}