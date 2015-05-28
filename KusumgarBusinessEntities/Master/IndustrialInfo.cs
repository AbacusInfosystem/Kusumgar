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
        public M_Industrial Industrial_Entity { get; set; }
        public string Industrial_Category_Name { get; set; }
        public string Industrial_Group_Name { get; set; }
        public IndustrialInfo()
        {
            Industrial_Entity = new M_Industrial();
        }
    }
}
