using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KusumgarBusinessEntities
{
  public  class MarketSegmentInfo 
    {
        public int Market_Segment_Id { get; set; }

        public string Market_Segment_Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
