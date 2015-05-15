using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public class DefectInfo
    {
        public DefectInfo()
        {
           DefectEntity =new M_Defect();
        }
        public M_Defect DefectEntity { get; set; }
        public string Defect_Type_Name { get; set; }
    }
}
