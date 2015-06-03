using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class FactoryInfo
    {
        public FactoryInfo()
        {
            Factory_Entity = new M_Factory();
        }
        public M_Factory Factory_Entity { get; set; }
    }
}
