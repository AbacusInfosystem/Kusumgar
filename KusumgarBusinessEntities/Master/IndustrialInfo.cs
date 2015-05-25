using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialInfo
    {
        public M_Industrial IndustrialEntity { get; set; }
        public string IndustrialCategoryName { get; set; }
        public string IndustrialGroupName { get; set; }
        public IndustrialInfo()
        {
            IndustrialEntity = new M_Industrial();
        }
    }
}
