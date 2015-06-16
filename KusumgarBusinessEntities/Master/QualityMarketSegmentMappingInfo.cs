using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
   public class QualityMarketSegmentMappingInfo 
    {
        public int Quality_Market_Segment_Id { get; set; }

        public int Quality_Id { get; set; }

        public int Market_Segment_Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Additional Fields

        public string Segment_Name { get; set; }

        #endregion
    }
}
