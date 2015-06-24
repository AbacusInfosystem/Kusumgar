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
    public class ProcessRepo
    {        
        SQLHelperRepo _sqlRepo;
        
        public ProcessRepo()
        {            
            _sqlRepo = new SQLHelperRepo();            
        }

        public void Insert_Process(ProcessInfo ProcessInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Process(ProcessInfo), StoredProcedures.Insert_Process_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Process(ProcessInfo ProcessInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Process(ProcessInfo), StoredProcedures.Update_Process_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Process(ProcessInfo ProcessInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (ProcessInfo.Process_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Process_Id", ProcessInfo.Process_Id));
            }
            sqlParams.Add(new SqlParameter("@Process_Name", ProcessInfo.Process_Name));
            sqlParams.Add(new SqlParameter("@Is_Active", ProcessInfo.Is_Active));            
            if (ProcessInfo.Process_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedOn", ProcessInfo.CreatedOn));
                sqlParams.Add(new SqlParameter("@CreatedBy", ProcessInfo.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@UpdatedOn", ProcessInfo.UpdatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", ProcessInfo.UpdatedBy));
            return sqlParams;
        }

        public List<ProcessInfo> Get_Process(ref PaginationInfo pager)
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Process_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                processes.Add(Get_Process_Values(dr));
            }
            return processes;
        }

        public ProcessInfo Get_Process_By_Process_Id(int process_Id)
        {
            ProcessInfo process = new ProcessInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Process_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    process = Get_Process_Values(dr);
                }
            }
            return process;
        }        

        private ProcessInfo Get_Process_Values(DataRow dr)
        {
            ProcessInfo process = new ProcessInfo();
            process.Process_Id = Convert.ToInt32(dr["Process_Id"]);
            process.Process_Name = Convert.ToString(dr["Process_Name"]);
            process.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            process.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            process.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            process.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            process.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return process;
        }

        public List<AutocompleteInfo> Get_Process_By_Name_Autocomplete(string process_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Process_Name", process_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Process_By_Process_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Process_Name"]);
                    auto.Value = Convert.ToInt32(dr["Process_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public List<ProcessInfo> Get_Process_By_Id(int process_Id, ref PaginationInfo pager)
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Process_By_Id_Sp.ToString(), CommandType.StoredProcedure);            
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                processes.Add(Get_Process_Values(dr));
            }
            return processes;
        }
    }
}
