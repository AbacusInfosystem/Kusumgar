using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ConsumableMasterInfo
    {
       

        public int Category_Id { get; set; }
        public string Category_Name { get; set; }

        public int SubCategory_Id { get; set; }
        public string SubCategory_Name { get; set; }

        public string Material_Name { get; set; }
        public string Material_Code { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int Consumable_Id { get; set; }

        public ConsumableMasterInfo()
        {
            Consumable_Entity = new M_Consumable();


        }
        public M_Consumable Consumable_Entity { get; set; }

        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }

    }
}
