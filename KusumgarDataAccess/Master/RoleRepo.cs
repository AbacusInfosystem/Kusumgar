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
    public class RoleRepo
    {
        SQLHelperRepo sqlRepo;
      

        public RoleRepo()
        {
            sqlRepo = new SQLHelperRepo();
        }

        public List<RoleInfo> Get_Roles(ref PaginationInfo pager)
        {
            List<RoleInfo> RoleInfoList = new List<RoleInfo>();

            DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Role_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    RoleInfoList.Add(Get_Role_Values(dr));
                }
            }


            return RoleInfoList;
        }

        public List<RoleInfo> Get_Roles_By_Name(string Role_Name, ref PaginationInfo pager)
        {
            List<RoleInfo> RoleInfoList = new List<RoleInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Name", Role_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Role_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    RoleInfoList.Add(Get_Role_Values(dr));
                }
            }

            return RoleInfoList;
        }

        public RoleInfo Get_Role_Values(DataRow dr)
        {
            RoleInfo role = new RoleInfo();

            role.RoleEntity.Role_Id = Convert.ToInt32(dr["Role_Id"]);

            role.RoleEntity.Role_Name = Convert.ToString(dr["Role_Name"]);

            role.RoleEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            role.RoleEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            role.RoleEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            role.RoleEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            role.RoleEntity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            return role;
        }

        public RoleInfo Get_Role_By_Id(int Role_Id)
        {
            RoleInfo RoleInfo = new RoleInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Id", Role_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Role_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    RoleInfo = Get_Role_Values(dr);
                }
            }

            return RoleInfo;
        }

        public List<RoleInfo> Get_Roles_By_Id(int Role_Id, ref PaginationInfo pager)
        {
            List<RoleInfo> Roles = new List<RoleInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Id", Role_Id));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Role_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    Roles.Add( Get_Role_Values(dr));
                }
            }

            return Roles;
        }

        public int Insert_Role(RoleInfo RoleInfo)
        {
             int Role_Id = Convert.ToInt32(sqlRepo.ExecuteScalerObj(SetValues_In_Role(RoleInfo), StoredProcedures.Insert_Role_Sp.ToString(), CommandType.StoredProcedure));

             return Role_Id;
        }

        public void Update_Role(RoleInfo RoleInfo)
        {
            sqlRepo.ExecuteNonQuery(SetValues_In_Role(RoleInfo), StoredProcedures.Update_Role_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> SetValues_In_Role(RoleInfo RoleInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            
            sqlParamList.Add(new SqlParameter("@Role_Name", RoleInfo.RoleEntity.Role_Name));
            sqlParamList.Add(new SqlParameter("@Is_Active", RoleInfo.RoleEntity.Is_Active));
            sqlParamList.Add(new SqlParameter("@UpdatedBy", RoleInfo.RoleEntity.UpdatedBy));
            if (RoleInfo.RoleEntity.Role_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", RoleInfo.RoleEntity.CreatedBy));
            }
            if (RoleInfo.RoleEntity.Role_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Role_Id", RoleInfo.RoleEntity.Role_Id));
               
            }

            return sqlParamList;
        }

        public bool Check_Existing_Role(string Role_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Name", Role_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Check_Existing_Role_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Role"]);
                }
            }

            return check;
        }


        public List<AutocompleteInfo> Get_Roles_By_Name(string role_Name)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Role_Name", role_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Role_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                if (dt != null && dt.Rows.Count > 0)
                {

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        AutocompleteInfo autoComplete = new AutocompleteInfo();

                        autoComplete.Value = Convert.ToInt32(dr["Role_Id"]);

                        autoComplete.Label = Convert.ToString(dr["Role_Name"]);

                        autoCompletes.Add(autoComplete);
                    }
                }
            }

            return autoCompletes;
        }
    }
}
