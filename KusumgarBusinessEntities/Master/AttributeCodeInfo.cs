using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
  public  class AttributeCodeInfo
    {
      public AttributeCodeInfo()
        {
           AttributeCodeEntity = new M_Attribute_Code();
        }
     
      public M_Attribute_Code AttributeCodeEntity { get; set; }

      public string Attribute_Name { get; set; }
    }
}
