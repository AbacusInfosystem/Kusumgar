using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class WorkCenterInfo
    {
        
        public WorkCenterInfo()
        {

         //   Work_Center_Entity = new M_Work_Center();
        }

       // public M_Work_Center Work_Center_Entity { get; set; }

        public int Work_Center_Id { get; set; }

        public int Factory_Id { get; set; }

        public string Work_Center_Name { get; set; }

        public string Work_Center_Code { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
