using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ProductInfo
    {
        public M_Product Product_Entity { get; set; }
        public string Product_Category_Name { get; set; }
        public string Product_SubCategory_Name { get; set; }

        public ProductInfo()
        {
            Product_Entity = new M_Product();
        }
    }
}
