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
    public class PackingRepo
    {
        SQLHelperRepo _sqlRepo;

        public PackingRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public void Insert_Packing(PackingInfo PackingInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Packing(PackingInfo), StoredProcedures.Insert_Packing_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Packing(PackingInfo PackingInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Packing(PackingInfo), StoredProcedures.Update_Packing_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Packing(PackingInfo PackingInfo)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (PackingInfo.Packing_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Packing_Id", PackingInfo.Packing_Id));
            }
            sqlParams.Add(new SqlParameter("@Packing_Name", PackingInfo.Packing_Name));
            sqlParams.Add(new SqlParameter("@Is_Active", PackingInfo.Is_Active));
            if (PackingInfo.Packing_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", PackingInfo.CreatedBy));
                sqlParams.Add(new SqlParameter("@CreatedOn", PackingInfo.CreatedOn));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", PackingInfo.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", PackingInfo.UpdatedOn));
            return sqlParams;
        }

        public List<PackingInfo> Get_Packings(ref PaginationInfo pager)
        {
            List<PackingInfo> packings = new List<PackingInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Packing_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                packings.Add(Get_Packing_Values(dr));
            }
            return packings;
        }

        public PackingInfo Get_Packing_By_Packing_Id(int packing_Id)
        {
            PackingInfo packing = new PackingInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Packing_Id", packing_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Packing_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    packing = Get_Packing_Values(dr);
                }
            }
            return packing;
        }

        private PackingInfo Get_Packing_Values(DataRow dr)
        {
            PackingInfo packing = new PackingInfo();
            packing.Packing_Id = Convert.ToInt32(dr["Packing_Id"]);
            packing.Packing_Name = Convert.ToString(dr["Packing_Name"]);
            packing.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            packing.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            packing.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            packing.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            packing.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            return packing;
        }

        public List<AutocompleteInfo> Get_Packing_By_Name_Autocomplete(string packing_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Packing_Name", packing_Name));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Packing_By_Packing_Name_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();
                    auto.Label = Convert.ToString(dr["Packing_Name"]);
                    auto.Value = Convert.ToInt32(dr["Packing_Id"]);
                    autoList.Add(auto);
                }
            }
            return autoList;
        }

        public List<PackingInfo> Get_Packing_By_Id(int packing_Id, ref PaginationInfo pager)
        {
            List<PackingInfo> packings = new List<PackingInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Packing_Id", packing_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Packing_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                packings.Add(Get_Packing_Values(dr));
            }
            return packings;
        }
    }
}
