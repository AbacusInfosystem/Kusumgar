using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialGroupInfo
    {
        //public M_Industrial_Group Industrial_Group_Entity { get; set; }

        public IndustrialGroupInfo()
        {
          //  Industrial_Group_Entity = new M_Industrial_Group();
        }

        public int Industrial_Group_Id { get; set; }

        public string Industrial_Group_Name { get; set; }

        public int Industrial_Category_Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }
    }
}
