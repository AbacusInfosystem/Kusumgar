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
using KusumgarDatabaseEntities;

namespace KusumgarDataAccess
{
    public class ConsumableMasterRepo 
    {
        private string _sqlCon = string.Empty;

        SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public ConsumableMasterRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();

            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();

        }

        public List<ConsumableMasterInfo> GetCategoryName()
        {
            List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();
            using (SqlConnection con = new SqlConnection(_sqlCon))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("Get_Category_Name_sp", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ConsumableMasterInfo CMInfo = new ConsumableMasterInfo();
                            CMInfo.Category_Id = Convert.ToInt32(dataReader["CategoryId"]);
                            CMInfo.Category_Name = Convert.ToString(dataReader["CategoryName"]);
                            retVal.Add(CMInfo);
                        }
                    }
                    dataReader.Close();
                }
            }
            return retVal;
        }

        public List<ConsumableMasterInfo> GetSubCategoryName()
        {
            List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();
            using (SqlConnection con = new SqlConnection(_sqlCon))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("Get_SubCategory_Name_sp", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ConsumableMasterInfo CMInfo = new ConsumableMasterInfo();
                            CMInfo.SubCategory_Id = Convert.ToInt32(dataReader["SubCategoryId"]);
                            CMInfo.SubCategory_Name = Convert.ToString(dataReader["SubCategoryName"]);
                            retVal.Add(CMInfo);
                        }
                    }
                    dataReader.Close();
                }
            }
            return retVal;
        }

        //public void Insert(ConsumableMasterInfo CMInfo)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_sqlCon))
        //        {
        //            con.Open();

        //            using (SqlCommand command = new SqlCommand("Insert_ConsumableMaster_sp", con))
        //            {
        //                SetValuesInConsumableMaster(command, CMInfo);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //private SqlCommand SetValuesInConsumableMaster(SqlCommand command, ConsumableMasterInfo CMInfo)
        //{
        //    command.CommandType = CommandType.StoredProcedure;

        //    command.Parameters.Add(new SqlParameter("@Category_Id", CMInfo.Category_Name));
        //    command.Parameters.Add(new SqlParameter("@SubCategory_Id", CMInfo.SubCategory_Name));
        //    command.Parameters.Add(new SqlParameter("@Material_Name", CMInfo.Material_Name));
        //    command.Parameters.Add(new SqlParameter("@Material_Code", CMInfo.Material_Code));
        //    command.Parameters.Add(new SqlParameter("@IsActive", CMInfo.IsActive));
        //    command.Parameters.Add(new SqlParameter("@CreatedBy", CMInfo.CreatedBy));
        //    command.Parameters.Add(new SqlParameter("@UpdatedBy", CMInfo.UpdatedBy));

        //    return command;
        //}
        public int Insert_Consumable(ConsumableMasterInfo ConsumableMaster)
        {
            int Consumable_Id = 0;

            Consumable_Id = Convert.ToInt32(sqlRepo.ExecuteScalerObj(Set_Values_In_Consumable(ConsumableMaster), StoredProcedures.Insert_ConsumableMaster_sp.ToString(), CommandType.StoredProcedure));

            return Consumable_Id;
        }
        private List<SqlParameter> Set_Values_In_Consumable(ConsumableMasterInfo ConsumableMaster)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (ConsumableMaster.Consumable_Entity.Consumable_Id != 0)
            {
                sqlparam.Add(new SqlParameter("@Consumable_Id", ConsumableMaster.Consumable_Entity.Consumable_Id));
            }
            sqlparam.Add(new SqlParameter("@Category_Id", ConsumableMaster.Category_Id));
            sqlparam.Add(new SqlParameter("@SubCategory_Id", ConsumableMaster.SubCategory_Id));
            sqlparam.Add(new SqlParameter("@Material_Name", ConsumableMaster.Consumable_Entity.Material_Name));
            sqlparam.Add(new SqlParameter("@Material_Code", ConsumableMaster.Consumable_Entity.Material_Code));
            sqlparam.Add(new SqlParameter("@IsActive", ConsumableMaster.Consumable_Entity.IsActive));
            //sqlparam.Add(new SqlParameter("@CreatedBy", ConsumableMaster.ConsumableMaster_Entity.CreatedBy));
            //sqlparam.Add(new SqlParameter("@UpdatedBy", ConsumableMaster.ConsumableMaster_Entity.UpdatedBy));


            if (ConsumableMaster.Consumable_Entity.Consumable_Id == 0)
            {
                sqlparam.Add(new SqlParameter("@CreatedBy", ConsumableMaster.Consumable_Entity.CreatedBy));
            }
            sqlparam.Add(new SqlParameter("@UpdatedBy", ConsumableMaster.Consumable_Entity.UpdatedBy));

            return sqlparam;
        }

        //public List<ConsumableMasterInfo> GetConsumableMaster()
        //{
        //    List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();
        //    using (SqlConnection con = new SqlConnection(_sqlCon))
        //    {
        //        con.Open();

        //        using (SqlCommand command = new SqlCommand("Get_Consumable_Master_sp", con))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            SqlDataReader dataReader = command.ExecuteReader();

        //            if (dataReader.HasRows)
        //            {
        //                while (dataReader.Read())
        //                {
        //                    ConsumableMasterInfo CMInfo = new ConsumableMasterInfo();
        //                    CMInfo.Consumable_Id = Convert.ToInt32(dataReader["Consumable_Id"]);
        //                    CMInfo.Category_Id = Convert.ToInt32(dataReader["Category_Id"]);
        //                    CMInfo.SubCategory_Id = Convert.ToInt32(dataReader["SubCategory_Id"]);
        //                    CMInfo.Material_Name = Convert.ToString(dataReader["Material_Name"]);
        //                    CMInfo.Material_Code = Convert.ToString(dataReader["Material_Code"]);
        //                    CMInfo.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
        //                    retVal.Add(CMInfo);
        //                }
        //            }
        //            dataReader.Close();
        //        }
        //    }
        //    return retVal;
        //}


        public List<ConsumableMasterInfo> Get_ConsumableMasters(PaginationInfo Pager)
        {
            List<ConsumableMasterInfo> ConsumableMasterInfoList = new List<ConsumableMasterInfo>();

            DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Consumable_Master_sp.ToString(), CommandType.StoredProcedure);

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
                    ConsumableMasterInfo consumablemaster = new ConsumableMasterInfo();

                    consumablemaster.Consumable_Entity.Consumable_Id = Convert.ToInt32(dr["Consumable_Id"]);

                    consumablemaster.Consumable_Entity.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                    consumablemaster.Consumable_Entity.SubCategory_Id = Convert.ToInt32(dr["SubCategory_Id"]);

                    consumablemaster.Consumable_Entity.Material_Name = Convert.ToString(dr["Material_Name"]);

                    consumablemaster.Consumable_Entity.Material_Code = Convert.ToString(dr["Material_Code"]);

                    consumablemaster.Consumable_Entity.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    //consumablemaster.ConsumableMaster_Entity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    //consumablemaster.ConsumableMaster_Entity.CreatedDtm = Convert.ToDateTime(dr["CreatedDtm"]);

                    //consumablemaster.ConsumableMaster_Entity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    //consumablemaster.ConsumableMaster_Entity.UpdatedDtm = Convert.ToDateTime(dr["UpdatedDtm"]);
                   
                    ConsumableMasterInfoList.Add(consumablemaster);
                }
            }

            return ConsumableMasterInfoList;
        }

        public List<ConsumableMasterInfo> Get_Supplier_Name(string SupplierName)
        {
            List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetSupplierAutoComplete_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Vendor_Name", SupplierName));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ConsumableMasterInfo CMInfo = new ConsumableMasterInfo();
                                CMInfo.Supplier_Id = Convert.ToInt32(dataReader["Vendor_Id"]);
                                CMInfo.Supplier_Name = Convert.ToString(dataReader["Vendor_Name"]);

                                retVal.Add(CMInfo);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }
      
    }
}
