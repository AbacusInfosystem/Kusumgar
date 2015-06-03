using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class WorkStationInfo
    {
        
        public WorkStationInfo()
        {

            Work_Station_Entity = new M_Work_Station();
        }

        public M_Work_Station Work_Station_Entity { get; set; }
    }
}
