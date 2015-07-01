using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
   public class QualityRepo
    {
       
            SQLHelperRepo _sqlRepo;

            public QualityRepo()
            {
                _sqlRepo = new SQLHelperRepo();
            }

            public int Insert_Quality(QualityInfo quality)
            {
                int Quality_Application_Id = 0;

                Quality_Application_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Quality(quality), StoredProcedures.Insert_Quality_Sp.ToString(), CommandType.StoredProcedure));

                return Quality_Application_Id;
            }

            public void Update_Quality(QualityInfo quality)
            {
                _sqlRepo.ExecuteNonQuery(Set_Values_In_Quality(quality), StoredProcedures.Update_Quality_Sp.ToString(), CommandType.StoredProcedure);
            }

            private List<SqlParameter> Set_Values_In_Quality(QualityInfo quality)
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@Yarn_Type_Id", quality.Yarn_Type_Id));
                sqlParamList.Add(new SqlParameter("@Reed", quality.Reed));
                sqlParamList.Add(new SqlParameter("@Pick", quality.Pick));
                sqlParamList.Add(new SqlParameter("@Weave", quality.Weave));
                sqlParamList.Add(new SqlParameter("@Minimum_Order_Size", quality.Minimum_Order_Size));
                sqlParamList.Add(new SqlParameter("@Ideal_Roll_Length", quality.Ideal_Roll_Length));
                sqlParamList.Add(new SqlParameter("@Our_Sample_No", quality.Our_Sample_No));
                sqlParamList.Add(new SqlParameter("@Quality_No", quality.Quality_No));
                sqlParamList.Add(new SqlParameter("@Status", quality.Status));
                sqlParamList.Add(new SqlParameter("@UpdatedOn", quality.UpdatedOn));
                sqlParamList.Add(new SqlParameter("@UpdatedBy", quality.UpdatedBy));
              
                if (quality.Quality_Id == 0)
                {
                    sqlParamList.Add(new SqlParameter("@CreatedBy", quality.CreatedBy));
                    sqlParamList.Add(new SqlParameter("@CreatedOn", quality.CreatedOn));
                }

                if (quality.Quality_Id != 0)
                {
                    sqlParamList.Add(new SqlParameter("@Quality_Id", quality.Quality_Id));
                }

                return sqlParamList;
            }

            public List<QualityInfo> Get_Qualities(ref PaginationInfo pager)
            {
                List<QualityInfo> qualities = new List<QualityInfo>();

                DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Quality_Sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    qualities.Add(Get_Quality_Values(dr));
                }
                
                return qualities;
            }

            public QualityInfo Get_Quality_By_Id(int Quality_Id)
            {
                QualityInfo quality = new QualityInfo();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Quality_Id", Quality_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_By_Id_Sp.ToString(), CommandType.StoredProcedure);

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    quality = Get_Quality_Values(dr);
                }
                return quality;
            }

            private QualityInfo Get_Quality_Values(DataRow dr)
            {
                QualityInfo quality = new QualityInfo();
               
                quality.Quality_Id = Convert.ToInt32(dr["Quality_Id"]);

                if (dr["Yarn_Type_Id"] != DBNull.Value)
                {
                  quality.Yarn_Type_Id = Convert.ToInt32(dr["Yarn_Type_Id"]);
                
                }
                else
                {
                    quality.Yarn_Type_Id = 0;
                }
               
                quality.Yarn_Type_Name = Convert.ToString(dr["Attribute_Code_Name"]);
               
                quality.Reed = Convert.ToString(dr["Reed"]);
              
                quality.Pick = Convert.ToString(dr["Pick"]);

                if (dr["Weave"] != DBNull.Value)
                {
                    quality.Weave = Convert.ToInt32(dr["Weave"]);

                }
                else
                {
                    quality.Weave = 0;
                }

                if (dr["Minimum_Order_Size"] != DBNull.Value)
                {
                    quality.Minimum_Order_Size = Convert.ToInt32(dr["Minimum_Order_Size"]);
                }
                else
                {
                    quality.Minimum_Order_Size = 0;
                }
               
                if (dr["Ideal_Roll_Length"] != DBNull.Value)
                {
                    quality.Ideal_Roll_Length = Convert.ToInt32(dr["Ideal_Roll_Length"]);
                }
                else
                {
                    quality.Ideal_Roll_Length = 0;
                }

                if (dr["Our_Sample_No"] != DBNull.Value)
                {
                    quality.Our_Sample_No = Convert.ToInt32(dr["Our_Sample_No"]);
                }
                else
                {
                    quality.Our_Sample_No = 0;
                }

                if (dr["Quality_No"] != DBNull.Value)
                {
                    quality.Quality_No = Convert.ToInt32(dr["Quality_No"]);
                }
                else
                {
                    quality.Quality_No = 0;
                }

                quality.Status = Convert.ToBoolean(dr["Status"]);
                
                quality.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
               
                quality.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                
                quality.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                
                quality.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                
                return quality;
            }

            public List<AttributeCodeInfo> Get_Yarn_Types()
            {
                List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();

                DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Yarn_Types_sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;
                    
                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    foreach (DataRow dr in drList)
                    {
                        AttributeCodeInfo yarnTypes= new AttributeCodeInfo();

                        yarnTypes.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

                        yarnTypes.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

                        retVal.Add(yarnTypes);

                    }

                }

                return retVal;
            }

            public List<QualityInfo> Get_Quality_By_Yarn_Types(int attributeCodeId, ref PaginationInfo pager)
            {
                List<QualityInfo> retVal = new List<QualityInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Attribute_Code_Id", attributeCodeId));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_By_Yarn_Types_Sp.ToString(), CommandType.StoredProcedure);

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {

                    retVal.Add(Get_Quality_Values(dr));
                }
                return retVal;
            }

            public List<AttributeCodeInfo> Get_Weave_Types()
            {
                List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();

                DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Weaves_Types_sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    foreach (DataRow dr in drList)
                    {
                        AttributeCodeInfo yarnTypes = new AttributeCodeInfo();

                        yarnTypes.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

                        yarnTypes.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

                        retVal.Add(yarnTypes);

                    }

                }

                return retVal;
            }

            public List<AutocompleteInfo> Get_Application_Name_AutoComplete(string applicationName)
            {
                List<AutocompleteInfo> applicationNames = new List<AutocompleteInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Application_Name", applicationName));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Application_AutoComplete_sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        AutocompleteInfo auto = new AutocompleteInfo();

                        auto.Label = Convert.ToString(dr["Application_Name"]);

                        auto.Value = Convert.ToInt32(dr["Application_Id"]);

                        applicationNames.Add(auto);
                    }
                }

                return applicationNames;
            }

            public void Insert_Application(QualityApplicationMappingInfo qualityApplications)
            {
                _sqlRepo.ExecuteNonQuery(Set_Values_In_Applications(qualityApplications), StoredProcedures.Insert_Application_sp.ToString(), CommandType.StoredProcedure);
            }

            private List<SqlParameter> Set_Values_In_Applications(QualityApplicationMappingInfo qualityApplications)
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@Quality_Id", qualityApplications.Quality_Id));
                sqlParamList.Add(new SqlParameter("@Application_Name_Id", qualityApplications.Application_Name_Id));

                if (qualityApplications.Quality_Application_Id == 0)
                {
                    sqlParamList.Add(new SqlParameter("@CreatedBy", qualityApplications.CreatedBy));
                }
                sqlParamList.Add(new SqlParameter("@UpdatedBy", qualityApplications.UpdatedBy));

                if (qualityApplications.Quality_Application_Id != 0)
                {
                    sqlParamList.Add(new SqlParameter("@Quality_Appication_Id)", qualityApplications.Quality_Application_Id));
                }

                return sqlParamList;
            }

            public void Delete_Quality_Application_By_Id(int quality_Application_Id)
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@Quality_Application_Id", quality_Application_Id));

                _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Quality_Application_By_Id.ToString(), CommandType.StoredProcedure);
            }

            public List<QualityApplicationMappingInfo> Get_Quality_Application_By_Id(int quality_Id)
            {
                List<QualityApplicationMappingInfo> qualityApplication = new List<QualityApplicationMappingInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_Application_sp.ToString(), CommandType.StoredProcedure);


                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    foreach (DataRow dr in drList)
                    {
                        qualityApplication.Add(Get_Quality_Application_Values(dr));

                    }
                }

                return qualityApplication;

            }

            private QualityApplicationMappingInfo Get_Quality_Application_Values(DataRow dr)
            {
                QualityApplicationMappingInfo qualityApplication= new QualityApplicationMappingInfo();

                qualityApplication.Quality_Application_Id = Convert.ToInt32(dr["Quality_Application_Id"]);
                qualityApplication.Application_Name = Convert.ToString(dr["Application_Name"]);

                return qualityApplication;
          }

            public List<QualityMarketSegmentMappingInfo> Get_Quality_Market_Segment_By_Id(int quality_Id)
            {
                List<QualityMarketSegmentMappingInfo> qualityMarketSegement = new List<QualityMarketSegmentMappingInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Quality_Id", quality_Id));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_Market_Segment_sp.ToString(), CommandType.StoredProcedure);


                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    foreach (DataRow dr in drList)
                    {
                        qualityMarketSegement.Add(Get_Quality_Market_Segment_Mapping_Values(dr));

                    }
                }

                return qualityMarketSegement;

            }

            private QualityMarketSegmentMappingInfo Get_Quality_Market_Segment_Mapping_Values(DataRow dr)
            {
                QualityMarketSegmentMappingInfo qualityMarketSegment = new QualityMarketSegmentMappingInfo();

                qualityMarketSegment.Quality_Market_Segment_Id = Convert.ToInt32(dr["Quality_Market_Segment_Id"]);
                qualityMarketSegment.Segment_Name = Convert.ToString(dr["Market_Segment_Name"]);

                return qualityMarketSegment;
            }

            public void Insert_Segment(QualityMarketSegmentMappingInfo qualityMarketSegments)
            {
                _sqlRepo.ExecuteNonQuery(Set_Values_In_Segments(qualityMarketSegments), StoredProcedures.Insert_Segment_sp.ToString(), CommandType.StoredProcedure);
            }

            private List<SqlParameter> Set_Values_In_Segments(QualityMarketSegmentMappingInfo qualityMarketSegments)
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@Quality_Id", qualityMarketSegments.Quality_Id));
               
                sqlParamList.Add(new SqlParameter("@Market_Segment_Id", qualityMarketSegments.Market_Segment_Id));

                if (qualityMarketSegments.Quality_Market_Segment_Id == 0)
                {
                    sqlParamList.Add(new SqlParameter("@CreatedBy", qualityMarketSegments.CreatedBy));
                }
                sqlParamList.Add(new SqlParameter("@UpdatedBy", qualityMarketSegments.UpdatedBy));

                if (qualityMarketSegments.Quality_Market_Segment_Id != 0)
                {
                    sqlParamList.Add(new SqlParameter("@Quality_Market_Segment_Id)", qualityMarketSegments.Quality_Market_Segment_Id));
                }

                return sqlParamList;
            }

            public void Delete_Quality_Market_Segment_By_Id(int quality_Market_Segment_Id)
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@Quality_Market_Segment_Id", quality_Market_Segment_Id));

                _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Quality_Market_Segment_By_Id_sp.ToString(), CommandType.StoredProcedure);
            }

            public List<AutocompleteInfo> Get_Segment_Name_AutoComplete(string segmentName)
            {
                List<AutocompleteInfo> segmentNames = new List<AutocompleteInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Market_Segment_Name",segmentName));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Segment_AutoComplete_sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        AutocompleteInfo auto = new AutocompleteInfo();

                        auto.Label = Convert.ToString(dr["Market_Segment_Name"]);

                        auto.Value = Convert.ToInt32(dr["Market_Segment_Id"]);

                        segmentNames.Add(auto);
                    }
                }

                return segmentNames;
            }

            public List<QualityInfo> Get_Grid_By_Yarn_Type(int attributeCodeId)
            {
                List<QualityInfo> retVal = new List<QualityInfo>();

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Attribute_Code_Id", attributeCodeId));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Quality_By_Yarn_Types_Sp.ToString(), CommandType.StoredProcedure);


                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    foreach (DataRow dr in drList)
                    {
                        retVal.Add(Get_Quality_Values(dr));
                    }
                }
                return retVal;

            }

            public bool Check_Existing_Quality_No(int quality_No)
            {
                bool check = false;

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Quality_No", quality_No));

                DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Check_Existing_Quality_No_Sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = dt.Rows.Count;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        check = Convert.ToBoolean(dr["check_Quality"]);
                    }
                }

                return check;
            }

   }

}
