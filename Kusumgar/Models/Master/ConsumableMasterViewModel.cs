using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class ConsumableMasterViewModel
    {
        public ConsumableMasterViewModel()
        {
            Consumable = new ConsumableMasterInfo();

            CategoryList = new List<ConsumableMasterInfo>();
            SubCategoryList = new List<ConsumableMasterInfo>();
            //ConsumableMasterList = new List<ConsumableMasterInfo>();

            Pager = new PaginationInfo();
            ConsumableMasterList = new List<ConsumableMasterInfo>();

            FriendlyMessage = new List<FriendlyMessageInfo>();

        }

        public ConsumableMasterInfo Consumable { get; set; }

        public List<ConsumableMasterInfo> CategoryList { get; set; }
        public List<ConsumableMasterInfo> SubCategoryList { get; set; }
        //public List<ConsumableMasterInfo> ConsumableMasterList { get; set; }

        public PaginationInfo Pager { get; set; }
        public List<ConsumableMasterInfo> ConsumableMasterList { get; set; }

        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }
        
    }
}