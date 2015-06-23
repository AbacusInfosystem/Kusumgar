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
    public class NationRepo
    {
         SQLHelperRepo sqlRepo;

        public NationRepo()
        {
            sqlRepo = new SQLHelperRepo();
        }

        public List<NationInfo> Get_Nations(ref PaginationInfo pager)
        {
            List<NationInfo> Nations = new List<NationInfo>();

             DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Nation_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                 {
                     Nations.Add(Get_Nation_Values(dr));
                 }
             }


             return Nations;
        }

        public NationInfo Get_Nation_Values(DataRow dr)
        {
            NationInfo nation = new NationInfo();

            nation.NationId = Convert.ToInt32(dr["NationId"]);

            nation.NationName = Convert.ToString(dr["NationName"]);

            nation.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            nation.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            nation.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            nation.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            nation.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            nation.Currency_Code = Convert.ToString(dr["Currency_Code"]);

            nation.Currency_Symbol = Convert.ToString(dr["Currency_Symbol"]);

            nation.Nation_Flag = Convert.ToString(dr["Nation_Flag"]);

            nation.Currency = Convert.ToString(dr["Currency"]);

            return nation;
        }
        

    }
}
