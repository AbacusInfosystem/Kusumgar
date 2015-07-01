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
    public class IndustrialRepo
    {
        SQLHelperRepo _sqlRepo;

        public IndustrialRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Industrial(IndustrialInfo industrialInfo)
        {
            int industrial_Master_Id = 0;
            industrial_Master_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Industrial(industrialInfo), StoredProcedures.Insert_Industrial_Master_Sp.ToString(), CommandType.StoredProcedure));
            return industrial_Master_Id;
        }

        public void Update_Industrial(IndustrialInfo industrialInfo)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Industrial(industrialInfo), StoredProcedures.Update_Industrial_Master_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Industrial(IndustrialInfo industrialInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (industrialInfo.Industrial_Master_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Industrial_Master_Id", industrialInfo.Industrial_Master_Id));
            }
            sqlParamList.Add(new SqlParameter("@Industrial_Category_Id", industrialInfo.Industrial_Category_Id));
            sqlParamList.Add(new SqlParameter("@Industrial_Group_Id", industrialInfo.Industrial_Group_Id));
            sqlParamList.Add(new SqlParameter("@Industrial_SubGroup_Name", industrialInfo.Industrial_SubGrp_Name));
            sqlParamList.Add(new SqlParameter("@Size", industrialInfo.Size));
            sqlParamList.Add(new SqlParameter("@COD", industrialInfo.COD));
            if (industrialInfo.Industrial_Master_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", industrialInfo.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", industrialInfo.UpdatedBy));
            return sqlParamList;
        }

        public List<IndustrialInfo> Get_Industrials(ref PaginationInfo pager)
        {
            List<IndustrialInfo> industrials = new List<IndustrialInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Industrial_Master_List_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, ref pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))            
            {                
                industrials.Add(Get_Industrial_Values(dr));
            }
            return industrials;
        }
        
        public List<IndustrialInfo> Get_Industrials_By_Industrial_Category_Name(int industrial_Category_Id, ref PaginationInfo pager)
        {
            List<IndustrialInfo> industrials = new List<IndustrialInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Category_Id", industrial_Category_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Industrial_Masters_By_Category_Name_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt,ref pager))
            {                
                industrials.Add(Get_Industrial_Values(dr));
            }
            return industrials;
        }

        public List<IndustrialInfo> Get_Industrials_By_Industrial_Category_Id_Group_Name(int industrial_Category_Id, int industrial_Group_Id, ref PaginationInfo pager)
        {
            List<IndustrialInfo> industrials = new List<IndustrialInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Category_Id", industrial_Category_Id));
            sqlParams.Add(new SqlParameter("@Industrial_Group_Id", industrial_Group_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Industrial_Masters_By_Category_Group_Name_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt,ref pager))
            {                
                industrials.Add(Get_Industrial_Values(dr));
            }
            return industrials;
        }

        private IndustrialInfo Get_Industrial_Values(DataRow dr)
        {
            IndustrialInfo industrial = new IndustrialInfo();
            industrial.Industrial_Master_Id = Convert.ToInt32(dr["Industrial_Master_Id"]);
            industrial.Industrial_Category_Name = Convert.ToString(dr["Industrial_Category_Name"]);
            industrial.Industrial_Group_Name = Convert.ToString(dr["Industrial_Group_Name"]);
            industrial.Industrial_SubGrp_Name = Convert.ToString(dr["Industrial_SubGrp_Name"]);
            industrial.Size = Convert.ToString(dr["Size"]);
            industrial.COD = Convert.ToString(dr["COD"]);
            return industrial;
        }

        public IndustrialInfo Get_Industrial_Master_By_Id(int industrial_Master_Id)
        {
            IndustrialInfo industrial = new IndustrialInfo();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Master_Id", industrial_Master_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Industrial_Master_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    industrial = Get_Industrial_Values_By_Id(dr);
                }
            }
            return industrial;
        }

        private IndustrialInfo Get_Industrial_Values_By_Id(DataRow dr)
        {
            IndustrialInfo industrial = new IndustrialInfo();
            industrial.Industrial_Master_Id = Convert.ToInt32(dr["Industrial_Master_Id"]);
            industrial.Industrial_Category_Id = Convert.ToInt32(dr["Industrial_Category_Id"]);
            industrial.Industrial_Group_Id = Convert.ToInt32(dr["Industrial_Group_Id"]);
            industrial.Industrial_Category_Name = Convert.ToString(dr["Industrial_Category_Name"]);
            industrial.Industrial_Group_Name = Convert.ToString(dr["Industrial_Group_Name"]);
            industrial.Industrial_SubGrp_Name = Convert.ToString(dr["Industrial_SubGrp_Name"]);
            industrial.Size = Convert.ToString(dr["Size"]);
            industrial.COD = Convert.ToString(dr["COD"]);
            return industrial;
        }

        public List<IndustrialCategoryInfo> Get_Industrial_Categories(ref PaginationInfo pager)
        {
            List<IndustrialCategoryInfo> industrial_Categories = new List<IndustrialCategoryInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Industrial_Category_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                industrial_Categories.Add(Get_Industrial_Category_Values(dr));
            }
            return industrial_Categories;
        }

        private IndustrialCategoryInfo Get_Industrial_Category_Values(DataRow dr)
        {
            IndustrialCategoryInfo industrial_category = new IndustrialCategoryInfo();
            industrial_category.Industrial_Category_Id = Convert.ToInt32(dr["Industrial_Category_Id"]);
            industrial_category.Industrial_Category_Name = Convert.ToString(dr["Industrial_Category_Name"]);
            industrial_category.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            industrial_category.CreatedDtm = Convert.ToDateTime(dr["CreatedDtm"]);
            industrial_category.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            industrial_category.UpdatedDtm = Convert.ToDateTime(dr["UpdatedDtm"]);
            return industrial_category;
        }

        public List<IndustrialGroupInfo> Get_Industrial_Groups(int industrial_Category_Id, ref PaginationInfo pager)
        {
            List<IndustrialGroupInfo> industrial_Groups = new List<IndustrialGroupInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Category_Id", industrial_Category_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Group_By_CategoryId_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                industrial_Groups.Add(Get_Industrial_Group_Values(dr));
            }
            return industrial_Groups;
        }

        private IndustrialGroupInfo Get_Industrial_Group_Values(DataRow dr)
        {
            IndustrialGroupInfo industrial_group = new IndustrialGroupInfo();
            industrial_group.Industrial_Group_Id = Convert.ToInt32(dr["Industrial_Group_Id"]);
            industrial_group.Industrial_Group_Name = Convert.ToString(dr["Industrial_Group_Name"]);
            industrial_group.Industrial_Category_Id = Convert.ToInt32(dr["Industrial_Category_Id"]);
            industrial_group.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            industrial_group.CreatedDtm = Convert.ToDateTime(dr["CreatedDtm"]);
            industrial_group.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            industrial_group.UpdatedDtm = Convert.ToDateTime(dr["UpdatedDtm"]);
            return industrial_group;
        }

        public int Insert_Industrial_Vendor(IndustrialVendorInfo industrialVendorInfo)
        {
            int industrial_Vendor_Id = 0;
            industrial_Vendor_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Industrial_Vendor(industrialVendorInfo), StoredProcedures.Insert_Industrial_Vendor_Sp.ToString(), CommandType.StoredProcedure));
            return industrial_Vendor_Id;
        }

        public void Update_Industrial_Vendor(IndustrialVendorInfo industrialVendorInfo)
        {

        }

        public void Delete_Industrial_Vendor_By_Id(int industrial_Vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Vendor_Id", industrial_Vendor_Id));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Industrial_Vendor_By_Id_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Industrial_Vendor(IndustrialVendorInfo industrialVendorInfo)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if(industrialVendorInfo.Industrial_Vendor_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Industrial_Vendor_Id", industrialVendorInfo.Industrial_Vendor_Id));
            }
            sqlParamList.Add(new SqlParameter("@Industrial_Master_Id", industrialVendorInfo.Industrial_Master_Id));
            sqlParamList.Add(new SqlParameter("@Vendor_Id", industrialVendorInfo.Vendor_Id));
            sqlParamList.Add(new SqlParameter("@Priority_Order", industrialVendorInfo.Priority_Order));
            if (industrialVendorInfo.Industrial_Vendor_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", industrialVendorInfo.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", industrialVendorInfo.UpdatedBy));
            return sqlParamList;
        }

        public List<IndustrialVendorInfo> Get_Industrial_Vendors_By_Id(int industrial_Master_Id, ref PaginationInfo pager)
        {
            List<IndustrialVendorInfo> industrial_Vendors = new List<IndustrialVendorInfo>();            
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Industrial_Master_Id", industrial_Master_Id));
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Industrial_Vendor_List_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            //var tupleData = CommonMethods.GetRows(dt, pager);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {                                
                industrial_Vendors.Add(Get_Industrial_Vendor_Values(dr));
            }
            return industrial_Vendors;
        }

        private IndustrialVendorInfo Get_Industrial_Vendor_Values(DataRow dr)
        {
            IndustrialVendorInfo industrial_vendor = new IndustrialVendorInfo();
            industrial_vendor.Industrial_Vendor_Id = Convert.ToInt32(dr["Industrial_Vendor_Id"]);
            industrial_vendor.Industrial_Master_Id = Convert.ToInt32(dr["Industrial_Master_Id"]);
            industrial_vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            industrial_vendor.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            industrial_vendor.Priority_Order = Convert.ToInt32(dr["Priority_Order"]);
            return industrial_vendor;
        }
    }
}
