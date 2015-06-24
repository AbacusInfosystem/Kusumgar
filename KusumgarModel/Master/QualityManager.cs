using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;


namespace KusumgarModel
{
  public  class QualityManager
    {

      QualityRepo _qualityRepo;

            public QualityManager()
            {
                _qualityRepo = new QualityRepo();
            }

            public int Insert_Quality(QualityInfo quality)
            {
               return  _qualityRepo.Insert_Quality(quality);
            }

            public void Update_Quality(QualityInfo quality)
            {
                _qualityRepo.Update_Quality(quality);
            }

            public List<QualityInfo> Get_Qualities(ref PaginationInfo pager)
            {
                return _qualityRepo.Get_Qualities(ref pager);
            }

            public QualityInfo Get_Quality_By_Id(int Quality_Id)
            {
                return _qualityRepo.Get_Quality_By_Id(Quality_Id);
            }

            public List<AttributeCodeInfo> Get_Yarn_Types()
            {
                return _qualityRepo.Get_Yarn_Types();
            }
            
            public List<QualityInfo> Get_Quality_By_Yarn_Types(int attributeCodeId, ref PaginationInfo pager)
            {
                return _qualityRepo.Get_Quality_By_Yarn_Types(attributeCodeId,ref pager);
            }

            public List<AttributeCodeInfo> Get_Weave_Types()
            {
                return _qualityRepo.Get_Weave_Types();
            }

            public List<AutocompleteInfo> Get_Application_Name_AutoComplete(string applicationName)
            {

                return _qualityRepo.Get_Application_Name_AutoComplete(applicationName);
            }

            public void Insert_Application(QualityApplicationMappingInfo qualityApplications)
            {
                _qualityRepo.Insert_Application(qualityApplications);
            }
           
            public void Delete_Quality_Application_By_Id(int quality_Application_Id)
            {
                _qualityRepo.Delete_Quality_Application_By_Id(quality_Application_Id);
            }

            public List<QualityApplicationMappingInfo> Get_Quality_Application_By_Id(int quality_Id)
            {

                return _qualityRepo.Get_Quality_Application_By_Id(quality_Id);

            }

            public List<AutocompleteInfo> Get_Segment_Name_AutoComplete(string segmentName)
            {

                return _qualityRepo.Get_Segment_Name_AutoComplete(segmentName);
            }

            public void Insert_Segment(QualityMarketSegmentMappingInfo qualityMarketSegments)
            {
                _qualityRepo.Insert_Segment(qualityMarketSegments);
            }

            public void Delete_Quality_Market_Segment_By_Id(int quality_Market_Segment_Id)
            {
                _qualityRepo.Delete_Quality_Market_Segment_By_Id(quality_Market_Segment_Id);
            }

            public List<QualityMarketSegmentMappingInfo> Get_Quality_Market_Segment_By_Id(int quality_Id)
            {

                return _qualityRepo.Get_Quality_Market_Segment_By_Id(quality_Id);

            }

            public List<QualityInfo> Get_Grid_By_Yarn_Type(int attributeCodeId)
            {
                return _qualityRepo.Get_Grid_By_Yarn_Type(attributeCodeId);
            }

            public bool Check_Existing_Quality_No(int quality_No)
            {
                return _qualityRepo.Check_Existing_Quality_No(quality_No);
            }
  
       }
    }
