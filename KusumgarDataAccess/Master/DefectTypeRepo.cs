using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;

namespace KusumgarDataAccess
{
    public class DefectTypeRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public DefectTypeRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<DefectTypeInfo> Get_Defect_Types(PaginationInfo Pager)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Defect_Types_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, Pager);

            foreach (DataRow dr in tupleData.Item1)
            {
                DefectTypeInfo defectTypes = new DefectTypeInfo();

                defectTypes.DefectTypeEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);

                defectTypes.DefectTypeEntity.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);

                defectTypes.DefectTypeEntity.Status = Convert.ToBoolean(dr["Status"]);

                defectTypes.DefectTypeEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                defectTypes.DefectTypeEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                defectTypes.DefectTypeEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                defectTypes.DefectTypeEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                retVal.Add(defectTypes);
            }

            return retVal;
        }

        private Tuple<List<DataRow>, PaginationInfo> GetRows(DataTable dt, PaginationInfo pager)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (pager.IsPagingRequired)
                {
                    drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                }

                pager.TotalRecords = count;

                int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

                pager.TotalPages = pages;
            }

            return new Tuple<List<DataRow>, PaginationInfo>(drList, pager);
        }

        public List<DefectTypeInfo> Get_Defect_Type_By_Name(string Defect_Type_Name,PaginationInfo Pager)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

               List<SqlParameter> sqlParams = new List<SqlParameter>();

              sqlParams.Add(new SqlParameter("@Defect_Type_Name", Defect_Type_Name));

              DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_Type_By_Name_sp.ToString(), CommandType.StoredProcedure);

              var tupleData = GetRows(dt, Pager);

              foreach (DataRow dr in tupleData.Item1)
                  {
                      DefectTypeInfo defectTypes = new DefectTypeInfo();

                      defectTypes.DefectTypeEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                      
                      defectTypes.DefectTypeEntity.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                      
                      defectTypes.DefectTypeEntity.Status = Convert.ToBoolean(dr["Status"]);
                      
                      defectTypes.DefectTypeEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                      
                      defectTypes.DefectTypeEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                      
                      defectTypes.DefectTypeEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                      
                      defectTypes.DefectTypeEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                      
                      retVal.Add(defectTypes);
                  }
             
              return retVal;
        }

        public DefectTypeInfo Get_Defects_Type_By_Id(int Defect_Type_Id)
        {
            DefectTypeInfo retVal = new DefectTypeInfo();
           
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_Type_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal.DefectTypeEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    retVal.DefectTypeEntity.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    retVal.DefectTypeEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    retVal.DefectTypeEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    retVal.DefectTypeEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    retVal.DefectTypeEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                    
                    retVal.DefectTypeEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                 }
              }
            return retVal;
        }

        public void Insert(DefectTypeInfo defectTypes)
        {
             _sqlRepo.ExecuteNonQuery(Set_Values_In_Defect_Type(defectTypes), StoredProcedures.Insert_Defect_Type_sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update(DefectTypeInfo defectTypes)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Defect_Type(defectTypes), StoredProcedures.Update_Defect_Type_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Defect_Type(DefectTypeInfo defectInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            
            sqlParamList.Add(new SqlParameter("@Defect_Type_Name", defectInfo.DefectTypeEntity.Defect_Type_Name));
            
            sqlParamList.Add(new SqlParameter("@Status", defectInfo.DefectTypeEntity.Status));
            
            sqlParamList.Add(new SqlParameter("@UpdatedBy", defectInfo.DefectTypeEntity.UpdatedBy));
            
            if (defectInfo.DefectTypeEntity.Defect_Type_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", defectInfo.DefectTypeEntity.CreatedBy));
            }
            if (defectInfo.DefectTypeEntity.Defect_Type_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Defect_Type_Id", defectInfo.DefectTypeEntity.Defect_Type_Id));
            }
             return sqlParamList;
        }

        public List<AutocompleteInfo> Get_Defect_Type_AutoComplete(string defect_Type_Name)
        {
            List<AutocompleteInfo> defectTypeName = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Name", defect_Type_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_Type_AutoComplete_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Defect_Type_Name"]);

                    auto.Value = Convert.ToInt32(dr["Defect_Type_Id"]);

                    defectTypeName.Add(auto);
                }
            }

            return defectTypeName;
        }

        public List<DefectTypeInfo> Get_Defect_Types_By_Id(int Defect_Type_Id, PaginationInfo Pager)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_Type_By_Id_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, Pager);

                foreach (DataRow dr in tupleData.Item1)
                {
                    DefectTypeInfo defectTypes = new DefectTypeInfo();

                    defectTypes.DefectTypeEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);

                    defectTypes.DefectTypeEntity.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);

                    defectTypes.DefectTypeEntity.Status = Convert.ToBoolean(dr["Status"]);

                    defectTypes.DefectTypeEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    defectTypes.DefectTypeEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                    defectTypes.DefectTypeEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    defectTypes.DefectTypeEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    retVal.Add(defectTypes);
                }
                return retVal;
            }
          
        }

    }


