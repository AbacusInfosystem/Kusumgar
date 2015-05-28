using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ProductSubCategoryInfo
    {
        public M_Product_SubCategory Product_SubCategory_Entity;

        public ProductSubCategoryInfo()
        {
            Product_SubCategory_Entity = new M_Product_SubCategory();
        }
    }
}
