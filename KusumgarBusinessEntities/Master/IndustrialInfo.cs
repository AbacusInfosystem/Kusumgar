using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialInfo
    {
       // public M_Industrial Industrial_Entity { get; set; }
       
        public IndustrialInfo()
        {
            //Industrial_Entity = new M_Industrial();
        }

        public int Industrial_Master_Id { get; set; }

        public int Industrial_Category_Id { get; set; }

        public int Industrial_Group_Id { get; set; }

        public string Industrial_SubGrp_Name { get; set; }

        public string Size { get; set; }

        public string COD { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }

        #region Additional Fields

        public string Industrial_Category_Name { get; set; }

        public string Industrial_Group_Name { get; set; }

        #endregion
    }
}
