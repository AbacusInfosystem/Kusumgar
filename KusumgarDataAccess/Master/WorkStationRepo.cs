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
    public class WorkStationRepo
    {
        SQLHelperRepo _sqlRepo;

        public WorkStationRepo()
        {
            _sqlRepo = new SQLHelperRepo();
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

                    factory.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);
                    factory.Factory_Name = Convert.ToString(dr["Factory_Name"]);

                    factories.Add(factory);
                }
            }

            return factories;
        }

        public List<WorkCenterInfo> Get_Work_Centers(ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Work_Centers_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    WorkCenterInfo work_Center = new WorkCenterInfo();

                    work_Center.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
                    work_Center.Work_Center_Name = Convert.ToString(dr["Work_Center_Name"]);

                    work_Centers.Add(work_Center);
                }
            }

            return work_Centers;
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

                    process.Process_Id = Convert.ToInt32(dr["Process_Id"]);
                    process.Process_Name = Convert.ToString(dr["Process_Name"]);

                    processes.Add(process);
                }
            }

            return processes;
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            List<WorkCenterInfo> work_Centers = new List<WorkCenterInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Centers_By_Factory_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    WorkCenterInfo work_Center = new WorkCenterInfo();

                    work_Center.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
                    work_Center.Work_Center_Name = Convert.ToString(dr["Work_Center_Name"]);

                    work_Centers.Add(work_Center);
                }
            }

            return work_Centers;
        }

        public int Insert_Work_Station(WorkStationInfo work_Station)
        {
            int work_Station_Id = 0;

            work_Station_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Work_Station(work_Station), StoredProcedures.Insert_Work_Station_sp.ToString(), CommandType.StoredProcedure));

            if (!string.IsNullOrEmpty(work_Station.Process_Ids))
            { 
                Insert_Work_Station_Process(work_Station.Process_Ids, work_Station_Id);
            }

            return work_Station_Id;
        }

        public void Update_Work_Station(WorkStationInfo work_Station)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Work_Station(work_Station), StoredProcedures.Update_Work_Station_sp.ToString(), CommandType.StoredProcedure);

            if (!string.IsNullOrEmpty(work_Station.Process_Ids))
            {
                Insert_Work_Station_Process(work_Station.Process_Ids, work_Station.Work_Station_Id);
            }
           
        }

        public void Insert_Work_Station_Process(string Process_Ids, int work_Station_Id)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            _sqlRepo.ExecuteNonQuery(sqlParam, StoredProcedures.Delete_Work_Station_Process_By_Work_Station_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (var item in Process_Ids.Split(','))
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                DateTime CreatedOn = DateTime.Now;
                int CreatedBy = 1;

                sqlparam.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));
                sqlparam.Add(new SqlParameter("@Process_Id", item));
                sqlparam.Add(new SqlParameter("@CreatedOn", CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", CreatedBy));

                _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Insert_Work_Station_Process_sp.ToString(), CommandType.StoredProcedure);
            }

        }

        private List<SqlParameter> Set_Values_In_Work_Station(WorkStationInfo work_Station)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (work_Station.Work_Station_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Work_Station_Id", work_Station.Work_Station_Id));
            }
            sqlparam.Add(new SqlParameter("@Work_Center_Id", work_Station.Work_Center.Work_Center_Id));
            //sqlparam.Add(new SqlParameter("@Work_Station_Id", work_Center.Work_Station_Id));
            sqlparam.Add(new SqlParameter("@Work_Station_Code", work_Station.Work_Station_Code));
            sqlparam.Add(new SqlParameter("@Machine_Name", work_Station.Machine_Name));
            sqlparam.Add(new SqlParameter("@Machine_Properties", work_Station.Machine_Properties));
            sqlparam.Add(new SqlParameter("@TPM_Speed", work_Station.TPM_Speed));
            sqlparam.Add(new SqlParameter("@Average_Order_Length", work_Station.Average_Order_Length));
            sqlparam.Add(new SqlParameter("@Capacity", work_Station.Capacity));
            sqlparam.Add(new SqlParameter("@Wastage", work_Station.Wastage));
            sqlparam.Add(new SqlParameter("@Target_Efficiency", work_Station.Target_Efficiency));
            sqlparam.Add(new SqlParameter("@Under_Maintainance", work_Station.Under_Maintainance));
            sqlparam.Add(new SqlParameter("@Is_Active", work_Station.Is_Active));

            if (work_Station.Work_Station_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedOn", work_Station.CreatedOn));
                sqlparam.Add(new SqlParameter("@CreatedBy", work_Station.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedOn", work_Station.UpdatedOn));
            sqlparam.Add(new SqlParameter("@UpdatedBy", work_Station.UpdatedBy));

            return sqlparam;
        }

        public List<WorkStationInfo> Get_Work_Stations(ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Work_Stations_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    work_Stations.Add(Get_Work_Station_Values(dr));
                }
            }

            return work_Stations;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Factory_Id_Sp.ToString(), CommandType.StoredProcedure);
            
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Work_Center_Id(int work_Center_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Work_Center_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Process_Id(int process_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Center_Id(int factory_Id, int work_Center_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }
        
        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Process_Id(int factory_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Factory_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Work_Center_Id_By_Work_Process_Id(int work_Center_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Work_Center_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }
        
        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id(int factory_Id, int work_Center_Id, int process_Id, ref PaginationInfo pager)
        {
            List<WorkStationInfo> work_Stations = new List<WorkStationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Factory_Id", factory_Id));

            sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

            sqlParams.Add(new SqlParameter("@Process_Id", process_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                work_Stations.Add(Get_Work_Station_Values(dr));
            }

            return work_Stations;
        }

        private WorkStationInfo Get_Work_Station_Values(DataRow dr)
        {
            WorkStationInfo work_Station = new WorkStationInfo();

            work_Station.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
            work_Station.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
            work_Station.Work_Station_Code = Convert.ToString(dr["Work_Station_Code"]);
            work_Station.Machine_Name = Convert.ToString(dr["Machine_Name"]);
            work_Station.Machine_Properties = Convert.ToString(dr["Machine_Properties"]);
            work_Station.TPM_Speed = Convert.ToInt32(dr["TPM_Speed"]);
            work_Station.Average_Order_Length = Convert.ToDecimal(dr["Average_Order_Length"]);
            work_Station.Capacity = Convert.ToString(dr["Capacity"]);
            work_Station.Wastage = Convert.ToInt32(dr["Wastage"]);
            work_Station.Target_Efficiency = Convert.ToInt32(dr["Target_Efficiency"]);
            work_Station.Under_Maintainance = Convert.ToBoolean(dr["Under_Maintainance"]);
            work_Station.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            work_Station.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            work_Station.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            work_Station.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            work_Station.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            work_Station.Work_Center.Work_Center_Name = Convert.ToString(dr["Work_Center_Name"]);
            work_Station.Factory.Factory_Name = Convert.ToString(dr["Factory_Name"]);
            //work_Station.Factory.Factory_Entity.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);

            return work_Station;
        }

        public WorkStationInfo Get_Work_Stations_By_Work_Station_Id(int work_Station_Id)
        {
            WorkStationInfo work_Station = new WorkStationInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Work_Stations_By_Work_Station_Id_Sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            //DataTable dt1 = ds.Tables[1];
 
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    work_Station = Get_Work_Station_Values_By_Id(dr);

                }
            }

            return work_Station;
        }

        private WorkStationInfo Get_Work_Station_Values_By_Id(DataRow dr)
        {
            WorkStationInfo work_Station = new WorkStationInfo();

            work_Station.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
            work_Station.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);
            work_Station.Work_Station_Code = Convert.ToString(dr["Work_Station_Code"]);
            work_Station.Machine_Name = Convert.ToString(dr["Machine_Name"]);
            work_Station.Machine_Properties = Convert.ToString(dr["Machine_Properties"]);
            work_Station.TPM_Speed = Convert.ToInt32(dr["TPM_Speed"]);
            work_Station.Average_Order_Length = Convert.ToDecimal(dr["Average_Order_Length"]);
            work_Station.Capacity = Convert.ToString(dr["Capacity"]);
            work_Station.Wastage = Convert.ToInt32(dr["Wastage"]);
            work_Station.Target_Efficiency = Convert.ToInt32(dr["Target_Efficiency"]);
            work_Station.Under_Maintainance = Convert.ToBoolean(dr["Under_Maintainance"]);
            work_Station.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            work_Station.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            work_Station.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            work_Station.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            work_Station.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            work_Station.Work_Center.Work_Center_Name = Convert.ToString(dr["Work_Center_Name"]);
            work_Station.Work_Center.Work_Center_Id = Convert.ToInt32(dr["Work_Center_Id"]);

            work_Station.Factory.Factory_Name = Convert.ToString(dr["Factory_Name"]);
            work_Station.Factory.Factory_Id = Convert.ToInt32(dr["Factory_Id"]);

            return work_Station;
        }


        public List<WorkStationProcessInfo> Get_Work_Station_Processes(int work_Station_Id, ref PaginationInfo pager)
        {
            List<WorkStationProcessInfo> work_Station_Processes = new List<WorkStationProcessInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Work_Station_Id", work_Station_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Station_Processes_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                WorkStationProcessInfo work_Station_Process = new WorkStationProcessInfo();
               
                work_Station_Process.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);
                work_Station_Process.Process_Id = Convert.ToInt32(dr["Process_Id"]);
                work_Station_Process.Process_Name = Convert.ToString(dr["Process_Name"]);

                work_Station_Processes.Add(work_Station_Process);
            }
          
            return work_Station_Processes;
        }

        //public WorkStationInfo Get_Work_Station_By_Work_Center(int work_Center_Id)
        //{
        //    WorkStationInfo work_Station = new WorkStationInfo();

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    sqlParams.Add(new SqlParameter("@Work_Center_Id", work_Center_Id));

        //    DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Work_Station_By_Work_Center_Id_Sp.ToString(), CommandType.StoredProcedure);

        //     List<DataRow> drList = new List<DataRow>();

        //    drList = dt.AsEnumerable().ToList();

        //    foreach (DataRow dr in drList )
        //    {
        //        work_Station.Work_Station_Id = Convert.ToInt32(dr["Work_Station_Id"]);

        //        work_Station.Work_Station_Name = Convert.ToString(dr["Work_Station_Name"]);
        //    }

        //    return work_Station;
        //}

    }
}
