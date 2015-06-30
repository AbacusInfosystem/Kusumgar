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
    public class WorkStationManager
    {
        public WorkStationRepo _workStationRepo;

        public WorkStationManager()
        {
            _workStationRepo = new WorkStationRepo();
        }

        public List<FactoryInfo> Get_Factories(ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Factories(ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers(ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Centers(ref pager);
        }

        public List<ProcessInfo> Get_Processes(ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Processes(ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id(int work_Center_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Centers_By_Factory_Id(work_Center_Id, ref pager);
        }


        public int Insert_Work_Station(WorkStationInfo work_Station)
        {
            return _workStationRepo.Insert_Work_Station(work_Station);
        }

        public void Update_Work_Station(WorkStationInfo work_Station)
        {
            _workStationRepo.Update_Work_Station(work_Station);
        }

        public List<WorkStationInfo> Get_Work_Stations(ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations(ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Factory_Id(factory_Id, ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Work_Center_Id(int work_Center_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Work_Center_Id(work_Center_Id, ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Process_Id(int process_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Process_Id(process_Id, ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Center_Id(int factory_Id, int work_Center_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id(factory_Id, work_Center_Id, ref pager);
        }
        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Process_Id(int factory_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Factory_Id_By_Work_Process_Id(factory_Id, process_Id, ref pager);
        }
        public List<WorkStationInfo> Get_Work_Stations_By_Work_Center_Id_By_Work_Process_Id(int work_Center_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Work_Center_Id_By_Work_Process_Id(work_Center_Id, process_Id, ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id(int factory_Id, int work_Center_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id(factory_Id, work_Center_Id, process_Id, ref pager);
        }

        public WorkStationInfo Get_Work_Stations_By_Work_Station_Id(int work_Station_Id)
        {
            return _workStationRepo.Get_Work_Stations_By_Work_Station_Id(work_Station_Id);
        }

        public List<WorkStationProcessInfo> Get_Work_Station_Processes(int work_Station_Id, ref PaginationInfo pager)
        {
            return _workStationRepo.Get_Work_Station_Processes(work_Station_Id, ref pager);
        }

        //public WorkCenterInfo Get_Work_Center_By_Work_Station(int work_Station_Id)
        //{
        //    return _workStationRepo.Get_Work_Center_By_Work_Station(work_Station_Id);
        //}

    }
}
