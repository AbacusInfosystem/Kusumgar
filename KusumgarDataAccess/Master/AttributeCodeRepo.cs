using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
   public class AttributeCodeRepo
    {
        private string _sqlCon = string.Empty;
        SQLHelperRepo _sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public AttributeCodeRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
            _sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<AttributeCodeInfo> Get_Attribute_Codes(PaginationInfo pager)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();
            
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Attribute_Codes_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, pager);

            foreach (DataRow dr in tupleData.Item1)
            {
                AttributeCodeInfo attributeCodes = new AttributeCodeInfo();
                
                attributeCodes.AttributeCodeEntity.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

                attributeCodes.AttributeCodeEntity.Attribute_Id = Convert.ToInt32(dr["Attribute_Id"]);

                attributeCodes.AttributeCodeEntity.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

                attributeCodes.AttributeCodeEntity.Code = Convert.ToString(dr["Code"]);

                attributeCodes.AttributeCodeEntity.Status = Convert.ToBoolean(dr["Status"]);

                attributeCodes.Attribute_Name = LookupInfo.GetAttributeNames()[attributeCodes.AttributeCodeEntity.Attribute_Id];

                retVal.Add(attributeCodes);
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
        
        public void Insert(AttributeCodeInfo attributeCode)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Insert_Attribute_Code_sp.ToString(), CommandType.StoredProcedure);
        }

        public List<AttributeCodeInfo> Get_Attribute_Codes_By_Attribute_Name(int attributeId,PaginationInfo pager)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();
            
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attribute_Id", attributeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attribute_Code_By_Attribute_Name_sp.ToString(), CommandType.StoredProcedure);

            var tupleData = GetRows(dt, pager);
               
            foreach (DataRow dr in tupleData.Item1)
                {

                    AttributeCodeInfo attributeCodes = new AttributeCodeInfo();

                    attributeCodes.AttributeCodeEntity.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

                    attributeCodes.AttributeCodeEntity.Attribute_Id = Convert.ToInt32(dr["Attribute_Id"]);

                    attributeCodes.AttributeCodeEntity.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

                    attributeCodes.AttributeCodeEntity.Code = Convert.ToString(dr["Code"]);

                    attributeCodes.AttributeCodeEntity.Status = Convert.ToBoolean(dr["Status"]);

                    attributeCodes.Attribute_Name = LookupInfo.GetAttributeNames()[attributeCodes.AttributeCodeEntity.Attribute_Id];

                    retVal.Add(attributeCodes);
                }
            
            return retVal;
        }
       
        public AttributeCodeInfo Get_Attribute_Code_By_Id(int attributeCodeId)
        {
            AttributeCodeInfo retVal = new AttributeCodeInfo();
           
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attribute_Code_Id", attributeCodeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attribute_Code_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal.AttributeCodeEntity.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

                    retVal.AttributeCodeEntity.Attribute_Id = Convert.ToInt32(dr["Attribute_Id"]);

                    retVal.AttributeCodeEntity.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

                    retVal.AttributeCodeEntity.Code = Convert.ToString(dr["Code"]);

                    retVal.AttributeCodeEntity.Status = Convert.ToBoolean(dr["Status"]);

                    retVal.Attribute_Name = LookupInfo.GetAttributeNames()[retVal.AttributeCodeEntity.Attribute_Id];

                }
            }

            return retVal;
        }

        public void Update(AttributeCodeInfo attributeCode)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Update_Attribute_Code_sp.ToString(), CommandType.StoredProcedure);

        }

        private List<SqlParameter> Set_Values_In_Attribute_Code(AttributeCodeInfo attributeCodes)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Status", attributeCodes.AttributeCodeEntity.Status));
            
            sqlParamList.Add(new SqlParameter("@Attribute_Id", attributeCodes.AttributeCodeEntity.Attribute_Id));

            sqlParamList.Add(new SqlParameter("@Attribute_Code_Name", attributeCodes.AttributeCodeEntity.Attribute_Code_Name));

            sqlParamList.Add(new SqlParameter("@Code", attributeCodes.AttributeCodeEntity.Code));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", attributeCodes.AttributeCodeEntity.UpdatedBy));

            if (attributeCodes.AttributeCodeEntity.Attribute_Code_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", attributeCodes.AttributeCodeEntity.CreatedBy));
            }
            if (attributeCodes.AttributeCodeEntity.Attribute_Code_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Attribute_Code_Id", attributeCodes.AttributeCodeEntity.Attribute_Code_Id));
            }

            return sqlParamList;
        } 
    }
}
