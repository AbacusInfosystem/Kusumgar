using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class NationInfo
    {

        public NationInfo()
        {
            Nation_Entity = new M_Nation();
        }

        public M_Nation Nation_Entity { get; set; }
    }
}
