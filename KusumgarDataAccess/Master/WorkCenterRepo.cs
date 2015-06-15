using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class WorkCenterRepo
    {
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public WorkCenterRepo()
        {
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<FactoryInfo> Get_Factories(ref PaginationInfo pager)
        {
            List<FactoryInfo> factories = new List<FactoryInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Factories_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    FactoryInfo factory = new FactoryInfo();

                    factory.Factory_Entity.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);
                    factory.Factory_Entity.Factory_Name = Convert.ToString(dr["Factory_Name"]);

                    factories.Add(factory);
                }
            }

            return factories;
        }

        public List<WorkStationInfo> Get_Work_Stations(ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Work_Stations_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    WorkStationInfo work_Station = new WorkStationInfo();

                    work_Station.Work_Station_Entity.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
                    work_Station.Work_Station_Entity.Work_Station_Name = Convert.ToString(dr["Work_Station_Name"]);

                    work_Stations.Add(work_Station);
                }
            }

            return work_Stations;
        }

        public List<ProcessInfo> Get_Processes(ref PaginationInfo pager)
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Processes_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    ProcessInfo process = new ProcessInfo();

                    process.Process_Entity.Process_Id = Convert.ToInt32(dr["Process_Id"]);
                    process.Process_Entity.Process_Name = Convert.ToString(dr["Process_Name"]);

                    processes.Add(process);
                }
            }

            return processes;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Factory_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    WorkStationInfo work_Station = new WorkStationInfo();

                    work_Station.Work_Station_Entity.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
                    work_Station.Work_Station_Entity.Work_Station_Name = Convert.ToString(dr["Work_Station_Name"]);

                    work_Stations.Add(work_Station);
                }
            }

            return work_Stations;
        }

        public int Insert_Work_Center(WorkCenterInfo work_Center)
        {
            int work_Center_Id = 0;

            work_Center_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Work_Center(work_Center), StoredProcedures.Insert_Work_Center_sp.ToString(), CommandType.StoredProcedure));

            if (!string.IsNullOrEmpty(work_Center.Process_Ids))
            { 
                Insert_Work_Center_Process(work_Center.Process_Ids, work_Center_Id);
            }

            return work_Center_Id;
        }

        public void Update_Work_Center(WorkCenterInfo work_Center)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Work_Center(work_Center), StoredProcedures.Update_Work_Center_sp.ToString(), CommandType.StoredProcedure);

            if (!string.IsNullOrEmpty(work_Center.Process_Ids))
            {
                Insert_Work_Center_Process(work_Center.Process_Ids, work_Center.Work_Center_Entity.Work_Center_Id);
            }
           
        }

        public void Insert_Work_Center_Process(string Process_Ids, int work_Center_Id)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            _sqlRepo.ExecuteNonQuery(sqlParam, StoredProcedures.Delete_Work_Center_Process_By_Work_Center_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (var item in Process_Ids.Split(','))
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                DateTime CreatedOn = DateTime.Now;
                int CreatedBy = 1;

                sqlparam.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));
                sqlparam.Add(new SqlParameter("@Process_Id", item));
                sqlparam.Add(new SqlParameter("@CreatedOn", CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", CreatedBy));

                _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Insert_Work_Center_Process_sp.ToString(), CommandType.StoredProcedure);
            }

        }

        private List<SqlParameter> Set_Values_In_Work_Center(WorkCenterInfo work_Center)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (work_Center.Work_Center_Entity.Work_Center_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Work_Center_Id", work_Center.Work_Center_Entity.Work_Center_Id));
            }
            sqlparam.Add(new SqlParameter("@Work_Station_Id", work_Center.Work_Station.Work_Station_Entity.Work_Station_Id));
            //sqlparam.Add(new SqlParameter("@Work_Station_Id", work_Center.Work_Center_Entity.Work_Station_Id));
            sqlparam.Add(new SqlParameter("@Work_Center_Code", work_Center.Work_Center_Entity.Work_Center_Code));
            sqlparam.Add(new SqlParameter("@Machine_Name", work_Center.Work_Center_Entity.Machine_Name));
            sqlparam.Add(new SqlParameter("@Machine_Properties", work_Center.Work_Center_Entity.Machine_Properties));
            sqlparam.Add(new SqlParameter("@TPM_Speed", work_Center.Work_Center_Entity.TPM_Speed));
            sqlparam.Add(new SqlParameter("@Average_Order_Length", work_Center.Work_Center_Entity.Average_Order_Length));
            sqlparam.Add(new SqlParameter("@Capacity", work_Center.Work_Center_Entity.Capacity));
            sqlparam.Add(new SqlParameter("@Wastage", work_Center.Work_Center_Entity.Wastage));
            sqlparam.Add(new SqlParameter("@Target_Efficiency", work_Center.Work_Center_Entity.Target_Efficiency));
            sqlparam.Add(new SqlParameter("@Under_Maintainance", work_Center.Work_Center_Entity.Under_Maintainance));
            sqlparam.Add(new SqlParameter("@Is_Active", work_Center.Work_Center_Entity.Is_Active));

            if (work_Center.Work_Center_Entity.Work_Center_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedOn", work_Center.Work_Center_Entity.CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", work_Center.Work_Center_Entity.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedOn", work_Center.Work_Center_Entity.UpdatedOn));
            sqlparam.Add(new SqlParameter("@UpdatedBy", work_Center.Work_Center_Entity.UpdatedBy));

            return sqlparam;
        }

        public List<WorkCenterInfo> Get_Work_Centers(ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Work_Centers_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    work_Centers.Add(Get_Work_Center_Values(dr));
                }
            }

            return work_Centers;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Factory_Id_Sp.ToString(), CommandType.StoredProcedure);
            
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Work_Station_Id(int work_Station_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Work_Station_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Process_Id(int process_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Station_Id(int factory_Id, int work_Station_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }
        
        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Process_Id(int factory_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Factory_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Work_Station_Id_By_Work_Process_Id(int work_Station_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Work_Station_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }
        
        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_By_Process_Id(int factory_Id, int work_Station_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Centers.Add(Get_Work_Center_Values(dr));
            }

            return work_Centers;
        }

        private WorkCenterInfo Get_Work_Center_Values(DataRow dr)
        {
            WorkCenterInfo work_Center = new WorkCenterInfo();

            work_Center.Work_Center_Entity.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
            work_Center.Work_Center_Entity.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
            work_Center.Work_Center_Entity.Work_Center_Code = Convert.ToString(dr["Work_Center_Code"]);
            work_Center.Work_Center_Entity.Machine_Name = Convert.ToString(dr["Machine_Name"]);
            work_Center.Work_Center_Entity.Machine_Properties = Convert.ToString(dr["Machine_Properties"]);
            work_Center.Work_Center_Entity.TPM_Speed = Convert.ToInt32(dr["TPM_Speed"]);
            work_Center.Work_Center_Entity.Average_Order_Length = Convert.ToDecimal(dr["Average_Order_Length"]);
            work_Center.Work_Center_Entity.Capacity = Convert.ToString(dr["Capacity"]);
            work_Center.Work_Center_Entity.Wastage = Convert.ToInt32(dr["Wastage"]);
            work_Center.Work_Center_Entity.Target_Efficiency = Convert.ToInt32(dr["Target_Efficiency"]);
            work_Center.Work_Center_Entity.Under_Maintainance = Convert.ToBoolean(dr["Under_Maintainance"]);
            work_Center.Work_Center_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            work_Center.Work_Center_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            work_Center.Work_Center_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            work_Center.Work_Center_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            work_Center.Work_Center_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            work_Center.Work_Station.Work_Station_Entity.Work_Station_Name = Convert.ToString(dr["Work_Station_Name"]);
            work_Center.Factory.Factory_Entity.Factory_Name = Convert.ToString(dr["Factory_Name"]);
            //work_Center.Factory.Factory_Entity.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);

            return work_Center;
        }

        public WorkCenterInfo Get_Work_Centers_By_Work_Center_Id(int work_Center_Id)
        {
            WorkCenterInfo work_Center = new WorkCenterInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Work_Centers_By_Work_Center_Id_Sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            //DataTable dt1 = ds.Tables[1];
 
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    work_Center = Get_Work_Center_Values_By_Id(dr);

                }
            }

            return work_Center;
        }

        private WorkCenterInfo Get_Work_Center_Values_By_Id(DataRow dr)
        {
            WorkCenterInfo work_Center = new WorkCenterInfo();

            work_Center.Work_Center_Entity.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
            work_Center.Work_Center_Entity.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
            work_Center.Work_Center_Entity.Work_Center_Code = Convert.ToString(dr["Work_Center_Code"]);
            work_Center.Work_Center_Entity.Machine_Name = Convert.ToString(dr["Machine_Name"]);
            work_Center.Work_Center_Entity.Machine_Properties = Convert.ToString(dr["Machine_Properties"]);
            work_Center.Work_Center_Entity.TPM_Speed = Convert.ToInt32(dr["TPM_Speed"]);
            work_Center.Work_Center_Entity.Average_Order_Length = Convert.ToDecimal(dr["Average_Order_Length"]);
            work_Center.Work_Center_Entity.Capacity = Convert.ToString(dr["Capacity"]);
            work_Center.Work_Center_Entity.Wastage = Convert.ToInt32(dr["Wastage"]);
            work_Center.Work_Center_Entity.Target_Efficiency = Convert.ToInt32(dr["Target_Efficiency"]);
            work_Center.Work_Center_Entity.Under_Maintainance = Convert.ToBoolean(dr["Under_Maintainance"]);
            work_Center.Work_Center_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            work_Center.Work_Center_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            work_Center.Work_Center_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            work_Center.Work_Center_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            work_Center.Work_Center_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            work_Center.Work_Station.Work_Station_Entity.Work_Station_Name = Convert.ToString(dr["Work_Station_Name"]);
            work_Center.Work_Station.Work_Station_Entity.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);

            work_Center.Factory.Factory_Entity.Factory_Name = Convert.ToString(dr["Factory_Name"]);
            work_Center.Factory.Factory_Entity.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);
          
            return work_Center;
        }


        public List<WorkCenterProcessInfo> Get_Work_Center_Processes(int work_Center_Id, ref PaginationInfo pager)
        {
            List<WorkCenterProcessInfo> work_Center_Processes = new List<WorkCenterProcessInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Center_Processes_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                WorkCenterProcessInfo work_Center_Process = new WorkCenterProcessInfo();

                work_Center_Process.Work_Center_Process_Entity.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
                work_Center_Process.Work_Center_Process_Entity.Process_Id = Convert.ToInt32(dr["Process_Id"]);

                work_Center_Processes.Add(work_Center_Process);
            }

            return work_Center_Processes;
        }

    }
}
