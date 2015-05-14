using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class StateRepo
    {
         SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public StateRepo()
        {
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<StateInfo> Get_State_List(int Nation_Id, PaginationInfo Pager)
        {
            List<StateInfo> State_List = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", Nation_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_State_By_Nation_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (Pager.IsPagingRequired)
                {
                    drList = drList.Skip(Pager.CurrentPage * Pager.PageSize).Take(Pager.PageSize).ToList();
                }

                Pager.TotalRecords = count;

                int pages = (Pager.TotalRecords + Pager.PageSize - 1) / Pager.PageSize;

                Pager.TotalPages = pages;

                foreach (DataRow dr in drList)
                {
                    State_List.Add(Get_State_Values(dr));
                }
            }

            return State_List;
        }

        public StateInfo Get_State_Values(DataRow dr)
        {
            StateInfo State = new StateInfo();

            State.State_Entity.StateId = Convert.ToInt32(dr["StateId"]);

            State.State_Entity.StateName = Convert.ToString(dr["StateName"]);

            State.State_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            State.State_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            State.State_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            State.State_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            State.State_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            return State;
        }
    }
}
