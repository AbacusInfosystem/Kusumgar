using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class FactoryInfo
    {
        public FactoryInfo()
        {
          //  Factory_Entity = new M_Factory();
        }
       // public M_Factory Factory_Entity { get; set; }

        public int Factory_Id { get; set; }

        public string Factory_Name { get; set; }

        public string Factory_Code { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
