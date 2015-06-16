using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CArticleInfo
    {
        public CArticleInfo()
        {

        }

        public int C_Article_Id { get; set; }

        public int Quality_Id { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int Weave_Id { get; set; }

        public int Shade_Id { get; set; }

        public int Chemical_Finish_Id { get; set; }

        public int Mechanical_Finish_Id { get; set; }

        public int Type_Id { get; set; }

        public decimal C_Finish_Width { get; set; }

        public string Coat { get; set; }

        public string C_gsm { get; set; }

        public string Full_Code { get; set; }

        public string Batch { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Addition

        public int Quality_No { get; set; }

        public string Yarn_Type_Name { get; set; }

        public string Weave_Name { get; set; }

        public string Shade_Name { get; set; }

        public string Chemical_Finish_Name { get; set; }

        public string Mechanical_Finish_Name { get; set; }

        public string Type_Name { get; set; }

        #endregion
    }
}
