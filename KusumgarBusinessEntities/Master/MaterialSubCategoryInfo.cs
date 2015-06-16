using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class MaterialSubCategoryInfo
    {
       // public M_Material_SubCategory Material_SubCategory_Entity;

        public MaterialSubCategoryInfo()
        {
            //Material_SubCategory_Entity = new M_Material_SubCategory();
        }

        public int Material_SubCategory_Id { get; set; }

        public string Material_SubCategory_Name { get; set; }

        public int Material_Category_Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
