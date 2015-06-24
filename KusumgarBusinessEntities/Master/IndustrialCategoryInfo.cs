using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class IndustrialCategoryInfo
    {
        //public M_Industrial_Category Industrial_Category_Entity { get; set; }

        public IndustrialCategoryInfo()
        {
            //Industrial_Category_Entity = new M_Industrial_Category();
        }

        public int Industrial_Category_Id { get; set; }

        public string Industrial_Category_Name { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDtm { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDtm { get; set; }

    }
}
