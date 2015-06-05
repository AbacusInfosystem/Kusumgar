using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class WorkCenterInfo
    {

        public WorkCenterInfo()
        {

           // Work_Center_Entity = new WorkCenterInfo();

           // Process_Entity = new M_Process();

          //  Work_Center_Process_Entity = new M_Work_Center_Process();

            Factory = new FactoryInfo();

            Factories = new List<FactoryInfo>();

            Work_Station = new WorkStationInfo();

            Work_Stations = new List<WorkStationInfo>();

            Process = new ProcessInfo();

            Processes = new List<ProcessInfo>();

            Work_Center_Process = new WorkCenterProcessInfo();

            Work_Center_Processes = new List<WorkCenterProcessInfo>();
        }

        public int Work_Center_Id { get; set; }

        public int Purpose { get; set; }

        public int Work_Station_Id { get; set; }

        public string Work_Center_Code { get; set; }

        public string Machine_Name { get; set; }

        public string Machine_Properties { get; set; }

        public int TPM_Speed { get; set; }

        public decimal Average_Order_Length { get; set; }

        public string Capacity { get; set; }

        public int Wastage { get; set; }

        public int Target_Efficiency { get; set; }

        public bool Under_Maintainance { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        // public WorkCenterInfo Work_Center_Entity { get; set; }

      //  public M_Process Process_Entity { get; set; }

        //public M_Work_Center_Process Work_Center_Process_Entity { get; set; }

        public FactoryInfo Factory { get; set; }

        public List<FactoryInfo> Factories { get; set; }

        public WorkStationInfo Work_Station { get; set; }

        public List<WorkStationInfo> Work_Stations { get; set; }

        public ProcessInfo Process { get; set; }

        public List<ProcessInfo> Processes { get; set; }

        public WorkCenterProcessInfo Work_Center_Process { get; set; }

        public List<WorkCenterProcessInfo> Work_Center_Processes { get; set; }

        public String Process_Ids { get; set; }

        #endregion

    }
}
