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
           // Work_Center_Process_Entity = new M_Work_Center_Process();

        }

        // public M_Work_Center_Process Work_Center_Process_Entity { get; set; }

        public int Work_Center_Process_Id { get; set; }

        public int Work_Center_Id { get; set; }

        public int Process_Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        #region Additional Fields

        public string Process_Name { get; set; }

        #endregion
    }

}
