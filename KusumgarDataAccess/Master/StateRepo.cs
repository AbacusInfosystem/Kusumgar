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
    public class StateRepo
    {
         SQLHelperRepo sqlRepo;

        public StateRepo()
        {
            sqlRepo = new SQLHelperRepo();
        }

        public List<StateInfo> Get_States(int nation_Id, ref PaginationInfo pager)
        {
            List<StateInfo> States = new List<StateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Nation_Id", nation_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_State_By_Nation_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    States.Add(Get_State_Values(dr));
                }
            }

            return States;
        }

        public StateInfo Get_State_Values(DataRow dr)
        {
            StateInfo State = new StateInfo();

            State.StateId = Convert.ToInt32(dr["StateId"]);

            State.StateName = Convert.ToString(dr["StateName"]);

            State.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            State.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            State.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            State.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            State.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            return State;
        }
    }
}
