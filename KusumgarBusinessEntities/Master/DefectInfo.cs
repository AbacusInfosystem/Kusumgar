using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities
{
  public class DefectInfo
    {
        public int DefectTypeId { get; set; }
        public string DefectTypeName { get; set; }
        public string DefectCode { get; set; }
        public string DefectName { get; set; }
        public bool Status { get; set; }
        public int DefectId { get; set; }

    }
}
