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
           //AttributeCodeEntity = new M_Attribute_Code();
        }
     
     // public M_Attribute_Code AttributeCodeEntity { get; set; }

      public int Attribute_Code_Id { get; set; }

      public int Attribute_Id { get; set; }

      public string Attribute_Code_Name { get; set; }

      public string Code { get; set; }

      public bool Status { get; set; }

      public DateTime CreatedOn { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedOn { get; set; }

      public int UpdatedBy { get; set; }

      #region Additional Fields

      public string Attribute_Name { get; set; }

      #endregion
    }
}
