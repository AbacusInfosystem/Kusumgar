using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ProductCategoryInfo
    {
        public M_Product_Category Product_Category_Entity { get; set; }

        public ProductCategoryInfo()
        {
            Product_Category_Entity = new M_Product_Category();
        }
public string Product_Category_Name { get; set; }
    }
}
