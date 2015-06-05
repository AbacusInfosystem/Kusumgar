using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
 public class DefectRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public DefectRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }
       
        public List<DefectInfo> Get_Defects(ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Defects_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    defects.Add(Get_Defect_Values(dr));
                }
         
            return defects;
        }

        public List<DefectTypeInfo> Get_Defect_Type()
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.List_Defect_Types_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    DefectTypeInfo defectTypes= new DefectTypeInfo();
                    
                    defectTypes.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    defectTypes.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    retVal.Add(defectTypes);
                }

            }

            return retVal;
       }

        public DefectInfo Get_Defects_By_Id(int Defect_Id)
        {
            DefectInfo defects = new DefectInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Id", Defect_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    defects = Get_Defect_Values(dr);
                }

            } 
            return defects;
        }

        public List<DefectInfo> Get_Defect_By_Type(int Defect_Type_Id, ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Type_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    defects.Add(Get_Defect_Values(dr));
                }

            return defects;
        }
      
        public List<DefectInfo> Get_Defect_By_Type_By_Name(int Defect_Type_Id,int Defect_Id,ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            sqlParams.Add(new SqlParameter("@Defect_Id", Defect_Id));
            
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Name_By_Type_sp.ToString(), CommandType.StoredProcedure);

             foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                   
                    defects.Add(Get_Defect_Values(dr));
                }

           
         return defects;
  }

        public void Insert(DefectInfo defects)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Defects(defects), StoredProcedures.Insert_Defect_sp.ToString(), CommandType.StoredProcedure);
       }

        public void Update(DefectInfo defects)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Defects(defects), StoredProcedures.Update_Defect_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Defects(DefectInfo defects)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Defect_Name", defects.Defect_Name));

            sqlParamList.Add(new SqlParameter("@Defect_Type_Id", defects.Defect_Type_Id));

            sqlParamList.Add(new SqlParameter("@Defect_Code", defects.Defect_Code));

            sqlParamList.Add(new SqlParameter("@Status", defects.Status));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", defects.UpdatedBy));
            
            if (defects.Defect_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", defects.CreatedBy));
            }
            if (defects.Defect_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Defect_Id", defects.Defect_Id));
            }

            return sqlParamList;
        }

        public List<DefectInfo> Get_Grid_By_Defect_Type(int Defect_Type_Id)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Type_sp.ToString(), CommandType.StoredProcedure);

          
           if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    defects.Add(Get_Defect_Values(dr));
                }
            }
           return defects;
           
        }

        public List<DefectInfo> Get_Defects_By_Name(int Defect_Id, ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Id", Defect_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                defects.Add(Get_Defect_Values(dr));
            }
            return defects;
        }

        private DefectInfo Get_Defect_Values(DataRow dr)
        {
            DefectInfo defects = new DefectInfo();

            defects.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);

            defects.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);

            defects.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);

            defects.Defect_Code = Convert.ToString(dr["Defect_Code"]);

            defects.Defect_Name = Convert.ToString(dr["Defect_Name"]);

            defects.Status = Convert.ToBoolean(dr["Status"]);

            defects.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            defects.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            defects.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            defects.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
           
            return defects;
        }

        public List<AutocompleteInfo> Get_Defect_AutoComplete(string defect_Name)
        {
            List<AutocompleteInfo> defectName = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Name", defect_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_AutoComplete_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Defect_Name"]);

                    auto.Value = Convert.ToInt32(dr["Defect_Id"]);

                    defectName.Add(auto);
                }
            }

            return defectName;
        }
    }
}
