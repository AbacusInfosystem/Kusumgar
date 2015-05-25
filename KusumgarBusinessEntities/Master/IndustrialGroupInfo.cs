using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialGroupInfo
    {
        public M_Industrial_Group Industrial_Group_Entity { get; set; }

        public IndustrialGroupInfo()
        {
            Industrial_Group_Entity = new M_Industrial_Group();
        }
    }
}
