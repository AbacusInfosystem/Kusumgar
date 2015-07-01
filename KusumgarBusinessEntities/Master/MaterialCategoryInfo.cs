using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class MaterialCategoryInfo
    {
        // public M_Material_Category Material_Category_Entity { get; set; }

        public MaterialCategoryInfo()
        {
            // Material_Category_Entity = new M_Material_Category();
        }
        //public string Material_Category_Name { get; set; }
        public int Material_Category_Id { get; set; }

        public string Material_Category_Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
