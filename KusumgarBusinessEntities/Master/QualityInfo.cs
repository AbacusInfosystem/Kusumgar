using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class QualityInfo
    {
        public int Quality_Id { get; set; }

        public int Yarn_Type_Id { get; set; }

        public string Reed { get; set; }

        public string Pick { get; set; }

        public int Weave { get; set; }

        public int Minimum_Order_Size { get; set; }

        public int Ideal_Roll_Length { get; set; }

        public int Our_Sample_No { get; set; }

        public int Quality_No { get; set; }

        public bool Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        #region Additional Fields

        public string Yarn_Type { get; set; }

        public string Weave_Name { get; set; }

        #endregion

    }
}
