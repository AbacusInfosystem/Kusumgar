using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using KusumgarBusinessEntities.Common;


namespace KusumgarDataAccess
{
    public class ConsumableRepo 
    {

        SQLHelperRepo _sqlRepo;

        public ConsumableRepo()
        {

            _sqlRepo = new SQLHelperRepo();

        }

        public List<ConsumableInfo> Get_Category_Name(PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Category_Name_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    ConsumableInfo consumable = new ConsumableInfo();

                    consumable.Category_Id = Convert.ToInt32(dr["CategoryId"]);
                    consumable.Category_Name = Convert.ToString(dr["CategoryName"]);

                    consumables.Add(consumable);
                }
            }

            return consumables;
        }

        public List<ConsumableInfo> Get_SubCategory_Name(PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_SubCategory_Name_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    ConsumableInfo consumable = new ConsumableInfo();

                    consumable.SubCategory_Id = Convert.ToInt32(dr["SubCategoryId"]);
                    consumable.SubCategory_Name = Convert.ToString(dr["SubCategoryName"]);

                    consumables.Add(consumable);
                }
            }

            return consumables;
        }

        public int Insert_Consumable(ConsumableInfo consumable)
        {
            int consumable_Id = 0;

            consumable_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Consumable(consumable), StoredProcedures.Insert_Consumable_sp.ToString(), CommandType.StoredProcedure));

            return consumable_Id;
        }

        private List<SqlParameter> Set_Values_In_Consumable(ConsumableInfo consumable)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (consumable.Consumable_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Consumable_Id", consumable.Consumable_Id));
            }
            sqlParams.Add(new SqlParameter("@Category_Id", consumable.Category_Id));
            sqlParams.Add(new SqlParameter("@SubCategory_Id", consumable.SubCategory_Id));
            sqlParams.Add(new SqlParameter("@Material_Name", consumable.Material_Name));
            sqlParams.Add(new SqlParameter("@Material_Code", consumable.Material_Code));
            sqlParams.Add(new SqlParameter("@IsActive", consumable.IsActive));

            if (consumable.Consumable_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@CreatedBy", consumable.CreatedBy));
            }
            sqlParams.Add(new SqlParameter("@UpdatedBy", consumable.UpdatedBy));

            return sqlParams;
        }

        public List<ConsumableInfo> Get_Consumables(PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Consumable_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
                {
                    consumables.Add(Get_Consumable_Values(dr));
                }
            }

            return consumables;
        }

        private ConsumableInfo Get_Consumable_Values(DataRow dr)
        {
            ConsumableInfo consumable = new ConsumableInfo();

            consumable.Consumable_Id = Convert.ToInt32(dr["Consumable_Id"]);
            consumable.Category_Id = Convert.ToInt32(dr["Category_Id"]); 
            consumable.SubCategory_Id = Convert.ToInt32(dr["SubCategory_Id"]);  
            consumable.Material_Name = Convert.ToString(dr["Material_Name"]);
            consumable.Material_Code = Convert.ToString(dr["Material_Code"]);
            consumable.IsActive = Convert.ToBoolean(dr["IsActive"]);

            consumable.CreatedDtm = Convert.ToDateTime(dr["CreatedDtm"]);
            consumable.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            consumable.UpdatedDtm = Convert.ToDateTime(dr["UpdatedDtm"]);
            consumable.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            consumable.Category_Name = Convert.ToString(dr["CategoryName"]);
            consumable.SubCategory_Name = Convert.ToString(dr["SubCategoryName"]);

            return consumable;
        }

        public int Insert_Consumable_Vendor(ConsumableInfo consumable)
        {
            int consumable_vendor_Id = 0;

            consumable_vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Consumable_Vendor(consumable), StoredProcedures.Insert_Consumable_Vendor_sp.ToString(), CommandType.StoredProcedure));

            return consumable_vendor_Id;
        }

        private List<SqlParameter> Set_Values_In_Consumable_Vendor(ConsumableInfo consumable)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (consumable.Consumable_Vendor.Consumable_Vendor_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Consumable_Vendor_Id", consumable.Consumable_Vendor.Consumable_Vendor_Id));
            }
            sqlparam.Add(new SqlParameter("@Vendor_Id", consumable.Consumable_Vendor.Vendor_Id));
            sqlparam.Add(new SqlParameter("@Consumable_Id", consumable.Consumable_Id));
            sqlparam.Add(new SqlParameter("@Priority_Order", consumable.Consumable_Vendor.Priority_Order));

            if (consumable.Consumable_Vendor.Consumable_Vendor_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", consumable.Consumable_Vendor.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", consumable.Consumable_Vendor.UpdatedBy));

            return sqlparam;
        }

        public List<ConsumableVendorInfo> Get_Consumable_Vendor_By_Consumable_Id(int consumable_Id)
        {

            List<ConsumableVendorInfo> consumable_vendors = new List<ConsumableVendorInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Consumable_Id", consumable_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Consumable_Vendor_sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                 
                    ConsumableVendorInfo ConsumableVendor = new ConsumableVendorInfo();

                    ConsumableVendor.Consumable_Vendor_Id = Convert.ToInt32(dr["Consumable_Vendor_Id"]);
                    ConsumableVendor.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
                    ConsumableVendor.Consumable_Id = Convert.ToInt32(dr["Consumable_Id"]);
                    ConsumableVendor.Priority_Order = Convert.ToInt32(dr["Priority_Order"]);
                    ConsumableVendor.Vendor_Entity.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                    consumable_vendors.Add(ConsumableVendor);
                }
            }

            return consumable_vendors;
        }

        public void Delete_Vendor_By_Id(int consumable_vendor_Id)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Consumable_Vendor_Id", consumable_vendor_Id));

            _sqlRepo.ExecuteNonQuery(sqlparam, StoredProcedures.Delete_Vendor_By_Id.ToString(), CommandType.StoredProcedure);
        }

        public ConsumableInfo Get_Consumable_By_Id(int consumable_Id)
        {
            ConsumableInfo consumable = new ConsumableInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Consumable_Id", consumable_Id));

            DataSet ds = _sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Consumable_By_Id_sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {

                    consumable.Consumable_Id = Convert.ToInt32(dr["Consumable_Id"]);
                    consumable.Category_Id = Convert.ToInt32(dr["Category_Id"]);
                    consumable.SubCategory_Id = Convert.ToInt32(dr["SubCategory_Id"]);
                    consumable.Material_Name = Convert.ToString(dr["Material_Name"]);
                    consumable.Material_Code = Convert.ToString(dr["Material_Code"]);
                    consumable.IsActive = Convert.ToBoolean(dr["IsActive"]);

                }
            }

            return consumable;
        }

        public void Update_Consumable(ConsumableInfo consumable)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Consumable(consumable), StoredProcedures.Update_Consumable_Sp.ToString(), CommandType.StoredProcedure);
        }

        public List<ConsumableInfo> Get_Consumable_By_Category_Id_By_Material_Name(int category_Id, string material_Name, PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Category_Id", category_Id));

            sqlParams.Add(new SqlParameter("@Material_Name", material_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Consumable_By_Category_By_Material_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                consumables.Add(Get_Consumable_Values(dr));
            }

            return consumables;
        }

        public List<ConsumableInfo> Get_Consumable_By_Category_Id(int category_Id, PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Category_Id", category_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Consumable_By_Category_Id_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                consumables.Add(Get_Consumable_Values(dr));
            }

            return consumables;
        }

        public List<ConsumableInfo> Get_Consumable_By_Material_Name(string material_Name, PaginationInfo pager)
        {
            List<ConsumableInfo> consumables = new List<ConsumableInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Material_Name", material_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Consumable_By_Material_Name_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                consumables.Add(Get_Consumable_Values(dr));
            }

            return consumables;
        }

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
        {
            List<AutocompleteInfo> consumable_list = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Name", vendor_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Vendor_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    AutocompleteInfo auto = new AutocompleteInfo();

                    auto.Label = Convert.ToString(dr["Vendor_Name"]);

                    auto.Value = Convert.ToInt32(dr["Vendor_Id"]);

                    consumable_list.Add(auto);
                }
            }

            return consumable_list;
        }

        public void Update_Consumable_Vendors(ConsumableInfo consumable)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Consumable_Vendor(consumable), StoredProcedures.Update_Consumable_Vendors_Sp.ToString(), CommandType.StoredProcedure);
        }
    }
}
