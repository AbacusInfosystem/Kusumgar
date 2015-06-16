using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class WArticleInfo
    {
        public WArticleInfo()
        {

        }

        public int W_Article_Id { get; set; }

        public int Quality_Id { get; set; }

        public int Yarn_Type_Id { get; set; }

        public decimal Reed_Space_Inch { get; set; }

        public decimal Total_No_Of_Ends { get; set; }

        public string Full_Code { get; set; }

        public string Ideal_Beam { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Addition

        public int Quality_No { get; set; }

        public string Yarn_Type_Name { get; set; }

        #endregion
    }
}
