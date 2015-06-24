using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class QualityViewModel
    {
        public QualityViewModel()
            {
                Friendly_Message = new List<FriendlyMessageInfo>();
                
                Pager = new PaginationInfo();
                
                Quality= new QualityInfo();

                Quality_Grid = new List<QualityInfo>();

                Filter = new Quality_Filter();

                Yarn_Types = new List<AttributeCodeInfo>();

                Weaves_Types = new List<AttributeCodeInfo>();

                Quality_Application_Mapping = new QualityApplicationMappingInfo();

                Quality_Application_Mapping_Grid = new List<QualityApplicationMappingInfo>();

                Application = new ApplicationInfo();

                Quality_Market_Segment_Mapping = new QualityMarketSegmentMappingInfo();

                Quality_Market_Segment_Mapping_Grid = new List<QualityMarketSegmentMappingInfo>();

                Market_Segment = new MarketSegmentInfo();
               
                
            }
           
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
           
        public PaginationInfo Pager { get; set; }
            
        public QualityInfo Quality { get; set; }
           
        public List<QualityInfo> Quality_Grid{ get; set; }

        public Quality_Filter Filter { get; set; }

        public List<AttributeCodeInfo> Yarn_Types { get; set; }

        public List<AttributeCodeInfo> Weaves_Types { get; set; }

        public QualityApplicationMappingInfo Quality_Application_Mapping { get; set; }

        public List<QualityApplicationMappingInfo> Quality_Application_Mapping_Grid { get; set; }

        public ApplicationInfo Application { get; set; }

        public QualityMarketSegmentMappingInfo Quality_Market_Segment_Mapping { get; set; }

        public List<QualityMarketSegmentMappingInfo> Quality_Market_Segment_Mapping_Grid { get; set; }

        public MarketSegmentInfo Market_Segment { get; set; }



    }

    public class Quality_Filter
    {
        public int Yarn_Type_Id { get; set; }

    }
}