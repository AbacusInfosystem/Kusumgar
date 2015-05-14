﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
 public class DefectRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public DefectRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }
       
        public List<DefectInfo> Get_Defects(PaginationInfo Pager)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Defects_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, Pager);
               
            foreach (DataRow dr in tupleData.Item1)
                {
                    DefectInfo defects = new DefectInfo();

                    defects.DefectEntity.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
                   
                    defects.DefectEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    defects.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    defects.DefectEntity.Defect_Code = Convert.ToString(dr["Defect_Code"]);
                    
                    defects.DefectEntity.Defect_Name = Convert.ToString(dr["Defect_Name"]);
                    
                    defects.DefectEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    defects.DefectEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    defects.DefectEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    defects.DefectEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                    
                    defects.DefectEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                   
                    retVal.Add(defects);
                }
         

            return retVal;
        }

        private Tuple<List<DataRow>, PaginationInfo> GetRows(DataTable dt, PaginationInfo pager)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (pager.IsPagingRequired)
                {
                    drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                }

                pager.TotalRecords = count;

                int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

                pager.TotalPages = pages;
            }

            return new Tuple<List<DataRow>, PaginationInfo>(drList, pager);
        }

        public List<DefectTypeInfo> Get_Defect_Type()
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.List_Defect_Types_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    DefectTypeInfo defectTypes= new DefectTypeInfo();
                    
                    defectTypes.DefectTypeEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    defectTypes.DefectTypeEntity.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    retVal.Add(defectTypes);
                }

            }

            return retVal;
       }

        public DefectInfo Get_Defects_By_Id(int Defect_Id)
        {
            DefectInfo retVal = new DefectInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Id", Defect_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal.DefectEntity.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
                    
                    retVal.DefectEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    retVal.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    retVal.DefectEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    retVal.DefectEntity.Defect_Code = Convert.ToString(dr["Defect_Code"]);
                    
                    retVal.DefectEntity.Defect_Name = Convert.ToString(dr["Defect_Name"]);
                    
                    retVal.DefectEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    retVal.DefectEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    retVal.DefectEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                   
                    retVal.DefectEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                }

            } 
            return retVal;
        }

        public List<DefectInfo> Get_Defect_By_Name(string Defect_Name, PaginationInfo Pager)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Name", Defect_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Name_sp.ToString(), CommandType.StoredProcedure);

             var tupleData = GetRows(dt, Pager);
               
            foreach (DataRow dr in tupleData.Item1)
                {
                    DefectInfo defects = new DefectInfo();

                    defects.DefectEntity.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
                    
                    defects.DefectEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    defects.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    defects.DefectEntity.Defect_Code = Convert.ToString(dr["Defect_Code"]);
                    
                    defects.DefectEntity.Defect_Name = Convert.ToString(dr["Defect_Name"]);
                    
                    defects.DefectEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    defects.DefectEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    defects.DefectEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    defects.DefectEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                    
                    defects.DefectEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    retVal.Add(defects);
                }
         
            return retVal;
        }

        public List<DefectInfo> Get_Defect_By_Type(int Defect_Type_Id, PaginationInfo Pager)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Type_sp.ToString(), CommandType.StoredProcedure);

             var tupleData = GetRows(dt, Pager);
               
            foreach (DataRow dr in tupleData.Item1)
                {
                    DefectInfo defects = new DefectInfo();

                    defects.DefectEntity.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
                    
                    defects.DefectEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                    
                    defects.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                   
                    defects.DefectEntity.Defect_Code = Convert.ToString(dr["Defect_Code"]);
                   
                    defects.DefectEntity.Defect_Name = Convert.ToString(dr["Defect_Name"]);
                    
                    defects.DefectEntity.Status = Convert.ToBoolean(dr["Status"]);
                    
                    defects.DefectEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    defects.DefectEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    defects.DefectEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                   
                    defects.DefectEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                    
                    retVal.Add(defects);
                }

            return retVal;
        }
      
        public List<DefectInfo> Get_Defect_By_Type_By_Name(int Defect_Type_Id,string Defect_Name,PaginationInfo Pager)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Defect_Type_Id", Defect_Type_Id));

            sqlParams.Add(new SqlParameter("@Defect_Name", Defect_Name));
            
            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Defect_By_Name_By_Type_sp.ToString(), CommandType.StoredProcedure);

             var tupleData = GetRows(dt, Pager);
               
            foreach (DataRow dr in tupleData.Item1)
                {
                    DefectInfo defects = new DefectInfo();

                    defects.DefectEntity.Defect_Id = Convert.ToInt32(dr["Defect_Id"]);
                    
                    defects.DefectEntity.Defect_Type_Id = Convert.ToInt32(dr["Defect_Type_Id"]);
                   
                    defects.Defect_Type_Name = Convert.ToString(dr["Defect_Type_Name"]);
                    
                    defects.DefectEntity.Defect_Code = Convert.ToString(dr["Defect_Code"]);
                   
                    defects.DefectEntity.Defect_Name = Convert.ToString(dr["Defect_Name"]);
                   
                    defects.DefectEntity.Status = Convert.ToBoolean(dr["Status"]);
                   
                    defects.DefectEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    
                    defects.DefectEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    
                    defects.DefectEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
                    
                    defects.DefectEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
                    
                retVal.Add(defects);
                }

           
         return retVal;
  }

        public void Insert(DefectInfo defects)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Defects(defects), StoredProcedures.Insert_Defect_sp.ToString(), CommandType.StoredProcedure);
       }

        public void Update(DefectInfo defects)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Defects(defects), StoredProcedures.Update_Defect_sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Defects(DefectInfo defects)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Defect_Name", defects.DefectEntity.Defect_Name));

            sqlParamList.Add(new SqlParameter("@Defect_Type_Id", defects.DefectEntity.Defect_Type_Id));

            sqlParamList.Add(new SqlParameter("@Defect_Code", defects.DefectEntity.Defect_Code));

            sqlParamList.Add(new SqlParameter("@Status", defects.DefectEntity.Status));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", defects.DefectEntity.UpdatedBy));
            
            if (defects.DefectEntity.Defect_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", defects.DefectEntity.CreatedBy));
            }
            if (defects.DefectEntity.Defect_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Defect_Id", defects.DefectEntity.Defect_Id));
            }

            return sqlParamList;
        }
  
    }
}