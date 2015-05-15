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
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }

        public IndustrialViewModel()
        {
            Industrial = new IndustrialInfo();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessageInfo>();
        }
    }
}