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

         //   Work_Station_Entity = new M_Work_Station();
        }

       // public M_Work_Station Work_Station_Entity { get; set; }

        public int Work_Station_Id { get; set; }

        public int Factory_Id { get; set; }

        public string Work_Station_Name { get; set; }

        public string Work_Station_Code { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
