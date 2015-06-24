using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public  class DefectTypeInfo
    {
      public DefectTypeInfo()
      {
            //DefectTypeEntity =new M_Defect_Type();
       
       }
      //public M_Defect_Type DefectTypeEntity { get; set; }

      public int Defect_Type_Id { get; set; }

      public string Defect_Type_Name { get; set; }

      public bool Status { get; set; }

      public DateTime CreatedOn { get; set; }

      public int CreatedBy { get; set; }

      public DateTime UpdatedOn { get; set; }

      public int UpdatedBy { get; set; }
    }
}


        