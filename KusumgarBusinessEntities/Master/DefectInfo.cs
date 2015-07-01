using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
  public class DefectInfo
    {
        public DefectInfo()
        {
         //  DefectEntity =new M_Defect();
        }
       // public M_Defect DefectEntity { get; set; }

        public int Defect_Id { get; set; }

        public int Process_Id { get; set; }

        public string Defect_Major { get; set; }

        public string Defect_Minor { get; set; }
        
        public string Defect_Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Process_Name { get; set; }

        #endregion
    }
}
