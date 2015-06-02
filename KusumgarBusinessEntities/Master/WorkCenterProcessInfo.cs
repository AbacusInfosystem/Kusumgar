using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class WorkCenterProcessInfo
    {
        public WorkCenterProcessInfo()
        {
            Work_Center_Process_Entity = new M_Work_Center_Process();

        }

        public M_Work_Center_Process Work_Center_Process_Entity { get; set; }

        public string Process_Name { get; set; }
    }

}
