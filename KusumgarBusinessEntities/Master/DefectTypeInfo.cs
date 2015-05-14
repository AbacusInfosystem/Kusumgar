using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public  class DefectTypeInfo
    {
      public DefectTypeInfo()
      {
            DefectTypeEntity =new M_Defect_Type();
       
       }
      public M_Defect_Type DefectTypeEntity { get; set; }

    }
}


        