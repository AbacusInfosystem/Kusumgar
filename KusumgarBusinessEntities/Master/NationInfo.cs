using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class NationInfo
    {

        public NationInfo()
        {
          //   Nation_Entity = new M_Nation();
        }

      //  public M_Nation Nation_Entity { get; set; }

        public int NationId { get; set; }

        public string NationName { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public string Currency_Code { get; set; }

        public string Currency_Symbol { get; set; }

        public string Nation_Flag { get; set; }

        public string Currency { get; set; }
    }
}
