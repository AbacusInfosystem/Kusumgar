
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ProcessInfo
    {
        public ProcessInfo()
        {
           // Process_Entity = new M_Process();
        }
        //public M_Process Process_Entity { get; set; }

        //public String Process_Ids { get; set; }

        public int Process_Id { get; set; }

        public string Process_Name { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
