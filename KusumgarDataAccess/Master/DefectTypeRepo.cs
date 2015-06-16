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
        SQLHelperRepo _sqlRepo;

        public DefectTypeRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<DefectTypeInfo> Get_Defect_Types(ref PaginationInfo pager)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Defect_Types_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                retVal.Add(Get_Defect_Type_Values(dr));
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
                    retVal=(Get_Defect_Type_Values(dr));
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
            
            sqlParamList.Add(new SqlParameter("@Defect_Type_Name", defectInfo.Defect_Type_Name));
            
            sqlParamList.Add(new SqlParameter("@Status", defectInfo.Status));
            
            sqlParamList.Add(new SqlParameter("@UpdatedBy", defectInfo.UpdatedBy));
            
            if (defectInfo.Defect_Type_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", defectInfo.CreatedBy));
            }
            if (defectInfo.Defect_Type_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Defect_Type_Id", defectInfo.Defect_Type_Id));
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

        public List<DefectTypeInfo> Get_Defect_Types_By_Id(int Defect_Type_Id, ref PaginationInfo pager)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_Type_By_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
             {
                 retVal.Add(Get_Defect_Type_Values(dr));
             }
                return retVal;
        }

        private DefectTypeInfo Get_Defect_Type_Values(DataRow dr)
        {
            DefectTypeInfo defectTypes = new DefectTypeInfo();
            
            defectTypes.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);

            defectTypes.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);

            defectTypes.Status = Convert.ToBoolean(dr["Status"]);

            defectTypes.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            defectTypes.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            defectTypes.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            defectTypes.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            return defectTypes;
        }
          
        }
 }


