using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
   public class FabricTypeInfo
    {
       public FabricTypeInfo()
      {
          //  FabricTypeEntity =new M_Fabric_Type();
       
       }
      // public M_Fabric_Type FabricTypeEntity { get; set; }

       public int Fabric_Type_Id { get; set; }

       public string Fabric_Type_Name { get; set; }

       public DateTime CreatedOn { get; set; }

       public int CreatedBy { get; set; }

       public DateTime UpdatedOn { get; set; }

       public int UpdatedBy { get; set; }


      
    }
}
