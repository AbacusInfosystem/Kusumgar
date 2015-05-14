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
        public SQLHelperRepo _sqlHelper { get; set; }

        public NationRepo()
        {
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<NationInfo> Get_Nation_List(PaginationInfo Pager)
        {
            List<NationInfo> NationList = new List<NationInfo>();

             DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Nation_Sp.ToString(), CommandType.StoredProcedure);

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
                    NationList.Add(Get_Nation_Values(dr));
                 }
             }


            return NationList;
        }

        public NationInfo Get_Nation_Values(DataRow dr)
        {
            NationInfo nation = new NationInfo();

            nation.Nation_Entity.NationId = Convert.ToInt32(dr["NationId"]);

            nation.Nation_Entity.NationName = Convert.ToString(dr["NationName"]);

            nation.Nation_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            nation.Nation_Entity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            nation.Nation_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            nation.Nation_Entity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            nation.Nation_Entity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);


            return nation;
        }
        

    }
}
