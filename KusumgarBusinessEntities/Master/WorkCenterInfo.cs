using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class WorkCenterInfo
    {

        public WorkCenterInfo()
        {
            Work_Center_Entity = new M_Work_Center();
        }

        public M_Work_Center Work_Center_Entity { get; set; }

    }

    
}
