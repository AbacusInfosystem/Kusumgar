using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class ConsumableViewModel
    {
        public ConsumableViewModel()
        {
            Consumable = new ConsumableInfo();

            Categories = new List<ConsumableInfo>();

            SubCategories = new List<ConsumableInfo>();
           
            Pager = new PaginationInfo();

            Consumables = new List<ConsumableInfo>();
           
            Friendly_Message = new List<FriendlyMessageInfo>();

            Filter = new Consumable_Filter();

        }

        public ConsumableInfo Consumable { get; set; }

        public List<ConsumableInfo> Categories { get; set; } 

        public List<ConsumableInfo> SubCategories { get; set; }
      
        public PaginationInfo Pager { get; set; }

        public List<ConsumableInfo> Consumables { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Consumable_Filter Filter { get; set; }
    }


    public class Consumable_Filter
    {
        public int Category_Id { get; set; }

        public string Material_Name { get; set; }
    }
}