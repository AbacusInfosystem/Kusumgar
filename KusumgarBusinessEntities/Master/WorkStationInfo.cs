using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class WorkStationInfo
    {

        public WorkStationInfo()
        {

           // Work_Center_Entity = new WorkCenterInfo();

           // Process_Entity = new M_Process();

          //  Work_Center_Process_Entity = new M_Work_Center_Process();

            Factory = new FactoryInfo();

            Factories = new List<FactoryInfo>();

            Work_Center = new WorkCenterInfo();

            Work_Centers = new List<WorkCenterInfo>();

            Process = new ProcessInfo();

            Processes = new List<ProcessInfo>();

            Work_Station_Process = new WorkStationProcessInfo();

            Work_Station_Processes = new List<WorkStationProcessInfo>();
        }

        public int Work_Station_Id { get; set; }

        public int Purpose { get; set; }

        public int Work_Center_Id { get; set; }

        public string Work_Station_Code { get; set; }

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

        // public WorkStationInfo Work_Station_Entity { get; set; }

      //  public M_Process Process_Entity { get; set; }

        //public M_Work_Station_Process Work_Station_Process_Entity { get; set; }

        public FactoryInfo Factory { get; set; }

        public List<FactoryInfo> Factories { get; set; }

        public WorkCenterInfo Work_Center { get; set; }

        public List<WorkCenterInfo> Work_Centers { get; set; }

        public ProcessInfo Process { get; set; }

        public List<ProcessInfo> Processes { get; set; }

        public WorkStationProcessInfo Work_Station_Process { get; set; }

        public List<WorkStationProcessInfo> Work_Station_Processes { get; set; }

        public String Process_Ids { get; set; }

        #endregion

    }
}
