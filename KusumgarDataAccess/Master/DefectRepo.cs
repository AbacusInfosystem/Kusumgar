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
        SQLHelperRepo _sqlRepo;

        public DefectRepo()
        {
            _sqlRepo = new SQLHelperRepo();
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
      
        public List<ProcessInfo> Get_Processes()
        {
            List<ProcessInfo> retVal = new List<ProcessInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Processes_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    ProcessInfo process= new ProcessInfo();

                    process.Process_Id = Convert.ToInt32(dr["Process_Id"]);

                    process.Process_Name = Convert.ToString(dr["Process_Name"]);

                    retVal.Add(process);
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

        public List<DefectInfo> Get_Defect_By_Process_Id(int Process_Id, ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Process_Id", Process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Process_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    defects.Add(Get_Defect_Values(dr));
                }

            return defects;
        }

        public List<DefectInfo> Get_Defect_By_Defect_Id_By_Process_Id(int Process_Id, int Defect_Id, ref PaginationInfo pager)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Process_Id", Process_Id));

            sqlParams.Add(new SqlParameter("@Defect_Id", Defect_Id));
            
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Defect_Name_By_Process_Name_sp.ToString(), CommandType.StoredProcedure);

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

            sqlParamList.Add(new SqlParameter("@Process_Id", defects.Process_Id));

            sqlParamList.Add(new SqlParameter("@Defect_Major", defects.Defect_Major));

            sqlParamList.Add(new SqlParameter("@Defect_Minor", defects.Defect_Minor));

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

        public List<DefectInfo> Get_Grid_By_Process_Id(int Process_Id)
        {
            List<DefectInfo> defects = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Process_Id", Process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Process_Id_sp.ToString(), CommandType.StoredProcedure);

          
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

            defects.Process_Id = Convert.ToInt32(dr["Process_Id"]);

            if (dr["Process_Name"] != DBNull.Value)
            {
                defects.Process_Name = Convert.ToString(dr["Process_Name"]);
            }
            else
            {
                defects.Process_Name = "";
            }

            if (dr["Defect_Major"] != DBNull.Value)
            {
                defects.Defect_Major = Convert.ToString(dr["Defect_Major"]);
            }
            else
            {
                defects.Defect_Major = "";
            }

            if (dr["Defect_Minor"] != DBNull.Value)
            {
                defects.Defect_Minor = Convert.ToString(dr["Defect_Minor"]);
            }
            else
            {
                defects.Defect_Minor = "";
            }

            if (dr["Defect_Name"] != DBNull.Value)
            {
                defects.Defect_Name = Convert.ToString(dr["Defect_Name"]);
            }
            else
            {
                defects.Defect_Name = "";
            }
           
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
