using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class WorkCenterManager
    {
        public WorkCenterRepo _workcenterRepo;

        public WorkCenterManager()
        {
            _workcenterRepo = new WorkCenterRepo();
        }

        public List<FactoryInfo> Get_Factories(ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Factories(ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations(ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Stations(ref pager);
        }

        public List<ProcessInfo> Get_Processes(ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Processes(ref pager);
        }

        public List<WorkStationInfo> Get_Work_Stations_By_Factory_Id(int work_Station_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Stations_By_Factory_Id(work_Station_Id, ref pager);
        }


        public int Insert_Work_Center(WorkCenterInfo work_Center)
        {
            return _workcenterRepo.Insert_Work_Center(work_Center);
        }

        public void Update_Work_Center(WorkCenterInfo work_Center)
        {
            _workcenterRepo.Update_Work_Center(work_Center);
        }

        public List<WorkCenterInfo> Get_Work_Centers(ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers(ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id(int factory_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Factory_Id(factory_Id, ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Work_Station_Id(int work_Station_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Work_Station_Id(work_Station_Id, ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Process_Id(int process_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Process_Id(process_Id, ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Station_Id(int factory_Id, int work_Station_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id(factory_Id, work_Station_Id, ref pager);
        }
        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Process_Id(int factory_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Factory_Id_By_Work_Process_Id(factory_Id, process_Id, ref pager);
        }
        public List<WorkCenterInfo> Get_Work_Centers_By_Work_Station_Id_By_Work_Process_Id(int work_Station_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Work_Station_Id_By_Work_Process_Id(work_Station_Id, process_Id, ref pager);
        }

        public List<WorkCenterInfo> Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_By_Process_Id(int factory_Id, int work_Station_Id, int process_Id, ref PaginationInfo pager)
        {
            return _workcenterRepo.Get_Work_Centers_By_Factory_Id_By_Work_Station_Id_By_Process_Id(factory_Id, work_Station_Id, process_Id, ref pager);
        }

        public WorkCenterInfo Get_Work_Centers_By_Work_Center_Id(int work_Center_Id)
        {
            return _workcenterRepo.Get_Work_Centers_By_Work_Center_Id(work_Center_Id);
        }

    }
}
