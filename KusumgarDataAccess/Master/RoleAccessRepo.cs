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
    public class RoleAccessRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public RoleAccessRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }   

        public List<RoleAccessInfo> Get_Access_List()
        {
            List<RoleAccessInfo> RoleAccessList = new List<RoleAccessInfo>();

             DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Access_Function_Sp.ToString(), CommandType.StoredProcedure);

             if (dt != null && dt.Rows.Count > 0)
             {
                 int count = 0;
                 List<DataRow> drList = new List<DataRow>();

                 drList = dt.AsEnumerable().ToList();

                 count = drList.Count();

                 foreach (DataRow dr in drList)
                 {

                     RoleAccessInfo roleAccess = new RoleAccessInfo();

                     roleAccess.RoleAccessEntity.Access_Function_Id = Convert.ToInt32(dr["Access_Fuction_Id"]);

                     roleAccess.Access_Name = Convert.ToString(dr["Access_Function_Name"]);

                     RoleAccessList.Add(roleAccess);
                 }
             }
            return RoleAccessList;
        }

        public List<RoleAccessInfo> Get_Role_Access_List_By_Role_Id(int RoleId)
        {
            List<RoleAccessInfo> RoleAccessList = new List<RoleAccessInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Id", RoleId));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Access_Function_By_Role_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {

                    RoleAccessInfo roleAccess = new RoleAccessInfo();

                    roleAccess.RoleAccessEntity.Access_Function_Id = Convert.ToInt32(dr["Access_Function_Id"]);

                    roleAccess.Access_Name = Convert.ToString(dr["Access_Function_Name"]);

                    RoleAccessList.Add(roleAccess);
                }
            }

            return RoleAccessList;
        }

        public void Insert_Role_Access(int RoleId, int[] Access_Ids)
        {
            foreach(var item in Access_Ids)
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@Role_Id",RoleId));
                sqlparam.Add(new SqlParameter("@Access_Id",item));
                sqlparam.Add(new SqlParameter("@CreatedBy", 1));
                sqlparam.Add(new SqlParameter("@UpdatedBy", 1));

                _sqlHelper.ExecuteNonQuery(sqlparam, StoredProcedures.Insert_Role_Access_Sp.ToString(), CommandType.StoredProcedure);
            }
        }
    }
}
