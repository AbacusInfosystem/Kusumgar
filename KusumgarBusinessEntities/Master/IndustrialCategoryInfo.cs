using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialCategoryInfo
    {
        public M_Industrial_Category Industrial_Category_Entity { get; set; }

        public IndustrialCategoryInfo()
        {
            Industrial_Category_Entity = new M_Industrial_Category();
        }
    }
}
