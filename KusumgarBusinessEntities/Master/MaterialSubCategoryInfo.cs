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
        public M_Material_SubCategory Material_SubCategory_Entity;

        public MaterialSubCategoryInfo()
        {
            Material_SubCategory_Entity = new M_Material_SubCategory();
        }
    }
}
